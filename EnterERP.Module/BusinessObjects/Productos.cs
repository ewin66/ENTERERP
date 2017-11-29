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
    [DefaultProperty("Nombre")]    
    [NavigationItem("Inventario")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Productos : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Productos(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        int producto;
        [Key(true)]
        public int Producto
        {
            get { return producto; }
            set { SetPropertyValue("Producto", ref producto, value); }
        }

        string codigo;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Codigo
        {
            get { return codigo; }
            set { SetPropertyValue("Codigo", ref codigo, value); }
        }

        string codigoDelProveedor;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodigoDelProveedor
        {
            get { return codigoDelProveedor; }
            set { SetPropertyValue("CodigoDelProveedor", ref codigoDelProveedor, value); }
        }

        string nombre;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField]
        public string Nombre
        {
            get { return nombre; }
            set { SetPropertyValue("Nombre", ref nombre, value); }
        }

        Departamentos departamento;
        [RuleRequiredField]
        public Departamentos Departamento
        {
            get { return departamento; }
            set { SetPropertyValue("Departamento", ref departamento, value); }
        }
        Categorias categoria;
        [RuleRequiredField]
        public Categorias Categoria
        {
            get { return categoria; }
            set { SetPropertyValue("Categoria", ref categoria, value); }
        }


        Monedas moneda;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Monedas Moneda
        {
            get { return moneda; }
            set { SetPropertyValue("Moneda", ref moneda, value); }
        }

        decimal costo;
        public decimal Costo
        {
            get { return costo; }
            set { SetPropertyValue("Costo", ref costo, value); }
        }

        decimal precio;
        public decimal Precio
        {
            get { return precio; }
            set { SetPropertyValue("Precio", ref precio, value); }
        }

        bool inventario;
        [ModelDefault("Caption","Manejar Inventarios?")]
        public bool Inventario
        {
            get { return inventario; }
            set { SetPropertyValue("Inventario", ref inventario, value); }
        }

        bool inactivo;
        public bool Inactivo
        {
            get { return inactivo; }
            set { SetPropertyValue("Inactivo", ref inactivo, value); }
        }

        Impuestos impuesto;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Impuestos Impuesto
        {
            get { return impuesto; }
            set { SetPropertyValue("Impuesto", ref impuesto, value); }
        }

        bool incluirImpuesto;
        [ToolTip("El precio tiene incluido el impuesto?")]
        public bool IncluirImpuesto
        {
            get { return incluirImpuesto; }
            set { SetPropertyValue("IncluirImpuesto", ref incluirImpuesto, value); }
        }

        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        [Action(Caption = "Desactivar Producto?", ConfirmationMessage = "Esta seguro de descativar este producto?", ImageName = "Attention", AutoCommit = true)]
        public void ActionMethod() {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            this.Inactivo = true;
        }
    }
}