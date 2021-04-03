using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmitterReceiver.Models {
  
  public class SessionDocument {

    public SessionDocument() {

    }

    public SessionDocument(Session session, int id) {

      Session = session;
      Id = id;
    }

    public Session Session { get; set; }

    public int Id { get; set; }
  }
}
