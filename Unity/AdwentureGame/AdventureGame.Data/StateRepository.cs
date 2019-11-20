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

  public class JsonStateRepository : IStateRepository {

    private readonly string fullFilePath;
    private Dictionary<Guid, SerializableState> states;
    private readonly Stream outerStream;

    public JsonStateRepository(string fullFilePath) : this(stream: null) {

      this.fullFilePath = fullFilePath;
    }

    public JsonStateRepository(Stream stream) {

      this.outerStream = stream;
      this.states = new Dictionary<Guid, SerializableState>();
    }

    public IEnumerable<State> GetAll() {

      List<SerializableState> serializableState;
      JsonSerializer serializer = new JsonSerializer();

      Stream stream = null;

      try {

        if (outerStream != null && outerStream.Length > 0) {
          outerStream.Position = 0;
          stream = outerStream;
        }
        else
          stream = File.Open(fullFilePath, FileMode.Open);

        using (var streamReader = new StreamReader(stream, encoding: Encoding.Default, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: outerStream != null))
        using (var jsonTextReader = new JsonTextReader(streamReader)) {
          serializableState = (List<SerializableState>)serializer.Deserialize(jsonTextReader, typeof(List<SerializableState>));
        }
      }
      finally {
        if (outerStream == null && stream != null)
          stream.Close();
      }

      Dictionary<Guid, State> statesDict = serializableState.ToDictionary(x => x.Id, x => ToDomainState(x));

      foreach (var serState in serializableState) {

        var domainState = statesDict[serState.Id];

        foreach (var trans in serState.Transitions) {
          domainState.Transitions.Add(new Transition() { Name = trans.Name, To = statesDict[trans.To] });
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

      Stream stream = null;

      try {
        stream = outerStream ?? File.Create(fullFilePath);
        using (StreamWriter sw = new StreamWriter(stream, encoding: Encoding.Default, bufferSize: 1024, leaveOpen: true))
        using (JsonWriter jw = new JsonTextWriter(sw)) {
          jw.Formatting = Formatting.Indented;
          serializer.Serialize(jw, states.Values);
        }
      }
      finally {
        if (outerStream == null && stream != null)
          stream.Close();
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

      return domainState;
    }
  }
}
