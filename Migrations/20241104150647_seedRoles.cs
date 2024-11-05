using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quick_Books.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] {"Id", "Name", "NormalizedName", "ConcurrencyStamp"},
               values: new Object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
               );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new Object[] {Guid.NewGuid().ToString(),"User", "User".ToUpper(), Guid.NewGuid().ToString() }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from [AspNetRoles]");
        }
    }
}
