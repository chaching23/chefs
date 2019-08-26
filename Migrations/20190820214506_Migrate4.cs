using Microsoft.EntityFrameworkCore.Migrations;

namespace chefs_dishes.Migrations
{
    public partial class Migrate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_user_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Posts_post_id",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_user_id",
                table: "Post",
                newName: "IX_Post_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_user_id",
                table: "Post",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Post_post_id",
                table: "Vote",
                column: "post_id",
                principalTable: "Post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_user_id",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Post_post_id",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Post_user_id",
                table: "Posts",
                newName: "IX_Posts_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_user_id",
                table: "Posts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Posts_post_id",
                table: "Vote",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
