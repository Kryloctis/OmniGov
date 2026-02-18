using System;
using System.Windows.Forms;

namespace OmniGov.App.CustomTools
{
    /// <summary>
    /// A TabControl without visible headers.
    /// </summary>
    public partial class CustomTabControl : TabControl
    {
        public CustomTabControl()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            const int TCM_ADJUSTRECT = 0x1328;
            if (m.Msg == TCM_ADJUSTRECT && !DesignMode)
            {
                // Remove the tab header area by returning 1
                m.Result = (IntPtr)1;
                return;
            }

            base.WndProc(ref m);
        }
    }
}
