using Microsoft.EntityFrameworkCore.Migrations;

namespace grand_circus.Migrations
{
    public partial class ChangeGradeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "UserCourses",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
