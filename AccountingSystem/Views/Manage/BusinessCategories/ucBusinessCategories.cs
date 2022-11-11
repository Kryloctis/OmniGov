using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessCategories
{
    public partial class ucBusinessCategories : UserControl
    {
        public ucBusinessCategories()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            return string.Empty;
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtOrdinanceReferenceNo.Clear();
            txtDescription.Clear();
            cbxLineOfBusiness.Checked = false;
        }


    }
}
