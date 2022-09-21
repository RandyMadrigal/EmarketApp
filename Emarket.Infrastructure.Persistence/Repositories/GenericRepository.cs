using Emarket.Infrastructure.Persistence.Contexts;

using EmarketApp.Core.Application.Interfaces.Repositoires;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Agregar
        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        //Editar/Actualizar
        public virtual async Task UpdateAsync(Entity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        //Borrar
        public virtual async Task DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        //Obtener todo
        public virtual async Task<List<Entity>> GetAllAsync()
        {
            
            return await _dbContext.Set<Entity>().ToListAsync();

        }

        //Obtener todo w' includes
        public virtual async Task<List<Entity>> GetAllAsyncWithIncludes(List<string> properties)
        {
            var query = _dbContext.Set<Entity>().AsQueryable();

            foreach (string item in properties)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }

       
        //Obtener por Id
        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }


    }

}

