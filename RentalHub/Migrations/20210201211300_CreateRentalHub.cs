using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalHub.Migrations
{
    public partial class CreateRentalHub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Rentees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentees_Adresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renters_Adresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenteeId = table.Column<int>(type: "int", nullable: true),
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BedRooms = table.Column<int>(type: "int", nullable: false),
                    Baths = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Adresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Rentees_RenteeId",
                        column: x => x.RenteeId,
                        principalTable: "Rentees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "PostalCode", "Province" },
                values: new object[] { 1, "William", "Shakespeare", "Test City", "Test country", "Test code", "Test Pro" });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "PostalCode", "Province" },
                values: new object[] { 2, "William", "Shakespeare", "Test City", "Test country", "Test code", "Test Pro" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, "Piklu@yahoo.com", "Piklu", "Sutradhar", "1234", "test" });

            migrationBuilder.InsertData(
                table: "Rentees",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "p@test.com", "piklu", "Hamlet", null, null },
                    { 3, 1, "p@test.com", "Mou", "Hamlet", null, null },
                    { 2, 2, "p@test.com", "Rubel", "Hamlet", null, null }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber", "UserName" },
                values: new object[] { 1, 1, null, "Adam", "John", null, null });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AddressId", "Available", "Baths", "BedRooms", "RenteeId", "RenterId", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, false, 1, 2, 1, 1, "Rancho Property", 0 },
                    { 3, 1, true, 1, 1, null, 1, "Globe Property", 0 },
                    { 4, 1, true, 3, 5, null, 1, "Private Property", 3 },
                    { 5, 1, true, 1, 2, null, 1, "Public Property", 0 },
                    { 6, 1, true, 2, 4, null, 1, "Rancho Property", 2 },
                    { 7, 1, true, 1, 2, null, 1, "Rancho Property", 0 },
                    { 2, 2, false, 2, 3, 2, 1, "Succex Property", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RenteeId",
                table: "Properties",
                column: "RenteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RenterId",
                table: "Properties",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentees_AddressId",
                table: "Rentees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_AddressId",
                table: "Renters",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Rentees");

            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
