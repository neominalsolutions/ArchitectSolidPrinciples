using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core
{
  // stateful
  public interface IReadOnlyRepository<TEntity,TKey>
    where TEntity:class
    where TKey:IComparable
  {

    TEntity FindById(TKey Id);
    IEnumerable<TEntity> Find();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> lamda);
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> lamda);



  }
}
