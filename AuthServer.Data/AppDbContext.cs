using AuthServer.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
            /*
             * Yukarıdaki kod bloğu, DbContext sınıfının ModelBuilder nesnesine uygulama yapılandırmalarını ekleyen iki satırdan oluşur.
             * ApplyConfigurationsFromAssembly() yöntemi,
             * belirtilen derlemedeki tüm konfigürasyon sınıflarını (modeli yapılandırmak için kullanılan sınıflar) tespit eder ve bunları ModelBuilder'a ekler.
             * Bu yöntem, Fluent API ayarlarını belirlemek için kullanılan ayrı sınıfların oluşturulmasını sağlar ve veritabanı modeli oluşturulurken kullanılacak olan kuralları ve kısıtlamaları tanımlar.
             * Böylece, veritabanına erişim işlemleri sırasında bu yapılandırmalar etkin hale gelir ve veritabanı işlemleri bu yapılandırmalarla uyumlu olarak gerçekleştirilir.
             */
        }
    }
}