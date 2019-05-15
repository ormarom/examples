using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleErrorExample.Domain
{
    public partial class ProjectProperties
    {
        //defaults are taken from ALM
        internal int Id { get; set; }
        public static int DEFAULT_MAX_NUM_OF_PROLONGS = 3;
        public static int DEFAULT_FUNCTIONAL_PROLONG_DURATION = 10;
        public static int DEFAULT_PROCEDURE_PROLONG_DURATION = 20;
        public static int STOP_RETRY_DEFAULT_PERCENT = 50;
        public static string DEFAULT_COPIED_FROM = "Not Copied";

        public ProjectProperties() { }

        public ProjectProperties(int projectId, string projectUid, string domain, string projectName)
        {
            PrjpProjectId = projectId;
            PrjpProjectUid = projectUid;
            PrjpDomain = domain;
            PrjpProjectName = projectName;
            SetDefaultValues();
        }

        public int? PrjpProjectId { get; private set; }
        public string PrjpProjectUid { get; private set; }
        public string PrjpDomain { get; private set; }
        public string PrjpProjectName { get; private set; }
        public int? PrjpState { get; private set; }
        public int? PrjpHostPoolId { get; private set; }
        public int? PrjpAutHostPoolId { get; private set; }
        public int? PrjpVuserLimit { get; private set; }
        public int? PrjpVudsLimit { get; private set; }
        public int? PrjpMachineLimit { get; private set; }
        public int? PrjpConcurrentRuns { get; private set; }
        public int? PrjpDiagnosticsServerId { get; private set; }
        public int? PrjpAdamServerId { get; private set; }
        public string PrjpAdamDomainId { get; private set; }
        public string PrjpAdamDomainName { get; private set; }
        public int? PrjpVerStamp { get; private set; }
        public string PrjpToolsOptions { get; private set; }
        public int PrjpRsvNotificationWindow { get; private set; }
        public int PrjpRsvWaitBeforeNotifying { get; private set; }
        public string PrjpRsvNotifyTo { get; private set; }
        public string PrjpVugenWorkingMode { get; private set; }
        public int PrjpStopRetryPercents { get; private set; }
        public int? PrjpTotalVudsUsed { get; private set; }
        public string PrjpCopiedFrom { get; private set; }
        public string PrjpUser01 { get; private set; }
        public string PrjpAssignedCloudAccounts { get; private set; }
        public int? PrjpMaxNumOfProlongs { get; private set; }
        public int? PrjpFuncProlongDuration { get; private set; }
        public int? PrjpProcProlongDuration { get; private set; }
        public int? PrjpTimeSeriesDbKey { get; private set; }
        public string PrjpDlgcMode { get; private set; }
        public int? PrjpRtsExLogAllowed { get; private set; }
        public string PrjpResLevel { get; private set; }
        public string PrjpPc01 { get; private set; }
        public string PrjpPc02 { get; private set; }
        public string PrjpPc03 { get; private set; }
        public string PrjpPc04 { get; private set; }
        public string PrjpRecResEnabled { get; private set; }
        public void SetId(int id)
        {
            Id = id;
        }

        public void ResetRecordProps(int projectId, string projectUid)
        {
            PrjpProjectId = projectId;
            PrjpProjectUid = projectUid;
            SetDefaultValues();
        }

        public void UpdateLimits(int? vuserLimit, int? vudsLimit, int? machineLimit, int? concurrentRunsLimit, string hostPoolId,
            string autPoolID, string diagnosticsServerId, string vugenWorkingMode, string toolsOptions, string recurrentReservation)
        {
            PrjpVuserLimit = vuserLimit;
            PrjpVudsLimit = vudsLimit;
            PrjpMachineLimit = machineLimit;
            PrjpConcurrentRuns = concurrentRunsLimit;
            PrjpState = (int)ProjectStateEnum.Active;
            int hPId;
            PrjpHostPoolId = int.TryParse(hostPoolId, out hPId) ? hPId : 1000;
            PrjpTotalVudsUsed = 0;
            PrjpVugenWorkingMode = vugenWorkingMode == null ? "User Defined" : vugenWorkingMode;
            int dSId;
            PrjpDiagnosticsServerId = int.TryParse(diagnosticsServerId, out dSId) ? dSId : (int?)null;
            int aPid;
            PrjpAutHostPoolId = int.TryParse(autPoolID, out aPid) ? aPid : (int?)null;
            PrjpRecResEnabled = recurrentReservation;

            PrjpToolsOptions = toolsOptions;

        }

        public void UpdateForDelete()
        {
            PrjpState = (int)ProjectStateEnum.Deleted;
            PrjpProjectId = 0;
        }

        public void UpdateForRemove()
        {
            PrjpState = (int)ProjectStateEnum.Inactive;
            PrjpProjectId = 0;
        }

        private void SetDefaultValues()
        {
            PrjpState = (int)ProjectStateEnum.Active;
            PrjpMaxNumOfProlongs = DEFAULT_MAX_NUM_OF_PROLONGS;
            PrjpFuncProlongDuration = DEFAULT_FUNCTIONAL_PROLONG_DURATION;
            PrjpProcProlongDuration = DEFAULT_PROCEDURE_PROLONG_DURATION;
            PrjpStopRetryPercents = STOP_RETRY_DEFAULT_PERCENT;
            PrjpCopiedFrom = DEFAULT_COPIED_FROM;
        }
        
    }
    public enum ProjectStateEnum
    {
        Active = 1,
        Deleted = 2,
        Inactive = 3,
        InactiveLab = 4
    }
}
    
