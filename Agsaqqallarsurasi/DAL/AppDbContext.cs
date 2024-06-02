using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Agsaqqallarsurasi.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<Muavin> Muavins { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Aparat> Aparat { get; set; }
        public DbSet<IdareHeyeti> IdareHeyeti { get; set; }
        public DbSet<NezaretKomissiyasi> NezaretKomissiyasi { get; set; }
        public DbSet<RayonSedr> RayonSedr { get; set; }
        public DbSet<Sedr> Sedr { get; set; }

    }
}
