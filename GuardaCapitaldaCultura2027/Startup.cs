using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GuardaCapitaldaCultura2027.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GuardaCapitaldaCultura2027.Models.Context;
using GuardaCapitaldaCultura2027.Models;
using System.IO;

namespace GuardaCapitaldaCultura2027
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //DB Contacto
            services.AddDbContext<GuardaEventosBdContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GuardaEventosConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            PopularBaseDadosAsync(app.ApplicationServices);
        }

        /// <summary>
        /// Recria os dados da base de dados que foram apagados se esta estiver vazia.
        /// </summary>
        /// <param name="serviceProvider"></param>
        private async Task PopularBaseDadosAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<GuardaEventosBdContext>();

                if (!db.Municipio.Any())
                {
                    Random rnd = new Random();
                    int foto_nome = rnd.Next(1, 20);
                    byte[] fotogafia = File.ReadAllBytes("./Image/" + foto_nome + ".jpg");
                    /*DateTime date = new DateTime(2010, 8, 18);
                    Console.WriteLine(date.ToString());*/

                    DateTime RandomDay()
                    {
                        DateTime start = new DateTime(1995, 1, 1);
                    int range = (DateTime.Today - start).Days;
                    return start.AddDays(rnd.Next(range));

                    }

                    db.Municipio.AddRange(new List<Municipio>() {
                        new Municipio()
                        {
                            Nome ="Guarda",
                            Descricao = "A Guarda � uma cidade portuguesa. Com 1 056 metros de altitude m�xima, � a mais alta cidade do pa�s. Com 26 565 habitantes no seu per�metro urbano, capital do distrito da Guarda, situada na regi�o estat�stica do Centro e sub-regi�o das Beiras e Serra da Estrela. � sede de um munic�pio com 712,1 km� de �rea e 42 541 habitantes (censos de 2011), subdividido desde a reorganiza��o administrativa de 2012/2013 em 43 freguesias.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },

                        new Municipio()
                        {
                            Nome = "Trancoso",
                            Descricao = "Trancoso � uma cidade portuguesa pertencente ao distrito da Guarda, na prov�ncia da Beira Alta, regi�o do Centro (Regi�o das Beiras) e sub-regi�o da Beira Interior Norte, com cerca de 3 420 habitantes (2011), situada num planalto em que o ponto mais alto tem 939 m de altitude.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Almeida",
                            Descricao = "Munic�pio de Almeida, um elemento catalisador de processos de grande transforma��o culturais, sociais, econ�micos e de mobiliza��o dos cidad�os, n�o s� para a pr�pria cidade, como tamb�m para todo o Distrito.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Belmonte",
                            Descricao = "Belmonte � um munic�pio quase t�o antigo quanto a nacionalidade. A aldeia de Belmonte teve um foral em 1199 e situa-se no panor�mico Monte da Esperan�a (Antigos Montes Crestados), sobre cujo Monte Rochoso foi edificado nos finais do s�c. XII o seu castelo, que juntamente com os castelos de Sortelha e Vila de Touro, formaram at� � assinatura do Tratado de Alcanices (1297), a linha defensiva do Alto C�a, apoiada pela muralha natural da Serra da Estrela e pelo vale do Z�zere.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Celorico da Beira",
                            Descricao ="Munic�pio de Celorico da Beira representa uma mais valia em termos de estrat�gia territorial; � uma oportunidade para projetar as nossas tradi��es numa outra escala, de pensar os novos desafios da p�s-modernidade que exigem adapta��o, numa s�ntese cultural que abre horizontes e representa uma �ponte�, um caminho que devemos fazer para reencontrar os outros; permite questionar aquilo que nos define como civiliza��o europeia (greco-latina), aquilo que nos aproxima dos outros, confrontar os nossos preconceitos, mostrar o que atrai e inspira ao conhecimento.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Covilh�",
                            Descricao ="A Covilh� DmC � GCMAI � uma cidade portuguesa pertencente ao distrito de Castelo Branco, na prov�ncia da Beira Baixa, regi�o estat�stica do Centro e sub-regi�o das Beiras e Serra da Estrela. � a porta da Serra da Estrela e tem 36 356 habitantes no seu per�metro urbano formado por cinco freguesias: Covilh� e Canhoso, Teixoso e Sarzedo, Cantar-Galo e Vila do Carvalho, Boidobra e Tortosendo.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Figueira de Castelo Rodrigo",
                            Descricao ="O Concelho de Figueira de Castelo Rodrigo, institu�do por decreto de 25 de Julho de 1836, apresenta uma grande riqueza de patrim�nio edificado, encontrando-se em todas as suas freguesias, obras de grande valor que desvendam segredos e recorda��es de grandes epis�dios de nossa hist�ria. As suas paisagens est�o repletas de belos atrativos com que a m�e natureza a contemplou, pois s�o in�meras as paisagens paradis�acas e invulgares de beleza e poesia, que transmitem uma mensagem de beleza, luz e cor. S�o magnif�cos e apelativos cart�es de visita que merecem uma passagem por estas terras.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {

                            Nome = "Fornos de Algodres",
                            Descricao = " Visitar o Munic�pio de Fornos de Algodres � contemplar o passado e o presente, a paisagem e o patrim�nio, assim como os usos e costumes!",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Fund�o",
                            Descricao = " Munic�pio do Fund�o o fazer parte de um processo de trabalho de constru��o de um projeto territorial comum fortalecendo parcerias de maneira a que permita inserir o concelho do Fund�o na contemporaneidade art�stica, dando o protagonismo central � cria��o art�stica nas suas diversas manifesta��es, de forma a proporcionar as condi��es ideais para a cria��o, a fomentar uma estrutura de forma��o art�stica necess�ria para a incorpora��o dos jovens no processo criativo e a otimizar os espa�os de apresenta��es art�sticas.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Gouveia",
                            Descricao = "Gouveia � uma cidade portuguesa do distrito da Guarda, situada na prov�ncia da Beira Alta, regi�o do Centro (Regi�o das Beiras) e sub-regi�o das Beiras e Serra da Estrela. Situa-se na encosta noroeste do maior sistema montanhoso portugu�s continental, a Serra da Estrela, a cerca de 700m de altura. ",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Manteigas",
                            Descricao = "Munic�pio de Manteigas como uma oportunidade de divulga��o e promo��o do territ�rio, assente na coopera��o cultural de todos os Munic�pios que a integram, com as suas diferen�as e especificidades. Olhar para o passado, viver o presente e acreditar no futuro. Mais do que uma candidatura, � acima de tudo uma oportunidade diferenciadora de aproxima��o das comunidades. ",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "M�da",
                            Descricao = " Meda � uma cidade portuguesa sede de um munic�pio que pertencente ao distrito da Guarda, na prov�ncia da Beira Alta, regi�o do Centro (Regi�o das Beiras) e sub-regi�o das Beiras e Serra da Estrela, com cerca de 2 100 habitantes. � sede de um munic�pio com 286,05 km� de �rea e 5 202 habitantes (2011), subdividido em 11 freguesias. O munic�pio � limitado a norte e nordeste por Vila Nova de Foz C�a, a sudeste por Pinhel, a sul por Trancoso e a oeste por Penedono.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Pinhel",
                            Descricao = " Pinhel � uma cidade portuguesa pertencente ao distrito da Guarda, na prov�ncia da Beira Alta, regi�o do Centro (Regi�o das Beiras) e sub-regi�o das Beiras e Serra da Estrela, com aproximadamente 3 500 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Sabugal",
                            Descricao = " Sabugal � uma cidade portuguesa pertencente ao distrito da Guarda, na prov�ncia da Beira Alta, regi�o do Centro (Regi�o das Beiras) e sub-regi�o das Beiras e Serra da Estrela, com cerca de 1 943 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Seia",
                            Descricao = " Seia � uma cidade portuguesa do distrito da Guarda, situada na prov�ncia da Beira Alta, regi�o do Centro (Regi�o das Beiras) e sub-regi�o da Serra da Estrela, com cerca de 5 300 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Vila Nova de Foz C�a",
                            Descricao = " Vila Nova de Foz C�a (p�s-AO 1990: Vila Nova de Foz Coa), por vezes designada abreviadamente Foz C�a, � uma cidade portuguesa, pertencente ao distrito de Guarda, Regi�o Norte e sub-regi�o do Douro, com cerca de 3 100 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        }
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
