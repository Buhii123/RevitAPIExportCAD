using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace RevitAPIExportCAD.Model
{
    public class ComboBoxTypeView
    {
        private string nametypeview;
        public ICollection<ElementId> selecView { get; set; }
        public string NameTypeView
        {
            get => nametypeview;
        }
        public ObservableCollection<InfoView> infoViews { get; set; }
        public ComboBoxTypeView(Document doc, List<View> v, string tView)
        {
            infoViews = new ObservableCollection<InfoView>();
            selecView = new ObservableCollection<ElementId>();
            nametypeview = tView;
            int stt = 1;
            foreach (View view in v)
            {
                if (!view.Name.Contains("<Revision Schedule>"))
                {
                    if (doc.GetElement(view.GetTypeId()) != null)
                    {
                        if (doc.GetElement(view.GetTypeId()).Name.Equals(tView))
                        {
                            infoViews.Add(new InfoView(view,stt));
                            selecView.Add(view.Id);
                            stt++;  
                        }
                    }

                }

            }

        }
        public ComboBoxTypeView(Document doc, List<View> v)
        {
            nametypeview = "All View";
            infoViews = new ObservableCollection<InfoView>();
            selecView = new ObservableCollection<ElementId>();
            int stt = 1;

            foreach (View V in v)
            {
                if (!V.Name.Contains("<Revision Schedule>"))
                {
                    if (doc.GetElement(V.GetTypeId()) != null && V.Id != null)
                    {
                        infoViews.Add(new InfoView(V, stt));
                        selecView.Add(V.Id);
                        stt++;
                    }
                }
            }
        }
    }
}
