using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("22373cb3-a466-4c25-85f0-521a64bbc3da"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ab83670-d677-400c-8f8c-4c515588e2ac"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("50cc902b-fe11-4b93-8d5a-56a6701db28e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c231139b-34a9-4df5-ac25-564437e1f76d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 254, 240, 192, 30, 132, 156, 157, 120, 252, 148, 190, 130, 84, 56, 212, 23, 146, 194, 190, 250, 125, 43, 123, 191, 155, 110, 76, 134, 128, 9, 130, 96, 0, 10, 67, 17, 244, 24, 248, 195, 198, 142, 133, 175, 43, 239, 149, 236, 203, 137, 187, 56, 69, 252, 95, 208, 61, 24, 70, 118, 140, 101, 102, 95 }, new byte[] { 124, 173, 37, 119, 167, 101, 82, 250, 35, 123, 25, 35, 67, 131, 149, 230, 85, 2, 203, 23, 162, 242, 220, 184, 3, 23, 57, 166, 185, 238, 14, 215, 177, 182, 248, 58, 60, 169, 58, 154, 9, 164, 125, 67, 115, 211, 203, 163, 110, 244, 36, 41, 160, 64, 110, 102, 96, 255, 122, 224, 248, 212, 254, 72, 65, 100, 61, 254, 104, 102, 106, 111, 44, 135, 236, 143, 219, 47, 205, 22, 1, 57, 163, 8, 241, 59, 20, 144, 179, 219, 95, 223, 58, 179, 227, 147, 179, 55, 125, 39, 248, 245, 0, 75, 157, 32, 165, 111, 79, 24, 254, 132, 199, 163, 4, 205, 246, 19, 163, 6, 196, 69, 38, 43, 125, 219, 174, 194 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("50cc902b-fe11-4b93-8d5a-56a6701db28e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c231139b-34a9-4df5-ac25-564437e1f76d"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("22373cb3-a466-4c25-85f0-521a64bbc3da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6ab83670-d677-400c-8f8c-4c515588e2ac"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 66, 217, 46, 106, 193, 244, 105, 123, 131, 100, 185, 220, 206, 144, 113, 174, 203, 177, 120, 79, 69, 213, 30, 132, 45, 198, 232, 79, 108, 135, 218, 73, 174, 92, 118, 154, 32, 116, 222, 249, 243, 195, 197, 161, 158, 175, 2, 201, 254, 188, 210, 33, 238, 138, 45, 20, 44, 240, 106, 129, 31, 114, 8, 169 }, new byte[] { 15, 113, 97, 157, 193, 112, 255, 164, 224, 113, 118, 197, 72, 156, 243, 44, 38, 9, 59, 7, 150, 150, 98, 99, 14, 216, 115, 36, 219, 172, 12, 232, 246, 81, 129, 2, 109, 225, 5, 126, 170, 118, 155, 69, 128, 171, 118, 120, 196, 100, 107, 35, 22, 82, 52, 197, 201, 37, 35, 199, 90, 255, 45, 221, 2, 119, 143, 105, 72, 22, 92, 23, 205, 79, 11, 80, 245, 35, 55, 210, 56, 196, 224, 156, 82, 212, 45, 163, 153, 128, 184, 78, 144, 209, 34, 228, 208, 38, 19, 153, 106, 26, 161, 111, 34, 7, 137, 222, 107, 194, 3, 166, 49, 185, 185, 19, 128, 178, 110, 7, 87, 137, 224, 101, 30, 211, 253, 176 }, null });
        }
    }
}
