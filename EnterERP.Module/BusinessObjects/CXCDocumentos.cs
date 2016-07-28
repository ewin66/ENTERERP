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
    [DefaultProperty("Documento")]
    [XafDisplayName("Movimientos de Cuentas por Cobrar")]
    [ModelDefault("IsCloneable", "True")]
    [ModelDefault("IsViewClonable", "True")]
    [ModelDefault("EnableUnboundColumnCreation", "True")]

    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    public class CXCDocumentos : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CXCDocumentos(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Fecha = DateTime.Now;
            Moneda = Session.FindObject<Monedas>(CriteriaOperator.Parse("Codigo='LPS'"));
            Factor = 1;
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if (propertyName == "Moneda")
            {
                Tasas tasa = Session.FindObject<Tasas>(CriteriaOperator.Parse("Codigo='" + Moneda.Codigo + "' and Fecha='" + Fecha.ToShortDateString() + "'"));
                if (tasa != null)
                {

                    _Factor = tasa.Tasa;
                }
            }
            if (Cliente != null)
            {
                if (propertyName == "Fecha")
                    _Vence = Fecha.AddDays(_Cliente.DiasDeCredito);
                _Registro = Cliente.Registro;
                _Direccion = Cliente.Direccion;
            }

            base.OnChanged(propertyName, oldValue, newValue);



        }

        [Persistent("Direccion")]
        private string _Direccion;
        [Persistent("Registro")]
        private string _Registro;
        private FileData _Adjunto;
        private DateTime _Vence;
        private Clientes _Cliente;
        private CXCConceptos _ConceptoCXC;
        private decimal _Monto;
        private DateTime _Fecha;
        private Monedas _Moneda;
        private decimal _Factor;
        private string _Aplica;
        private string _Referencia;

        private string _Observaciones;
        private int fDocumento;
        [Key(true)]
        public int Documento
        {
            get { return fDocumento; }
            set { SetPropertyValue<int>("Documento", ref fDocumento, value); }
        }

        [RuleRequiredField(DefaultContexts.Save)]
        [ImmediatePostData]
        //[XafDisplayName("Concepto por Aplicar")]
        public CXCConceptos ConceptoCXC
        {
            get { return _ConceptoCXC; }
            set { SetPropertyValue("ConceptoCXC", ref _ConceptoCXC, value); }
        }
        [ImmediatePostData]
        [Association("Clientes-CXCDocumentos")]
        public Clientes Cliente
        {
            get { return _Cliente; }
            set { SetPropertyValue("Cliente", ref _Cliente, value); }
        }

        [PersistentAlias("_Registro")]
        public string Registro
        {
            get { return _Registro; }
        }


        [PersistentAlias("_Direccion")]
        public string Direccion
        {
            get { return _Direccion; }
        }




        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                SetPropertyValue("Fecha", ref _Fecha, value);
            }
        }

        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime Vence
        {
            get { return _Vence; }
            set { SetPropertyValue("Vence", ref _Vence, value); }
        }


        [RuleRequiredField(DefaultContexts.Save)]
        [ToolTip("Documento de Referencia")]
        public string Referencia
        {
            get
            {
                return _Referencia;
            }
            set
            {
                SetPropertyValue("Referencia", ref _Referencia, value);
            }
        }

        [RuleRequiredField(DefaultContexts.Save)]
        [ToolTip("Numero de Documento que se aplicara...")]
        public string Aplica
        {
            get
            {
                return _Aplica;
            }
            set
            {
                SetPropertyValue("Aplica", ref _Aplica, value);
            }
        }

        [ImmediatePostData]
        [RuleRequiredField(DefaultContexts.Save)]
        public Monedas Moneda
        {
            get
            {
                return _Moneda;
            }
            set
            {
                SetPropertyValue("Moneda", ref _Moneda, value);
            }
        }

        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "###0.####"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:n4}")]
        public decimal Factor
        {
            get
            {
                return _Factor;
            }
            set
            {
                SetPropertyValue("Factor", ref _Factor, value);
            }
        }


        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "###0.##"), VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:n2}")]
        public decimal Monto
        {
            get { return _Monto; }
            set { SetPropertyValue("Monto", ref _Monto, value); }
        }


        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                SetPropertyValue("Observaciones", ref _Observaciones, value);
            }
        }

        [XafDisplayName("Archivo Adjunto"), ToolTip("Sirve para adjuntar cualquier archivo como respaldo al movimiento")]
        public FileData Adjunto
        {
            get { return _Adjunto; }
            set { SetPropertyValue("Adjunto", ref _Adjunto, value); }
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
