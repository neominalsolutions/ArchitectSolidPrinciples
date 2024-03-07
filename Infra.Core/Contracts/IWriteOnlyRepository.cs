using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core
{
  // IWriteOnlyRepository stateless
  // Interface Seggregation
  // Bazı entityle sadece write only olabilir read işlemine tabi tutulmayabilir
  public interface IWriteOnlyRepository<TEntity,TKey> 
    where TEntity:class
    where TKey:IComparable
  {
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TKey Id);
  }
}
