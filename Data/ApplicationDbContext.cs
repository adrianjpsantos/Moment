using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moment.Models.Entity;

namespace Moment.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<ConventionCategory> ConventionCategories { get; set; }
    public DbSet<Convention> Conventions { get; set; }
    public DbSet<ItemPurchase> ItemPurchases { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Inject Data City
        builder.Entity<City>().HasData(new City
        {
            Id = Guid.NewGuid(),
            Name = "Macatuba",
            State = "SP"
        }, new City
        {
            Id = Guid.NewGuid(),
            Name = "Barra Bonita",
            State = "SP"
        }, new City
        {
            Id = Guid.NewGuid(),
            Name = "Igaraçu do Tiête",
            State = "SP"
        }, new City
        {
            Id = Guid.NewGuid(),
            Name = "Jau",
            State = "SP"
        }
        , new City
        {
            Id = Guid.NewGuid(),
            Name = "Pederneiras",
            State = "SP"
        }, new City
        {
            Id = Guid.NewGuid(),
            Name = "Lençois Paulista",
            State = "SP"
        });
        #endregion
        
        #region Inject Data Categories
        builder.Entity<ConventionCategory>().HasData(
            new ConventionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Festas e Shows",
                Description = "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!",
                ImagePath = @"\img\conventionCategory\festaseshows.jpg"
            },
            new ConventionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Teatros e Espetáculos",
                Description = "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.",
                ImagePath = @"\img\conventionCategory\teatroseespetaculos.jpg"
            },
            new ConventionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Stand up Comedy",
                Description = "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!",
                ImagePath = @"\img\conventionCategory\standupcomedy.jpg"
            },
            new ConventionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Tecnologia",
                Description = "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.",
                ImagePath = @"\img\conventionCategory\tecnologia.jpg"
            },
            new ConventionCategory
            {
                Id = Guid.NewGuid(),
                Name = "Passeios e Tours",
                Description = "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.",
                ImagePath = @"\img\conventionCategory\passeiosetours.jpg"
            }
        );

        #endregion
    }

}
