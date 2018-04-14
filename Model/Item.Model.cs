using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiEdit.Model
{
    public class ItemModel : PropertyChangedNotification
    {
        /// <summary>
        ///     Name
        /// </summary>
        public string KeyName
        {
            get { return GetValue(() => KeyName); }
            set { SetValue(() => KeyName, value); }
        }

        /// <summary>
        ///     LV
        /// </summary>
        public string Value1
        {
            get { return GetValue(() => Value1); }
            set { SetValue(() => Value1, value); }
        }

        /// <summary>
        ///     RU
        /// </summary>
        public string Value2
        {
            get { return GetValue(() => Value2); }
            set { SetValue(() => Value2, value); }
        }

        /// <summary>
        ///     EN
        /// </summary>
        public string Value3
        {
            get { return GetValue(() => Value3); }
            set { SetValue(() => Value3, value); }
        }

        /// <summary>
        ///     DE
        /// </summary>
        public string Value4
        {
            get { return GetValue(() => Value4); }
            set { SetValue(() => Value4, value); }
        }
    }
}
