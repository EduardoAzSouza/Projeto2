using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto2.API.Migrations
{
    public partial class FistMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_abertura = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_empresarial = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome_fantasia = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cnae = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Natureza_Juridica = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false),
                    telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capital = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_empresa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    documento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pessoa_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresa",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "id", "Bairro", "Cep", "Cidade", "Estado", "Numero", "Rua" },
                values: new object[,]
                {
                    { 1L, "St Belem", "70648-138", "Brasília", "DF", "2568", "Quadra SRES" },
                    { 2L, "Umarizal", "66055-070", "Belém", "PA", "258", "Vila Baturité" },
                    { 3L, "Suíssa", "49050-070", "Aracaju", "SE", "802", "Rua Aquidabã" }
                });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "id", "documento", "EmpresaId", "Nome", "status", "telefone", "usuario" },
                values: new object[,]
                {
                    { 1L, "497.540.527-00", null, "Kaique Igor", "Ativo", "(62) 99955-1199", "KaiqueIgor" },
                    { 2L, "382.265.533-34", null, "Leonardo Diogo Calebe Alves", "Ativo", "(61) 98807-2939", "Leonardo Diogo" },
                    { 3L, "634.184.253-80", null, "Filipe Geraldo Theo da Mata", "Ativo", "(71) 99998-0749", "Filipe Geraldo" }
                });

            migrationBuilder.InsertData(
                table: "empresa",
                columns: new[] { "id", "cnae", "capital", "cnpj", "data_abertura", "EnderecoId", "Natureza_Juridica", "nome_empresarial", "nome_fantasia", "status", "telefone" },
                values: new object[] { 1L, "6911-7/01", 1000000.0, "00038742000106", "20/04/2018", 1L, "EIRELI", "Kauê e Hadassa Telas ME", "Telas ME", "Ativo", "(19) 99194-0652" });

            migrationBuilder.InsertData(
                table: "empresa",
                columns: new[] { "id", "cnae", "capital", "cnpj", "data_abertura", "EnderecoId", "Natureza_Juridica", "nome_empresarial", "nome_fantasia", "status", "telefone" },
                values: new object[] { 2L, "2569-7/01", 5498.0, "69911127000169", "08/06/2018", 2L, "MEI", "Marcela e Pedro Corretores Associados Ltda", "Marcela e Pedro", "Ativo", "(11) 2550-6553" });

            migrationBuilder.InsertData(
                table: "empresa",
                columns: new[] { "id", "cnae", "capital", "cnpj", "data_abertura", "EnderecoId", "Natureza_Juridica", "nome_empresarial", "nome_fantasia", "status", "telefone" },
                values: new object[] { 3L, "5879-7/01", 50634.0, "43658842000148", "22/05/2018", 3L, "LTDA", "Natália e Lavínia Advocacia ME", "Lavínia Advocacia", "Ativo", "(11) 3924-2963" });

            migrationBuilder.CreateIndex(
                name: "IX_empresa_EnderecoId",
                table: "empresa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EmpresaId",
                table: "Pessoa",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
