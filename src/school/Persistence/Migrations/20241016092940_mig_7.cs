using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Students.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("fdc16148-ef51-43bf-be2a-cd887268a643"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("80eea823-df3a-4768-b8ea-8350608b1824"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 87, 58, 21, 173, 134, 4, 83, 103, 108, 182, 144, 213, 152, 252, 97, 248, 242, 128, 69, 159, 152, 140, 235, 229, 6, 182, 20, 26, 216, 216, 29, 134, 79, 139, 154, 53, 171, 19, 106, 38, 106, 89, 73, 183, 33, 207, 153, 206, 169, 40, 84, 145, 252, 20, 39, 42, 92, 228, 13, 19, 95, 70, 154, 213 }, new byte[] { 170, 135, 244, 157, 39, 163, 23, 211, 202, 151, 235, 12, 112, 174, 84, 144, 122, 30, 18, 186, 14, 251, 96, 21, 59, 161, 209, 223, 166, 102, 131, 234, 146, 70, 83, 168, 210, 70, 68, 234, 212, 251, 219, 106, 141, 64, 211, 73, 191, 171, 29, 180, 47, 246, 251, 19, 135, 166, 151, 46, 108, 43, 35, 84, 171, 116, 209, 53, 231, 121, 165, 142, 133, 132, 142, 149, 97, 104, 242, 65, 61, 214, 120, 185, 149, 165, 115, 124, 130, 190, 58, 143, 90, 3, 3, 103, 96, 142, 230, 172, 255, 163, 29, 232, 99, 205, 233, 133, 192, 231, 197, 144, 50, 82, 79, 182, 233, 53, 209, 11, 99, 91, 97, 205, 210, 136, 196, 125 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("fdc16148-ef51-43bf-be2a-cd887268a643"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80eea823-df3a-4768-b8ea-8350608b1824"));

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
    }
}
