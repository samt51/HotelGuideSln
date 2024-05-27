using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AuthorizedName", "AuthorizedSurName", "CompanyName", "CreatedDate", "IsDeleted", "ModifyDate" },
                values: new object[] { new Guid("b9f3de51-b8ca-4427-adee-6fd3548d61af"), "Samet", "Bağlan", "Worigo", new DateTime(2024, 5, 27, 13, 59, 38, 494, DateTimeKind.Local).AddTicks(3086), false, null });

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "CityId", "CountyId", "CreatedDate", "Description", "DistrictId", "IsDeleted", "ModifyDate" },
                values: new object[] { new Guid("5c6686c0-cd05-47f1-890f-c8b675ef5219"), new Guid("c8570c8a-03c2-4f48-96dd-8bc43b917143"), new Guid("b3fca7a2-7fb8-4071-a89e-19b064612564"), new DateTime(2024, 5, 27, 13, 59, 38, 494, DateTimeKind.Local).AddTicks(4061), "dsadsa", new Guid("3718bf9a-bd1a-4544-8cd9-eacdab3910ec"), false, null });

            migrationBuilder.InsertData(
                table: "ContactInformation",
                columns: new[] { "Id", "CreatedDate", "HotelId", "InformationContentValue", "InformationType", "IsDeleted", "ModifyDate" },
                values: new object[,]
                {
                    { new Guid("8e091fa3-3ced-4d50-b89d-b890e0a2deb4"), new DateTime(2024, 5, 27, 13, 59, 38, 494, DateTimeKind.Local).AddTicks(1272), new Guid("b9f3de51-b8ca-4427-adee-6fd3548d61af"), "5c6686c0-cd05-47f1-890f-c8b675ef5219", 3, false, null },
                    { new Guid("bdbcaa6a-ed99-4373-ad40-0d3d08c4a712"), new DateTime(2024, 5, 27, 13, 59, 38, 494, DateTimeKind.Local).AddTicks(1271), new Guid("b9f3de51-b8ca-4427-adee-6fd3548d61af"), "samt51.m@icloud.com", 2, false, null },
                    { new Guid("e66f288b-6044-4def-a62a-384bb3706be3"), new DateTime(2024, 5, 27, 13, 59, 38, 494, DateTimeKind.Local).AddTicks(1253), new Guid("b9f3de51-b8ca-4427-adee-6fd3548d61af"), "05363956979", 1, false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactInformation",
                keyColumn: "Id",
                keyValue: new Guid("8e091fa3-3ced-4d50-b89d-b890e0a2deb4"));

            migrationBuilder.DeleteData(
                table: "ContactInformation",
                keyColumn: "Id",
                keyValue: new Guid("bdbcaa6a-ed99-4373-ad40-0d3d08c4a712"));

            migrationBuilder.DeleteData(
                table: "ContactInformation",
                keyColumn: "Id",
                keyValue: new Guid("e66f288b-6044-4def-a62a-384bb3706be3"));

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "Id",
                keyValue: new Guid("5c6686c0-cd05-47f1-890f-c8b675ef5219"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b9f3de51-b8ca-4427-adee-6fd3548d61af"));
        }
    }
}
