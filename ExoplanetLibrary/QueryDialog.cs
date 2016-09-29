using System;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public partial class QueryDialog : Form
        {
        static private string QueryText = "";

        public QueryDialog ()
            {
            }

        public QueryDialog (LibraryDialog parent) : this ()
            {
            ParentDialog = parent;
            InitializeComponent ();

            queryTextBox.Text = QueryText;
            }

        private LibraryDialog ParentDialog_ = null;
        private LibraryDialog ParentDialog
            {
            get { return ParentDialog_; }
            set { ParentDialog_ = value; }
            }

        private void QueryBuilder_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (ParentDialog != null)
                ParentDialog.QueryBuilderClosed ();
            }

        private void applyButton_Click (object sender, EventArgs e)
            {
            Queries.CurrentQueries = new Queries (queryTextBox.Text);
            ParentDialog.ProcessQuery ();
            QueryText = queryTextBox.Text;
            }
        }
    }
