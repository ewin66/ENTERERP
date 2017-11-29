using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

namespace EnterWinApp.Module.Win
{
    public partial class RichEditContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public RichEditContainer()
        {
            InitializeComponent();            
        }

        public RichEditControl RichEditControl
        {
            get
            {
                return richEditControl1;
            }
        }

        public string RtfText
        {
            get
            {
                return RichEditControl.RtfText;
            }
            set
            {
                RichEditControl.RtfText = value;
            }
        }

        private void btnFullSizeEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FullWinRichtEdit fullEditor = new FullWinRichtEdit();
            
            fullEditor.RtfText = RtfText;;
            fullEditor.ShowDialog();
            RtfText = fullEditor.RtfText;

        }
    }
}
