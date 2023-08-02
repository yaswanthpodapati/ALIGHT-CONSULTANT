using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllRightConsultant.Migrations
{
    /// <inheritdoc />
    public partial class AnyUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LaborCess",
                table: "ProjectWorks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborCess",
                table: "ProjectWorks");
        }
    }
}
