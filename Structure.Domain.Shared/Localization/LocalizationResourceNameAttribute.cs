using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Localization
{
    public class LocalizationResourceNameAttribute:Attribute
    {
        public LocalizationResourceNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public static string GetName(Type resourceType)
        {
            return nameof(resourceType);
        }
    
    }
}
