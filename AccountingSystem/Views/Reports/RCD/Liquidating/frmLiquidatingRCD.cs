using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD.Liquidating
{
    public partial class frmLiquidatingRCD : Form
    {
        private readonly ReportViewer reportViewer = new();
        private readonly string _reportNumber;

        public frmLiquidatingRCD(string reportNumber)
        {
            InitializeComponent();
        }
    }
}
