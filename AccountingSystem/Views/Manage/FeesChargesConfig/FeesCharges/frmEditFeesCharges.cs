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
    public partial class frmEditFeesCharges : Form
    {
        private readonly frmFeesChargesClassification frmFeesChargesClassification;
        private readonly int feesChargesId;
        private readonly ucFeesCharges uc;

        public frmEditFeesCharges(int feesChargesId, frmFeesChargesClassification frmFeesChargesClassification)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFeesCharges1;
            this.feesChargesId = feesChargesId;
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

        private void frmEditFeesCharges_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, feesChargesId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    this.frmFeesChargesClassification.LoadTaxTypes();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods
    }
}