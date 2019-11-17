using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain.Interfaces {

  public interface IStateRepository : IRepository<State> {

    State GetById(int id);
  }
}
