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
  
  public class Receiver {

    private readonly IDocumentsRepository documentsRepository;

    public Receiver() {

      documentsRepository = new DocumentsRepository();
    }

    public IEnumerable<SessionDocument> GetDocuments() {

      return documentsRepository.GetDocuments();
    }
  }
}
