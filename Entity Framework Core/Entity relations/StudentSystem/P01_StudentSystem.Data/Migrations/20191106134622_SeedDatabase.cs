using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "HomeworkSubmissions",
                columns: new[] { "HomeworkId", "Content", "ContentType", "CourseId", "StudentId", "SubmissionTime" },
                values: new object[] { 2, null, 0, 2, 2, new DateTime(2019, 11, 6, 13, 46, 21, 484, DateTimeKind.Utc).AddTicks(8554) });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "CourseId", "Name", "ResourceType", "Url" },
                values: new object[] { 2, 2, "Wikipedia", 3, null });

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
                column: "RegisteredOn",
                value: new DateTime(2019, 11, 6, 13, 46, 21, 475, DateTimeKind.Utc).AddTicks(3755));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 12, 26, 13, 35, 28, 949, DateTimeKind.Utc).AddTicks(2133), new DateTime(2019, 11, 6, 13, 35, 28, 949, DateTimeKind.Utc).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2019, 12, 26, 13, 35, 28, 949, DateTimeKind.Utc).AddTicks(3722), new DateTime(2019, 11, 6, 13, 35, 28, 949, DateTimeKind.Utc).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 13, 35, 28, 963, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2019, 11, 6, 13, 35, 28, 954, DateTimeKind.Utc).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2019, 11, 6, 13, 35, 28, 954, DateTimeKind.Utc).AddTicks(6817));
        }
    }
}
