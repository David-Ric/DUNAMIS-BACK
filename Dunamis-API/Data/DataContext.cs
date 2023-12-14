using Dunamis_API.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Dunamis_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Usuario> Usuario => Set<Usuario>();
        public DbSet<Motorista> Motorista => Set<Motorista>();
        public DbSet<Distribuidora> Distribuidora => Set<Distribuidora>();
        public DbSet<Veiculo> Veiculo => Set<Veiculo>();
        public DbSet<Alocacao> Alocacao => Set<Alocacao>();

        

        private byte[] CreateHash(string input, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = hmac.ComputeHash(inputBytes);
            return hashBytes;
        }

        private byte[] CreateSalt()
        {
            using var rng = new RNGCryptoServiceProvider();
            var salt = new byte[32];
            rng.GetBytes(salt);
            return salt;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var password = "1234";
            var salt = CreateSalt();

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Email = "dunamis@dunamis.com.brr",
                    Username = "dunamis",
                    NomeCompleto = "Dunamis",
                    PasswordHash = CreateHash(password, salt),
                    PasswordSalt = salt,
                    Status = "1",
                    Funcao = "Administrador do Sistema",
                    Telefone = "(85) 3333-3333",

                }
            );
            modelBuilder.Entity<Motorista>().HasData(
              new Motorista
              {
                 Id = 1,
                 Cpf = "93245678954",
                 Nome ="Julio Roberto Torres",
                 Fone ="21998765439",
                 Email ="julio_rob@gmail.com",
              },
              new Motorista
              {
                 Id = 2,
                 Cpf = "94215678943",
                 Nome = "Paulo Morais Torres",
                 Fone = "11987432167",
                 Email = "paulo7789@gmail.com",
              },
              new Motorista
              {
                  Id = 3,
                  Cpf = "94943256789",
                  Nome = "Jose da Mata Mourinho",
                  Fone = "85986541234",
                  Email = "jose_mata@gmail.com",
              }

          );
            modelBuilder.Entity<Distribuidora>().HasData(
              new Distribuidora
              {
                  Id = 1,
                  Cnpj = "16870304000140",
                  Razao_Social = "Mirante Distribuidora de Grâos",
                  Fone = "45998761234",
                  Email = "mirante@gmail.com",
                  Logradouro = "Rua Ulises Cerpa,78",
                  Municipio = "São José dos Pinhais",
                  Uf = "PR"
              },
              new Distribuidora
              {
                  Id = 2,
                  Cnpj = "17493153000110",
                  Razao_Social = "Adailto Souza de Melo",
                  Fone = "12997323456",
                  Email = "adailton@gmail.com",
                  Logradouro = "Rua Pablo Goias,133 - Lote 07",
                  Municipio = "Bueguesia",
                  Uf = "ES"
              },
              new Distribuidora
              {
                  Id = 3,
                  Cnpj = "36411834000137",
                  Razao_Social = "Antonio Muriel Matoso",
                  Fone = "45998764532",
                  Email = "muriel324@gmail.com",
                  Logradouro = "Rua Colina Santa",
                  Municipio = "Morteiro",
                  Uf = "PR"
              }

          );
            modelBuilder.Entity<Veiculo>().HasData(
            new Veiculo
            {
                Id = 1,
                Placa = "SBB7G54",
                Modelo = "Mercedes-Benz",
                MotoristaId = 1,
            },
            new Veiculo
            {
                Id = 2,
                Placa = "DMO5G97",
                Modelo = "Scania",
                MotoristaId = 3,
            },
            new Veiculo
            {
                Id = 3,
                Placa = "BOO5G12",
                Modelo = " Volvo FH",
                MotoristaId = 2,
            }

        );
        }
    }
}
