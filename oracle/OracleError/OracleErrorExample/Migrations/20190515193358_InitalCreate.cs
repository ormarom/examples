using Microsoft.EntityFrameworkCore.Migrations;

namespace OracleErrorExample.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LAB_PROJECT_PROPERTIES",
                columns: table => new
                {
                    PRJP_ID = table.Column<int>(nullable: false),
                    PRJP_PROJECT_ID = table.Column<int>(nullable: true),
                    PRJP_PROJECT_UID = table.Column<string>(unicode: false, maxLength: 36, nullable: true),
                    PRJP_DOMAIN = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_PROJECT_NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_STATE = table.Column<int>(nullable: true),
                    PRJP_HOST_POOL_ID = table.Column<int>(nullable: true),
                    PRJP_AUT_HOST_POOL_ID = table.Column<int>(nullable: true),
                    PRJP_VUSER_LIMIT = table.Column<int>(nullable: true),
                    PRJP_VUDS_LIMIT = table.Column<int>(nullable: true),
                    PRJP_MACHINE_LIMIT = table.Column<int>(nullable: true),
                    PRJP_CONCURRENT_RUNS = table.Column<int>(nullable: true),
                    PRJP_DIAGNOSTICS_SERVER_ID = table.Column<int>(nullable: true),
                    PRJP_ADAM_SERVER_ID = table.Column<int>(nullable: true),
                    PRJP_ADAM_DOMAIN_ID = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_ADAM_DOMAIN_NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_VER_STAMP = table.Column<int>(nullable: true),
                    PRJP_TOOLS_OPTIONS = table.Column<string>(unicode: false, nullable: true),
                    PRJP_RSV_NOTIFICATION_WINDOW = table.Column<int>(nullable: false),
                    PRJP_RSV_WAIT_BEFORE_NOTIFYING = table.Column<int>(nullable: false),
                    PRJP_RSV_NOTIFY_TO = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PRJP_VUGEN_WORKING_MODE = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    PRJP_STOP_RETRY_PERCENTS = table.Column<int>(nullable: false),
                    PRJP_TOTAL_VUDS_USED = table.Column<int>(nullable: true),
                    PRJP_COPIED_FROM = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_USER_01 = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    PRJP_ASSIGNED_CLOUD_ACCOUNTS = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    PRJP_MAX_NUM_OF_PROLONGS = table.Column<int>(nullable: true),
                    PRJP_FUNC_PROLONG_DURATION = table.Column<int>(nullable: true),
                    PRJP_PROC_PROLONG_DURATION = table.Column<int>(nullable: true),
                    PRJP_TIME_SERIES_DB_KEY = table.Column<int>(nullable: true),
                    PRJP_DLGC_MODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PRJP_RTS_EX_LOG_ALLOWED = table.Column<int>(nullable: true),
                    PRJP_RES_LEVEL = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PRJP_PC_01 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_PC_02 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_PC_03 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_PC_04 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PRJP_REC_RES_ENABLED = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LAB_PROJECT_PROPERTIES", x => x.PRJP_ID);
                });

            migrationBuilder.CreateIndex(
                name: "LAB_PRJ_PROP_STATE_PUID_IDX",
                table: "LAB_PROJECT_PROPERTIES",
                columns: new[] { "PRJP_PROJECT_UID", "PRJP_STATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LAB_PROJECT_PROPERTIES");
        }
    }
}
