using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OracleErrorExample.Domain;

namespace OracleErrorExample.Infra
{
    public class ProjectPropertiesEntityConfigurations : IEntityTypeConfiguration<ProjectProperties>
    {
        public void Configure(EntityTypeBuilder<ProjectProperties> entity)
        {
            entity.ToTable("LAB_PROJECT_PROPERTIES");

            entity.HasKey(e => e.Id);


            entity.HasIndex(e => new { e.PrjpProjectUid, e.PrjpState })
                .HasName("LAB_PRJ_PROP_STATE_PUID_IDX");

            entity.Property(e => e.Id)
                .HasColumnName("PRJP_ID")
                .ValueGeneratedNever();

            entity.Property(e => e.PrjpAdamDomainId)
                .HasColumnName("PRJP_ADAM_DOMAIN_ID")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpAdamDomainName)
                .HasColumnName("PRJP_ADAM_DOMAIN_NAME")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpAdamServerId).HasColumnName("PRJP_ADAM_SERVER_ID");

            entity.Property(e => e.PrjpAssignedCloudAccounts)
                .HasColumnName("PRJP_ASSIGNED_CLOUD_ACCOUNTS")
                .HasMaxLength(4000)
                .IsUnicode(false);

            entity.Property(e => e.PrjpAutHostPoolId).HasColumnName("PRJP_AUT_HOST_POOL_ID");

            entity.Property(e => e.PrjpConcurrentRuns).HasColumnName("PRJP_CONCURRENT_RUNS");

            entity.Property(e => e.PrjpCopiedFrom)
                .HasColumnName("PRJP_COPIED_FROM")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpDiagnosticsServerId).HasColumnName("PRJP_DIAGNOSTICS_SERVER_ID");

            entity.Property(e => e.PrjpDlgcMode)
                .HasColumnName("PRJP_DLGC_MODE")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PrjpDomain)
                .HasColumnName("PRJP_DOMAIN")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpFuncProlongDuration).HasColumnName("PRJP_FUNC_PROLONG_DURATION");

            entity.Property(e => e.PrjpHostPoolId).HasColumnName("PRJP_HOST_POOL_ID");

            entity.Property(e => e.PrjpMachineLimit).HasColumnName("PRJP_MACHINE_LIMIT");

            entity.Property(e => e.PrjpMaxNumOfProlongs).HasColumnName("PRJP_MAX_NUM_OF_PROLONGS");

            entity.Property(e => e.PrjpPc01)
                .HasColumnName("PRJP_PC_01")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpPc02)
                .HasColumnName("PRJP_PC_02")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpPc03)
                .HasColumnName("PRJP_PC_03")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpPc04)
                .HasColumnName("PRJP_PC_04")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpProcProlongDuration).HasColumnName("PRJP_PROC_PROLONG_DURATION");

            entity.Property(e => e.PrjpProjectId).HasColumnName("PRJP_PROJECT_ID");

            entity.Property(e => e.PrjpProjectName)
                .HasColumnName("PRJP_PROJECT_NAME")
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.PrjpProjectUid)
                .HasColumnName("PRJP_PROJECT_UID")
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.Property(e => e.PrjpRecResEnabled)
                .HasColumnName("PRJP_REC_RES_ENABLED")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PrjpResLevel)
                .HasColumnName("PRJP_RES_LEVEL")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PrjpRsvNotificationWindow).HasColumnName("PRJP_RSV_NOTIFICATION_WINDOW");

            entity.Property(e => e.PrjpRsvNotifyTo)
                .HasColumnName("PRJP_RSV_NOTIFY_TO")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.PrjpRsvWaitBeforeNotifying).HasColumnName("PRJP_RSV_WAIT_BEFORE_NOTIFYING");

            entity.Property(e => e.PrjpRtsExLogAllowed).HasColumnName("PRJP_RTS_EX_LOG_ALLOWED");

            entity.Property(e => e.PrjpState).HasColumnName("PRJP_STATE");

            entity.Property(e => e.PrjpStopRetryPercents).HasColumnName("PRJP_STOP_RETRY_PERCENTS");

            entity.Property(e => e.PrjpTimeSeriesDbKey).HasColumnName("PRJP_TIME_SERIES_DB_KEY");

            entity.Property(e => e.PrjpToolsOptions)
                .HasColumnName("PRJP_TOOLS_OPTIONS")
                .IsUnicode(false);

            entity.Property(e => e.PrjpTotalVudsUsed).HasColumnName("PRJP_TOTAL_VUDS_USED");

            entity.Property(e => e.PrjpUser01)
                .HasColumnName("PRJP_USER_01")
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.Property(e => e.PrjpVerStamp).HasColumnName("PRJP_VER_STAMP");

            entity.Property(e => e.PrjpVudsLimit).HasColumnName("PRJP_VUDS_LIMIT");

            entity.Property(e => e.PrjpVugenWorkingMode)
                .IsRequired()
                .HasColumnName("PRJP_VUGEN_WORKING_MODE")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.PrjpVuserLimit).HasColumnName("PRJP_VUSER_LIMIT");
        }
    }
}
