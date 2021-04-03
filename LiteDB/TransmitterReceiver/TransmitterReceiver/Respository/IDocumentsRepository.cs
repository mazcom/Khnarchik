using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransmitterReceiver.Models;

namespace TransmitterReceiver.Respository {
  
  public interface IDocumentsRepository {

    IEnumerable<SessionDocument> GetDocuments();

    Session CreateSession(Guid id, string name);

    SessionDocument CreateDocument(Session session);

    void UpdateDocument(SessionDocument document);
  }
}
