using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryServiceMonolithic.Migrations
{
    public partial class orderrefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderedBook_OrderedBookId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderedBook");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderedBookId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrdTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderedBookId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PhysicalBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: true),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalBook_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId",
                table: "Order",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalBook_BookId",
                table: "PhysicalBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalBook_OrderId",
                table: "PhysicalBook",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Book_BookId",
                table: "Order",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Book_BookId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "PhysicalBook");

            migrationBuilder.DropIndex(
                name: "IX_Order_BookId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "Order");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrdTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderedBookId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderedBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderedBookId",
                table: "Order",
                column: "OrderedBookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedBook_AuthorId",
                table: "OrderedBook",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderedBook_OrderedBookId",
                table: "Order",
                column: "OrderedBookId",
                principalTable: "OrderedBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
