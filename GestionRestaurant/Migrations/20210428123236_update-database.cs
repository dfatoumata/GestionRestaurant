using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionRestaurant.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consommations_Tables_TableCmdId",
                table: "Consommations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Serveurs_ServeurId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "TableCmds");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_ServeurId",
                table: "TableCmds",
                newName: "IX_TableCmds_ServeurId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Serveurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableCmds",
                table: "TableCmds",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consommations_TableCmds_TableCmdId",
                table: "Consommations",
                column: "TableCmdId",
                principalTable: "TableCmds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableCmds_Serveurs_ServeurId",
                table: "TableCmds",
                column: "ServeurId",
                principalTable: "Serveurs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consommations_TableCmds_TableCmdId",
                table: "Consommations");

            migrationBuilder.DropForeignKey(
                name: "FK_TableCmds_Serveurs_ServeurId",
                table: "TableCmds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableCmds",
                table: "TableCmds");

            migrationBuilder.RenameTable(
                name: "TableCmds",
                newName: "Tables");

            migrationBuilder.RenameIndex(
                name: "IX_TableCmds_ServeurId",
                table: "Tables",
                newName: "IX_Tables_ServeurId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Serveurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consommations_Tables_TableCmdId",
                table: "Consommations",
                column: "TableCmdId",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Serveurs_ServeurId",
                table: "Tables",
                column: "ServeurId",
                principalTable: "Serveurs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
