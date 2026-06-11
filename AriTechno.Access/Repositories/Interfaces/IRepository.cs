namespace AriTechno.Access.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public void Save(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(int id);
    public List<TEntity> GetAll();
    public TEntity GetById(int id);
    public List<TEntity> GetByName(string name);

}
