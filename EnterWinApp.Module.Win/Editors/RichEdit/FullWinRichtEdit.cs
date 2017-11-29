using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraRichEdit;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;

namespace EnterWinApp.Module.Win
{
    public partial class FullWinRichtEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FullWinRichtEdit()
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
                return richEditControl1.RtfText;
            }
            set
            {
                richEditControl1.RtfText = value;
            }
        }

 
    }
}