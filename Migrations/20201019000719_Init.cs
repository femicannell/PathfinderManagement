using Microsoft.EntityFrameworkCore.Migrations;

namespace PathfinderManagement.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counsellors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    GroupSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counsellors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pathfinders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    CounsellorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathfinders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pathfinders_Counsellors_CounsellorId",
                        column: x => x.CounsellorId,
                        principalTable: "Counsellors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pathfinders_CounsellorId",
                table: "Pathfinders",
                column: "CounsellorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pathfinders");

            migrationBuilder.DropTable(
                name: "Counsellors");
        }
    }
}
