using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogfa.Infrastructure.EfCore.Migrations
{
    public partial class editPermission : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_RoleId",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                schema: "role",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "role",
                table: "Permissions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "role",
                table: "Permissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "role",
                table: "Permissions",
                columns: new[] { "RoleId", "Id" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                schema: "role",
                table: "Permissions");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "role",
                table: "Permissions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                schema: "role",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                schema: "role",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "role",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                schema: "role",
                table: "Permissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                schema: "role",
                table: "Permissions",
                column: "RoleId");

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
