using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolWeebs.API.Database.Migrations.DevMigration
{
    public partial class TitleList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tl_list",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_thumbnail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tl_list", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tl_title",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_thumbnail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tl_title", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tl_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    is_completed = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    tl_title_id = table.Column<long>(type: "bigint", nullable: false),
                    tl_list_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tl_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tl_item_tb_tl_list_tl_list_id",
                        column: x => x.tl_list_id,
                        principalTable: "tb_tl_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tl_item_tb_tl_title_tl_title_id",
                        column: x => x.tl_title_id,
                        principalTable: "tb_tl_title",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_item_id_tl_title_id_tl_list_id",
                table: "tb_tl_item",
                columns: new[] { "id", "tl_title_id", "tl_list_id" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_item_is_deleted_created_at_updated_at",
                table: "tb_tl_item",
                columns: new[] { "is_deleted", "created_at", "updated_at" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_item_tl_list_id",
                table: "tb_tl_item",
                column: "tl_list_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_item_tl_title_id",
                table: "tb_tl_item",
                column: "tl_title_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_list_id_name",
                table: "tb_tl_list",
                columns: new[] { "id", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_list_is_deleted_created_at_updated_at",
                table: "tb_tl_list",
                columns: new[] { "is_deleted", "created_at", "updated_at" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_title_id_name",
                table: "tb_tl_title",
                columns: new[] { "id", "name" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tl_title_is_deleted_created_at_updated_at",
                table: "tb_tl_title",
                columns: new[] { "is_deleted", "created_at", "updated_at" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tl_item");

            migrationBuilder.DropTable(
                name: "tb_tl_list");

            migrationBuilder.DropTable(
                name: "tb_tl_title");
        }
    }
}
