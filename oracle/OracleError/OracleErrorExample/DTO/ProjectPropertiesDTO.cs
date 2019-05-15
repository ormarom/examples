using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleErrorExample.DTO
{
    public class ProjectPropertiesDTO 
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public string ProjectID { get; set; }

        public string UniqueID { get; set; }

        public int? State { get; set; }

        public string Domain { get; set; }

        public string ToolsOptions { get; set; }

        public string DiagnosticsServerId { get; set; }

        public int? TotalConsumption { get; set; }

        public string VugenWorkingMode { get; set; }

        public string HostPoolID { get; set; }

        public int? ConcurrentRuns { get; set; }

        public int? HostsLimit { get; set; }

        public int? VUDSLimit { get; set; }

        public int? VusersLimit { get; set; }

        public string AutPoolID { get; set; }

        public string RecurrentReservation { get; set; }

        public string TestExtendDuration { get; set; }

        public string MaxNumberOfProlongs { get; set; }

        public string Description { get; set; }
    }
}
