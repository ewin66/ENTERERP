using System;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.XtraEditors.Repository;

namespace EnterWinApp.Module.Win{
    [PropertyEditor(typeof(String), "RTF2", false)]
    public class RichEditPropertyEditor : WinPropertyEditor, IInplaceEditSupport {
        public RichEditPropertyEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) {
            ControlBindingProperty = "RtfText";
        }
        private RichEditUserControl richEditUserControlCore = null;
        public RichEditUserControl RichEditUserControl {
            get {
                return richEditUserControlCore;
            }
        }
        protected override object CreateControlCore() {
            richEditUserControlCore = new RichEditUserControl();
            UpdateReadOnly();
            return richEditUserControlCore;
        }
        protected override void OnAllowEditChanged() {
            base.OnAllowEditChanged();
            UpdateReadOnly();
        }
        private void UpdateReadOnly() {
            if (RichEditUserControl != null && RichEditUserControl.RichEditControl != null) {
                RichEditUserControl.RichEditControl.ReadOnly = !AllowEdit;
            }
        }

        #region IInplaceEditSupport Members

        public DevExpress.XtraEditors.Repository.RepositoryItem CreateRepositoryItem() {
            return new RepositoryItemRtfEditEx();
        }

        #endregion
    }
}