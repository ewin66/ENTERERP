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
    [DefaultClassOptions]
    [XafDefaultProperty("Codigo")]
    [NavigationItem("Sistema")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Monedas : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Monedas(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string fCodigo;
        [Size(20)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue<string>("Codigo", ref fCodigo, value); }
        }
        string fDescripcion;
        public string Descripcion
        {
            get { return fDescripcion; }
            set { SetPropertyValue<string>("Descripcion", ref fDescripcion, value); }
        }
        decimal fFactor;
        public decimal Factor
        {
            get { return fFactor; }
            set { SetPropertyValue<decimal>("Factor", ref fFactor, value); }
        }
        bool fLocal;
        public bool Local
        {
            get { return fLocal; }
            set { SetPropertyValue<bool>("Local", ref fLocal, value); }
        }
        string fSimbolo;
        [Size(3)]
        public string Simbolo
        {
            get { return fSimbolo; }
            set { SetPropertyValue<string>("Simbolo", ref fSimbolo, value); }
        }
        string fObservaciones;
        [Size(4000)]
        public string Observaciones
        {
            get { return fObservaciones; }
            set { SetPropertyValue<string>("Observaciones", ref fObservaciones, value); }
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
        [Association(@"TasasReferencesMonedas", typeof(Tasas))]
        public XPCollection<Tasas> TasasCollection { get { return GetCollection<Tasas>("TasasCollection"); } }
    }
}