using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepositorySearch<TModel, TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TModel, bool>> predicate);
    }
}

/*
 * Why are we using 'Expression'? 
 * The reason is that we want to efficiently work with the database. 
 * If we use 'Func<TModel, bool>', the filtering would happen in memory, 
 * meaning all the records would be fetched from the database first, and 
 * then filtered within the application.

 * However, by using 'Expression', the query is translated into an expression 
 * that the ORM (like Entity Framework) converts into SQL. This way, the filtering 
 * is performed directly in the database, returning only the records that meet 
 * the condition. This approach reduces the amount of data transferred and 
 * optimizes the performance of the application.
 */