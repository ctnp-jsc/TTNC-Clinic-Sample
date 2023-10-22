using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Update_Db_skeleton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_HRMForms_FormId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDetails_HRMForms_FormId",
                table: "ResponseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HRMForms",
                table: "HRMForms");

            migrationBuilder.RenameTable(
                name: "HRMForms",
                newName: "Forms");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseId",
                table: "ResponseDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMandatory",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QuestionCategory",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionCategoryDescription",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionDataType",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionId",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Forms_FormId",
                table: "Questions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDetails_Forms_FormId",
                table: "ResponseDetails",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Forms_FormId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDetails_Forms_FormId",
                table: "ResponseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "IsMandatory",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionCategory",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionCategoryDescription",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionDataType",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Forms");

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "HRMForms");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseId",
                table: "ResponseDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionId",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HRMForms",
                table: "HRMForms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_HRMForms_FormId",
                table: "Questions",
                column: "FormId",
                principalTable: "HRMForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDetails_HRMForms_FormId",
                table: "ResponseDetails",
                column: "FormId",
                principalTable: "HRMForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
