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
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace EnterWinApp.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class GridVC : ViewController
    {
        public GridVC()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.

            GridListEditor listEditor = ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
            if (listEditor != null)
            {
                GridView gridView = listEditor.GridView;
                if (gridView != null)
                {
                    gridView.OptionsView.EnableAppearanceOddRow = true;
                    gridView.OptionsView.ShowFooter = true;
                    if (gridView.VisibleColumns.Count > 0)
                    {
                        if (gridView.VisibleColumns[0].Summary.Count == 0)
                            gridView.VisibleColumns[0].SummaryItem.SummaryType = SummaryItemType.Count;
                    }

                    foreach (GridColumn grcol in gridView.Columns)
                    {
                        if (grcol.ColumnType.ToString() == "System.Decimal")
                        {
                            if (grcol.Summary.Count == 0)
                            {
                                grcol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            }
                        }
                    }

                    if (gridView.VisibleColumns.Count > 8)
                    {
                        gridView.OptionsView.ColumnAutoWidth = false;
                        gridView.BestFitColumns();

                    }

                }
            }

        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
