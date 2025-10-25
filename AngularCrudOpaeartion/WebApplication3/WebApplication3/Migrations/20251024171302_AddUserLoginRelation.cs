using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLoginRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSignUps",
                table: "UserSignUps");

            migrationBuilder.RenameTable(
                name: "UserSignUps",
                newName: "SignUp");

            migrationBuilder.AddColumn<int>(
                name: "UserSignUpId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "SignUp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "SignUp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "SignUp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SignUp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignUp",
                table: "SignUp",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserSignUpId",
                table: "Logins",
                column: "UserSignUpId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_SignUp_UserSignUpId",
                table: "Logins",
                column: "UserSignUpId",
                principalTable: "SignUp",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_SignUp_UserSignUpId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_UserSignUpId",
                table: "Logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SignUp",
                table: "SignUp");

            migrationBuilder.DropColumn(
                name: "UserSignUpId",
                table: "Logins");

            migrationBuilder.RenameTable(
                name: "SignUp",
                newName: "UserSignUps");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "UserSignUps",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserSignUps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserSignUps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserSignUps",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSignUps",
                table: "UserSignUps",
                column: "id");
        }
    }
}
