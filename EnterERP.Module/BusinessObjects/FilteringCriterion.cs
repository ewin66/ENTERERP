using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using System.ComponentModel;

namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions, ImageName("Action_Filter")]
    public class CriteriosDeFiltro : BaseObject
    {
        public CriteriosDeFiltro(Session session) : base(session) { }
        public string Descripcion
        {
            get { return GetPropertyValue<string>("Descripcion"); }
            set { SetPropertyValue<string>("Descripcion", value); }
        }
        [ValueConverter(typeof(TypeToStringConverter)), ImmediatePostData]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type TipodeDatos
        {
            get { return GetPropertyValue<Type>("TipodeDatos"); }
            set
            {
                SetPropertyValue<Type>("TipodeDatos", value);
                Criterio = String.Empty;
            }
        }
        [CriteriaOptions("TipodeDatos"), Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public string Criterio
        {
            get { return GetPropertyValue<string>("Criterio"); }
            set { SetPropertyValue<string>("Criterio", value); }
        }
    }
}