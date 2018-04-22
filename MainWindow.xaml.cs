using MultiEdit.Functions;
using MultiEdit.Model;
using MultiEdit.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MultiEdit
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///     Data for display. Based on Data Model for this form.
        /// </summary>
        public EditorDataModel EditorDataModel
        {
            get; set;
        } = new EditorDataModel()
        {
            Items = new ObservableCollection<ItemModel>(),
            CurrentItemOriginalValue = new ItemModel()
        };

        /// <summary>
        ///     Instances of editable ResourceDictionary
        ///     This is place where I keep all translations
        ///     <para>NOTE: The order of elements in a dictionary is non-deterministic. The notion of order simply is not defined for hashtables. So don't rely on enumerating in the same order as elements were added to the dictionary. That's not guaranteed.</para>
        /// </summary>
        private ResourceDictionary[] ResourcesDictionary
        {
            get;
            set;
        } = new ResourceDictionary[LanguageTypes.TotalLanguages];

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void lstKeys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadAndShowItem();
        }

        public void LoadAndShowItem()
        {
            EditorDataModel.CurrentItem = SelectedItem;

            //ObservableCollection<TMyData> observableCollection = new ObservableCollection<TMyData>();
            //observableCollection.Add(MyDataForDisplay.CurrentItem);

            //ObservableCollection<TMyData> _observableCollection = new ObservableCollection<TMyData>(observableCollection);
            //MyDataForDisplay.CurrentItemOriginalValue = _observableCollection[0];

            if (EditorDataModel.CurrentItem != null)
            {
                EditorDataModel.CurrentItemOriginalValue.Value1 = EditorDataModel.CurrentItem.Value1;
                EditorDataModel.CurrentItemOriginalValue.Value2 = EditorDataModel.CurrentItem.Value2;
                EditorDataModel.CurrentItemOriginalValue.Value3 = EditorDataModel.CurrentItem.Value3;
                EditorDataModel.CurrentItemOriginalValue.Value4 = EditorDataModel.CurrentItem.Value4;
            }
            else
            {
                EditorDataModel.CurrentItemOriginalValue.Value1 = "";
                EditorDataModel.CurrentItemOriginalValue.Value2 = "";
                EditorDataModel.CurrentItemOriginalValue.Value3 = "";
                EditorDataModel.CurrentItemOriginalValue.Value4 = "";
            }

            stcEditor.Visibility = EditorDataModel.CurrentItem != null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (EditorDataModel.CurrentItemOriginalValue != null && EditorDataModel.CurrentItem != null)
            {
                // Reload data
                EditorDataModel.CurrentItem.Value1 = EditorDataModel.CurrentItemOriginalValue.Value1;
                EditorDataModel.CurrentItem.Value2 = EditorDataModel.CurrentItemOriginalValue.Value2;
                EditorDataModel.CurrentItem.Value3 = EditorDataModel.CurrentItemOriginalValue.Value3;
                EditorDataModel.CurrentItem.Value4 = EditorDataModel.CurrentItemOriginalValue.Value4;
            }
            else
            {
                EditorDataModel.CurrentItemOriginalValue.Value1 = "";
                EditorDataModel.CurrentItemOriginalValue.Value2 = "";
                EditorDataModel.CurrentItemOriginalValue.Value3 = "";
                EditorDataModel.CurrentItemOriginalValue.Value4 = "";
            }

        }

        #region MVC
        private ItemModel SelectedItem
        {
            get
            {
                return (ItemModel)lstKeys.SelectedItem;
            }
        }
        #endregion
    }
}

