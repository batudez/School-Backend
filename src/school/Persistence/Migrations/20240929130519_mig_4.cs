using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8a4e353b-d0c4-4e9c-a5f9-068050332213"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9790da2e-d22d-4977-9971-5a9e0877e618"));

            migrationBuilder.CreateTable(
                name: "StudentOperationClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOperationClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentOperationClaim_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOperationClaim_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("22373cb3-a466-4c25-85f0-521a64bbc3da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6ab83670-d677-400c-8f8c-4c515588e2ac"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 66, 217, 46, 106, 193, 244, 105, 123, 131, 100, 185, 220, 206, 144, 113, 174, 203, 177, 120, 79, 69, 213, 30, 132, 45, 198, 232, 79, 108, 135, 218, 73, 174, 92, 118, 154, 32, 116, 222, 249, 243, 195, 197, 161, 158, 175, 2, 201, 254, 188, 210, 33, 238, 138, 45, 20, 44, 240, 106, 129, 31, 114, 8, 169 }, new byte[] { 15, 113, 97, 157, 193, 112, 255, 164, 224, 113, 118, 197, 72, 156, 243, 44, 38, 9, 59, 7, 150, 150, 98, 99, 14, 216, 115, 36, 219, 172, 12, 232, 246, 81, 129, 2, 109, 225, 5, 126, 170, 118, 155, 69, 128, 171, 118, 120, 196, 100, 107, 35, 22, 82, 52, 197, 201, 37, 35, 199, 90, 255, 45, 221, 2, 119, 143, 105, 72, 22, 92, 23, 205, 79, 11, 80, 245, 35, 55, 210, 56, 196, 224, 156, 82, 212, 45, 163, 153, 128, 184, 78, 144, 209, 34, 228, 208, 38, 19, 153, 106, 26, 161, 111, 34, 7, 137, 222, 107, 194, 3, 166, 49, 185, 185, 19, 128, 178, 110, 7, 87, 137, 224, 101, 30, 211, 253, 176 }, null });

            migrationBuilder.CreateIndex(
                name: "IX_StudentOperationClaim_OperationClaimId",
                table: "StudentOperationClaim",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOperationClaim_StudentId",
                table: "StudentOperationClaim",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentOperationClaim");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("22373cb3-a466-4c25-85f0-521a64bbc3da"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ab83670-d677-400c-8f8c-4c515588e2ac"));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8a4e353b-d0c4-4e9c-a5f9-068050332213"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6a90dd73-a134-476f-b072-5ba502c1e7dd") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9790da2e-d22d-4977-9971-5a9e0877e618"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 195, 201, 85, 250, 77, 169, 32, 244, 115, 198, 191, 30, 145, 99, 84, 76, 140, 49, 129, 26, 151, 147, 98, 67, 188, 167, 41, 118, 76, 183, 110, 230, 95, 134, 247, 232, 85, 38, 128, 18, 5, 169, 148, 98, 111, 140, 146, 163, 173, 219, 117, 252, 190, 66, 145, 119, 239, 193, 55, 146, 11, 148, 228, 120 }, new byte[] { 249, 65, 155, 202, 244, 108, 11, 66, 108, 142, 67, 126, 125, 158, 177, 101, 176, 48, 69, 200, 175, 74, 56, 204, 239, 233, 18, 178, 13, 28, 226, 223, 198, 203, 154, 162, 192, 191, 55, 78, 180, 184, 192, 91, 95, 243, 177, 5, 213, 73, 29, 241, 174, 212, 136, 34, 205, 184, 43, 111, 202, 164, 237, 14, 205, 139, 215, 85, 246, 145, 231, 104, 58, 200, 119, 186, 112, 232, 17, 97, 117, 197, 198, 205, 77, 68, 253, 169, 84, 220, 17, 219, 169, 118, 196, 20, 63, 213, 252, 242, 61, 200, 201, 205, 150, 254, 172, 223, 73, 128, 119, 100, 173, 207, 186, 0, 78, 141, 189, 213, 225, 234, 7, 182, 189, 73, 107, 36 }, null });
        }
    }
}
