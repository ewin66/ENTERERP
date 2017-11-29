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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Transacciones")]
    
    [ImageName("BO_Invoice")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Facturas : DatosFiscales
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Facturas(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Fecha = DateTime.Now;
            TipoDeFactura = TipoFactura.Contado;
            
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "Cliente")
            {

                Direccion = Cliente?.Direccion;
                if(TipoDeFactura==TipoFactura.Credito)
                    Vence = Fecha.AddDays(Convert.ToDouble(Cliente?.DiasDeCredito));
            }

            if (propertyName == "Moneda")
            {
                if (moneda.Local == false)
                {

                    try
                    {
                        Tasas TasaDelDia = Session.FindObject<Tasas>(CriteriaOperator.Parse("Moneda=" + Moneda.ToString() + " and Fecha=" + Fecha.ToString() + ""));
                        TasaCambiaria = Convert.ToDecimal(TasaDelDia?.Tasa);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }

            if (propertyName == "Total")
            {
                Conv convertir = new Conv();
                TotalEnLetras = convertir.enletras((Total*TasaCambiaria).ToString()) + " LEMPIRAS";
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (Session.IsNewObject(this))
            {
                ControlesFiscales df = Session.FindObject<ControlesFiscales>(CriteriaOperator.Parse("Activado=true"));
                try
                {
                    if (Id == 0)
                    {
                        object fac = Session.Evaluate<Facturas>(CriteriaOperator.Parse("Max(Id)"), null);
                   
                        Id = Convert.ToInt32(fac.ToString()) + 1;
                       
                    }


                }
                catch (Exception)
                {


                }
                if (CAI == null || CAI.Length==0)
                {
                    CAI = df.CAI;
                    PuntoDeEmision = df.PuntoDeEmision;
                    Sucursal = df.Sucursal;
                    RangoInicial = df.RangoDesde;
                    RangoFinal = df.RangoHasta;
                    Limite = df.LimiteDeEmision;
                }
                if (Factura == null)
                {

                    String documento = new String('0', 8 - Id.ToString().Length) + Id.ToString();
                    
                    object factura = Session.Evaluate<Facturas>(CriteriaOperator.Parse("Max(Factura)"), null);
                    String facturanueva = factura.ToString();
                    
                    facturanueva = facturanueva.Substring(facturanueva.Length - 8);
                    facturanueva = new String('0', 8 - (Int32.Parse(facturanueva) + 1).ToString().Length) + (Int32.Parse(facturanueva) + 1).ToString();
                    MessageOptions options = new MessageOptions();
                    options.Message = string.Format("{0}.", facturanueva);
                    options.Win.Caption = "Filtro";
                    options.Win.Type = WinMessageType.Toast;
                    //String Facturas = Sucursal + "-" + PuntoDeEmision + "-01-" + documento;
                    String Facturas = Sucursal + "-" + PuntoDeEmision + "-01-" +facturanueva;
                    Factura = Facturas;
                }

            }
        }




        int fId;
        
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }

        string factura; 
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Factura
        {
            get { return factura; }
            set { SetPropertyValue("Factura", ref factura, value); }
        }

        DateTime fecha;
        [RuleRequiredField]
        public DateTime Fecha
        {
            get { return fecha; }
            set { SetPropertyValue("Fecha", ref fecha, value); }
        }

        DateTime vence;
        public DateTime Vence
        {
            get { return vence; }
            set { SetPropertyValue("Vence", ref vence, value); }
        }


        Clientes cliente;
        [RuleRequiredField]
        [ImmediatePostData]
        public Clientes Cliente
        {
            get { return cliente; }
            set { SetPropertyValue("Cliente", ref cliente, value); }
        }

        string direccion;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Direccion
        {
            get { return direccion; }
            set { SetPropertyValue("Direccion", ref direccion, value); }
        }

        TipoFactura tipoDeFactura;
        [RuleRequiredField]
        public TipoFactura TipoDeFactura
        {
            get { return tipoDeFactura; }
            set { SetPropertyValue("TipoDeFactura", ref tipoDeFactura, value); }
        }
        public enum TipoFactura : int { Contado = 1, Credito = 2, Consignacion=3 };


        Monedas moneda;
        [ImmediatePostData]
        public Monedas Moneda
        {
            get { return moneda; }
            set { SetPropertyValue("Moneda", ref moneda, value); }
        }

        decimal tasaCambiaria;
        [ModelDefault("EditMask", "######0.####"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:########.####}")]

        public decimal TasaCambiaria
        {
            get { return tasaCambiaria; }
            set { SetPropertyValue("TasaCambiaria", ref tasaCambiaria, value); }
        }


        //TipoEstatus estado;
        //[Appearance("DisableEstatus", AppearanceItemType = "ViewItem", Context = "DetailView", Enabled = false, TargetItems = "TipoEstatus")]
        //public TipoEstatus Estado
        //{
        //    get { return estado; }
        //    set { SetPropertyValue("Estado", ref estado, value); }
        //}


        //public enum TipoEstatus : int { Enviada = 1, Anulada = 2 };

        bool anulada;
        [Appearance("DisableEstatus", AppearanceItemType = "ViewItem", Context = "DetailView", Enabled = false, TargetItems = "Anulada")]
        public bool Anulada
        {
            get { return anulada; }
            set { SetPropertyValue("Anulada", ref anulada, value); }
        }

        decimal subTotal;
        [ModelDefault("EditMask", "n2"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public decimal SubTotal
        {
            get { return subTotal; }
            set { SetPropertyValue("SubTotal", ref subTotal, value); }
        }


        [PersistentAlias("SubTotal*TasaCambiaria")]
        [VisibleInDetailView(false)]
        public double SubtTotalLocal
        {
            get
            {
                try { return Convert.ToDouble(EvaluateAlias("SubTotalLocal")); }
                catch { return 0; }
            }
        }

        decimal descuento;
        [ModelDefault("EditMask", "n2"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public decimal Descuento
        {
            get { return descuento; }
            set { SetPropertyValue("Descuento", ref descuento, value); }
        }

        decimal impuesto;
        [ModelDefault("EditMask", "n2"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public decimal Impuesto
        {
            get { return impuesto; }
            set { SetPropertyValue("Impuesto", ref impuesto, value); }
        }

        [PersistentAlias("Impuesto*TasaCambiaria")]
        [VisibleInDetailView(false)]
        public double ImpuestoLocal
        {
            get
            {
                try { return Convert.ToDouble(EvaluateAlias("ImpuestoLocal")); }
                catch { return 0; }
            }
        }



        decimal total;
        [ModelDefault("EditMask", "n2"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public decimal Total
        {
            get { return total; }
            set { SetPropertyValue("Total", ref total, value); }
        }

        [PersistentAlias("Total*TasaCambiaria")]
        [VisibleInDetailView(false)]
        public double TotalLocal
        {
            get
            {
                try { return Convert.ToDouble(EvaluateAlias("TotalLocal")); }
                catch { return 0; }
            }
        }

        string observaciones;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Observaciones
        {
            get { return observaciones; }
            set { SetPropertyValue("Observaciones", ref observaciones, value); }
        }

        string totalEnLetras;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TotalEnLetras
        {
            get { return totalEnLetras; }
            set { SetPropertyValue("TotalEnLetras", ref totalEnLetras, value); }
        }

        

        [Association(@"FacFacturasDetalles", typeof(FacturasDetalles)), DevExpress.Xpo.Aggregated]
        [ModelDefault("NewItemRowPosition","Bottom")]

        public XPCollection<FacturasDetalles> FacturasDetallesDatos { get { return GetCollection<FacturasDetalles>("FacturasDetallesDatos"); } }


        public void CalcularTotales()
        {
            decimal subtot = 0;
            decimal descuentotot = 0;
            decimal impuestotot = 0;
            decimal totaltot = 0;
            foreach (FacturasDetalles det in FacturasDetallesDatos)
            {
                subtot += Convert.ToDecimal(det.Cantidad) * det.Precio;
                descuentotot += Convert.ToDecimal(det.Cantidad) * det.Precio * Convert.ToDecimal(det.Descuento) / 100;
                impuestotot += Convert.ToDecimal(det.Cantidad) * det.Precio * Convert.ToDecimal(det.PorcentajeImpuesto) / 100;
                totaltot += subtot - descuentotot + impuestotot;
            }

            SubTotal = subtot;
            Descuento = descuentotot;
            Impuesto = impuestotot;
            Total = subtot - descuentotot + impuestotot;
            Save();
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
        [Action(Caption = "Anular", ConfirmationMessage = "Desea anular la factura?", ImageName = "Attention", AutoCommit = true,TargetObjectsCriteria ="Anulada!=true")]
        public void ActionMethod()
        {
            Anulada = true;
        }

        [Action(Caption = "Cuentas por Cobrar", ConfirmationMessage = "Crear cuentas por cobrar?", ImageName = "Attention", AutoCommit = true, TargetObjectsCriteria = "Anulada!=true")]
        public void CXCMethod()
        {
            CXCDocumentos doccxc = new CXCDocumentos(Session);
            doccxc.Cliente = Cliente;
            doccxc.Referencia = Factura;
            doccxc.Aplica = Factura;
            doccxc.Fecha = Fecha;
            doccxc.Vence = Fecha.AddDays(Cliente.DiasDeCredito);
            doccxc.Monto = Total;
            doccxc.Moneda = Moneda;
            doccxc.Factor = TasaCambiaria;        
            doccxc.Concepto = Session.FindObject<CXCConceptos>(CriteriaOperator.Parse("Concepto='FACTURA'"));
            doccxc.Observaciones="Cuentas por Cobrar de la Factura: " + Factura + " del Cliente: " + Cliente.Nombre; 
        }




    }
}