using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FeesChargesConfig.Classification
{
    public partial class frmEditFeesChargesClassification : Form
    {
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly ucFeesChargesClassification uc;
        private readonly int feesChargesClassificationId;

        public frmEditFeesChargesClassification(int feesChargesClassificationId, frmFeesChargesConfig frmFeesChargesClassification)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFeesChargesClassification1;
            this.frmFeesChargesClassification = frmFeesChargesClassification;
            this.feesChargesClassificationId = feesChargesClassificationId;
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

        private void frmEditFeesChargesClassification_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, this.feesChargesClassificationId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    frmFeesChargesClassification.LoadFeesCharges();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods
    }
}