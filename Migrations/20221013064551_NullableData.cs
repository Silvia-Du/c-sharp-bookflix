using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c_sharp_bookflix.Migrations
{
    public partial class NullableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaInfos_Films_FilmId",
                table: "MediaInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaInfos_Series_TvSerieId",
                table: "MediaInfos");

            migrationBuilder.DropIndex(
                name: "IX_MediaInfos_FilmId",
                table: "MediaInfos");

            migrationBuilder.DropIndex(
                name: "IX_MediaInfos_TvSerieId",
                table: "MediaInfos");

            migrationBuilder.AlterColumn<int>(
                name: "TvSerieId",
                table: "MediaInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "MediaInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_FilmId",
                table: "MediaInfos",
                column: "FilmId",
                unique: true,
                filter: "[FilmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_TvSerieId",
                table: "MediaInfos",
                column: "TvSerieId",
                unique: true,
                filter: "[TvSerieId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaInfos_Films_FilmId",
                table: "MediaInfos",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaInfos_Series_TvSerieId",
                table: "MediaInfos",
                column: "TvSerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaInfos_Films_FilmId",
                table: "MediaInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaInfos_Series_TvSerieId",
                table: "MediaInfos");

            migrationBuilder.DropIndex(
                name: "IX_MediaInfos_FilmId",
                table: "MediaInfos");

            migrationBuilder.DropIndex(
                name: "IX_MediaInfos_TvSerieId",
                table: "MediaInfos");

            migrationBuilder.AlterColumn<int>(
                name: "TvSerieId",
                table: "MediaInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "MediaInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_FilmId",
                table: "MediaInfos",
                column: "FilmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_TvSerieId",
                table: "MediaInfos",
                column: "TvSerieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaInfos_Films_FilmId",
                table: "MediaInfos",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaInfos_Series_TvSerieId",
                table: "MediaInfos",
                column: "TvSerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
