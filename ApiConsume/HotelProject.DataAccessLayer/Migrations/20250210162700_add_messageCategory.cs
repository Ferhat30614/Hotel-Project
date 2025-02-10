using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class add_messageCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageCategoryID",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MessageCategoryID1",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MessageCategories",
                columns: table => new
                {
                    MessageCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCategories", x => x.MessageCategoryID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID1",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "MessageCategories");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MessageCategoryID1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MessageCategoryID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MessageCategoryID1",
                table: "Contacts");
        }
    }
}
