using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiEdit.Model
{
    public class EditorDataModel : PropertyChangedNotification
    {
        public ObservableCollection<ItemModel> Items
        {
            get { return GetValue(() => Items); }
            set { SetValue(() => Items, value); }
        }

        public ItemModel CurrentItemOriginalValue
        {
            get { return GetValue(() => CurrentItemOriginalValue); }
            set { SetValue(() => CurrentItemOriginalValue, value); }
        }

        public ItemModel CurrentItem
        {
            get { return GetValue(() => CurrentItem); }
            set { SetValue(() => CurrentItem, value); }
        }
    }
}
