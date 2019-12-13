using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryServiceMonolithic.Migrations
{
    public partial class orderedbookid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderedBook_OrderedBookId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "OrderedBookId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderedBook_OrderedBookId",
                table: "Order",
                column: "OrderedBookId",
                principalTable: "OrderedBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderedBook_OrderedBookId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "OrderedBookId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderedBook_OrderedBookId",
                table: "Order",
                column: "OrderedBookId",
                principalTable: "OrderedBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
