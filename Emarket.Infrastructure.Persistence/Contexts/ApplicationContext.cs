using EmarketApp.Core.Application.Helpers;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Common;
using EmarketApp.Core.Domain.Entiities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Contexts
{
   public class ApplicationContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVm _userVm;

        //Configuracion del constructor para pasar las configuraciones de conexion
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
           _httpContextAccessor = httpContextAccessor;
            _userVm = _httpContextAccessor.HttpContext.Session.Get<UserVm>("user");
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken() )
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>() )
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Autor = _userVm.Name;
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.Email = _userVm.Email;
                        entry.Entity.Phone = _userVm.Telefono;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        

        //Indicando al Context las Entities que se van a utilizar.
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }        
       
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API -Configuracion de la base de datos

            #region tablas
            modelBuilder.Entity<Anuncio>()
                .ToTable("Anuncios");

            modelBuilder.Entity<Category>()
                .ToTable("Categorias");

            modelBuilder.Entity<User>()
                .ToTable("Usuarios");
            

            #endregion


            #region Unique Index

            modelBuilder.Entity<User>()
                .HasIndex(user => user.UserName)
                .IsUnique();

            #endregion

            #region Primary keys
            modelBuilder.Entity<Anuncio>()
                .HasKey(anuncio => anuncio.Id);

            modelBuilder.Entity<Category>()
                .HasKey(category => category.Id);

            modelBuilder.Entity<User>()
               .HasKey(user => user.Id);
            
            
            #endregion


            #region Relationships

            modelBuilder.Entity<Category>()
                .HasMany<Anuncio>(category => category.Anuncios) //Navigation Property de Category en Anuncio
                .WithOne(anuncio => anuncio.Category) //Navigation Property de Anuncio en Category
                .HasForeignKey(anuncio => anuncio.CategoryId) //ForeignKey
                .OnDelete(DeleteBehavior.Cascade); //Borrado

            modelBuilder.Entity<User>()
                .HasMany<Anuncio>(user => user.Anuncios) //Navigation Property de Anuncio en User
                .WithOne(anuncio => anuncio.User) //Navigation Property de User en Anuncio
                .HasForeignKey(anuncio => anuncio.UserId) //ForeignKey
                .OnDelete(DeleteBehavior.Cascade); //Borrado                      

            #endregion

            #region Contraints Anuncio
            modelBuilder.Entity<Anuncio>().Property(anuncio => anuncio.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Anuncio>().Property(anuncio => anuncio.Price)
                .IsRequired();

            #endregion

            #region Contraints Category

            modelBuilder.Entity<Category>().Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(30);
            #endregion

            #region Constraints User

            modelBuilder.Entity<User>().Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<User>().Property(user => user.Apellido)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<User>().Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>().Property(user => user.Phone)
               .IsRequired()
               .HasMaxLength(20);

            modelBuilder.Entity<User>().Property(user => user.UserName)
               .IsRequired()
               .HasMaxLength(30);

            modelBuilder.Entity<User>().Property(user => user.Password)
               .IsRequired();

            #endregion


        }






    }
}
