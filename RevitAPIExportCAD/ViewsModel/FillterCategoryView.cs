using Autodesk.Revit.DB;
using System;
using System.Collections.ObjectModel;



namespace RevitAPIExportCAD.ViewsModel
{
    public static class FillterCategoryView
    {
        public static LogicalOrFilter FilterView(params ElementFilter[] arr)
        {
            
            var n = new ObservableCollection<ElementFilter>();
            foreach (ElementFilter i in arr)
            {
                n.Add(i);
            }
            return new LogicalOrFilter(n);
        }
    }
}
