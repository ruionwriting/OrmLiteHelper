using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;

namespace OrmLiteHelper
{
	public abstract class OrmLiteHelper
	{
		/// <summary>
		/// Set this to fill messages with more detailed informations
		/// </summary>
		public virtual bool Verbose { get; set; }

		public virtual string ConnectionString { get; set; }

		#region Insert

		public virtual CommandResult Insert<T>(T obj, string idColumn = "Id", IDbTransaction transaction = null) where T : new()
		{
			var result = new CommandResult();
			IDbConnection db = null;

			try
			{
				GetConnectionInstance(transaction, ref db);

				// perform insert command
				db.Insert<T>(obj);

				if (Verbose)
					result.Messages.Add(db.GetLastSql());

				if (idColumn != null)
				{
					// set "id", using reflection, when supplied by current object

					result.LastInsertId = db.GetLastInsertId();
					result.Error = result.LastInsertId == 0;

					var objType = typeof(T);
					var objTypeProperty = objType.GetProperty(idColumn);

					if (objTypeProperty != null)
					{
						// TODO: OrmLite only supports long as return type

						// Fill obj id field with last inserted id
						objTypeProperty.SetValue(obj, result.LastInsertId, null);
					}
				}
				else
				{
					result.Error = false;
				}
			}
			catch (Exception ex)
			{
				if (Verbose)
					result.CollectErrorMessages(db, ex);
			}
			finally
			{
				DisposeConnectionInstance(transaction, ref db);
			}

			return result;
		}

		#endregion

		#region Select

		public virtual GenericResult<T> Select<T>(IDbTransaction transaction = null) where T : new()
		{
			var result = new GenericResult<T>();
			IDbConnection db = null;

			try
			{
				GetConnectionInstance(transaction, ref db);

				result.ResultItems = db.Select<T>();
				result.Error = false;

				if (Verbose)
					result.Messages.Add(db.GetLastSql());
			}
			catch (Exception ex)
			{
				if (Verbose)
					result.CollectErrorMessages(db, ex);
			}
			finally
			{
				DisposeConnectionInstance(transaction, ref db);
			}

			return result;
		}

		// TODO: other overloads

		#endregion

		#region GetById

		public virtual GenericResult<T> GetById<T>(object idValue, IDbTransaction transaction = null) where T : new()
		{
			var result = new GenericResult<T>();
			IDbConnection db = null;

			try
			{
				GetConnectionInstance(transaction, ref db);

				result.ResultItems.Add(db.GetById<T>(idValue));
				result.Error = false;

				if (Verbose)
					result.Messages.Add(db.GetLastSql());
			}
			catch (Exception ex)
			{
				if (Verbose)
					result.CollectErrorMessages(db, ex);
			}
			finally
			{
				DisposeConnectionInstance(transaction, ref db);
			}

			return result;
		}

		#endregion

		#region Support methods

		/// <summary>
		/// Get/init connection instance.
		/// </summary>
		/// <param name="transaction">Existing IDbTransaction(null inits new connection instance).</param>
		/// <param name="db">IDbConnection that holds new or existing transaction connection.</param>
		/// <returns></returns>
		private IDbConnection GetConnectionInstance(IDbTransaction transaction, ref IDbConnection db)
		{
			// get/init connection instance
			db = (transaction == null) ? ConnectionString.OpenDbConnection() : transaction.Connection;
			return db;
		}

		/// <summary>
		/// Release current connection resources if not using a transaction.
		/// </summary>
		/// <param name="transaction">Existing IDbTransaction(null inits new connection instance).</param>
		/// <param name="db">IDbConnection that holds new or existing transaction connection.</param>
		private static void DisposeConnectionInstance(IDbTransaction transaction, ref IDbConnection db)
		{
			// dispose connection if no transaction was supplied
			if (transaction == null && db != null)
				db.Dispose();
		}

		#endregion
	}
}