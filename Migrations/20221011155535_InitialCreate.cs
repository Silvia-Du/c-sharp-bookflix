﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c_sharp_bookflix.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisualizationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisualizationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaInfos_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaInfos_Series_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMediaInfo",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMediaInfo", x => new { x.CastId, x.MediaInfosId });
                    table.ForeignKey(
                        name: "FK_ActorMediaInfo_Actor_CastId",
                        column: x => x.CastId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMediaInfo_MediaInfos_MediaInfosId",
                        column: x => x.MediaInfosId,
                        principalTable: "MediaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureMediaInfo",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureMediaInfo", x => new { x.FeaturesId, x.MediaInfosId });
                    table.ForeignKey(
                        name: "FK_FeatureMediaInfo_Feature_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureMediaInfo_MediaInfos_MediaInfosId",
                        column: x => x.MediaInfosId,
                        principalTable: "MediaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMediaInfo",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MediaInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMediaInfo", x => new { x.GenresId, x.MediaInfosId });
                    table.ForeignKey(
                        name: "FK_GenreMediaInfo_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMediaInfo_MediaInfos_MediaInfosId",
                        column: x => x.MediaInfosId,
                        principalTable: "MediaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMediaInfo_MediaInfosId",
                table: "ActorMediaInfo",
                column: "MediaInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureMediaInfo_MediaInfosId",
                table: "FeatureMediaInfo",
                column: "MediaInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMediaInfo_MediaInfosId",
                table: "GenreMediaInfo",
                column: "MediaInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_FilmId",
                table: "MediaInfos",
                column: "FilmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaInfos_TvSeriesId",
                table: "MediaInfos",
                column: "TvSeriesId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMediaInfo");

            migrationBuilder.DropTable(
                name: "FeatureMediaInfo");

            migrationBuilder.DropTable(
                name: "GenreMediaInfo");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MediaInfos");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
