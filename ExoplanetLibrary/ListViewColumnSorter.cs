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
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer ();
            }

        public int Compare (object x, object y)
            {
            int compareResult;
            double dx, dy;
            ListViewItem listviewX, listviewY;

            listviewX = ( ListViewItem )x;
            listviewY = ( ListViewItem )y;

            if (double.TryParse (listviewX.SubItems [ColumnToSort].Text, out dx) && double.TryParse (listviewY.SubItems [ColumnToSort].Text, out dy))
                compareResult = ObjectCompare.Compare (dx, dy);
            else if (Helper.ParseHMS (listviewX.SubItems [ColumnToSort].Text, out dx) && Helper.ParseHMS (listviewY.SubItems [ColumnToSort].Text, out dy))
                compareResult = ObjectCompare.Compare (dx, dy);
            else
                compareResult = ObjectCompare.Compare (listviewX.SubItems [ColumnToSort].Text, listviewY.SubItems [ColumnToSort].Text);

            if (OrderOfSort == SortOrder.Ascending)
                return compareResult;
            else if (OrderOfSort == SortOrder.Descending)
                return ( -compareResult );
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
