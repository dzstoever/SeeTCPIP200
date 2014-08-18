using System;

namespace ConsoleRecords
{
	/// <summary>
	/// Summary description for Pageable.
	/// </summary>
	/// /// <remarks>
	/// 20060530 P. McClain		initial version	
	public interface Pageable
	{
		// Size of a logical page.
		int PageSize { get; set; }
		
		// Page navigation.
		void NextPage();
		void PreviousPage();
		void FirstPage();
		void LastPage();
		
		// Line navigation.
		bool PreviousLine();
		bool NextLine();
	} // end of Pageable
}
