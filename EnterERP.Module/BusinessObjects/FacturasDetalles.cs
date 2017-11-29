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
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp.SystemModule;

namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, true, NewItemRowPosition.Bottom)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class FacturasDetalles : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public FacturasDetalles(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        
        


        protected override void OnSaving()
        {
            base.OnSaving();
            subtotal = SubTotal;
            try
            {
                Factura.CalcularTotales();
            }
            catch (Exception ex)
            {
                
            }
        }

  
        protected override void OnDeleting()
        {
            base.OnDeleting();
            try
            {
                Factura.CalcularTotales();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            try
            {
                if (propertyName == "Impuesto")
                {
                    PorcentajeImpuesto = Impuesto.Porcentaje;
                }

                if (propertyName == "DProducto")
                {
                    if (Precio == 0)
                    {
                        if (DProducto.IncluirImpuesto == true)
                        {
                            Precio = DProducto.Precio / (1 + (Impuesto.Porcentaje / 100));
                        }
                        else
                        {
                            Precio = DProducto.Precio;
                        }
                    }
                }
            }
            catch { }
        }

        int iD;
        [Key(true)]
        public int ID
        {
            get { return iD; }
            set { SetPropertyValue("ID", ref iD, value); }
        }

        Facturas factura;
        [Association(@"FacFacturasDetalles")]
        public Facturas Factura
        {
            get { return factura; }
            set { SetPropertyValue("Factura", ref factura, value); }
        }


        double cantidad;
        public double Cantidad
        {
            get { return cantidad; }
            set { SetPropertyValue("Cantidad", ref cantidad, value); }
        }

        string producto;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Producto
        {
            get { return producto; }
            set { SetPropertyValue("Producto", ref producto, value); }
        }

        Productos dProducto;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [DataSourceCriteria("Inactivo!=True")]
        public Productos DProducto
        {
            get { return dProducto; }
            set { SetPropertyValue("DProducto", ref dProducto, value); }
        }

        string descripcion;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Descripcion
        {
            get { return descripcion; }
            set { SetPropertyValue("Descripcion", ref descripcion, value); }
        }



        decimal precio;
        public decimal Precio
        {
            get { return precio; }
            set { SetPropertyValue("Precio", ref precio, value); }
        }

        Impuestos impuesto;
        [ImmediatePostData]
        public Impuestos Impuesto
        {
            get { return impuesto; }
            set { SetPropertyValue("Impuesto", ref impuesto, value); }
        }

        decimal porcentajeImpuesto;
        public decimal PorcentajeImpuesto
        {
            get { return porcentajeImpuesto; }
            set { SetPropertyValue("PorcentajeImpuesto", ref porcentajeImpuesto, value); }
        }

        double descuento;
        public double Descuento
        {
            get { return descuento; }
            set { SetPropertyValue("Descuento", ref descuento, value); }
        }

        decimal subtotal;
        //[PersistentAlias("Cantidad*Precio-(Cantidad*Precio)*Descuento/100+(Cantidad*Precio)*PorcentajeImpuesto/100")]
        [PersistentAlias("Cantidad*Precio")]
        public decimal SubTotal
        {
            get {
                try
                {
                    return Convert.ToDecimal(EvaluateAlias("SubTotal"));
                }
                catch { return 0; }
            }
            set { SetPropertyValue("SubTotal", ref subtotal, value); }
        }
        


      [Association("FacturasDetFacturasComent"), DevExpress.Xpo.Aggregated]
        [ModelDefault("NewItemRowPosition", "Bottom")]
        public XPCollection<FacturasComentarios> FacturasComentariosDat { get { return GetCollection<FacturasComentarios>("FacturasComentariosDat"); } }

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