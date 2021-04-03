using LiteDB;
using System;
using System.Collections.Generic;
using System.Threading;
using TransmitterReceiver.Models;

namespace TransmitterReceiver.Respository {

  public class DocumentsRepository : IDocumentsRepository {

    private const string dbName = "MyLite.db";
    private static int DocId = 1;

    public IEnumerable<SessionDocument> GetDocuments() {

      var list = new List<SessionDocument>();

      using (LiteDatabase db = new LiteDatabase($"Filename={dbName}; Connection=shared")) {

        foreach (var doc in db.GetCollection<SessionDocument>().FindAll()) {
          list.Add(doc);
        }

        db.Commit();
      }

      return list;
    }

    public Session CreateSession(Guid id, string name) {

      Session session = new Session(id, name);

      using (LiteDatabase db = new LiteDatabase($"Filename={dbName}; Connection=shared")) {
        db.GetCollection<Session>().Insert(session);
        db.Commit();
      }

      return session;
    }

    public SessionDocument CreateDocument(Session session) {

      SessionDocument doc = new SessionDocument(session, Interlocked.Increment(ref DocId));

      using (LiteDatabase db = new LiteDatabase($"Filename={dbName}; Connection=shared")) {
        db.GetCollection<SessionDocument>().Insert(doc);
        db.Commit();
      }

      return doc;
    }

    public void UpdateDocument(SessionDocument document) {

    }
  }
}
