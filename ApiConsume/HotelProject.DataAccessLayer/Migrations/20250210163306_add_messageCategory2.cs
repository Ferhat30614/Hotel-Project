using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class add_messageCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MessageCategoryID1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MessageCategoryID1",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "MessageCategoryID",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MessageCategoryID",
                table: "Contacts",
                column: "MessageCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID",
                table: "Contacts",
                column: "MessageCategoryID",
                principalTable: "MessageCategories",
                principalColumn: "MessageCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MessageCategoryID",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "MessageCategoryID",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MessageCategoryID1",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MessageCategoryID1",
                table: "Contacts",
                column: "MessageCategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID1",
                table: "Contacts",
                column: "MessageCategoryID1",
                principalTable: "MessageCategories",
                principalColumn: "MessageCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
