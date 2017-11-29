using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraBars.Ribbon;

namespace EnterWinApp.Module.Win
{
    public partial class RichEditUserControl : XtraUserControl {
        public RichEditUserControl() {
            InitializeComponent();
        }
        public RichEditControl RichEditControl {
            get {
                return this.richEditControl;
            }
        }
        public RibbonControl RibbonControl {
            get {
                return this.ribbonControl1;
            }
        }
        public string RtfText {
            get {
                if (richEditControl != null) {
                    return richEditControl.RtfText;
                }
                return string.Empty;
            }
            set {
                if (richEditControl != null) {
                    richEditControl.RtfText = value;
                }
            }
        }
    }
}