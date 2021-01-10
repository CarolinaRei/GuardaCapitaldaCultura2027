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
                            Descricao = "A Guarda é uma cidade portuguesa. Com 1 056 metros de altitude máxima, é a mais alta cidade do país. Com 26 565 habitantes no seu perímetro urbano, capital do distrito da Guarda, situada na região estatística do Centro e sub-região das Beiras e Serra da Estrela. É sede de um município com 712,1 km² de área e 42 541 habitantes (censos de 2011), subdividido desde a reorganização administrativa de 2012/2013 em 43 freguesias.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },

                        new Municipio()
                        {
                            Nome = "Trancoso",
                            Descricao = "Trancoso é uma cidade portuguesa pertencente ao distrito da Guarda, na província da Beira Alta, região do Centro (Região das Beiras) e sub-região da Beira Interior Norte, com cerca de 3 420 habitantes (2011), situada num planalto em que o ponto mais alto tem 939 m de altitude.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Almeida",
                            Descricao = "Município de Almeida, um elemento catalisador de processos de grande transformação culturais, sociais, económicos e de mobilização dos cidadãos, não só para a própria cidade, como também para todo o Distrito.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Belmonte",
                            Descricao = "Belmonte é um município quase tão antigo quanto a nacionalidade. A aldeia de Belmonte teve um foral em 1199 e situa-se no panorâmico Monte da Esperança (Antigos Montes Crestados), sobre cujo Monte Rochoso foi edificado nos finais do séc. XII o seu castelo, que juntamente com os castelos de Sortelha e Vila de Touro, formaram até à assinatura do Tratado de Alcanices (1297), a linha defensiva do Alto Côa, apoiada pela muralha natural da Serra da Estrela e pelo vale do Zêzere.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Celorico da Beira",
                            Descricao ="Município de Celorico da Beira representa uma mais valia em termos de estratégia territorial; é uma oportunidade para projetar as nossas tradições numa outra escala, de pensar os novos desafios da pós-modernidade que exigem adaptação, numa síntese cultural que abre horizontes e representa uma “ponte”, um caminho que devemos fazer para reencontrar os outros; permite questionar aquilo que nos define como civilização europeia (greco-latina), aquilo que nos aproxima dos outros, confrontar os nossos preconceitos, mostrar o que atrai e inspira ao conhecimento.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Covilhã",
                            Descricao ="A Covilhã DmC • GCMAI é uma cidade portuguesa pertencente ao distrito de Castelo Branco, na província da Beira Baixa, região estatística do Centro e sub-região das Beiras e Serra da Estrela. É a porta da Serra da Estrela e tem 36 356 habitantes no seu perímetro urbano formado por cinco freguesias: Covilhã e Canhoso, Teixoso e Sarzedo, Cantar-Galo e Vila do Carvalho, Boidobra e Tortosendo.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Figueira de Castelo Rodrigo",
                            Descricao ="O Concelho de Figueira de Castelo Rodrigo, instituído por decreto de 25 de Julho de 1836, apresenta uma grande riqueza de património edificado, encontrando-se em todas as suas freguesias, obras de grande valor que desvendam segredos e recordações de grandes episódios de nossa história. As suas paisagens estão repletas de belos atrativos com que a mãe natureza a contemplou, pois são inúmeras as paisagens paradisíacas e invulgares de beleza e poesia, que transmitem uma mensagem de beleza, luz e cor. São magnifícos e apelativos cartões de visita que merecem uma passagem por estas terras.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {

                            Nome = "Fornos de Algodres",
                            Descricao = " Visitar o Município de Fornos de Algodres é contemplar o passado e o presente, a paisagem e o património, assim como os usos e costumes!",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Fundão",
                            Descricao = " Município do Fundão o fazer parte de um processo de trabalho de construção de um projeto territorial comum fortalecendo parcerias de maneira a que permita inserir o concelho do Fundão na contemporaneidade artística, dando o protagonismo central à criação artística nas suas diversas manifestações, de forma a proporcionar as condições ideais para a criação, a fomentar uma estrutura de formação artística necessária para a incorporação dos jovens no processo criativo e a otimizar os espaços de apresentações artísticas.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Gouveia",
                            Descricao = "Gouveia é uma cidade portuguesa do distrito da Guarda, situada na província da Beira Alta, região do Centro (Região das Beiras) e sub-região das Beiras e Serra da Estrela. Situa-se na encosta noroeste do maior sistema montanhoso português continental, a Serra da Estrela, a cerca de 700m de altura. ",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Manteigas",
                            Descricao = "Município de Manteigas como uma oportunidade de divulgação e promoção do território, assente na cooperação cultural de todos os Municípios que a integram, com as suas diferenças e especificidades. Olhar para o passado, viver o presente e acreditar no futuro. Mais do que uma candidatura, é acima de tudo uma oportunidade diferenciadora de aproximação das comunidades. ",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Mêda",
                            Descricao = " Meda é uma cidade portuguesa sede de um município que pertencente ao distrito da Guarda, na província da Beira Alta, região do Centro (Região das Beiras) e sub-região das Beiras e Serra da Estrela, com cerca de 2 100 habitantes. É sede de um município com 286,05 km² de área e 5 202 habitantes (2011), subdividido em 11 freguesias. O município é limitado a norte e nordeste por Vila Nova de Foz Côa, a sudeste por Pinhel, a sul por Trancoso e a oeste por Penedono.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Pinhel",
                            Descricao = " Pinhel é uma cidade portuguesa pertencente ao distrito da Guarda, na província da Beira Alta, região do Centro (Região das Beiras) e sub-região das Beiras e Serra da Estrela, com aproximadamente 3 500 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Sabugal",
                            Descricao = " Sabugal é uma cidade portuguesa pertencente ao distrito da Guarda, na província da Beira Alta, região do Centro (Região das Beiras) e sub-região das Beiras e Serra da Estrela, com cerca de 1 943 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Seia",
                            Descricao = " Seia é uma cidade portuguesa do distrito da Guarda, situada na província da Beira Alta, região do Centro (Região das Beiras) e sub-região da Serra da Estrela, com cerca de 5 300 habitantes.",
                            Desativar = true,
                            Data_imagem = RandomDay(),
                            Imagem = fotogafia
                        },
                        new Municipio()
                        {
                            Nome = "Vila Nova de Foz Côa",
                            Descricao = " Vila Nova de Foz Côa (pós-AO 1990: Vila Nova de Foz Coa), por vezes designada abreviadamente Foz Côa, é uma cidade portuguesa, pertencente ao distrito de Guarda, Região Norte e sub-região do Douro, com cerca de 3 100 habitantes.",
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
