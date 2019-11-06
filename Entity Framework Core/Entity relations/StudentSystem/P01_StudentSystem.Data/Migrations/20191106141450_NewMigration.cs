using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2010, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 6, 14, 14, 50, 189, DateTimeKind.Utc).AddTicks(84) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 6, 14, 14, 50, 189, DateTimeKind.Utc).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 14, 14, 50, 204, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 14, 14, 50, 204, DateTimeKind.Utc).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2019, 11, 6, 14, 14, 50, 194, DateTimeKind.Utc).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1956), new DateTime(2019, 11, 6, 14, 14, 50, 194, DateTimeKind.Utc).AddTicks(5333) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 12, 26, 13, 46, 21, 469, DateTimeKind.Utc).AddTicks(9246), new DateTime(2019, 11, 6, 13, 46, 21, 469, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 12, 26, 13, 46, 21, 470, DateTimeKind.Utc).AddTicks(815), new DateTime(2019, 11, 6, 13, 46, 21, 470, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 13, 46, 21, 484, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 13, 46, 21, 484, DateTimeKind.Utc).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2019, 11, 6, 13, 46, 21, 475, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1966), new DateTime(2019, 11, 6, 13, 46, 21, 475, DateTimeKind.Utc).AddTicks(3755) });
        }
    }
}
