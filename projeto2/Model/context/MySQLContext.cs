using Microsoft.EntityFrameworkCore;

namespace projeto2.API.Model.context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){ }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Pessoa>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelbuilder.Entity<Empresa>()
                .Property(p => p.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelbuilder);
            /*
            modelbuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 1,
                Nome = "Tester",
                Documento = "66556559885",
                Telefone = "5456456564654",
                Usuario = "Userteste",
                Status = Enums.Status.Pendente,
                EmpresaId = 0
            });
            modelbuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 2,
                Nome = "segundo teste",
                Documento = "5456486512",
                Telefone = "5261564184651",
                Usuario = "usuariodeteste",
                Status = Enums.Status.Ativo,
                EmpresaId = 0
            });
            
            modelbuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = 1,
                Cep = "54564856",
                Estado = "Sp",
                Cidade = "Testelandia",
                Rua = "Rua dos Testes",
                Numero = "2568",
                Bairro = "St Teste"
            });
            modelbuilder.Entity<Empresa>().HasData(new Empresa
            {
                Id = 1,
                Cnpj = "256161651561",
                Status = Enums.Status.Ativo,
                DataAbertura = "25/11/1968",
                NomeEmpresarial = "Testes testes testadose CIA",
                NomeFantasia = "Teste",
                CNAE = "6911-7/01",
                NaturezaJuridica = "EIRELI",
                Endereco = new Endereco()
                {
                    Cep = "54564856",
                    Estado = "Sp",
                    Cidade = "Testelandia",
                    Rua = "Rua dos Testes",
                    Numero = "2568",
                    Bairro = "St Teste"
                },
                Telefone = "(12)3456-7891",
                Capital = 1000000
            });
            */
        }
    }
}
