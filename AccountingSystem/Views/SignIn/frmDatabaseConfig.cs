using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.SignIn
{
    public partial class frmDatabaseConfig : Form
    {
        public frmDatabaseConfig()
        {
            InitializeComponent();
        }

        private void LoadAvailableLguDatabases()
        {
            //foreach (DataRow row in DataTableLgus().Rows)
            //{
            //    RadioButton radioButton = new RadioButton();
            //    string municipality = row["municipality"].ToString();
            //    string province = row["province"].ToString();

            //    radioButton.Text = $"{municipality} - {province}";

            //    flowLayoutPanel1.Controls.Add(radioButton);
            //}
        }

        private void OnLoad()
        {
            LoadAvailableLguDatabases();
        }

        private void frmDatabaseConfig_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}