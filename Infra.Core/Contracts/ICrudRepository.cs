using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core
{
  // Crud Repo hem read hemde write özellikleri için var
  public interface ICrudRepository<TEntity,TKey>:IReadOnlyRepository<TEntity,TKey>,IWriteOnlyRepository<TEntity,TKey>
    where TEntity:class
    where TKey:IComparable
  {
  }
}
