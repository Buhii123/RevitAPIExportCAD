using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAPIExportCAD.Model;
using RevitAPIExportCAD.Views.ViewsMain;
using RevitAPIExportCAD.ViewsModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace RevitAPIExportCAD.ViewsModel
{
    public class ViewMainWindow : ViewModelBase
    {
        UIDocument uidoc { get; }
        Document doc { get; }
        public ObservableCollection<ComboBoxTypeView> lstTypeView { get; set; }
        #region Main View
        private MainViewModel mainview;
        public MainViewModel MainView
        {
            get
            {
                if (mainview == null)
                {
                    mainview = new MainViewModel() { DataContext = this };
                }
                return mainview;
            }
            set
            {
                mainview = value;
                OnPropertyChanged(nameof(MainView));
            }
        }
        #endregion


        public RelayCommand<object> ButtonRun { get; set; }
        public RelayCommand<object> ButtonLink { get; set; }
        public RelayCommand<object> ButtonClose { get; set; }
        public RelayCommand<object> ButtonMaximize { get; set; }



        #region Khoi Tao
        public ViewMainWindow(UIApplication uiapp)
        {
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;

            List<Autodesk.Revit.DB.View> v = new FilteredElementCollector(doc)
                .WherePasses(FillterCategoryView.FilterView(new ElementCategoryFilter(BuiltInCategory.OST_Views),
                                                            new ElementCategoryFilter(BuiltInCategory.OST_Schedules),
                                                            new ElementCategoryFilter(BuiltInCategory.OST_Sheets)))
                .WhereElementIsNotElementType().Cast<Autodesk.Revit.DB.View>()
                .ToList();

            lstTypeView = new ObservableCollection<ComboBoxTypeView>();
            #region
            lstTypeView.Add(new ComboBoxTypeView(doc, v));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.View3D)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.FloorPlaneView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.StructuralView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.ElevationView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.CellingPlaneView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.DetailView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.WallSection)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.SectionView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.SheetView)));
            lstTypeView.Add(new ComboBoxTypeView(doc, v, EnumExtensionsEnumView.ToDisplayString(EnumViewType.Schedule)));


            #endregion            
            ButtonRun = new RelayCommand<object>(p => ConditionRun(), p => EventButtonRun());
            ButtonLink = new RelayCommand<object>(p => true, p => ShowDialogFolder());

        }
        #endregion
        public void EventButtonRun()
        {
            string path = @mainview.tbLinkfolder.Text;
            ComboBoxTypeView item = (ComboBoxTypeView)mainview.cbbViewType.SelectedItem;
            mainview.btnOk.IsEnabled= false;
            try
            {
                using (Transaction tran = new Transaction(doc))
                {
                    tran.Start("ToolExportCAD");

                    if ((bool)mainview.exportDFX.IsChecked)
                    {
                        DXFExportOptions optionDXF = new DXFExportOptions()
                        {
                            Colors = OptionSet.SetColorMode((bool)mainview.Viewoption.rdoIndexColor.IsChecked,
                                                                  (bool)mainview.Viewoption.rdoTrueColor.IsChecked,
                                                                  (bool)mainview.Viewoption.rdoTrueColorPerView.IsChecked),
                            ExportOfSolids = OptionSet.SetSolidMode((bool)mainview.Viewoption.checkPolymesh.IsChecked,
                                                                          (bool)mainview.Viewoption.checkACIS.IsChecked),
                            HideReferencePlane = (bool)mainview.Viewoption.checkHideReferencePlane.IsChecked,
                            HideScopeBox = (bool)mainview.Viewoption.checkHideScopeBox.IsChecked,
                            HideUnreferenceViewTags = (bool)mainview.Viewoption.checkHideUnreferenceViewTags.IsChecked,
                            PreserveCoincidentLines = (bool)mainview.Viewoption.checkPreserveCoincidentLines.IsChecked
                        };
                        doc.Export(path, "DXF", item.selecView, optionDXF);


                    }
                    if ((bool)mainview.exportDWG.IsChecked)
                    {
                        DWGExportOptions optionDWG = new DWGExportOptions()
                        {
                            Colors = OptionSet.SetColorMode((bool)mainview.Viewoption.rdoIndexColor.IsChecked,
                                                                  (bool)mainview.Viewoption.rdoTrueColor.IsChecked,
                                                                  (bool)mainview.Viewoption.rdoTrueColorPerView.IsChecked),
                            ExportOfSolids = OptionSet.SetSolidMode((bool)mainview.Viewoption.checkPolymesh.IsChecked,
                                                                          (bool)mainview.Viewoption.checkACIS.IsChecked),
                            HideReferencePlane = (bool)mainview.Viewoption.checkHideReferencePlane.IsChecked,
                            HideScopeBox = (bool)mainview.Viewoption.checkHideScopeBox.IsChecked,
                            HideUnreferenceViewTags = (bool)mainview.Viewoption.checkHideUnreferenceViewTags.IsChecked,
                            PreserveCoincidentLines = (bool)mainview.Viewoption.checkPreserveCoincidentLines.IsChecked,
                            MergedViews = (bool)mainview.Viewoption.checkMergedViews.IsChecked,
                        };
                        doc.Export(path, "DWG", item.selecView, optionDWG);

                    }
                    tran.Commit();
                }

            }
            catch (Exception e)
            {
                TaskDialog.Show("Lỗi", e.Message);
                mainview.Close();
            }
            mainview.btnOk.IsEnabled = true;

        }
        public bool ConditionRun()
        {
            if (!string.IsNullOrEmpty(mainview.tbLinkfolder.Text))
            {
                return true;
            }
            return false;
        }
        public void ShowDialogFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                Description = "Chọn Link Folder muốn Export",
                RootFolder = Environment.SpecialFolder.Desktop,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mainview.tbLinkfolder.Text = dialog.SelectedPath;
            }
        }
    }



}
