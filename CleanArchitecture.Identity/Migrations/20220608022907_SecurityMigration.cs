using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    public partial class SecurityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f64a5f6-2e77-41ab-a790-a73e6898a34b",
                column: "ConcurrencyStamp",
                value: "fd8fdb75-b807-42e2-88d0-50d0f8820bf0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc756a21-0731-4ebf-9e4f-a495d819410b",
                column: "ConcurrencyStamp",
                value: "f83e72d1-7363-424f-87c4-d8896d4023aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "048880ff-3248-48e9-8400-c27c814ee2c1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "063c518f-d35f-47d6-a985-b2f0fc1713f3", "AQAAAAEAACcQAAAAEByBea81It1zud96sB0I2f16CDm/NQUis9gul7ZY+mHCn9UQT5h93I2BKunpHI/9Rw==", "759d8b49-8473-4d3b-8518-8536d19e790f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30893af3-12ce-4a50-8dac-7bde58106aaf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd9fdc04-a4d3-44cf-ab5c-ef329a364df8", "AQAAAAEAACcQAAAAEKxMk2Zw0ckjzRljOj8bmm39j3pGJJqVtmnW5zy3xcPCnY/a2ZIyJmCW/PsS7OONhw==", "860f703d-3fbb-4d3b-bd98-9ee1bd04eb2f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f64a5f6-2e77-41ab-a790-a73e6898a34b",
                column: "ConcurrencyStamp",
                value: "fe90e131-8e14-4e64-9d8d-a63940cd7400");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc756a21-0731-4ebf-9e4f-a495d819410b",
                column: "ConcurrencyStamp",
                value: "35e1ab77-331c-455f-b08b-b8b6ed2ad0f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "048880ff-3248-48e9-8400-c27c814ee2c1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14894d37-b076-4a57-b278-ed533e16f0db", "AQAAAAEAACcQAAAAEG95oAu4clWXFMwXcpPelntW7xNbKSzYJcaGgryQguHJKqMn3NauvcIwZbY0Yks5KQ==", "815b6a0d-685d-4ad0-996c-f99be8ee640e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30893af3-12ce-4a50-8dac-7bde58106aaf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d35df2aa-29df-41f5-b09e-8570e8cb22e7", "AQAAAAEAACcQAAAAEPmODuAAOGc6WUCQUxmw5HsW06NBBeK/IV7Smr8uKGwuL5fW39jrvd8TkHR25hXN3g==", "218c998a-0d9d-4e1f-bf09-ba375ba066f5" });
        }
    }
}
