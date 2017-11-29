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
    [NavigationItem("Dominios")]
    [ImageName("BO_Country_v92")]
    [DefaultProperty("URL")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Dominios : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Dominios(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Clientes cliente;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Clientes Cliente
        {
            get { return cliente; }
            set { SetPropertyValue("Cliente", ref cliente, value); }
        }

        string uRL;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string URL
        {
            get { return uRL; }
            set { SetPropertyValue("URL", ref uRL, value); }
        }

        DateTime fechaDeCreacion;
        public DateTime FechaDeCreacion
        {
            get { return fechaDeCreacion; }
            set { SetPropertyValue("FechaDeCreacion", ref fechaDeCreacion, value); }
        }


        DateTime fechaActualido;
        public DateTime FechaActualizado
        {
            get { return fechaActualido; }
            set { SetPropertyValue("FechaActualido", ref fechaActualido, value); }
        }

        DateTime fechaDeExpiracion;
        public DateTime FechaDeExpiracion
        {
            get { return fechaDeExpiracion; }
            set { SetPropertyValue("FechaDeExpiracion", ref fechaDeExpiracion, value); }
        }
        [PersistentAlias("DateDiffDay(Now(),Iif(IsNullOrEmpty(FechaDeExpiracion),Now(),FechaDeExpiracion))")]
        public int DiasParaExpirar
        {
            get { return Convert.ToInt32(EvaluateAlias("DiasParaExpirar")); }
        }

        string contacto;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Contacto
        {
            get { return contacto; }
            set { SetPropertyValue("Contacto", ref contacto, value); }
        }


        [Association("Dominios-AgregadosDominios")]
        [XafDisplayName("Agregados")]
        public XPCollection<AgregadosDominios> AgregadosCol
        {
            get
            {
                return GetCollection<AgregadosDominios>("AgregadosCol");
            }
        }


        [PersistentAlias("AgregadosCol.Count()")]
        public int AgregadosRealizados
        {
            get { return Convert.ToInt32(EvaluateAlias("AgregadosRealizados")); }
        }


        [PersistentAlias("AgregadosCol.Sum(Valor)")]
        public double TotalAgregados
        {
            get { return Convert.ToDouble(EvaluateAlias("TotalAgregados")); }
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