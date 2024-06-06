using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;


namespace Agsaqqallarsurasi.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<Muavin> Muavins { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Aparat> Aparat { get; set; }
        public DbSet<IdareHeyeti> IdareHeyeti { get; set; }
        public DbSet<NezaretKomissiyasi> NezaretKomissiyasi { get; set; }
        public DbSet<RayonSedr> RayonSedr { get; set; }
        public DbSet<Sedr> Sedr { get; set; }
        public DbSet<Surasedr> SuraSedr { get; set; }
        public DbSet<Congrats> Congrats { get; set; }
        public DbSet<RayonMuavin> RayonMuavins { get; set; }
        public DbSet<RayonHeyet> RayonHeyets { get; set; }

    }
}
