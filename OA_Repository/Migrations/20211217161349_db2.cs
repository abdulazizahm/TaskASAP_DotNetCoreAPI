using Microsoft.EntityFrameworkCore.Migrations;

namespace OA_Repository.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_PersonID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Person_Id",
                table: "Address",
                column: "Person_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_Person_Id",
                table: "Address",
                column: "Person_Id",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_Person_Id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_Person_Id",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonID",
                table: "Address",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
