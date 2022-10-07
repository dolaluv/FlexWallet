using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexWallet.Data.Service.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletUserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletAccountBalance = table.Column<double>(type: "float", nullable: false),
                    WalletAccountOpeningBalance = table.Column<double>(type: "float", nullable: false),
                    WalletAccountTotalSavedFunds = table.Column<double>(type: "float", nullable: false),
                    WalletAccountTotalWithdrawFunds = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletUserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletUserAccounts_WalletUsers_WalletUserId",
                        column: x => x.WalletUserId,
                        principalTable: "WalletUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletFundTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountmNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
                    TransactionAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionBankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletUserAccountId = table.Column<int>(type: "int", nullable: false),
                    WalletUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletFundTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletFundTransactions_WalletUserAccounts_WalletUserAccountId",
                        column: x => x.WalletUserAccountId,
                        principalTable: "WalletUserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WalletFundTransactions_WalletUsers_WalletUserId",
                        column: x => x.WalletUserId,
                        principalTable: "WalletUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletFundTransactions_WalletUserAccountId",
                table: "WalletFundTransactions",
                column: "WalletUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletFundTransactions_WalletUserId",
                table: "WalletFundTransactions",
                column: "WalletUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletUserAccounts_WalletUserId",
                table: "WalletUserAccounts",
                column: "WalletUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletFundTransactions");

            migrationBuilder.DropTable(
                name: "WalletUserAccounts");

            migrationBuilder.DropTable(
                name: "WalletUsers");
        }
    }
}
