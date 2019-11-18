using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain {

  public interface IRepository<T> where T : BaseEntity {

    IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    void SaveChanges();
  }
}
