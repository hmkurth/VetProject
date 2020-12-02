using Microsoft.EntityFrameworkCore.Migrations;

namespace KurthProject2Vet.Migrations
{
    public partial class changenull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetsServices_Pets_PetId",
                table: "PetsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PetsServices_Services_ServiceId",
                table: "PetsServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetsServices",
                table: "PetsServices");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "PetsServices",
                newName: "PetServices");

            migrationBuilder.RenameIndex(
                name: "IX_PetsServices_ServiceId",
                table: "PetServices",
                newName: "IX_PetServices_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetServices",
                table: "PetServices",
                columns: new[] { "PetId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetServices_Pets_PetId",
                table: "PetServices",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetServices_Services_ServiceId",
                table: "PetServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetServices_Pets_PetId",
                table: "PetServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PetServices_Services_ServiceId",
                table: "PetServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetServices",
                table: "PetServices");

            migrationBuilder.RenameTable(
                name: "PetServices",
                newName: "PetsServices");

            migrationBuilder.RenameIndex(
                name: "IX_PetServices_ServiceId",
                table: "PetsServices",
                newName: "IX_PetsServices_ServiceId");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Pets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetsServices",
                table: "PetsServices",
                columns: new[] { "PetId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetsServices_Pets_PetId",
                table: "PetsServices",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetsServices_Services_ServiceId",
                table: "PetsServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
