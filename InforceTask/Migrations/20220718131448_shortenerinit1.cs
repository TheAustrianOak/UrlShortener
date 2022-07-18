using Microsoft.EntityFrameworkCore.Migrations;

namespace InforceTask.Migrations
{
    public partial class shortenerinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalUrl = table.Column<string>(type: "nvarchar(3999)", nullable: true),
                    ShortedUrl = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    CreatedAt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
