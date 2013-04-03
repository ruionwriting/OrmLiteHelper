
namespace OrmLiteHelper
{
	/// <summary>
	/// Support class for paged data.
	/// </summary>
	public sealed class Page
	{
		/// <summary>
		/// Desired page index to move to.
		/// </summary>
		public int PageIndex { get; set; }

		/// <summary>
		/// Number of items per page.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Page count base on the supplied <see cref="PageSize"/>
		/// </summary>
		public int PageCount { get; internal set; }

		/// <summary>
		/// Referes to the overall index for the 1st item on current page.
		/// </summary>
		public long ItemIndex { get; internal set; }

		/// <summary>
		/// Overall item count
		/// </summary>
		public long ItemCount { get; internal set; }

		public Page()
		{
			this.PageIndex = 1;
			this.PageSize = 20;
		}
	}
}