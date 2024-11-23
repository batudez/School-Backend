using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e8b58d0c-747e-406c-a1f8-bfccb3d46ccd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e0c810c-5339-472a-8ef7-81c4ffc64dc1"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8a4e353b-d0c4-4e9c-a5f9-068050332213"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9790da2e-d22d-4977-9971-5a9e0877e618"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 195, 201, 85, 250, 77, 169, 32, 244, 115, 198, 191, 30, 145, 99, 84, 76, 140, 49, 129, 26, 151, 147, 98, 67, 188, 167, 41, 118, 76, 183, 110, 230, 95, 134, 247, 232, 85, 38, 128, 18, 5, 169, 148, 98, 111, 140, 146, 163, 173, 219, 117, 252, 190, 66, 145, 119, 239, 193, 55, 146, 11, 148, 228, 120 }, new byte[] { 249, 65, 155, 202, 244, 108, 11, 66, 108, 142, 67, 126, 125, 158, 177, 101, 176, 48, 69, 200, 175, 74, 56, 204, 239, 233, 18, 178, 13, 28, 226, 223, 198, 203, 154, 162, 192, 191, 55, 78, 180, 184, 192, 91, 95, 243, 177, 5, 213, 73, 29, 241, 174, 212, 136, 34, 205, 184, 43, 111, 202, 164, 237, 14, 205, 139, 215, 85, 246, 145, 231, 104, 58, 200, 119, 186, 112, 232, 17, 97, 117, 197, 198, 205, 77, 68, 253, 169, 84, 220, 17, 219, 169, 118, 196, 20, 63, 213, 252, 242, 61, 200, 201, 205, 150, 254, 172, 223, 73, 128, 119, 100, 173, 207, 186, 0, 78, 141, 189, 213, 225, 234, 7, 182, 189, 73, 107, 36 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8a4e353b-d0c4-4e9c-a5f9-068050332213"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9790da2e-d22d-4977-9971-5a9e0877e618"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e8b58d0c-747e-406c-a1f8-bfccb3d46ccd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7e0c810c-5339-472a-8ef7-81c4ffc64dc1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 222, 22, 216, 65, 236, 59, 76, 79, 43, 149, 60, 89, 199, 142, 229, 167, 210, 180, 10, 20, 82, 134, 119, 163, 206, 12, 231, 124, 235, 250, 136, 84, 214, 121, 179, 210, 245, 113, 48, 218, 199, 152, 137, 18, 190, 230, 124, 136, 168, 171, 163, 243, 34, 242, 241, 250, 163, 241, 160, 1, 19, 79, 13, 152 }, new byte[] { 167, 252, 28, 197, 131, 1, 41, 206, 158, 142, 134, 89, 121, 252, 181, 202, 46, 188, 186, 198, 213, 102, 173, 41, 38, 88, 191, 136, 225, 64, 147, 241, 116, 63, 46, 229, 45, 199, 51, 96, 165, 240, 204, 11, 182, 41, 143, 230, 238, 46, 33, 27, 234, 59, 215, 92, 88, 235, 164, 102, 39, 134, 124, 83, 142, 101, 253, 240, 93, 8, 87, 237, 234, 175, 84, 63, 93, 197, 34, 100, 139, 137, 165, 235, 22, 223, 97, 235, 37, 233, 16, 77, 75, 71, 189, 167, 32, 18, 43, 167, 103, 113, 64, 104, 246, 14, 206, 126, 60, 73, 229, 214, 151, 221, 163, 160, 237, 57, 47, 144, 249, 149, 40, 29, 140, 14, 55, 202 }, null });
        }
    }
}
