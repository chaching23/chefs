using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chefs_dishes.Migrations
{
    public partial class Migrate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    post_id = table.Column<int>(nullable: false),
                    is_upvote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vote_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vote_post_id",
                table: "Vote",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_user_id",
                table: "Vote",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");
        }
    }
}
