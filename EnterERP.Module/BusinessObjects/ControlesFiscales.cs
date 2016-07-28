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
    
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ControlesFiscales : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ControlesFiscales(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Controles control;
        [Association(@"ControlesFiscalesDet")]
        public Controles Control
        {
            get
            {
                return control;
            }
            set
            {
                SetPropertyValue("Control", ref control, value);
            }
        }

        string sucursal;
        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Sucursal
        {
            get
            {
                return sucursal;
            }
            set
            {
                SetPropertyValue("Sucursal", ref sucursal, value);
            }
        }

        string cAI;
        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CAI
        {
            get
            {
                return cAI;
            }
            set
            {
                SetPropertyValue("CAI", ref cAI, value);
            }
        }

        string rangoDesde;
        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RangoDesde
        {
            get
            {
                return rangoDesde;
            }
            set
            {
                SetPropertyValue("RangoDesde", ref rangoDesde, value);
            }
        }

        string rangoHasta;
        [RuleRequiredField]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RangoHasta
        {
            get
            {
                return rangoHasta;
            }
            set
            {
                SetPropertyValue("RangoHasta", ref rangoHasta, value);
            }
        }


        DateTime limiteDeEmision;
        [RuleRequiredField]
        public DateTime LimiteDeEmision
        {
            get
            {
                return limiteDeEmision;
            }
            set
            {
                SetPropertyValue("LimiteDeEmision", ref limiteDeEmision, value);
            }
        }

        bool activado;
        public bool Activado
        {
            get
            {
                return activado;
            }
            set
            {
                SetPropertyValue("Activado", ref activado, value);
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

        [Action(Caption = "Activar", ConfirmationMessage = "Esta seguro?", ImageName = "Attention", AutoCommit = true, SelectionDependencyType =MethodActionSelectionDependencyType.RequireSingleObject,TargetObjectsCriteria ="Activado=0")]
        public void ActionMethod()
        {
            // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
            this.Activado = true;

            
            //foreach(ControlesFiscales x in)
        }
    }
}