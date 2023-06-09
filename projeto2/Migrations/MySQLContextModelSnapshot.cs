﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projeto2.API.Model.context;

#nullable disable

namespace projeto2.API.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("projeto2.API.Model.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("CNAE")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cnae");

                    b.Property<double>("Capital")
                        .HasColumnType("double")
                        .HasColumnName("capital");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("cnpj");

                    b.Property<string>("DataAbertura")
                        .HasColumnType("longtext")
                        .HasColumnName("data_abertura");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint")
                        .HasColumnName("EnderecoId");

                    b.Property<string>("NaturezaJuridica")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Natureza_Juridica");

                    b.Property<string>("NomeEmpresarial")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("nome_empresarial");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("empresa");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CNAE = "6911-7/01",
                            Capital = 1000000.0,
                            Cnpj = "00038742000106",
                            DataAbertura = "20/04/2018",
                            EnderecoId = 1L,
                            NaturezaJuridica = "EIRELI",
                            NomeEmpresarial = "Kauê e Hadassa Telas ME",
                            NomeFantasia = "Telas ME",
                            Status = "Ativo",
                            Telefone = "(19) 99194-0652"
                        },
                        new
                        {
                            Id = 2L,
                            CNAE = "2569-7/01",
                            Capital = 5498.0,
                            Cnpj = "69911127000169",
                            DataAbertura = "08/06/2018",
                            EnderecoId = 2L,
                            NaturezaJuridica = "MEI",
                            NomeEmpresarial = "Marcela e Pedro Corretores Associados Ltda",
                            NomeFantasia = "Marcela e Pedro",
                            Status = "Ativo",
                            Telefone = "(11) 2550-6553"
                        },
                        new
                        {
                            Id = 3L,
                            CNAE = "5879-7/01",
                            Capital = 50634.0,
                            Cnpj = "43658842000148",
                            DataAbertura = "22/05/2018",
                            EnderecoId = 3L,
                            NaturezaJuridica = "LTDA",
                            NomeEmpresarial = "Natália e Lavínia Advocacia ME",
                            NomeFantasia = "Lavínia Advocacia",
                            Status = "Ativo",
                            Telefone = "(11) 3924-2963"
                        });
                });

            modelBuilder.Entity("projeto2.API.Model.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Endereco");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Bairro = "St Belem",
                            Cep = "70648-138",
                            Cidade = "Brasília",
                            Estado = "DF",
                            Numero = "2568",
                            Rua = "Quadra SRES"
                        },
                        new
                        {
                            Id = 2L,
                            Bairro = "Umarizal",
                            Cep = "66055-070",
                            Cidade = "Belém",
                            Estado = "PA",
                            Numero = "258",
                            Rua = "Vila Baturité"
                        },
                        new
                        {
                            Id = 3L,
                            Bairro = "Suíssa",
                            Cep = "49050-070",
                            Cidade = "Aracaju",
                            Estado = "SE",
                            Numero = "802",
                            Rua = "Rua Aquidabã"
                        });
                });

            modelBuilder.Entity("projeto2.API.Model.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("documento");

                    b.Property<long?>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("EmpresaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Nome");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("usuario");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Documento = "497.540.527-00",
                            Nome = "Kaique Igor",
                            Status = "Ativo",
                            Telefone = "(62) 99955-1199",
                            Usuario = "KaiqueIgor"
                        },
                        new
                        {
                            Id = 2L,
                            Documento = "382.265.533-34",
                            Nome = "Leonardo Diogo Calebe Alves",
                            Status = "Ativo",
                            Telefone = "(61) 98807-2939",
                            Usuario = "Leonardo Diogo"
                        },
                        new
                        {
                            Id = 3L,
                            Documento = "634.184.253-80",
                            Nome = "Filipe Geraldo Theo da Mata",
                            Status = "Ativo",
                            Telefone = "(71) 99998-0749",
                            Usuario = "Filipe Geraldo"
                        });
                });

            modelBuilder.Entity("projeto2.API.Model.Empresa", b =>
                {
                    b.HasOne("projeto2.API.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("projeto2.API.Model.Pessoa", b =>
                {
                    b.HasOne("projeto2.API.Model.Empresa", "Empresa")
                        .WithMany("Pessoas")
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("projeto2.API.Model.Empresa", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
