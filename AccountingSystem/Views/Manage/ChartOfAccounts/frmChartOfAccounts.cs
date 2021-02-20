using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts
{
    public partial class frmChartOfAccounts : Form
    {
        public frmChartOfAccounts()
        {
            InitializeComponent();
        }

        private void AccountGroupNodes()
        {
            DataTable dtaccountGroup = Factory.AccountGroupRepository().GetRecords();

            foreach (DataRow dataRow in dtaccountGroup.Rows)
            {
                int accountGroupId = int.Parse(dataRow["id"].ToString());
                string accountGroupCode = dataRow["account_group_code"].ToString();
                string accountGroupName = dataRow["account_group_name"].ToString();

                TreeNode accountGroupNode = new TreeNode(accountGroupCode);
                accountGroupNode.Nodes.Add(accountGroupName);

            }
        }

        private void PopulateTreeView()
        {
            // get account group records
            
        }

        private void frmChartOfAccounts_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            PopulateTreeView();
        }
    }
}
