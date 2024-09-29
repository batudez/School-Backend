using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_test_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f28e8d26-e172-4f23-b140-502c4d24ed53"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("dcb49f13-c945-4632-92ce-7cf397bedd19") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("35c11572-dc5c-4387-a3a2-dd61e23d859f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 28, 129, 84, 183, 151, 33, 189, 154, 255, 102, 54, 85, 172, 240, 31, 148, 104, 253, 65, 14, 208, 206, 212, 218, 226, 102, 8, 153, 33, 95, 195, 163, 213, 221, 91, 112, 38, 150, 101, 88, 10, 190, 207, 151, 152, 46, 231, 7, 104, 197, 0, 72, 91, 140, 162, 156, 128, 196, 25, 112, 13, 73, 211, 135 }, new byte[] { 65, 88, 243, 33, 209, 26, 72, 10, 9, 45, 154, 57, 243, 18, 10, 68, 55, 74, 228, 224, 189, 179, 53, 206, 54, 73, 71, 4, 37, 43, 60, 223, 118, 51, 87, 92, 131, 177, 133, 208, 117, 219, 188, 56, 145, 116, 86, 96, 72, 105, 62, 220, 46, 120, 36, 232, 31, 110, 43, 194, 199, 136, 115, 199, 90, 49, 207, 167, 63, 180, 146, 238, 180, 126, 219, 206, 224, 248, 152, 22, 186, 195, 2, 5, 247, 183, 112, 197, 250, 66, 62, 46, 161, 194, 52, 214, 57, 224, 105, 129, 204, 16, 121, 140, 160, 70, 136, 38, 149, 187, 224, 168, 156, 86, 207, 106, 76, 48, 194, 18, 182, 51, 148, 114, 26, 172, 246, 71 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("d3c990c0-b06e-42de-90d2-35cd6cb005e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("dcb49f13-c945-4632-92ce-7cf397bedd19") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9507d5c5-8505-4d24-b13b-47a830bc570e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 122, 227, 92, 244, 191, 199, 109, 50, 36, 53, 100, 203, 207, 51, 203, 121, 13, 75, 20, 90, 4, 48, 129, 158, 55, 66, 168, 242, 203, 234, 134, 160, 28, 192, 4, 219, 247, 5, 7, 199, 159, 42, 67, 81, 162, 109, 177, 216, 51, 100, 44, 223, 153, 30, 83, 241, 84, 178, 211, 170, 14, 148, 177, 89 }, new byte[] { 40, 61, 78, 156, 70, 154, 66, 91, 191, 67, 121, 99, 53, 38, 146, 8, 150, 3, 204, 123, 181, 30, 112, 59, 206, 88, 201, 84, 1, 232, 148, 183, 129, 17, 134, 121, 254, 92, 170, 206, 238, 65, 22, 254, 12, 156, 109, 126, 69, 61, 10, 29, 211, 192, 23, 109, 250, 39, 85, 48, 124, 35, 158, 24, 114, 187, 139, 177, 101, 251, 203, 137, 126, 3, 205, 83, 225, 9, 222, 141, 167, 189, 15, 151, 110, 187, 204, 168, 32, 231, 253, 93, 40, 0, 206, 152, 80, 153, 96, 13, 188, 219, 130, 135, 202, 229, 80, 110, 216, 135, 33, 39, 255, 37, 127, 80, 95, 227, 5, 10, 216, 34, 227, 186, 45, 214, 182, 247 }, null });
        }
    }
}
