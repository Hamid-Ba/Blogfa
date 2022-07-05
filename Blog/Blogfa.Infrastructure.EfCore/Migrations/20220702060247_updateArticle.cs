using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogfa.Infrastructure.EfCore.Migrations
{
    public partial class updateArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                schema: "article",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                schema: "users",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ImageAlternative",
                schema: "article",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                schema: "article",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "article",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MetaKeyWords",
                schema: "article",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                schema: "article",
                table: "Articles");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                schema: "article",
                table: "Likes",
                column: "ArticleId",
                principalSchema: "article",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "role",
                table: "Permissions",
                column: "RoleId",
                principalSchema: "role",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId",
                schema: "users",
                table: "Role",
                column: "UserId",
                principalSchema: "users",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                schema: "article",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                schema: "users",
                table: "Role");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlternative",
                schema: "article",
                table: "Articles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                schema: "article",
                table: "Articles",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "article",
                table: "Articles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyWords",
                schema: "article",
                table: "Articles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                schema: "article",
                table: "Articles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Articles_ArticleId",
                schema: "article",
                table: "Likes",
                column: "ArticleId",
                principalSchema: "article",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "role",
                table: "Permissions",
                column: "RoleId",
                principalSchema: "role",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId",
                schema: "users",
                table: "Role",
                column: "UserId",
                principalSchema: "users",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
