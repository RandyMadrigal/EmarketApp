using Microsoft.EntityFrameworkCore.Migrations;

namespace Emarket.Infrastructure.Persistence.Migrations
{
    public partial class OperationImgTableFailed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Imagenes_ImgFileId",
                table: "Anuncios");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_ImgFileId",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ImgFileId",
                table: "Anuncios");

            migrationBuilder.AddColumn<string>(
                name: "ImgFile1",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFile2",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFile3",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFile4",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgFile1",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ImgFile2",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ImgFile3",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ImgFile4",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "ImgFileId",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_ImgFileId",
                table: "Anuncios",
                column: "ImgFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Imagenes_ImgFileId",
                table: "Anuncios",
                column: "ImgFileId",
                principalTable: "Imagenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
