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
using System.Globalization;

namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Transacciones")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Cotizaciones : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Cotizaciones(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Fecha = DateTime.Now;
            string conteo = "1";
            try
            {
                 conteo = Session.Evaluate<Cotizaciones>(CriteriaOperator.Parse("Count"), CriteriaOperator.Parse("1=1")).ToString();
            }
            catch (Exception ex)
            {
                
            }
            Codigo = "COT" + DateTime.Now.ToString("yyyyMMdd") + conteo;
            Estatus = "Pendiente";
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            try
            {
                if (propertyName == "Fecha" || propertyName=="Cliente")
                {
                    if (Fecha != null)
                        Vence = Fecha.AddDays(Cliente.DiasDeCredito);

                }
            }
            catch (Exception ex)
            {
                
            }
        }
        string codigo;

        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                SetPropertyValue("Codigo", ref codigo, value);
            }
        }
        Clientes cliente;
        [ImmediatePostData]
        [RuleRequiredField(CustomMessageTemplate ="Debe ingresar un cliente")]
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

 

        private FileData file;
  
        public FileData File
        {
            get { return file; }
            set
            {
                SetPropertyValue("File", ref file, value);
            }
        }

        decimal monto;
        public decimal Monto
        {
            get
            {
                return monto;
            }
            set
            {
                SetPropertyValue("Monto", ref monto, value);
            }
        }

        string estatus;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Estatus
        {
            get
            {
                return estatus;
            }
            set
            {
                SetPropertyValue("Estatus", ref estatus, value);
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

        [Action(Caption = "Aprobar", ConfirmationMessage = "Esta seguro?", ImageName = "Attention", AutoCommit = true,TargetObjectsCriteria ="[Estatus]='Pendiente'")]
        public void ActionMethod()
        {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            this.Estatus = "Aprobada";
        }
    }
}