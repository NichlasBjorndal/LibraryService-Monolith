using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryServiceMonolithic.Migrations
{
    public partial class addbookorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderedBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedBook_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdTime = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    OrderedBookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderedBook_OrderedBookId",
                        column: x => x.OrderedBookId,
                        principalTable: "OrderedBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderedBookId",
                table: "Order",
                column: "OrderedBookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedBook_AuthorId",
                table: "OrderedBook",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderedBook");
        }
    }
}
