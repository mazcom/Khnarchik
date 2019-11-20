using AdventureGame.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Infrastructure {

  public class StateRepository : IStateRepository, IDisposable {

    private readonly string fullFilePath;

    private Dictionary<Guid, SerializableState> states;

    public StateRepository(string fullFilePath) {

      this.fullFilePath = fullFilePath;
      this.states = new Dictionary<Guid, SerializableState>();
    }

    public IEnumerable<State> GetAll() {

      List<SerializableState> serializableState;
      JsonSerializer serializer = new JsonSerializer();

      using (FileStream stream = File.Open(fullFilePath, FileMode.Open))
      using (var streamReader = new StreamReader(stream))
      using (var jsonTextReader = new JsonTextReader(streamReader)) {
        serializableState = (List<SerializableState>)serializer.Deserialize(jsonTextReader, typeof(List<SerializableState>));
      }

      Dictionary<Guid, State> statesDict = serializableState.ToDictionary(x => x.Id, x => ToDomainState(x));

      foreach (var serState in serializableState) {

        var domainState = statesDict[serState.Id];

        foreach (var trans in serState.Transitions) {
          domainState.Transitions.Add(new Transition() {Name = trans.Name,  To = statesDict[trans.To] });
        }
      }

      return statesDict.Values.AsEnumerable();
    }

    public IEnumerable<State> FindBy(Expression<Func<State, bool>> predicate) {

      throw new NotImplementedException();
    }

    public State GetById(Guid id) {

      throw new NotImplementedException();
    }

    public void Add(State entity) {

      SerializableState serializableState = ToSerializableState(entity);
      states.Add(serializableState.Id, serializableState);
    }

    public void Delete(State entity) {

      if (states.ContainsKey(entity.Id))
        states.Remove(entity.Id);
    }

    public void Update(State entity) {

      throw new NotImplementedException();
    }

    public void SaveChanges() {

      JsonSerializer serializer = new JsonSerializer();
      serializer.NullValueHandling = NullValueHandling.Include;
      serializer.Formatting = Formatting.Indented;

      using (FileStream fs = File.Create(fullFilePath))
      using (StreamWriter sw = new StreamWriter(fs))
      using (JsonWriter jw = new JsonTextWriter(sw)) {
        jw.Formatting = Formatting.Indented;
        serializer.Serialize(jw, states.Values);
      }
    }

    public void Dispose() {
      throw new NotImplementedException();
    }

    protected SerializableState ToSerializableState(State domainModel) {

      var serializableState = new SerializableState() {
        Id = domainModel.Id,
        Number = domainModel.Number,
        Title = domainModel.Title,
        Description = domainModel.Description
      };

      foreach (var trans in domainModel.Transitions)
        serializableState.Transitions.Add(new SerializableTransition() { To = trans.To.Id, Name = trans.Name });

      return serializableState;
    }


    protected State ToDomainState(SerializableState serializableState) {

      var domainState = new State() {
        Id = serializableState.Id,
        Number = serializableState.Number,
        Title = serializableState.Title,
        Description = serializableState.Description
      };

      //foreach (var trans in serializableState.Transitions)
      //  domainState.Transitions.Add(new Transition() { Name = trans.Name });

      return domainState;
    }
  }
}
