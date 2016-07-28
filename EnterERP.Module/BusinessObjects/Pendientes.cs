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

namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewAndDetailView, true, NewItemRowPosition.Bottom)]
    [Appearance("Completed1", TargetItems = "*",Criteria = "Finalizado = true", FontStyle = FontStyle.Strikeout, FontColor = "ForestGreen")]
    [Appearance("PorCompletar", TargetItems = "Descripcion", Criteria = "Finalizado = false", FontStyle = FontStyle.Bold, FontColor = "Black",BackColor ="LightBlue")]

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
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
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
        }
    }
}