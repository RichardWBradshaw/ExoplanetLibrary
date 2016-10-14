using System;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public partial class QueryDialog : Form
        {
        static private int CurrentIndex = 0;

        public QueryDialog ()
            {
            }

        public QueryDialog (LibraryDialog parent) : this ()
            {
            ParentDialog = parent;
            InitializeComponent ();

            queryComboBox.BeginUpdate ();
            queryComboBox.Items.AddRange (Queries.Name);
            queryComboBox.EndUpdate ();

            queryComboBox.SelectedIndex = CurrentIndex;
            queryTextBox.Text = Queries.WhereClause [CurrentIndex];
            Update ();
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
            }

        private void queryComboBox_selectedIndexChanged (object sender, EventArgs e)
            {
            if (queryComboBox.SelectedIndex >= 0 && queryComboBox.SelectedIndex < Queries.Name.Length)
                {
                CurrentIndex = queryComboBox.SelectedIndex;
                queryTextBox.Text = Queries.WhereClause [CurrentIndex];
                queryTextBox.Update ();
                Update ();
                }
            }

        private void updateQueryButton_Click (object sender, EventArgs e)
            {
            if (queryComboBox.SelectedIndex >= 0 && queryComboBox.SelectedIndex < Queries.Name.Length)
                {
                CurrentIndex = queryComboBox.SelectedIndex;
                Queries.WhereClause [CurrentIndex] = queryTextBox.Text;

                Queries.Name [CurrentIndex] = NameFromWhereClause ();

                queryComboBox.Items.Clear ();

                queryComboBox.BeginUpdate ();
                queryComboBox.Items.AddRange (Queries.Name);
                queryComboBox.EndUpdate ();

                queryComboBox.SelectedIndex = CurrentIndex;
                }
            }

        private string NameFromWhereClause ()
            {
            if (Queries.WhereClause [CurrentIndex].Length > 0)
                {
                char [] delimiterChars = { '\n', '\r' };
                string [] strings = Queries.WhereClause [CurrentIndex].Split (delimiterChars);

                return strings [0];
                }

            return Queries.Name [CurrentIndex];
            }
        }
    }
