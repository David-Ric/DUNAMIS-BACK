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
    [Migration("20231213192436_Create_Table_Distribuidora_Insert_Cadastros_Defaults")]
    partial class Create_Table_Distribuidora_Insert_Cadastros_Defaults
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                            PasswordHash = new byte[] { 215, 196, 133, 80, 253, 244, 254, 163, 235, 7, 30, 140, 240, 182, 223, 192, 172, 203, 114, 240, 145, 124, 250, 225, 109, 221, 144, 242, 246, 125, 131, 222, 133, 127, 109, 169, 236, 25, 181, 20, 223, 64, 29, 15, 84, 231, 32, 249, 33, 41, 117, 86, 139, 61, 175, 97, 197, 98, 252, 73, 120, 25, 104, 82 },
                            PasswordSalt = new byte[] { 27, 167, 180, 213, 56, 69, 138, 48, 93, 159, 40, 172, 176, 80, 239, 135, 189, 41, 151, 105, 200, 224, 15, 185, 192, 135, 178, 176, 29, 15, 113, 94 },
                            RefreshToken = "",
                            Status = "1",
                            Telefone = "(85) 3333-3333",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "dunamis"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
