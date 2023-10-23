using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Update_Db_skeleton_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDetails_Answers_AnswerId",
                table: "ResponseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerId",
                table: "ResponseDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDetails_Answers_AnswerId",
                table: "ResponseDetails",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDetails_Answers_AnswerId",
                table: "ResponseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerId",
                table: "ResponseDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDetails_Answers_AnswerId",
                table: "ResponseDetails",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
