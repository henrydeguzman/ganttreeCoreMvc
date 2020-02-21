using Microsoft.EntityFrameworkCore.Migrations;

namespace ganttreeCoreMvc.Migrations
{
    public partial class addedLastjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "last_job_no",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_job_no",
                table: "AspNetUsers");
        }
    }
}
