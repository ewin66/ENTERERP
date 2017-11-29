using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace EnterERP.Module.BusinessObjects
{
    [NonPersistent]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public abstract class DatosFiscales : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DatosFiscales(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string fCAI;
        [Size(50)]
        [ImmediatePostData]
        public string CAI
        {
            get { return fCAI; }
            set { SetPropertyValue<string>("CAI", ref fCAI, value); }
        }
        string fSucursal;
        [Size(50)]
        public string Sucursal
        {
            get { return fSucursal; }
            set { SetPropertyValue<string>("Sucursal", ref fSucursal, value); }
        }
        DateTime fLimite;
        [Size(50)]
        public DateTime Limite
        {
            get { return fLimite; }
            set { SetPropertyValue<DateTime>("Limite", ref fLimite, value); }
        }
        string fRangoInicial;
        [Size(50)]
        public string RangoInicial
        {
            get { return fRangoInicial; }
            set { SetPropertyValue<string>("RangoInicial", ref fRangoInicial, value); }
        }
        string fRangoFinal;
        [Size(50)]
        public string RangoFinal
        {
            get { return fRangoFinal; }
            set { SetPropertyValue<string>("RangoFinal", ref fRangoFinal, value); }
        }
        string fPuntoDeEmision;
        [Size(50)]
        public string PuntoDeEmision
        {
            get { return fPuntoDeEmision; }
            set { SetPropertyValue<string>("PuntoDeEmision", ref fPuntoDeEmision, value); }
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}