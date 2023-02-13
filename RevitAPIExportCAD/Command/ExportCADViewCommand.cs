
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using RevitAPIExportCAD.ViewsModel;


namespace RevitAPIExportCAD
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ExportCADViewCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            UIApplication UIAPP = commandData.Application;
            UIDocument UIDOC = UIAPP.ActiveUIDocument;
            Document DOC = UIDOC.Document;
            //TaskDialog.Show("sdasd", "Teasdasdas");
            if (DOC.IsFamilyDocument)
            {
                TaskDialog.Show("Warrning", "Không thể Tool trên Family!");
                return Result.Cancelled;
            }
            ViewMainWindow Mainwindow = new ViewMainWindow(UIAPP);
            Mainwindow.MainView.ShowDialog();

            return Result.Succeeded;
        }




        public static string GetPath()
        {
            return typeof(ExportCADViewCommand).Namespace + "." + nameof(ExportCADViewCommand);
        }
    }
}
