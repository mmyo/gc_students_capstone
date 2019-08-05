using Microsoft.EntityFrameworkCore.Migrations;

namespace grand_circus.Migrations
{
    public partial class ChangeGradeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "UserCourses",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
