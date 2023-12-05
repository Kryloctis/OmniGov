using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges
{
    public partial class frmAddFeesCharges : Form
    {
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly ucFeesCharges uc;

        public frmAddFeesCharges(frmFeesChargesConfig frmFeesChargesClassification)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFeesCharges1;
            this.frmFeesChargesClassification = frmFeesChargesClassification;
        }

        #region Private Methods

        private bool Save()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }
            return true;
        }

        #endregion Private Methods

        #region Event Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    this.frmFeesChargesClassification.LoadFeesCharges();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods

        private void frmAddFeesCharges_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}