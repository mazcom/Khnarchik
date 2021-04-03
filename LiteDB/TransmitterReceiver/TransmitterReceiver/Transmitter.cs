using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransmitterReceiver.Respository;
using LiteDB;
using TransmitterReceiver.Models;

namespace TransmitterReceiver {
  
  public class Transmitter {

    private static int GlobalId = 1;

    private readonly IDocumentsRepository documentsRepository;

    public Transmitter() {

      documentsRepository = new DocumentsRepository();
    }

    public Session CreatSession() {

      return documentsRepository.CreateSession(Guid.NewGuid(), "session" + Interlocked.Increment(ref GlobalId).ToString());
    }

    public SessionDocument CreateDocument(Session session) {

      return documentsRepository.CreateDocument(session);
    }

    public void UpdateDocument(int docId) {

    }
  }
}
