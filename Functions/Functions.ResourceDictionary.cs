using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace MultiEdit.Functions
{
    public static class ResourceDictionaryFunctions
    {
        /// <summary>
        ///     Load ResourceDictionary from file to memory
        /// </summary>
        /// <param name="fileName">
        ///     File name
        /// </param>
        /// <returns>
        ///     Loaded ResourceDictionary
        /// </returns>
        public static ResourceDictionary LoadResourceDictionaryFromFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                return (ResourceDictionary)XamlReader.Load(fileStream);
            }
        }

        /// <summary>
        ///     Load ResourceDictionary from memory to file
        /// </summary>
        /// <param name="fileName">
        ///     File name. Will be created or overwritten
        /// </param>
        /// <param name="resourceDictionary">
        ///     ResourceDictionary to save
        /// </param>
        /// <returns></returns>
        public static bool SaveResourceDictionaryToFile(string fileName, ResourceDictionary resourceDictionary)
        {
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    XamlWriter.Save(resourceDictionary, fileStream);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Verify that all values in first ResourceDictionary also present in other ResourcesDictionary
        /// </summary>
        /// <param name="resourcesDictionary">
        ///     Array of ResourceDictionary. More than one
        /// </param>
        /// <returns>
        /// </returns>
        public static bool VerifyKeysInResourcesDictionary(ResourceDictionary[] resourcesDictionary)
        {
            // Get first
            ResourceDictionary firstResourceDictionary = resourcesDictionary.First();

            // Iterate over all keys
            foreach (DictionaryEntry key in firstResourceDictionary)
            {
                // Iterate over all ResourceDictionary except first one
                foreach (ResourceDictionary resourceDictionary in resourcesDictionary.Skip(1))
                {
                    if (resourceDictionary[key.Key] == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Verify that size of all ResourcesDictionary are the same
        /// </summary>
        /// <param name="resourcesDictionary">
        ///     Array of ResourceDictionary. More than one
        /// </param>
        /// <returns>
        /// </returns>
        public static bool VerifySizeOfResourcesDictionary(ResourceDictionary[] resourcesDictionary)
        {
            int sizeOfFirst = resourcesDictionary.First().Count;

            foreach (ResourceDictionary resourceDictionary in resourcesDictionary.Skip(1))
            {
                if (resourceDictionary.Count != sizeOfFirst)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Get list of all keys from ResourceDictionary
        /// </summary>
        /// <param name="resourceDictionary"></param>
        /// <returns></returns>
        public static List<string> GetListOfAllKeys(ResourceDictionary resourceDictionary)
        {
            return resourceDictionary.Keys.Cast<string>().ToList();
        }

        /// <summary>
        ///     Get list of all keys from ResourceDictionary as ObservableCollection
        /// </summary>
        public static ObservableCollection<string> GetListOfAllKeysAsObservableCollection(ResourceDictionary resourceDictionary)
        {
            return new ObservableCollection<string>(GetListOfAllKeys(resourceDictionary));
        }
    }
}
