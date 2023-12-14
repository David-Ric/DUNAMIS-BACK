using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Helpers;
using Dunamis_API.Persist;
using Dunamis_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text;

namespace Dunamis_API
{
    public class Program
    {
  
            public static void Main(string[] args)

            {


                var builder = WebApplication.CreateBuilder(args);

  
                string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContextPool<DataContext>(options =>
                    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection),
                                     mySqlOptions => mySqlOptions.EnableRetryOnFailure()));



                builder.Services.AddCors();
                builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

                builder.Services.AddControllers().AddJsonOptions(x =>
                {

                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());


                    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

                builder.Services.AddControllers().AddXmlSerializerFormatters();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Dunamis API", Version = "v1" });
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });

                });


                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
                builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                builder.Services.AddDbContext<DataContext>();

                // Services

                builder.Services.AddScoped<IUserService, UserService>();
                builder.Services.AddScoped<IDistribuidoraService, DistribuidoraService>();
                builder.Services.AddScoped<IVeiculoService, VeiculoService>();
                builder.Services.AddScoped<IAlocacaoService, AlocacaoService>();


                // Persist

                builder.Services.AddScoped<IUsuarioPersist, UsuarioPersist>();
                builder.Services.AddScoped<IDistribuidoraPersist,DistribuidoraPersist>();
                builder.Services.AddScoped<IVeiculoPersist, VeiculoPersist>();
                builder.Services.AddScoped<IAlocacaoPersist, AlocacaoPersist>();
            

                var app = builder.Build();


                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }



                app.UseStaticFiles();

                app.UseHttpsRedirection();


                app.UseAuthentication();


                app.UseAuthorization();




                app.UseCors(x => x.AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowAnyOrigin());


                app.MapControllers();

                app.Run();


            }

        }
    }
