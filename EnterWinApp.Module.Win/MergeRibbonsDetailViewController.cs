using System;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.Ribbon;

namespace EnterWinApp.Module.Win
{
    public class MergeRibbonsViewController : ViewController<DetailView>
    {
        private RichEditPropertyEditor editorWithRibbon;
        protected override void OnFrameAssigned()
        {
            base.OnFrameAssigned();
            Frame.TemplateChanged += new EventHandler(Frame_TemplateChanged);
        }
        protected override void OnDeactivated()
        {
            Frame.TemplateChanged += new EventHandler(Frame_TemplateChanged);
            UnMergeRibbon();
            editorWithRibbon = null;
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            IList<RichEditPropertyEditor> editors = View.GetItems<RichEditPropertyEditor>();
            if (editors.Count > 0)
            {
                editorWithRibbon = editors[0];
                MergeRibbons();
            }
        }
        protected RibbonControl MainWindowRibbon
        {
            get
            {
                if (Application.MainWindow != null && Application.MainWindow.Template != null)
                {
                    //return ((XtraFormTemplateBase)(Application.MainWindow.Template)).Ribbon;
                    //return Application.MainWindow.Template.DefaultContainer
                    try
                    {
                        return ((MainRibbonFormV2)(Frame.Template)).Ribbon;
                    }
                    catch (Exception ex)
                    {


                        try
                        {
                            return ((DetailRibbonFormV2)(Frame.Template)).Ribbon;
                        }
                        catch (Exception ex2) { }
                    }
                    
                }
                return null;
            }
        }
        private void UnMergeRibbon()
        {
            if (MainWindowRibbon != null)
            {
                MainWindowRibbon.UnMergeRibbon();
            }
        }
        private void Frame_TemplateChanged(object sender, EventArgs e)
        {
            UnMergeRibbon();
            IClassicToRibbonTransformerHolder form = Frame.Template as IClassicToRibbonTransformerHolder;
            if (form != null)
            {
                form.RibbonTransformer.Transformed += RibbonTransformer_Transformed;
            }
        }
        private void RibbonTransformer_Transformed(object sender, EventArgs e)
        {
            ClassicToRibbonTransformer transformer = (ClassicToRibbonTransformer)sender;
            transformer.Transformed -= RibbonTransformer_Transformed;
            MergeRibbons();
        }
        private void MergeRibbons()
        {
            if (editorWithRibbon != null && (MainWindowRibbon != null) && (editorWithRibbon.RichEditUserControl != null))
            {
                MainWindowRibbon.MergeRibbon(editorWithRibbon.RichEditUserControl.RibbonControl);
            }
        }
    }
}