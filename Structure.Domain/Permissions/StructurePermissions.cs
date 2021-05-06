using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Permissions
{
    public class StructurePermissions
    {
        public const string GroupName = "Structure";
        public class Patients
        {
            public const string Default = GroupName + ".Patients";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Consultaties
        {
            public const string Default = GroupName + ".Consultaties";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ResourceAppointments
        {
            public const string Default = GroupName + ".ResourceAppointments";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Resources
        {
            public const string Default = GroupName + ".Resources";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class LabelObjects
        {
            public const string Default = GroupName + ".LabelObjects";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
