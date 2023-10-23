using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Update_Db_skeleton_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseDetails_Forms_FormId",
                table: "ResponseDetails");

            migrationBuilder.DropIndex(
                name: "IX_ResponseDetails_FormId",
                table: "ResponseDetails");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "ResponseDetails");

            migrationBuilder.AddColumn<string>(
                name: "FormId",
                table: "Responses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_FormId",
                table: "Responses",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_FormId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Responses");

            migrationBuilder.AddColumn<string>(
                name: "FormId",
                table: "ResponseDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseDetails_FormId",
                table: "ResponseDetails",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseDetails_Forms_FormId",
                table: "ResponseDetails",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
