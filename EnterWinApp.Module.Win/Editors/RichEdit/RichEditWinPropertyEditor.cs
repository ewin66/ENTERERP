using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using EnterWinApp.Module.Win;

namespace EnterWinApp.Module.Win
{
    //   [PropertyEditor(typeof(string),false)]
    [PropertyEditor(typeof(String), "RTF", false)]

    public class RichEditWinPropertyEditor : WinPropertyEditor, IInplaceEditSupport 
    {
        RichEditContainer ctrl;
        bool changed = false;

        public RichEditWinPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }


        protected override object CreateControlCore()
        {
            
            ctrl = new RichEditContainer();
            ControlBindingProperty = "RtfText";                        
            return ctrl;
          
        }

        protected override void OnAllowEditChanged()
        {
            base.OnAllowEditChanged();
            if (ctrl != null)
                ctrl.RichEditControl.ReadOnly  = !AllowEdit;
        }

        #region IInplaceEditSupport Members

        public DevExpress.XtraEditors.Repository.RepositoryItem CreateRepositoryItem()
        {
            return new RepositoryItemRtfEditEx();
        }

        #endregion


    }

}
