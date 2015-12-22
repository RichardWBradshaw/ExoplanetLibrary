using System;
using System.Windows.Forms;

namespace ExoplanetLibrary
    {
    public partial class FilterByStarType : Form
        {
        private CheckBox TypeO = null;
        private CheckBox TypeB = null;
        private CheckBox TypeA = null;
        private CheckBox TypeF = null;
        private CheckBox TypeG = null;
        private CheckBox TypeK = null;
        private CheckBox TypeM = null;
        private CheckBox AllTypes = null;

        public FilterByStarType ()
            {
            InitializeComponent ();
            InstantiateCheckBoxes ();
            }

        public void InstantiateCheckBoxes ()
            {
            TypeO = new CheckBox ();

            TypeO.CheckedChanged += CheckChangedHandler;
            TypeO.Appearance = Appearance.Button;
            TypeO.AutoCheck = false;
            Controls.Add (TypeO);

            TypeB = new CheckBox ();

            TypeB.CheckedChanged += CheckChangedHandler;
            TypeB.Appearance = Appearance.Button;
            TypeB.AutoCheck = false;
            Controls.Add (TypeB);

            TypeA = new CheckBox ();

            TypeA.CheckedChanged += CheckChangedHandler;
            TypeA.Appearance = Appearance.Button;
            TypeA.AutoCheck = false;
            Controls.Add (TypeA);

            TypeF = new CheckBox ();

            TypeF.CheckedChanged += CheckChangedHandler;
            TypeF.Appearance = Appearance.Button;
            TypeF.AutoCheck = false;
            Controls.Add (TypeF);

            TypeG = new CheckBox ();

            TypeG.CheckedChanged += CheckChangedHandler;
            TypeG.Appearance = Appearance.Button;
            TypeG.AutoCheck = false;
            Controls.Add (TypeG);

            TypeK = new CheckBox ();

            TypeK.CheckedChanged += CheckChangedHandler;
            TypeK.Appearance = Appearance.Button;
            TypeK.AutoCheck = false;
            Controls.Add (TypeK);

            TypeM = new CheckBox ();

            TypeM.CheckedChanged += CheckChangedHandler;
            TypeM.Appearance = Appearance.Button;
            TypeM.AutoCheck = false;
            Controls.Add (TypeM);

            AllTypes = new CheckBox ();

            AllTypes.CheckedChanged += CheckChangedHandler;
            AllTypes.Appearance = Appearance.Button;
            AllTypes.AutoCheck = true;
            Controls.Add (AllTypes);
            }

        static void CheckChangedHandler (object objSender, EventArgs ea)
            {
            CheckBox cb = objSender as CheckBox;

            //if (cb.Checked)
            //    MessageBox.Show (cb.Text + " checked");
            //else
            //    MessageBox.Show (cb.Text + " unchecked");
            }

        private void Filter_FormClosing (object sender, FormClosingEventArgs e)
            {
            Filters filter = new Filters ();

            filter.TypeOEnabled = TypeO.Checked;
            filter.TypeBEnabled = TypeB.Checked;
            filter.TypeAEnabled = TypeA.Checked;
            filter.TypeFEnabled = TypeF.Checked;
            filter.TypeGEnabled = TypeG.Checked;
            filter.TypeKEnabled = TypeK.Checked;
            filter.TypeMEnabled = TypeM.Checked;
            filter.AllTypesEnabled = AllTypes.Checked;
            //if (ParentDialog != null)
            //    ParentDialog.ExoplanetDetailsClosed ();
            }

        }
    }
