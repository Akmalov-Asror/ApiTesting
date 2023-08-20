using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace postgress.Migrations
{
    /// <inheritdoc />
    public partial class inni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_DescriptionCourses_DescriptionCourseId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DescriptionCourseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DescriptionCourseId",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DescriptionCourseId",
                table: "Courses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DescriptionCourseId",
                table: "Courses",
                column: "DescriptionCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_DescriptionCourses_DescriptionCourseId",
                table: "Courses",
                column: "DescriptionCourseId",
                principalTable: "DescriptionCourses",
                principalColumn: "Id");
        }
    }
}
