using DevExpress.Data;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpand.ExpressApp;

namespace Cadexsa.Module.BusinessObjects
{
    public class CriteriaController : ObjectViewController
    {
        private SingleChoiceAction filteringCriterionAction;
        public CriteriaController()
        {
            filteringCriterionAction = new SingleChoiceAction(this, "Criterios de Filtro", PredefinedCategory.Filters);
            filteringCriterionAction.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.FilteringCriterionAction_Execute);
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Root;        
        }
        protected override void OnActivated()
        {

                filteringCriterionAction.Items.Clear();
            foreach (CriteriosDeFiltro criterion in ObjectSpace.GetObjects<CriteriosDeFiltro>())
                if (criterion.TipodeDatos.IsAssignableFrom(View.ObjectTypeInfo.Type))
                {
                    filteringCriterionAction.Items.Add(
                        new ChoiceActionItem(criterion.Descripcion, criterion.Criterio));
                }
            if (filteringCriterionAction.Items.Count > 0)
                filteringCriterionAction.Items.Add(new ChoiceActionItem("Todos los Registros", null));

            string propertyName = "Fecha";
            ListView vw = null;
            if (View.GetType().ToString().Contains("VST") == false)
            {
                if (View.GetType().ToString().Contains("ListView"))
                {
                    if (View.GetType().ToString().Contains("Collection") == false)
                    {
                        vw = View as XpandListView;
                        IModelColumn columnInfo = ((IModelList<IModelColumn>)vw.Model.Columns)[propertyName];
                        if (columnInfo != null)
                        {

                            filteringCriterionAction.Items.Clear();
                            filteringCriterionAction.Items.Add(new ChoiceActionItem("Este Mes", "GetMonth([Fecha]) = GetMonth(Now()) AND GetYear([Fecha])=GetYear(Now())"));
                            filteringCriterionAction.Items.Add(new ChoiceActionItem("Este Mes y Mes Pasado", "GetMonth([Fecha]) >= GetMonth(Now())-1 AND GetMonth([Fecha]) <= GetMonth(Now()) AND GetYear([Fecha])=GetYear(Now())"));
                            filteringCriterionAction.Items.Add(new ChoiceActionItem("Este Año", "GetYear([Fecha])=GetYear(Now())"));
                            filteringCriterionAction.Items.Add(new ChoiceActionItem("Todos los Registros", ""));
                            //Quita los demas registros es a nivel de datasource
                            //View.CollectionSource.Criteria["Este Mes"] = CriteriaOperator.Parse("GetMonth([Fecha])=GetMonth(Now()) and GetYear([Fecha])=GetYear(Now())");
                            filteringCriterionAction.SelectedIndex = 0;
                            filteringCriterionAction.DoExecute(filteringCriterionAction.SelectedItem);
                        }
                    }
                }
            }
       


        }
        private void FilteringCriterionAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {

                ((ListView)View).CollectionSource.BeginUpdateCriteria();
                ((ListView)View).CollectionSource.Criteria.Clear();
                ((ListView)View).CollectionSource.Criteria[e.SelectedChoiceActionItem.Caption] =
                   CriteriaEditorHelper.GetCriteriaOperator(
                   e.SelectedChoiceActionItem.Data as string, View.ObjectTypeInfo.Type, ObjectSpace);
                ((ListView)View).CollectionSource.EndUpdateCriteria();
       
        }

        private void InitializeComponent()
        {
            // 
            // CriteriaController
            // 
            this.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;

        }
    }
}
