using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace TheWorld.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    nameToSisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });
            migrationBuilder.CreateTable(
                name: "Communaute",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bio = table.Column<string>(nullable: true),
                    birth = table.Column<int>(nullable: false),
                    city = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    firstname = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    picture = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communaute", x => x.id);
                });
            migrationBuilder.CreateTable(
                name: "Recettes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    creatorid = table.Column<int>(nullable: true),
                    isAvailable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    nameToDisplay = table.Column<string>(nullable: true),
                    picture = table.Column<string>(nullable: true),
                    preparation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recettes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Recettes_Communaute_creatorid",
                        column: x => x.creatorid,
                        principalTable: "Communaute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Recettesid = table.Column<int>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    mark = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Recettes_Recettesid",
                        column: x => x.Recettesid,
                        principalTable: "Recettes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Communaute_userid",
                        column: x => x.userid,
                        principalTable: "Communaute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Recettesid = table.Column<int>(nullable: true),
                    calories = table.Column<int>(nullable: false),
                    categoryid = table.Column<int>(nullable: true),
                    isAvailable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recettes_Recettesid",
                        column: x => x.Recettesid,
                        principalTable: "Recettes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_Categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Comments");
            migrationBuilder.DropTable("Ingredients");
            migrationBuilder.DropTable("Recettes");
            migrationBuilder.DropTable("Categories");
            migrationBuilder.DropTable("Communaute");
        }
    }
}
