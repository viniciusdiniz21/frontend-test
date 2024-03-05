using CompanyApi.Data.Interface;
using CompanyApi.Domain.Entities;
using CompanyApi.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Data.Repositiorio
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;


        protected Repository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity ObterPorId(int id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }


        public virtual bool Adicionar(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                Db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool Atualizar(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public virtual bool Remover(int id)
        {
            try
            {
                DbSet.Remove(new TEntity { Id = id });
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public virtual bool ExclusaoLogica(TEntity entity)
        {
            entity.Active = false;
            try
            {
                DbSet.Update(entity);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
