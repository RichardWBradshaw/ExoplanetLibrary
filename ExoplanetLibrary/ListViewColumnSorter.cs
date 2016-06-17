using System.Collections;
using System.Windows.Forms;

//
// google search "How to sort a ListView control by a column in Visual C#"
//

namespace ExoplanetLibrary
    {
    public class ListViewColumnSorter : IComparer
        {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter ()
            {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.Ascending;
            ObjectCompare = new CaseInsensitiveComparer ();
            }

        public int Compare (object x, object y)
            {
            int compareResults;
            double dx, dy;
            ListViewItem listviewX, listviewY;

            listviewX = ( ListViewItem )x;
            listviewY = ( ListViewItem )y;

            //
            // 1st condition is exoplanet name and star name
            //

            if (( ColumnToSort == 0 || ColumnToSort == 13 ) && ( compareResults = Helper.AlphaNumericSort (listviewX.SubItems [ColumnToSort].Text, listviewY.SubItems [ColumnToSort].Text) ) != 0)
                {
                ;
                }
            else if (double.TryParse (listviewX.SubItems [ColumnToSort].Text, out dx) && double.TryParse (listviewY.SubItems [ColumnToSort].Text, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else if (Helper.ParseHMS (listviewX.SubItems [ColumnToSort].Text, out dx) && Helper.ParseHMS (listviewY.SubItems [ColumnToSort].Text, out dy))
                compareResults = ObjectCompare.Compare (dx, dy);
            else
                compareResults = ObjectCompare.Compare (listviewX.SubItems [ColumnToSort].Text, listviewY.SubItems [ColumnToSort].Text);

            if (OrderOfSort == SortOrder.Ascending)
                return compareResults;
            else if (OrderOfSort == SortOrder.Descending)
                return ( -compareResults );
            else
                return 0;
            }

        public int SortColumn
            {
            set
                {
                ColumnToSort = value;
                }
            get
                {
                return ColumnToSort;
                }
            }

        public SortOrder Order
            {
            set
                {
                OrderOfSort = value;
                }
            get
                {
                return OrderOfSort;
                }
            }

        }
    }
