using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API.Models
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set; }
        public string PacientiCollectionName { get; set; }
        public string ConsultatiiCollectionName { get; set; }
        public string LabelObjectCollectionName { get; set; }
        public string ResourceCollectionName { get; set; }
        public string ResourceAppointmentCollectionName { get; set; }
    }

    public interface IDataBaseSettings
    {
        string PacientiCollectionName { get; set; }
        string ConsultatiiCollectionName { get; set; }

        string LabelObjectCollectionName { get; set; }
        string ResourceCollectionName { get; set; }
        string ResourceAppointmentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
