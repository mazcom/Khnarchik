using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain.Core {

  public interface IRepository<T> where T : StateBase {

    T GetById(int id);
    IEnumerable<T> List();
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    void SaveChanges();
  }
}
