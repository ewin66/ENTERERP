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
    [ImageName("BO_Contact")]
    [DefaultProperty("Nombre")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Clientes : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Clientes(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                SetPropertyValue("Nombre", ref nombre, value);
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

        string registro;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Registro
        {
            get
            {
                return registro;
            }
            set
            {
                SetPropertyValue("Registro", ref registro, value);
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

        string contacto;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Contacto
        {
            get
            {
                return contacto;
            }
            set
            {
                SetPropertyValue("Contacto", ref contacto, value);
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
        int propertyName;
        public int DiasDeCredito
        {
            get
            {
                return propertyName;
            }
            set
            {
                SetPropertyValue("PropertyName", ref propertyName, value);
            }
        }


        [Association("Clientes-CXCDocumentos")]
        [XafDisplayName("Movimientos Cuentas por Cobrar")]
        public XPCollection<CXCDocumentos> CXCDocumentos
        {
            get
            {
                return GetCollection<CXCDocumentos>("CXCDocumentos");
            }
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display namep"), ToolTip("My hint message")]
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