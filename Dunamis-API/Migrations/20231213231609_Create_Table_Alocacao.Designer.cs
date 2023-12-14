﻿// <auto-generated />
using System;
using Dunamis_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dunamis_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231213231609_Create_Table_Alocacao")]
    partial class Create_Table_Alocacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dunamis_API.Model.Alocacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Carga")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<bool?>("Checado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("DistribuidoraId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Entrada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Obs")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<int?>("Peso")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Saída")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistribuidoraId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Alocacao");
                });

            modelBuilder.Entity("Dunamis_API.Model.Distribuidora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Fone")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Municipio")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Razao_Social")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Uf")
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Distribuidora");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cnpj = "16870304000140",
                            Email = "mirante@gmail.com",
                            Fone = "45998761234",
                            Logradouro = "Rua Ulises Cerpa,78",
                            Municipio = "São José dos Pinhais",
                            Razao_Social = "Mirante Distribuidora de Grâos",
                            Uf = "PR"
                        },
                        new
                        {
                            Id = 2,
                            Cnpj = "17493153000110",
                            Email = "adailton@gmail.com",
                            Fone = "12997323456",
                            Logradouro = "Rua Pablo Goias,133 - Lote 07",
                            Municipio = "Bueguesia",
                            Razao_Social = "Adailto Souza de Melo",
                            Uf = "ES"
                        },
                        new
                        {
                            Id = 3,
                            Cnpj = "36411834000137",
                            Email = "muriel324@gmail.com",
                            Fone = "45998764532",
                            Logradouro = "Rua Colina Santa",
                            Municipio = "Morteiro",
                            Razao_Social = "Antonio Muriel Matoso",
                            Uf = "PR"
                        });
                });

            modelBuilder.Entity("Dunamis_API.Model.Motorista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Fone")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Nome")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.HasKey("Id");

                    b.ToTable("Motorista");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "93245678954",
                            Email = "julio_rob@gmail.com",
                            Fone = "21998765439",
                            Nome = "Julio Roberto Torres"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "94215678943",
                            Email = "paulo7789@gmail.com",
                            Fone = "11987432167",
                            Nome = "Paulo Morais Torres"
                        },
                        new
                        {
                            Id = 3,
                            Cpf = "94943256789",
                            Email = "jose_mata@gmail.com",
                            Fone = "85986541234",
                            Nome = "Jose da Mata Mourinho"
                        });
                });

            modelBuilder.Entity("Dunamis_API.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Funcao")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("PasswordResetToken")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("VerificationToken")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "dunamis@dunamis.com.brr",
                            Funcao = "Administrador do Sistema",
                            NomeCompleto = "Dunamis",
                            PasswordHash = new byte[] { 30, 94, 187, 34, 247, 70, 172, 0, 58, 2, 32, 17, 247, 113, 64, 68, 250, 140, 255, 70, 112, 75, 32, 215, 76, 131, 96, 35, 13, 204, 185, 248, 238, 105, 60, 35, 248, 122, 109, 95, 73, 129, 175, 234, 18, 146, 180, 65, 49, 103, 109, 213, 27, 251, 178, 40, 203, 249, 145, 15, 21, 69, 142, 80 },
                            PasswordSalt = new byte[] { 238, 196, 132, 205, 150, 153, 251, 176, 104, 145, 177, 227, 235, 204, 184, 151, 15, 9, 47, 85, 5, 240, 87, 72, 217, 51, 249, 133, 186, 142, 21, 20 },
                            RefreshToken = "",
                            Status = "1",
                            Telefone = "(85) 3333-3333",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "dunamis"
                        });
                });

            modelBuilder.Entity("Dunamis_API.Model.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("MotoristaId")
                        .HasMaxLength(25)
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

                    b.ToTable("Veiculo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Modelo = "Mercedes-Benz",
                            MotoristaId = 1,
                            Placa = "SBB7G54"
                        },
                        new
                        {
                            Id = 2,
                            Modelo = "Scania",
                            MotoristaId = 3,
                            Placa = "DMO5G97"
                        },
                        new
                        {
                            Id = 3,
                            Modelo = " Volvo FH",
                            MotoristaId = 2,
                            Placa = "BOO5G12"
                        });
                });

            modelBuilder.Entity("Dunamis_API.Model.Alocacao", b =>
                {
                    b.HasOne("Dunamis_API.Model.Distribuidora", "Distribuidora")
                        .WithMany()
                        .HasForeignKey("DistribuidoraId");

                    b.HasOne("Dunamis_API.Model.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId");

                    b.Navigation("Distribuidora");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Dunamis_API.Model.Veiculo", b =>
                {
                    b.HasOne("Dunamis_API.Model.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");
                });
#pragma warning restore 612, 618
        }
    }
}