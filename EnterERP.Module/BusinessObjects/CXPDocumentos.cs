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
    [NavigationItem("Cuentas por Pagar")]
   
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]

    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class CXPDocumentos : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CXPDocumentos(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        int iD;
        [Key(true)]
        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                SetPropertyValue("ID", ref iD, value);
            }
        }


        string documento;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                SetPropertyValue("Documento", ref documento, value);
            }
        }

        Proveedores proveedor;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Proveedores Proveedor
        {
            get
            {
                return proveedor;
            }
            set
            {
                SetPropertyValue("Proveedor", ref proveedor, value);
            }
        }

        DateTime fecha;
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                SetPropertyValue("Fecha", ref fecha, value);
            }
        }


        DateTime vence;
        public DateTime Vence
        {
            get
            {
                return vence;
            }
            set
            {
                SetPropertyValue("Vence", ref vence, value);
            }
        }


        Monedas moneda;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Monedas Moneda
        {
            get
            {
                return moneda;
            }
            set
            {
                SetPropertyValue("Moneda", ref moneda, value);
            }
        }

        decimal factor;
        public decimal Factor
        {
            get
            {
                return factor;
            }
            set
            {
                SetPropertyValue("Factor", ref factor, value);
            }
        }

        string referencia;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Referencia
        {
            get
            {
                return referencia;
            }
            set
            {
                SetPropertyValue("Referencia", ref referencia, value);
            }
        }

        string aplica;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Aplica
        {
            get
            {
                return aplica;
            }
            set
            {
                SetPropertyValue("Aplica", ref aplica, value);
            }
        }

        double subTotal;
        public double SubTotal
        {
            get
            {
                return subTotal;
            }
            set
            {
                SetPropertyValue("SubTotal", ref subTotal, value);
            }
        }

        double impuesto;
        public double Impuesto
        {
            get
            {
                return impuesto;
            }
            set
            {
                SetPropertyValue("Impuesto", ref impuesto, value);
            }
        }

        double total;
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                SetPropertyValue("Total", ref total, value);
            }
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