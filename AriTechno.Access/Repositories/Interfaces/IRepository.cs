namespace AriTechno.Access.Repositories.Interfaces;

internal interface IRepository<TEntity> where TEntity : class
{
    public void Save(string name, string description);
    public void Update(int id, string name, string description);
    public void Delete(int id);
    public List<TEntity> GetAll();
    public TEntity GetById(int id);
    public List<TEntity> GetByName(string name);

}
