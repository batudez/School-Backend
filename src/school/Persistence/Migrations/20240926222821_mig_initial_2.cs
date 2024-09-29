using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_initial_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("141cd128-1ec6-4093-b352-1aabcbe143a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e260ab0-1743-4b24-9ce1-c65ae37dad29"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d3c990c0-b06e-42de-90d2-35cd6cb005e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("dcb49f13-c945-4632-92ce-7cf397bedd19") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9507d5c5-8505-4d24-b13b-47a830bc570e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 122, 227, 92, 244, 191, 199, 109, 50, 36, 53, 100, 203, 207, 51, 203, 121, 13, 75, 20, 90, 4, 48, 129, 158, 55, 66, 168, 242, 203, 234, 134, 160, 28, 192, 4, 219, 247, 5, 7, 199, 159, 42, 67, 81, 162, 109, 177, 216, 51, 100, 44, 223, 153, 30, 83, 241, 84, 178, 211, 170, 14, 148, 177, 89 }, new byte[] { 40, 61, 78, 156, 70, 154, 66, 91, 191, 67, 121, 99, 53, 38, 146, 8, 150, 3, 204, 123, 181, 30, 112, 59, 206, 88, 201, 84, 1, 232, 148, 183, 129, 17, 134, 121, 254, 92, 170, 206, 238, 65, 22, 254, 12, 156, 109, 126, 69, 61, 10, 29, 211, 192, 23, 109, 250, 39, 85, 48, 124, 35, 158, 24, 114, 187, 139, 177, 101, 251, 203, 137, 126, 3, 205, 83, 225, 9, 222, 141, 167, 189, 15, 151, 110, 187, 204, 168, 32, 231, 253, 93, 40, 0, 206, 152, 80, 153, 96, 13, 188, 219, 130, 135, 202, 229, 80, 110, 216, 135, 33, 39, 255, 37, 127, 80, 95, 227, 5, 10, 216, 34, 227, 186, 45, 214, 182, 247 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d3c990c0-b06e-42de-90d2-35cd6cb005e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9507d5c5-8505-4d24-b13b-47a830bc570e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("1e260ab0-1743-4b24-9ce1-c65ae37dad29"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 9, 226, 58, 1, 243, 240, 28, 45, 85, 11, 68, 181, 95, 170, 71, 21, 89, 177, 236, 27, 126, 236, 142, 189, 102, 123, 157, 242, 111, 71, 119, 123, 45, 77, 38, 35, 104, 84, 165, 209, 241, 233, 97, 248, 56, 88, 22, 154, 102, 115, 195, 206, 88, 58, 91, 211, 140, 83, 221, 89, 145, 140, 57, 151 }, new byte[] { 55, 159, 126, 66, 60, 160, 205, 154, 104, 93, 195, 171, 172, 22, 149, 219, 80, 210, 198, 138, 96, 87, 217, 187, 149, 133, 119, 21, 103, 21, 61, 5, 126, 34, 42, 185, 110, 226, 182, 219, 159, 179, 140, 188, 248, 61, 69, 28, 91, 137, 194, 226, 170, 56, 235, 86, 152, 240, 226, 156, 52, 110, 132, 132, 38, 38, 237, 23, 119, 132, 101, 53, 188, 35, 174, 62, 91, 150, 161, 144, 235, 10, 147, 228, 123, 69, 141, 218, 147, 249, 134, 62, 11, 61, 218, 54, 79, 154, 254, 36, 237, 122, 17, 197, 245, 29, 95, 101, 179, 195, 97, 95, 228, 211, 185, 130, 8, 209, 69, 83, 238, 205, 77, 25, 139, 186, 230, 122 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("141cd128-1ec6-4093-b352-1aabcbe143a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1e260ab0-1743-4b24-9ce1-c65ae37dad29") });
        }
    }
}
