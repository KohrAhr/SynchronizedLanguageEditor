using MultiEdit.Functions;
using MultiEdit.Model;
using MultiEdit.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiEdit
{
    public partial class MainWindow
    {
        public class LanguageFile
        {
            public string file;
            public LanguageTypes.Languages language;
        }

        public LanguageFile[] filesForProceed = new LanguageFile[]
        {
            new LanguageFile { file = @"Resources\ln1.xaml", language = LanguageTypes.Languages.lLV },
            new LanguageFile { file = @"Resources\ln2.xaml", language = LanguageTypes.Languages.lRU },
            new LanguageFile { file = @"Resources\ln3.xaml", language = LanguageTypes.Languages.lEN },
            new LanguageFile { file = @"Resources\ln4.xaml", language = LanguageTypes.Languages.lDE }
        };

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Read data
            foreach (LanguageFile file in filesForProceed)
            {
                ResourcesDictionary[(int)file.language] = ResourceDictionaryFunctions.LoadResourceDictionaryFromFile(file.file);
            }

            bool result;

            // Verify data (quick way 1)
            result = ResourceDictionaryFunctions.VerifySizeOfResourcesDictionary(ResourcesDictionary);

            if (!result)
            {
                MessageBox.Show("Size of resources doesnot match!");
                return;
            }

            // Verify data (way 2)
            result = ResourceDictionaryFunctions.VerifyKeysInResourcesDictionary(ResourcesDictionary);

            if (!result)
            {
                MessageBox.Show("Keys in resources does not match!");
                return;
            }

            // Build list of Keys and values
            EditorDataModel.Items.Clear();
            foreach (DictionaryEntry key in ResourcesDictionary[(int)LanguageTypes.Languages.lLV])
            {
                ItemModel myData = new ItemModel
                {
                    KeyName = key.Key.ToString(),
                    Value1 = key.Value.ToString(),
                    Value2 = ResourcesDictionary[(int)LanguageTypes.Languages.lRU][key.Key].ToString(),
                    Value3 = ResourcesDictionary[(int)LanguageTypes.Languages.lEN][key.Key].ToString(),
                    Value4 = ResourcesDictionary[(int)LanguageTypes.Languages.lDE][key.Key].ToString()
                };

                EditorDataModel.Items.Add(myData);
            }

            //ResourceDictionaryKeys = ResourceDictionaryFunctions.GetListOfAllKeysAsObservableCollection(ResourcesDictionary[(int)LanguageTypes.Languages.lLV]);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool result;

            // надо скопировать данные из EditorDataModel.Items в новый ResourcesDictionary
            // need to copy data from EditorDataModel.Items to new ResourcesDictionary

            ResourceDictionary newResourceDictionary = new ResourceDictionary();
            foreach (LanguageFile file in filesForProceed)
            {
                string value;
                newResourceDictionary.Clear();
                foreach (ItemModel itemModel in EditorDataModel.Items)
                {
                    switch (file.language)
                    {
                        case LanguageTypes.Languages.lLV:
                            {
                                value = itemModel.Value1;
                                break;
                            }
                        case LanguageTypes.Languages.lRU:
                            {
                                value = itemModel.Value2;
                                break;
                            }
                        case LanguageTypes.Languages.lEN:
                            {
                                value = itemModel.Value3;
                                break;
                            }
                        default:
                            {
                                value = itemModel.Value4;
                                break;
                            }
                    }

                    newResourceDictionary.Add(itemModel.KeyName, value);
                }

                result = ResourceDictionaryFunctions.SaveResourceDictionaryToFile(file.file, newResourceDictionary);

                if (!result)
                {
                    MessageBox.Show(
                        String.Format("Cannot save resources dictionary '{0}'!", file.language)
                    );
                    return;
                }
            }
        }

    }
}
