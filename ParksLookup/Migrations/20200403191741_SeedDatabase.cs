using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksLookup.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Location", "Management", "Name" },
                values: new object[,]
                {
                    { 1, "Baker, NV", "National", "Great Basin National Park" },
                    { 2, "Las Vegas, NV", "National", "Tule Springs Fossil Beds National Monument" },
                    { 3, "Incline Village, NV", "State", "Sand Harbor" },
                    { 4, "South Lake Tahoe, CA", "State", "Van Sickle" }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "DetailId", "Address", "Description", "ParkId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "5500 W Hwy 488, Baker, NV 89311", "Ancient bristlecone pines", 1, 5, null },
                    { 2, "16001 Corn Creek Rd, Las Vegas, NV 89166", "Established as the 405th unit of the National Park Service.", 2, 2, null },
                    { 3, "2005 NV-28, Incline Village, NV 89452", "The largest alpine lake in North America.", 3, 5, null },
                    { 4, "30 Lake Pkwy, South Lake Tahoe, CA 96150", "One the most accessible parks in the Tahoe Basin.", 4, 3, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "DetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "DetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "DetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "DetailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);
        }
    }
}
