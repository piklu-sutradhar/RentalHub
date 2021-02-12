using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalHub.Migrations
{
    public partial class UpdateProfileTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Adresses_AddressId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "568aff67-b4d3-420f-a1ae-c973288b486f", "b00f02ca-2845-4028-a84e-314424bdae3e" });

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Adresses_AddressId",
                table: "Profiles",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Adresses_AddressId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e3b91bc-d819-413d-a1f0-feb74e6c4a95", "96e69138-8796-48af-8ed0-f9a3de46c42d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Adresses_AddressId",
                table: "Profiles",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
