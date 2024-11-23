using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("07a01bb4-badd-49b2-a00e-dedaaa1ad0fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c7fdf089-7047-4ba2-82dd-be5fde18fcc8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 27, 107, 152, 49, 177, 103, 72, 61, 195, 36, 115, 188, 142, 177, 38, 189, 142, 145, 78, 88, 230, 117, 75, 186, 205, 56, 224, 245, 97, 187, 107, 220, 205, 253, 107, 165, 88, 19, 149, 221, 30, 113, 224, 153, 18, 33, 60, 46, 182, 60, 131, 118, 63, 145, 234, 194, 165, 13, 214, 16, 240, 34, 55, 91 }, new byte[] { 96, 99, 211, 203, 152, 54, 196, 118, 95, 134, 124, 240, 0, 150, 200, 84, 194, 61, 78, 142, 220, 221, 93, 230, 14, 234, 34, 33, 72, 51, 203, 175, 203, 131, 243, 128, 249, 209, 235, 18, 177, 176, 125, 50, 182, 253, 161, 208, 147, 16, 47, 32, 22, 109, 12, 117, 176, 27, 5, 172, 37, 120, 0, 102, 210, 111, 30, 186, 127, 224, 201, 115, 238, 55, 111, 207, 171, 79, 107, 57, 139, 152, 32, 188, 54, 241, 198, 125, 27, 253, 43, 12, 189, 50, 177, 252, 1, 170, 90, 20, 187, 213, 46, 168, 11, 63, 225, 199, 88, 106, 112, 130, 57, 185, 188, 65, 116, 93, 214, 179, 27, 151, 124, 208, 186, 62, 70, 1 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("07a01bb4-badd-49b2-a00e-dedaaa1ad0fc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7fdf089-7047-4ba2-82dd-be5fde18fcc8"));

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
    }
}
