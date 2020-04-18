using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAPI.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineName = table.Column<string>(nullable: true),
                    LocalAddress = table.Column<string>(nullable: true),
                    WindowsVersion = table.Column<string>(nullable: true),
                    RuntimeVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntivirusInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HasAntivirusInstalled = table.Column<bool>(nullable: false),
                    ApplicationName = table.Column<string>(nullable: true),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntivirusInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntivirusInfos_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardDriveInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiskName = table.Column<string>(nullable: true),
                    FreeSpace = table.Column<string>(nullable: true),
                    TotalSize = table.Column<string>(nullable: true),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDriveInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardDriveInfos_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntivirusInfos_MachineId",
                table: "AntivirusInfos",
                column: "MachineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardDriveInfos_MachineId",
                table: "HardDriveInfos",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntivirusInfos");

            migrationBuilder.DropTable(
                name: "HardDriveInfos");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
