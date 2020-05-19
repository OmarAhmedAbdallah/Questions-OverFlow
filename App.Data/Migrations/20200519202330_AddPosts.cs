using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class AddPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_userdetails_OwnerId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "posts");

            migrationBuilder.RenameIndex(
                name: "IX_Post_OwnerId",
                table: "posts",
                newName: "IX_posts_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_userdetails_OwnerId",
                table: "posts",
                column: "OwnerId",
                principalTable: "userdetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_userdetails_OwnerId",
                table: "posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_posts_OwnerId",
                table: "Post",
                newName: "IX_Post_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_userdetails_OwnerId",
                table: "Post",
                column: "OwnerId",
                principalTable: "userdetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
