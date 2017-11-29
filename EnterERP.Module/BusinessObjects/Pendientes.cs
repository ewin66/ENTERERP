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
using System.Drawing;
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


namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Tareas")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    [Appearance("Completed1", TargetItems = "*",Criteria = "Finalizado = true", FontStyle = FontStyle.Strikeout, FontColor = "ForestGreen")]
    [Appearance("PorCompletar", TargetItems = "*", Criteria = "Finalizado = false", FontColor = "Black",BackColor ="LightBlue")]
    [Appearance("PorCompletar2", TargetItems = "*", Criteria = "Finalizado = false and GetDate(Fecha)=GetDate(Now())", BackColor = "LightBlue",FontStyle =FontStyle.Bold)]

    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Pendientes : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Pendientes(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Fecha = System.DateTime.Now;
        }

        Clientes cliente;
        [Association(@"Clientes-Pendientes")]
        public Clientes Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                SetPropertyValue("Cliente", ref cliente, value);
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


        Contactos requeridopor;
        //[DataSourceProperty("Cliente")]
        public Contactos RequeridoPor
        {
            get
            {
                return requeridopor;
            }
            set
            {
                SetPropertyValue("RequeridoPor", ref requeridopor, value);
            }
        }


        string descripcion;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                SetPropertyValue("Descripcion", ref descripcion, value);
            }
        }

        string descripcionExtendida;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DescripcionExtendida
        {
            get { return descripcionExtendida; }
            set { SetPropertyValue("DescripcionExtendida", ref descripcionExtendida, value); }
        }


        DateTime fechaDeEntrega;
        public DateTime FechaDeEntrega
        {
            get { return fechaDeEntrega; }
            set { SetPropertyValue("FechaDeEntrega", ref fechaDeEntrega, value); }
        }

        bool finalizado;
        public bool Finalizado
        {
            get
            {
                return finalizado;
            }
            set
            {
                SetPropertyValue("Finalizado", ref finalizado, value);
            }
        }

        DateTime fechaFinalizado;
        public DateTime FechaFinalizado
        {
            get { return fechaFinalizado; }
            set { SetPropertyValue("FechaFinalizado", ref fechaFinalizado, value); }
        }

        bool cuentaPorCobrar;
        public bool CuentaPorCobrar
        {
            get
            {
                return cuentaPorCobrar;
            }
            set
            {
                SetPropertyValue("CuentaPorCobrar", ref cuentaPorCobrar, value);
            }
        }


        bool cancelado;
        public bool Cancelado
        {
            get { return cancelado; }
            set { SetPropertyValue("Cancelado", ref cancelado, value); }
        }


        [PersistentAlias("DateDiffDay(Fecha,Iif(IsNullOrEmpty(FechaFinalizado),Today(),FechaFinalizado))")]
        public int Dias
        {
            get { return Convert.ToInt32(EvaluateAlias("Dias")); }
        }

        [PersistentAlias("DateDiffHour(Fecha,Iif(IsNullOrEmpty(FechaFinalizado),Today(),FechaFinalizado))")]
        public int Horas
        {
            get { return Convert.ToInt32(EvaluateAlias("Horas")); }
        }

        int horasPorCobrar;
        public int HorasPorCobrar
        {
            get { return horasPorCobrar; }
            set { SetPropertyValue("HorasPorCobrar", ref horasPorCobrar, value); }
        }

        Facturas factura;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Facturas Factura
        {
            get { return factura; }
            set { SetPropertyValue("Factura", ref factura, value); }
        }


        string comentarios;
        [VisibleInListView(false)]
        [VisibleInDetailView(true)]   
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias("RTF2")]
        public string Comentarios
        {
            get
            {
                return comentarios;
            }
            set
            {
                SetPropertyValue("Comentarios", ref comentarios, value);
            }
        }

        private string _cuadro;
        [VisibleInListView(false)]
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias("XLS")]
        //[EditorAlias("RtfText")]
        //RtfText
        //[EditorAlias("HtmlPropertyEditor")]
        public string Cuadro
        {
            get { return _cuadro; }
            set { SetPropertyValue("Cuadro", ref _cuadro, value); }
        }

        FileData adjunto;
        public FileData Adjunto
        {
            get
            {
                return adjunto;
            }
            set
            {
                SetPropertyValue("Adjunto", ref adjunto, value);
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

        [Action(Caption = "Finalizar Tarea", ConfirmationMessage = "Desea finalizar la tarea?", ImageName = "Attention", AutoCommit = true)]
        public void ActionMethod()
        {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            this.Finalizado = true;
            this.FechaFinalizado = DateTime.Now;
        }

        [Action(Caption = "Crear Cuenta por Cobrar", ConfirmationMessage = "Desea crear una cuenta por cobrar de esta tarea?", ImageName = "Attention", AutoCommit = true,TargetObjectsCriteria ="Finalizado=true AND Cliente!=''")]
        public void CrearCXC()
        {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            CXCDocumentos cxcdoc = new CXCDocumentos(Session);
            cxcdoc.Fecha = Fecha;
            cxcdoc.Cliente = Cliente;
            cxcdoc.Aplica = "Pendiente";
            cxcdoc.Vence = Fecha.AddDays(Cliente.DiasDeCredito);
            cxcdoc.Monto = 1;
            cxcdoc.Concepto = Session.FindObject<CXCConceptos>(CriteriaOperator.Parse("Concepto like '%Pendiente%'"));
            CuentaPorCobrar = true;
            Save();
            //DetailView dv = Application.CreateDetailView(cxcdoc);//Specify the IsRoot parameter if necessary.
            //dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            //e.ShowViewParameters.CreatedView = dv;
        }
    }
}