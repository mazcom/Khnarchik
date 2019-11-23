using AdventureGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Infrastructure {

   public class FakeStateRepository : IStateRepository {

    public void Add(State entity) {
      throw new NotImplementedException();
    }

    public void Delete(State entity) {
      throw new NotImplementedException();
    }

    public IEnumerable<State> FindBy(Expression<Func<State, bool>> predicate) {
      throw new NotImplementedException();
    }

    public IEnumerable<State> GetAll() {

      List<State> states = new List<State>();

      State river = new State() {
        Id = Guid.NewGuid(),
        Number = 50,
        Title = "Река",
        Description = @"Через несколько минут вы достигаете реки. На другом ее берегу разбиты палатки, горят
                        костры, между которыми снуют Гоблины и Орки.",
      };

      states.Add(river);

      State towards = new State() {
        Id = Guid.NewGuid(),
        Number = 272,
        Title = "Лес",
        Description = @"Вы идете по дороге дальше. Начинает смеркаться. Как странно быстро пролетело
                      время. Кажется, что только-только вошел в лес, а уже темно.",
      };

      states.Add(towards);

      states.Add(new State() {
        Id = Guid.NewGuid(),
        Number = 1,
        Title = "Старт",
        Description = @"Вы быстро идете вперед и вскоре оказываетесь в лесу. Даже странно, что о нем
                      рассказывают столько страшных и невероятных историй: таинственный, зачарованный, смножеством ловушек и опасностей.",
        Transitions = { new Transition() { Name = "Вперёд" , To = towards }, new Transition() { Name = "К Реке", To = river } }
      });

      return states;
    }

    public State GetById(Guid id) {
      throw new NotImplementedException();
    }

    public void SaveChanges() {
      throw new NotImplementedException();
    }

    public void Update(State entity) {
      throw new NotImplementedException();
    }
  }
}
