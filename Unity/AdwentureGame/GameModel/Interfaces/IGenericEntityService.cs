using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain.Interfaces {

  public interface IGenericEntityService<T> : IService where T : BaseEntity {

    void Add(T entity);
    void Delete(T entity);
    IEnumerable<T> GetAll();
    void Update(T entity);
  }
}
