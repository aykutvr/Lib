using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Localization.Builders
{
    public class LocalizationListFilterBuilder
    {
        internal Models.LocalizationListFilter _filter { get; set; }
        public void SetId(params int[] id)
        {
            _filter.Id.AddRange(id);
        }

        public void SetLanguage(params string[] language)
        {
            _filter.Lang.AddRange(language);
        }

        public void SetKey(params string[] key)
        {
            _filter.Lang.AddRange(key);
        }
    }
}
