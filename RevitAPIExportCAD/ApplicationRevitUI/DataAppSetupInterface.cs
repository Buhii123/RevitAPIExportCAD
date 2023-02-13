using Autodesk.Revit.UI;
using RevitAPIExportCAD.Model;
using RevitAPIExportCAD.Resources;
using System;


namespace RevitAPIExportCAD.ApplicationRevitUI
{
    public class DataAppSetupInterface
    {
        private UIControlledApplication App;
        public DataAppSetupInterface(UIControlledApplication app) 
        {
            App = app;
        }
        public void InitializeSetupButton() 
        {
            string TabName = "Buhii Tool";
            App.CreateRibbonTab(TabName);   
            var panel = App.CreateRibbonPanel(TabName,"Export Command");
            var ExportCadDataButton = new RevitPushButtonDataModel()
            {
                Label = "Export CAD\n(Filter)",
                Panel = panel,
                Tooltip = "Xuất CAD có Filter",
                IconImageName = "ExportCAD(32x32).png",
                TooltipImageName = "ExportCAD(320x320).png",
                CommandNamespacePath = ExportCADViewCommand.GetPath()
            };
            PushButton button = RevitPushButton.Create(ExportCadDataButton);
        }

    }
}
