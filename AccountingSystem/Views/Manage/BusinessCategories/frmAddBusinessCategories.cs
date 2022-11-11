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
    public partial class frmAddBusinessCategories : Form
    {
        private readonly frmBusinessCategories _frmBusinessCategories;
        private readonly ucBusinessCategories _ucBusinessCategories;

        public frmAddBusinessCategories(frmBusinessCategories frmBusinessCategories)
        {
            InitializeComponent();
            _frmBusinessCategories = frmBusinessCategories;
            _ucBusinessCategories = ucBusinessCategories1;
        }


    }
}
