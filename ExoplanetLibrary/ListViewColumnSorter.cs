using System.Collections;
using System.Windows.Forms;

//
// google search "How to sort a ListView control by a column in Visual C#"
//

namespace ExoplanetLibrary
    {
    public class ListViewColumnSorter : IComparer
        {
        private CaseInsensitiveComparer ObjectCompare;

        private int ColumnToSort_ = 0;
        public int ColumnToSort
            {
            set { ColumnToSort_ = value; }
            get { return ColumnToSort_; }
            }

        private SortOrder OrderOfSort_ = SortOrder.Ascending;
        public SortOrder OrderOfSort
            {
            set { OrderOfSort_ = value; }
            get { return OrderOfSort_; }
            }

        private bool IsAlphaNumeric_ = false;
        public bool IsAlphaNumeric
            {
            set { IsAlphaNumeric_ = value; }
            get { return IsAlphaNumeric_; }
            }

        public ListViewColumnSorter ()
            {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.Ascending;
            ObjectCompare = new CaseInsensitiveComparer ();
            IsAlphaNumeric = false;
            }

        public int Compare (object x, object y)
            {
            int compareResults;
            double dx, dy;
            ListViewItem listviewX, listviewY;

            listviewX = ( ListViewItem )x;
            listviewY = ( ListViewItem )y;

            if (IsAlphaNumeric && ( compareResults = Helper.AlphaNumericSort (listviewX.SubItems [ColumnToSort].Text, listviewY.SubItems [ColumnToSort].Text) ) != 0)
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

        }
    }
