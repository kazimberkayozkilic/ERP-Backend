using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepotId",
                table: "InvoicesDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetails_DepotId",
                table: "InvoicesDetails",
                column: "DepotId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetails_Depots_DepotId",
                table: "InvoicesDetails",
                column: "DepotId",
                principalTable: "Depots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetails_Depots_DepotId",
                table: "InvoicesDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoicesDetails_DepotId",
                table: "InvoicesDetails");

            migrationBuilder.DropColumn(
                name: "DepotId",
                table: "InvoicesDetails");
        }
    }
}
