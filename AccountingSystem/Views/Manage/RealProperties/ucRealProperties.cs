using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class ucRealProperties : UserControl
    {
        public ucRealProperties()
        {
            InitializeComponent();
        }

        private void LoadPropertyKind() 
        {
            var dict = new Dictionary<string, string>();

            dict.Add("1", "Land");
            dict.Add("2", "Building");
            dict.Add("3", "Machinery");

            cmbxPropertyKind.DataSource = new BindingSource(dict.Values, null);
        }

        private void ucRealProperties_Load(object sender, EventArgs e)
        {
            LoadPropertyKind();
        }
    }
}
