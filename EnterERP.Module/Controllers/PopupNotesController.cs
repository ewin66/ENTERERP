using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;

namespace EnterERP.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PopupNotesController : ViewController
    {
        public PopupNotesController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ShowNotesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs args)
        {
            ListView lv = Application.CreateListView(Application.CreateObjectSpace(typeof(AuditDataItemPersistent)), typeof(AuditDataItemPersistent), true);
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            criteria.Operands.Add(new BinaryOperator("AuditedObject.TargetType", ((XPObjectSpace)ObjectSpace).Session.GetObjectType(View.CurrentObject)));
            criteria.Operands.Add(new BinaryOperator("AuditedObject.TargetKey", XPWeakReference.KeyToString(ObjectSpace.GetKeyValue(View.CurrentObject))));
            lv.CollectionSource.Criteria["ByTargetObject"] = criteria;
            args.View = lv;
        }

        private void popupWindowShowAction1_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //ListView lv = Application.CreateListView(Application.CreateObjectSpace(typeof(AuditDataItemPersistent)), typeof(AuditDataItemPersistent), true);
            //GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            //criteria.Operands.Add(new BinaryOperator("AuditedObject.TargetType", ((XPObjectSpace)ObjectSpace).Session.GetObjectType(View.CurrentObject)));
            //criteria.Operands.Add(new BinaryOperator("AuditedObject.TargetKey", XPWeakReference.KeyToString(ObjectSpace.GetKeyValue(View.CurrentObject))));
            //lv.CollectionSource.Criteria["ByTargetObject"] = criteria;
            //args.View = lv;
        }
    }
}
