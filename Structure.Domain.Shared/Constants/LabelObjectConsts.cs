using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Shared.Constants
{
    public static class LabelObjectConsts
    {
        private const string DefaultSorting = "{0}LabelObjectId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "LabelObject." : string.Empty);
        }
    }
}
