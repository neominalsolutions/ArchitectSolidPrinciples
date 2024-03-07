using Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infra.Core.Contracts
{
  public class EFUnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
  {
    private readonly TContext context;
    public EFUnitOfWork(TContext context)
    {
      this.context = context;
    }

    public void AutoSave()
    {
      try
      {
        this.context.SaveChanges();
        // auto commit olur
      }
      catch (Exception)
      {
        // auto rollbak
        throw;
      }
    }


    public void Save()
    {
      // Disposable olarak çalışmak için
      // IDisposable ile using aynı şekilde çalışıyor
      using (var tran = this.context.Database.BeginTransaction())
      {
        try
        {

          this.context.SaveChanges();
          tran.Commit(); // burda savechanges işlemi transaction scope da olduğu için tran.commit kodunu bekler
        }
        catch (Exception ex)
        {
          var entries =  this.context.ChangeTracker.Entries();

          foreach (EntityEntry item in entries)
          {
            if(item.State == EntityState.Modified)
            {
              // var propEntry = item.Property("Name");
              // object currentValue = propEntry.CurrentValue;
            }
          }

          tran.Rollback();
        }

      }


    }


  }
}
