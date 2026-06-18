using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database;
using Microsoft.EntityFrameworkCore;

namespace AriTechno.Access.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AriTechnoDB _ariTechnoDB;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AriTechnoDB ariTechnoDB)
    {
        _ariTechnoDB = ariTechnoDB;
        _dbSet = _ariTechnoDB.Set<TEntity>();
    }
    public void Save(TEntity entity)
    {
        _dbSet.Add(entity);
        _ariTechnoDB.SaveChanges();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public List<TEntity> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
