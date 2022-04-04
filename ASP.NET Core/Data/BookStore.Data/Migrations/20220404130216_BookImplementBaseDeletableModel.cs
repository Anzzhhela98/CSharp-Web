using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class BookImplementBaseDeletableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "UserQuestions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsDeleted",
                table: "Books",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_IsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "UserQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
