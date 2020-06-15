using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessDetailsEF.Migrations
{
    public partial class updatebusinesstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessDetails",
                columns: table => new
                {
                    Business_Id = table.Column<int>(nullable: false),
                    BusinessToken = table.Column<string>(nullable: false),
                    Business_Name = table.Column<string>(nullable: false),
                    Business_Type = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Contact_Number = table.Column<string>(maxLength: 12, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDetails_1", x => x.Business_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessDetails");
        }
    }
}
