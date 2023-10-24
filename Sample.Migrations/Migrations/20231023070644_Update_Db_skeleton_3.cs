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

            migrationBuilder.Sql(
                """
                CREATE VIEW "HRAFormView" AS
                SELECT r.Id, FirstName, LastName, DOB, Gender, Lang, ExtraAnswer, HasAsthma, HasCOPD, HasDiabetes, HasKidney
                FROM Responses r
                LEFT JOIN (
                	SELECT rd.ResponseId, a.Answer AS FirstName
                	FROM ResponseDetails rd
                	JOIN Answers a ON a.Id = rd.AnswerId 
                	JOIN Questions q ON q.Id = a.QuestionId 
                	WHERE q.QuestionText = 'First Name'
                ) t1 ON t1.ResponseId = r.Id
                LEFT JOIN (
                	SELECT rd.ResponseId, a.Answer AS LastName
                	FROM ResponseDetails rd
                	JOIN Answers a ON a.Id = rd.AnswerId 
                	JOIN Questions q ON q.Id = a.QuestionId 
                	WHERE q.QuestionText = 'Last Name'
                ) t2 ON t2.ResponseId = r.Id
                LEFT JOIN (
                	SELECT rd.ResponseId, a.Answer AS DOB
                	FROM ResponseDetails rd
                	JOIN Answers a ON a.Id = rd.AnswerId 
                	JOIN Questions q ON q.Id = a.QuestionId 
                	WHERE q.QuestionText = 'DOB'
                ) t3 ON t3.ResponseId = r.Id
                LEFT JOIN (
                	SELECT rd.ResponseId, a.Answer AS Gender
                	FROM ResponseDetails rd
                	JOIN Answers a ON a.Id = rd.AnswerId 
                	JOIN Questions q ON q.Id = a.QuestionId 
                	WHERE q.QuestionText = 'Gender'
                ) t4 ON t4.ResponseId = r.Id
                LEFT JOIN (
                	SELECT rd.ResponseId, a.Answer AS Lang, rd.ExtraAnswer
                	FROM ResponseDetails rd
                	JOIN Answers a ON a.Id = rd.AnswerId 
                	JOIN Questions q ON q.Id = a.QuestionId 
                	WHERE q.QuestionText = 'What language do you prefer to speak?'
                ) t5 ON t5.ResponseId = r.Id
                LEFT JOIN (
                	SELECT
                		rd.ResponseId,
                		count(CASE WHEN a.Answer = 'Asthma' THEN 1 ELSE NULL END) AS HasAsthma,
                		count(CASE WHEN a.Answer = 'COPD' THEN 1 ELSE NULL END) AS HasCOPD,
                		count(CASE WHEN a.Answer = 'Diabetes or high blood sugar' THEN 1 ELSE NULL END) AS HasDiabetes,
                		count(CASE WHEN a.Answer = 'Kidney diease or kidney failure' THEN 1 ELSE NULL END) AS HasKidney
                	FROM ResponseDetails rd
                	JOIN Answers a ON a.Id = rd.AnswerId 
                	JOIN Questions q ON q.Id = a.QuestionId 
                	WHERE q.QuestionText = 'What health condition do you currently have?'
                	GROUP BY rd.ResponseId
                ) t6 ON t6.ResponseId = r.Id
                """
            );
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
