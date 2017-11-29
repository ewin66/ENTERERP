using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;

namespace EnterERP.Module {
    [DefaultClassOptions]
    [DefaultProperty("Subject")]
    public class Document : BaseObject {
        public Document(Session session) : base(session) { }
        private string _Subject;
        public string Subject {
            get { return _Subject; }
            set { SetPropertyValue("Subject", ref _Subject, value); }
        }
        private string _Text;
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias("RTF")]
        public string Text {
            get { return _Text; }
            set { SetPropertyValue("Text", ref _Text, value); }
        }
    }
}
