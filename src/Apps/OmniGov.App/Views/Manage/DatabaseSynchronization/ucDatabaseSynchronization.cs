namespace OmniGov.App.Views.Manage.DatabaseSynchronization
{
    public partial class ucDatabaseSynchronization : UserControl
    {
        public ucDatabaseSynchronization()
        {
            InitializeComponent();
        }

        private void LoadSyncOptions()
        {
            var dict = new Dictionary<string, string>()
            {
                { "RPT", "0"}
            };

            var bindingSource = new BindingSource(dict, null);
            cmbxSyncType.DataSource = bindingSource;
            cmbxSyncType.DisplayMember = "Key";
            cmbxSyncType.ValueMember = "Value";
        }

        private void ucDatabaseSynchronization_Load(object sender, System.EventArgs e)
        {
            if (!DesignMode)
            {
                LoadSyncOptions();
            }
        }
    }
}
