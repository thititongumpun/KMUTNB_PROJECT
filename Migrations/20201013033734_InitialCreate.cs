using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dded.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amlo_officer",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CitizenID = table.Column<string>(unicode: false, maxLength: 13, nullable: true),
                    CardID = table.Column<string>(maxLength: 50, nullable: true),
                    Pin = table.Column<string>(maxLength: 4, nullable: true),
                    GovOfficer = table.Column<bool>(nullable: true),
                    ActiveFlag = table.Column<bool>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amlo_officer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_DEPARTMENT",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<Guid>(nullable: false),
                    DEPARTMENT_CODE = table.Column<string>(maxLength: 10, nullable: true),
                    DEPARTMENT_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    ACTIVE_FLAG = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DEPARTMENT", x => x.DEPARTMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LEVEL",
                columns: table => new
                {
                    LEVEL_ID = table.Column<int>(nullable: false),
                    LEVEL_NAME = table.Column<string>(nullable: true),
                    ACTIVE_FLAG = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LEVEL", x => x.LEVEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LOG",
                columns: table => new
                {
                    LOG_ID = table.Column<Guid>(nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    MAPMENU_ID = table.Column<Guid>(nullable: true),
                    DATA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MAINMENU",
                columns: table => new
                {
                    MAINMENU_ID = table.Column<Guid>(nullable: false),
                    MenuNo = table.Column<int>(nullable: true),
                    MenuName_th = table.Column<string>(maxLength: 100, nullable: true),
                    MenuShortName_th = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName_en = table.Column<string>(maxLength: 100, nullable: true),
                    OfficeID = table.Column<string>(maxLength: 50, nullable: true),
                    PageAddress = table.Column<string>(maxLength: 500, nullable: true),
                    Activeflag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MAINMENU", x => x.MAINMENU_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MAP_PERMISSION",
                columns: table => new
                {
                    PERMISSION_ID = table.Column<Guid>(nullable: false),
                    OFFICER_ID = table.Column<Guid>(nullable: true),
                    MAP_MENU_ID = table.Column<Guid>(nullable: true),
                    ACTIVE_FLAG = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MAP_PERMISSION", x => x.PERMISSION_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MAPCOLUMN",
                columns: table => new
                {
                    MAPCOLUMN_ID = table.Column<Guid>(nullable: false),
                    SubMenu_ID = table.Column<Guid>(nullable: true),
                    ColumnName = table.Column<string>(nullable: true),
                    ColumnDESC = table.Column<string>(nullable: true),
                    ColumnLevel = table.Column<int>(nullable: true),
                    ActiveFlag = table.Column<bool>(nullable: true),
                    No = table.Column<int>(nullable: true),
                    ColumnDateFormat = table.Column<string>(maxLength: 50, nullable: true),
                    ColumnTimeFormat = table.Column<string>(maxLength: 50, nullable: true),
                    ColumnTimestamp = table.Column<bool>(nullable: true),
                    ColumnDateTimeFormat = table.Column<string>(maxLength: 50, nullable: true),
                    ColumnFileFormat = table.Column<string>(maxLength: 50, nullable: true),
                    isCitizenID = table.Column<bool>(nullable: true),
                    startColor = table.Column<short>(nullable: true),
                    externalLink = table.Column<string>(nullable: true),
                    moneyFormat = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MAPCOLUMN", x => x.MAPCOLUMN_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MAPMENU",
                columns: table => new
                {
                    MAPMENU_ID = table.Column<Guid>(nullable: false),
                    MainMenuID = table.Column<Guid>(nullable: false),
                    SubMenuID = table.Column<Guid>(nullable: false),
                    No = table.Column<int>(nullable: true),
                    ActiveFlag = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MAPMENU", x => x.MAPMENU_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_OFFICER",
                columns: table => new
                {
                    OFFICER_ID = table.Column<Guid>(nullable: false),
                    USERNAME = table.Column<string>(nullable: true),
                    CITIZEN_ID = table.Column<string>(maxLength: 13, nullable: true),
                    CARD_ID = table.Column<string>(maxLength: 100, nullable: true),
                    PIN_CODE = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    DEPARTMENT_ID = table.Column<Guid>(nullable: true),
                    LEVEL_ID = table.Column<int>(nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACTIVE_FLAG = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_OFFICER", x => x.OFFICER_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SUBMENU",
                columns: table => new
                {
                    SUBMENU_ID = table.Column<Guid>(nullable: false),
                    MenuNo = table.Column<int>(nullable: true),
                    MenuName_th = table.Column<string>(maxLength: 100, nullable: true),
                    MenuName_en = table.Column<string>(maxLength: 100, nullable: true),
                    ServiceAddress = table.Column<string>(maxLength: 500, nullable: true),
                    OfficeID = table.Column<string>(maxLength: 50, nullable: true),
                    ServiceID = table.Column<string>(maxLength: 50, nullable: true),
                    Version = table.Column<string>(maxLength: 50, nullable: true),
                    Activeflag = table.Column<bool>(nullable: true),
                    ServiceQty = table.Column<int>(nullable: true),
                    ServiceFormatType = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SUBMENU", x => x.SUBMENU_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amlo_officer");

            migrationBuilder.DropTable(
                name: "TBL_DEPARTMENT");

            migrationBuilder.DropTable(
                name: "TBL_LEVEL");

            migrationBuilder.DropTable(
                name: "TBL_LOG");

            migrationBuilder.DropTable(
                name: "TBL_MAINMENU");

            migrationBuilder.DropTable(
                name: "TBL_MAP_PERMISSION");

            migrationBuilder.DropTable(
                name: "TBL_MAPCOLUMN");

            migrationBuilder.DropTable(
                name: "TBL_MAPMENU");

            migrationBuilder.DropTable(
                name: "TBL_OFFICER");

            migrationBuilder.DropTable(
                name: "TBL_SUBMENU");
        }
    }
}
