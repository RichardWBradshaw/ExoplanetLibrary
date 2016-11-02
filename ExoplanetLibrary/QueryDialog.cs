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

        private void exampleQueryButton_click (object sender, EventArgs e)
            {
            MessageBox.Show (
                "where <keyword> <string-value>\n" +
                "where <keyword> startswith <string-value>\n" +
                "where <keyword> contains <string-value>\n" +
                "where <keyword> endswith <string-value>\n" +
                "<keyword> is either 'name', 'detection', 'spectral' or 'habitability'\n" +
                "<string-value> is an alpha-numeric string\n\n" +

                "where <keyword> >= <numeric-value>\n" +
                "where <keyword> <= <numeric-value>\n" +
                "where <keyword> between <numeric-value> and <numeric-value>\n" +
                "<keyword> is either 'mass', 'radius', 'orbitalperiod', 'semimajoraxis', 'eccentricity', 'angulardistance', 'inclination', 'temperature' or 'omega'\n" +
                "<numeric-value> is a numeric value\n"
                , "Example query statements" 
                );
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

        private void applyButton_Click (object sender, EventArgs e)
            {
            Queries.CurrentQueries = new Queries (queryTextBox.Text);
            ParentDialog.ProcessQuery ();
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
