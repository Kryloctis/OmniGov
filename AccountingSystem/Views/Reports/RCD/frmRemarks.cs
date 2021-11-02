using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRemarks : Form
    {
        internal int Id = 0;
        public frmRemarks(int _id)
        {
            InitializeComponent();
            Id = _id;
        }

        private void frmRemarks_Load(object sender, EventArgs e)
        {
            LoadRemarks();
        }

        private void LoadRemarks()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var rcddata = rcdRepository.GetRecordByID(Id);
                txtremarks.Text = rcddata["remarks"];

                var uRepository = Factory.UsersRepository();
                bool is_liquidate = uRepository.GetUserRole(Helper.UserId) == "Liquidating Officer" ? true : false;
                btnSave.Visible = is_liquidate;
            }
            catch(Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SaveRemarks()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                CollectorReportModel model = new CollectorReportModel()
                {
                    Id = Id,
                    remarks = txtremarks.Text.Trim()
                };
                return rcdRepository.Remarks(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveRemarks())
            {
                this.Close();
            }
        }
    }
}
