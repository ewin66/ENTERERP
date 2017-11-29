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
using EnterERP.Module.BusinessObjects.maptooni_CFSCustomers;
using EnterERP.Module.BusinessObjects.CFSDealers.maptooni_CFSDealers;

namespace EnterERP.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [NavigationItem("CFSPOS")]
    public class SupportTickets : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SupportTickets(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "Dealer")
            {
                if (Dealer != null)
                {
                    ContactName = Dealer.xx_name_tx;
                    PhoneNumber = Session.FindObject<ccPayments>(CriteriaOperator.Parse("ROID=?",Dealer.DID)).phone;
                    Email = dealer.xx_user_name_tx;
                    UserName = dealer.xx_user_name_tx;
                    Password = dealer.xx_password_tx;
                }
            }
        }

        int ticket;
        [Key(true)]
        public int Ticket
        {
            get
            {
                return ticket;
            }
            set
            {
                SetPropertyValue("Ticket", ref ticket, value);
            }
        }

        DateTime ticketDate;
        [ModelDefault("DisplayFormat", "{g}")]
        [ModelDefault("EditMask", "g")]
        public DateTime TicketDate
        {
            get
            {
                return ticketDate;
            }
            set
            {
                SetPropertyValue("TicketDate", ref ticketDate, value);
            }
        }
        DSettings dealer;
        [ImmediatePostData]
        public DSettings Dealer
        {
            get
            {
                return dealer;
            }
            set
            {
                SetPropertyValue("Dealer", ref dealer, value);
            }
        }

        string contactName;
       
        public string ContactName
        {
            get
            {
                return contactName;
            }
            set
            {
                SetPropertyValue("ContactName", ref contactName, value);
            }
        }

        string phoneNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                SetPropertyValue("PhoneNumber", ref phoneNumber, value);
            }
        }
        string email;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                SetPropertyValue("Email", ref email, value);
            }
        }


        string mySQLDataBase;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MySQLDataBase
        {
            get
            {
                return mySQLDataBase;
            }
            set
            {
                SetPropertyValue("MySQLDataBase", ref mySQLDataBase, value);
            }
        }


        string userName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                SetPropertyValue("UserName", ref userName, value);
            }
        }

        string password;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetPropertyValue("Password", ref password, value);
            }
        }


        string description;
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias("RTF")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                SetPropertyValue("Description", ref description, value);
            }
        }

        DateTime solutionDate;
        [ModelDefault("DisplayFormat", "{g}")]
        [ModelDefault("EditMask", "g")]
        public DateTime SolutionDate
        {
            get
            {
                return solutionDate;
            }
            set
            {
                SetPropertyValue("SolutionDate", ref solutionDate, value);
            }
        }

        string solution;
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias("RTF")]
        public string Solution
        {
            get
            {
                return solution;
            }
            set
            {
                SetPropertyValue("Solution", ref solution, value);
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
    }
}