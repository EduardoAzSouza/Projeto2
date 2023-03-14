using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime;

namespace projeto2.API.Model.context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){ }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
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

        }
    }
}
