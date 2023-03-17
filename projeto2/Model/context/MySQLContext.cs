using Microsoft.EntityFrameworkCore;
using projeto2.API.Data.ValueObjects;

namespace projeto2.API.Model.context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){ }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Pessoa>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelbuilder.Entity<Empresa>()
                .Property(p => p.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = 1,
                Cep = "70648-138",
                Estado = "DF",
                Cidade = "Brasília",
                Rua = "Quadra SRES",
                Numero = "2568",
                Bairro = "St Belem"
            });
            modelbuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = 2,
                Cep = "66055-070",
                Estado = "PA",
                Cidade = "Belém",
                Rua = "Vila Baturité",
                Numero = "258",
                Bairro = "Umarizal"
            });
            modelbuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = 3,
                Cep = "49050-070",
                Estado = "SE",
                Cidade = "Aracaju",
                Rua = "Rua Aquidabã",
                Numero = "802",
                Bairro = "Suíssa"
            });
            
            modelbuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 1,
                Nome = "Kaique Igor",
                Documento = "497.540.527-00",
                Telefone = "(62) 99955-1199",
                Status = Enums.Status.Ativo,
                Usuario = "KaiqueIgor",
                EmpresaId = null
            });
            modelbuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 2,
                Nome = "Leonardo Diogo Calebe Alves",
                Documento = "382.265.533-34",
                Telefone = "(61) 98807-2939",
                Status = Enums.Status.Ativo,
                Usuario = "Leonardo Diogo",
                EmpresaId = null
            });
            modelbuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 3,
                Nome = "Filipe Geraldo Theo da Mata",
                Documento = "634.184.253-80",
                Telefone = "(71) 99998-0749",
                Status = Enums.Status.Ativo,
                Usuario = "Filipe Geraldo",
                EmpresaId = null
            });
            modelbuilder.Entity<Empresa>().HasData(new Empresa
            {
                Id = 1,
                Cnpj = "00.038.742/0001-06",
                Status = Enums.Status.Ativo,
                DataAbertura = "20/04/2018",
                NomeEmpresarial = "Kauê e Hadassa Telas ME",
                NomeFantasia = "Telas ME",
                CNAE = "6911-7/01",
                NaturezaJuridica = "EIRELI",
                EnderecoId = 1,
                Telefone = "(19) 99194-0652",
                Capital = 1000000
            });
            modelbuilder.Entity<Empresa>().HasData(new Empresa
            {
                Id = 2,
                Cnpj = "69.911.127/0001-69",
                Status = Enums.Status.Ativo,
                DataAbertura = "08/06/2018",
                NomeEmpresarial = "Marcela e Pedro Corretores Associados Ltda",
                NomeFantasia = "Marcela e Pedro",
                CNAE = "2569-7/01",
                NaturezaJuridica = "MEI",
                EnderecoId = 2,
                Telefone = "(11) 2550-6553",
                Capital = 5498
            });
            modelbuilder.Entity<Empresa>().HasData(new Empresa
            {
                Id = 3,
                Cnpj = "43.658.842/0001-48",
                Status = Enums.Status.Ativo,
                DataAbertura = "22/05/2018",
                NomeEmpresarial = "Natália e Lavínia Advocacia ME",
                NomeFantasia = "Lavínia Advocacia",
                CNAE = "5879-7/01",
                NaturezaJuridica = "LTDA",
                EnderecoId = 3,
                Telefone = "(11) 3924-2963",
                Capital = 50634
            });
        }
    }
}
