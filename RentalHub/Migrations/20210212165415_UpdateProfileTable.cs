using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalHub.Migrations
{
    public partial class UpdateProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Adresses_AdressId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AdressId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e3b91bc-d819-413d-a1f0-feb74e6c4a95", "96e69138-8796-48af-8ed0-f9a3de46c42d" });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Adresses_AddressId",
                table: "Profiles",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Adresses_AddressId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b52cf716-e1a4-4392-bfae-9dce1aa8ae76", "ffab7035-dcfa-4671-866f-5381306f47b7" });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AdressId",
                table: "Profiles",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Adresses_AdressId",
                table: "Profiles",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
