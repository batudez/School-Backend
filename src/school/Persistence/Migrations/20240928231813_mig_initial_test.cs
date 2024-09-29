using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_initial_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f28e8d26-e172-4f23-b140-502c4d24ed53"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c11572-dc5c-4387-a3a2-dd61e23d859f"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("07e20041-0d0a-4929-8b97-54edcfa618ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("faeac8f0-3125-4f44-a860-b8c6887235af") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("31e439fc-c268-4b9a-8b6a-1bda7dcd539a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 59, 231, 103, 170, 55, 37, 176, 96, 44, 220, 201, 134, 214, 63, 251, 154, 188, 76, 125, 179, 208, 193, 159, 217, 18, 59, 78, 255, 196, 230, 81, 172, 177, 91, 142, 117, 24, 10, 215, 219, 15, 235, 83, 119, 213, 167, 103, 202, 45, 88, 52, 10, 148, 132, 16, 134, 171, 5, 1, 225, 34, 181, 93, 27 }, new byte[] { 108, 68, 9, 147, 130, 230, 61, 231, 224, 108, 202, 251, 110, 34, 206, 206, 247, 156, 63, 8, 13, 126, 140, 82, 112, 91, 236, 63, 140, 241, 156, 222, 35, 195, 126, 190, 204, 180, 239, 20, 45, 168, 210, 201, 48, 112, 186, 127, 28, 131, 250, 75, 189, 126, 60, 42, 29, 12, 226, 82, 244, 22, 156, 98, 1, 36, 236, 100, 179, 73, 241, 204, 197, 8, 193, 172, 44, 63, 60, 2, 247, 147, 49, 72, 177, 181, 18, 67, 161, 122, 132, 73, 245, 179, 187, 70, 48, 211, 11, 238, 109, 109, 131, 113, 51, 84, 102, 16, 4, 148, 124, 206, 69, 185, 216, 9, 252, 63, 0, 211, 217, 202, 207, 167, 145, 222, 71, 129 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("07e20041-0d0a-4929-8b97-54edcfa618ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("31e439fc-c268-4b9a-8b6a-1bda7dcd539a"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f28e8d26-e172-4f23-b140-502c4d24ed53"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("dcb49f13-c945-4632-92ce-7cf397bedd19") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("35c11572-dc5c-4387-a3a2-dd61e23d859f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 28, 129, 84, 183, 151, 33, 189, 154, 255, 102, 54, 85, 172, 240, 31, 148, 104, 253, 65, 14, 208, 206, 212, 218, 226, 102, 8, 153, 33, 95, 195, 163, 213, 221, 91, 112, 38, 150, 101, 88, 10, 190, 207, 151, 152, 46, 231, 7, 104, 197, 0, 72, 91, 140, 162, 156, 128, 196, 25, 112, 13, 73, 211, 135 }, new byte[] { 65, 88, 243, 33, 209, 26, 72, 10, 9, 45, 154, 57, 243, 18, 10, 68, 55, 74, 228, 224, 189, 179, 53, 206, 54, 73, 71, 4, 37, 43, 60, 223, 118, 51, 87, 92, 131, 177, 133, 208, 117, 219, 188, 56, 145, 116, 86, 96, 72, 105, 62, 220, 46, 120, 36, 232, 31, 110, 43, 194, 199, 136, 115, 199, 90, 49, 207, 167, 63, 180, 146, 238, 180, 126, 219, 206, 224, 248, 152, 22, 186, 195, 2, 5, 247, 183, 112, 197, 250, 66, 62, 46, 161, 194, 52, 214, 57, 224, 105, 129, 204, 16, 121, 140, 160, 70, 136, 38, 149, 187, 224, 168, 156, 86, 207, 106, 76, 48, 194, 18, 182, 51, 148, 114, 26, 172, 246, 71 }, null });
        }
    }
}
