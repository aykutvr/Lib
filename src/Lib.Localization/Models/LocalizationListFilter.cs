using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Localization.Models
{
    internal class LocalizationListFilter
    {
        public List<int> Id { get; set; } = new List<int>();
        public List<string> Key { get; set; } = new List<string>();
        public List<string> Lang { get; set; } = new List<string>();
    }
}
