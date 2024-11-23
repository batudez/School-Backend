using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("78ccbf57-51e2-41e4-beae-3687a88562e5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f5e55a2-c69c-4eb6-a0b8-d044c88ed9ab"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e8b58d0c-747e-406c-a1f8-bfccb3d46ccd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7e0c810c-5339-472a-8ef7-81c4ffc64dc1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 222, 22, 216, 65, 236, 59, 76, 79, 43, 149, 60, 89, 199, 142, 229, 167, 210, 180, 10, 20, 82, 134, 119, 163, 206, 12, 231, 124, 235, 250, 136, 84, 214, 121, 179, 210, 245, 113, 48, 218, 199, 152, 137, 18, 190, 230, 124, 136, 168, 171, 163, 243, 34, 242, 241, 250, 163, 241, 160, 1, 19, 79, 13, 152 }, new byte[] { 167, 252, 28, 197, 131, 1, 41, 206, 158, 142, 134, 89, 121, 252, 181, 202, 46, 188, 186, 198, 213, 102, 173, 41, 38, 88, 191, 136, 225, 64, 147, 241, 116, 63, 46, 229, 45, 199, 51, 96, 165, 240, 204, 11, 182, 41, 143, 230, 238, 46, 33, 27, 234, 59, 215, 92, 88, 235, 164, 102, 39, 134, 124, 83, 142, 101, 253, 240, 93, 8, 87, 237, 234, 175, 84, 63, 93, 197, 34, 100, 139, 137, 165, 235, 22, 223, 97, 235, 37, 233, 16, 77, 75, 71, 189, 167, 32, 18, 43, 167, 103, 113, 64, 104, 246, 14, 206, 126, 60, 73, 229, 214, 151, 221, 163, 160, 237, 57, 47, 144, 249, 149, 40, 29, 140, 14, 55, 202 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5f5e55a2-c69c-4eb6-a0b8-d044c88ed9ab"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 140, 53, 150, 108, 90, 202, 136, 140, 155, 84, 17, 71, 8, 111, 208, 160, 233, 130, 113, 236, 227, 226, 238, 186, 40, 134, 192, 80, 96, 83, 201, 237, 185, 105, 2, 57, 127, 217, 89, 234, 244, 148, 131, 215, 149, 137, 245, 91, 58, 163, 248, 158, 169, 238, 66, 87, 83, 221, 187, 237, 103, 221, 186, 36 }, new byte[] { 216, 26, 243, 54, 248, 223, 248, 176, 151, 34, 223, 36, 223, 141, 130, 161, 47, 59, 56, 184, 243, 32, 242, 89, 206, 132, 251, 213, 45, 47, 74, 91, 239, 223, 22, 50, 40, 232, 108, 182, 110, 211, 135, 108, 182, 254, 6, 66, 164, 207, 191, 169, 23, 189, 35, 125, 220, 75, 248, 17, 28, 190, 148, 252, 217, 169, 97, 54, 195, 141, 155, 247, 195, 65, 25, 252, 153, 87, 54, 146, 98, 46, 171, 255, 252, 125, 179, 101, 51, 184, 127, 106, 107, 160, 155, 155, 2, 113, 201, 71, 152, 142, 175, 74, 143, 176, 124, 129, 6, 141, 177, 106, 21, 32, 115, 180, 252, 140, 96, 242, 166, 11, 122, 217, 137, 109, 185, 44 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("78ccbf57-51e2-41e4-beae-3687a88562e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5f5e55a2-c69c-4eb6-a0b8-d044c88ed9ab") });
        }
    }
}
