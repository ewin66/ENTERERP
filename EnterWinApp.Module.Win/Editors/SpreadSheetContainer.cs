using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSpreadsheet;

namespace EnterWinApp.Module.Win
{
    public partial class SpreadSheetContainer : UserControl
    {
        public SpreadSheetContainer()
        {
            InitializeComponent();
        }


        public SpreadsheetControl SheetControl
        {
            get
            {
                return spreadsheetControl1;
            }
        }

        public string RtfText
        {
            get
            {
                return SheetControl.Text ;
            }
            set
            {
                SheetControl.Text = value;
            }
        }

        private void btnFullSizeEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FullWinRichtEdit fullEditor = new FullWinRichtEdit();

            fullEditor.RtfText = RtfText; ;
            fullEditor.ShowDialog();
            RtfText = fullEditor.RtfText;

        }



    }
}
