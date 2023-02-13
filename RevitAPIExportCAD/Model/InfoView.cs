using Autodesk.Revit.DB;
using System;

namespace RevitAPIExportCAD.Model
{
    public class InfoView
    {
        public string IdView { get; set; }  
        public string NameView { get; set; }
        public string typeView { get; set; }
        public int STT { get; set; }
        public InfoView(View v,int stt = 0) 
        {
            IdView = v.Id.ToString();
            NameView = v.Name;
            typeView = v.ViewType.ToString();
            STT = stt;
        }
    }
}
