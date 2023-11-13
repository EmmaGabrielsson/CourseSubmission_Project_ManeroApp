using Manero.Contexts;
using Manero.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Manero.Repositories;
public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : class
{

    #region Private fields & Constructors
    private readonly DataContext _dataContext;
    protected Repo(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    #endregion

    #region Tasks for DataContext
    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            await _dataContext.Set<TEntity>().AnyAsync(expression);
            return true;
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return false;
        }
    }
    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return null!;
        }
    }
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _dataContext.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity!;
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return null!;
        }
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return null!;
        }
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _dataContext.Set<TEntity>().Where(expression).ToListAsync();
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return null!;
        }
    }
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return null!;
        }
    }
    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return false;
        }
    }

    #endregion
}
