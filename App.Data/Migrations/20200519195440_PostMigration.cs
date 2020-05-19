using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class PostMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "userdetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    postType = table.Column<int>(nullable: false),
                    postStatus = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    AnswersNum = table.Column<long>(nullable: false),
                    viewNum = table.Column<long>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_userdetails_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "userdetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_OwnerId",
                table: "Post",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "userdetails");
        }
    }
}
