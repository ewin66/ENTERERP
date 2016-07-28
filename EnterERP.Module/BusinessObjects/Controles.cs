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
    [ImageName("BO_User")]
    [XafDisplayName("Datos Generales")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Controles : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Controles(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string empresa;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                SetPropertyValue("Empresa", ref empresa, value);
            }
        }

        string rTN;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RTN
        {
            get
            {
                return rTN;
            }
            set
            {
                SetPropertyValue("RTN", ref rTN, value);
            }
        }

        string direccion;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                SetPropertyValue("Direccion", ref direccion, value);
            }
        }

        string telefono;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                SetPropertyValue("Telefono", ref telefono, value);
            }
        }

        string celular;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Celular
        {
            get
            {
                return celular;
            }
            set
            {
                SetPropertyValue("Celular", ref celular, value);
            }
        }

        string correo;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                SetPropertyValue("Correo", ref correo, value);
            }
        }

        [Association(@"ControlesFiscalesDet", typeof(ControlesFiscales))]
        public XPCollection<ControlesFiscales> ControlesFiscalesDetalle { get { return GetCollection<ControlesFiscales>("ControlesFiscalesDetalle"); } }
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