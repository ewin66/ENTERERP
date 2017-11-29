using System;
using System.IO;
using System.Text;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;


namespace EnterWinApp.Module.Win
{

    [PropertyEditor(typeof(String), "XLS", false)]
    public class SpreadSheetWinPropertyEditor : WinPropertyEditor, IInplaceEditSupport
    {
        private SpreadSheetContainer ctrl =null;
        bool changed = false;

        public SpreadSheetWinPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }



        protected override object CreateControlCore()
        {

            ctrl = new SpreadSheetContainer();
           // ctrl.SheetControl.CellEndEdit += SpreadSheetEditValueChanged;
            ctrl.SheetControl.ModifiedChanged += SpreadSheetEditValueChanged;
            ControlBindingProperty = "Text";
                return ctrl;
        }

        protected override void ReadValueCore()  //Load From Text PropertyValue
        {
            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            if (PropertyValue != null)
            {
                Byte[] bytes = Convert.FromBase64String(PropertyValue.ToString());

                using (MemoryStream ms = new MemoryStream(bytes))
                {
        
                        ms.Position = 0;
                        ctrl.SheetControl.LoadDocument(ms, DevExpress.Spreadsheet.DocumentFormat.OpenXml);
                }
            }
        }
        
        private void SpreadSheetEditValueChanged(object sender, EventArgs e) // Save to Text PropertyValue
        {
            
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {

                    ctrl.SheetControl.SaveDocument(ms, DevExpress.Spreadsheet.DocumentFormat.OpenXml);
                    //ms.Seek(0, SeekOrigin.Begin);
                    ms.Position = 0;

                    PropertyValue = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch { PropertyValue= null; }

        }


        protected override void OnAllowEditChanged()
        {
            base.OnAllowEditChanged();
            if (ctrl != null)
                ctrl.SheetControl.ReadOnly = !AllowEdit;
        }

        #region IInplaceEditSupport Members

        public DevExpress.XtraEditors.Repository.RepositoryItem CreateRepositoryItem()
        {
            return new RepositoryItemRtfEditEx();
        }
        #endregion
    }
}
