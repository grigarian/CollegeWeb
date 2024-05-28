using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTableGroupToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Groups",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Course", "Name", "SpecializationId" },
                values: new object[] { 1, 3, "ИС", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecializationId",
                table: "Groups",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specializations_SpecializationId",
                table: "Groups",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specializations_SpecializationId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecializationId",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "SpecializationId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
