using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiEdit.Types
{
    public static class LanguageTypes
    {
        [Flags]
        public enum Languages
        {
            lLV = 0,
            lRU = 1,
            lEN = 2,
            lDE = 3
        };

        /// <summary>
        ///     Просто размер. Просто определяется в одном месте.
        ///     <para>Just size. Just declared in one single place.</para>
        /// </summary>
        public static int TotalLanguages { get; set; }  = Enum.GetValues(typeof(LanguageTypes.Languages)).Cast<int>().Max() + 1;
    }
}
