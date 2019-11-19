using AdventureGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Infrastructure {

  class StateRepository : IStateRepository, IDisposable {
    
    private readonly string fullFilePath;

    private Dictionary<Guid, SerializableState> states;

    public StateRepository(string fullFilePath) {

      this.fullFilePath = fullFilePath;
      this.states = new Dictionary<Guid, SerializableState>();
    }

    public IEnumerable<State> GetAll() {

      throw new NotImplementedException();
    }

    public IEnumerable<State> FindBy(Expression<Func<State, bool>> predicate) {

      throw new NotImplementedException();
    }

    public State GetById(Guid id) {

      throw new NotImplementedException();
    }

    public void Add(State entity) {

      SerializableState serializableState = ToSerializableState(entity);
      serializableState.SerialisationKey = Guid.NewGuid();

      //this.states.Add(entity.Id, entity);

      throw new NotImplementedException();
    }

    public void Delete(State entity) {

      throw new NotImplementedException();
    }

    public void Update(State entity) {

      throw new NotImplementedException();
    }

    public void SaveChanges() {

      throw new NotImplementedException();
    }

    public void Dispose() {
      throw new NotImplementedException();
    }

    protected SerializableState ToSerializableState(State domainModel) {

      return new SerializableState() {
        Id = domainModel.Id,
        Title = domainModel.Title,
        Description = domainModel.Description
      };

    }
  }
}
