using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalHub.Migrations
{
    public partial class UpdatePropertyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Adresses_PropertyAddressId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropertyAddressId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: "8fb04a10-92c2-4633-9445-f02728a84906");

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: "b6d09d14-ddc9-4603-a804-3f724f182d10");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "24020ee8-7b8c-4dfe-b04c-7a7bebfbca41");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "30221311-646c-40ed-9124-44928e710134");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "524680d1-29e1-4f69-b9d6-bde17e19466a");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "7f091dfc-e17a-4360-9a63-d9dfe3c06370");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "981b8062-4c76-4a68-8763-32fc876adfa3");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "a6ead585-4c16-42c7-876d-cfd3c6d3e574");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "edbfafc2-f462-45ed-86e7-155339aace60");

            migrationBuilder.DropColumn(
                name: "PropertyAddressId",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "PostalCode", "Province" },
                values: new object[,]
                {
                    { "c4eb1b0b-1a20-425f-ba09-513bc99b137f", "William", "Shakespeare", "Test City", "Test country", "Test code", "Test Pro" },
                    { "74ce797c-8235-4386-864e-43066e33b34b", "William", "Shakespeare", "Test City", "Test country", "Test code", "Test Pro" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AddressId", "Available", "Baths", "BedRooms", "ProfileId", "RenterId", "Title", "Type" },
                values: new object[,]
                {
                    { "43d43624-f469-4c4e-8896-8a2259401e1a", null, false, 1, 2, null, null, "Rancho Property", 0 },
                    { "642577bf-49fb-494c-8795-f6dc40550b65", null, false, 2, 3, null, null, "Succex Property", 1 },
                    { "70f53669-7b0f-40f2-b00e-aa772ddddbca", null, true, 1, 1, null, null, "Globe Property", 0 },
                    { "470a560c-0512-43ab-8547-34b78522c6d2", null, true, 3, 5, null, null, "Private Property", 3 },
                    { "22f8a51f-8190-4dca-9a10-1b78605f09a9", null, true, 1, 2, null, null, "Public Property", 0 },
                    { "4f9466c8-a19e-43b0-b159-d59c6d414c66", null, true, 2, 4, null, null, "Rancho Property", 2 },
                    { "9b58b286-5f0d-4359-a7fc-6cbf44972e85", null, true, 1, 2, null, null, "Rancho Property", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Adresses_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Adresses_AddressId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AddressId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: "74ce797c-8235-4386-864e-43066e33b34b");

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: "c4eb1b0b-1a20-425f-ba09-513bc99b137f");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "22f8a51f-8190-4dca-9a10-1b78605f09a9");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "43d43624-f469-4c4e-8896-8a2259401e1a");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "470a560c-0512-43ab-8547-34b78522c6d2");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "4f9466c8-a19e-43b0-b159-d59c6d414c66");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "642577bf-49fb-494c-8795-f6dc40550b65");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "70f53669-7b0f-40f2-b00e-aa772ddddbca");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: "9b58b286-5f0d-4359-a7fc-6cbf44972e85");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddressId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "PostalCode", "Province" },
                values: new object[,]
                {
                    { "8fb04a10-92c2-4633-9445-f02728a84906", "William", "Shakespeare", "Test City", "Test country", "Test code", "Test Pro" },
                    { "b6d09d14-ddc9-4603-a804-3f724f182d10", "William", "Shakespeare", "Test City", "Test country", "Test code", "Test Pro" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AddressId", "Available", "Baths", "BedRooms", "ProfileId", "PropertyAddressId", "RenterId", "Title", "Type" },
                values: new object[,]
                {
                    { "a6ead585-4c16-42c7-876d-cfd3c6d3e574", 1, false, 1, 2, null, null, null, "Rancho Property", 0 },
                    { "30221311-646c-40ed-9124-44928e710134", 2, false, 2, 3, null, null, null, "Succex Property", 1 },
                    { "7f091dfc-e17a-4360-9a63-d9dfe3c06370", 1, true, 1, 1, null, null, null, "Globe Property", 0 },
                    { "981b8062-4c76-4a68-8763-32fc876adfa3", 1, true, 3, 5, null, null, null, "Private Property", 3 },
                    { "edbfafc2-f462-45ed-86e7-155339aace60", 1, true, 1, 2, null, null, null, "Public Property", 0 },
                    { "24020ee8-7b8c-4dfe-b04c-7a7bebfbca41", 1, true, 2, 4, null, null, null, "Rancho Property", 2 },
                    { "524680d1-29e1-4f69-b9d6-bde17e19466a", 1, true, 1, 2, null, null, null, "Rancho Property", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyAddressId",
                table: "Properties",
                column: "PropertyAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Adresses_PropertyAddressId",
                table: "Properties",
                column: "PropertyAddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
