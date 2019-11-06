using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Data.Migrations
{
    public partial class SeedersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "Price", "StartDate" },
                values: new object[] { 250.40m, new DateTime(2019, 11, 6, 17, 22, 48, 530, DateTimeKind.Utc).AddTicks(3289) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2009, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 17, 22, 48, 545, DateTimeKind.Utc).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2019, 11, 6, 17, 22, 48, 545, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Youtube", 0 });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2,
                column: "ResourceType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1968), new DateTime(2019, 11, 6, 17, 22, 48, 535, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "Name", "RegisteredOn" },
                values: new object[] { "Dimitar", new DateTime(2019, 11, 6, 17, 22, 48, 536, DateTimeKind.Utc).AddTicks(181) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "Price", "StartDate" },
                values: new object[] { 200m, new DateTime(2019, 11, 6, 14, 14, 50, 189, DateTimeKind.Utc).AddTicks(84) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2019, 11, 6, 14, 14, 50, 189, DateTimeKind.Utc).AddTicks(2866));

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
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1,
                columns: new[] { "Name", "ResourceType" },
                values: new object[] { "Wikipedia", 3 });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2,
                column: "ResourceType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1966), new DateTime(2019, 11, 6, 14, 14, 50, 194, DateTimeKind.Utc).AddTicks(3957) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "Name", "RegisteredOn" },
                values: new object[] { "Pesho", new DateTime(2019, 11, 6, 14, 14, 50, 194, DateTimeKind.Utc).AddTicks(5333) });
        }
    }
}
