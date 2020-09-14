using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_system.Repository
{
    public interface IDocumentService
    {
        Document Add(Document doc, int docType, int empId);
        IEnumerable<Document> GetAll(int empId);
        DocumentType AddType(DocumentType docType);
        IEnumerable<DocumentType> GetAllTypes();
        void DeleteDoc(Document doc);
        Document GetDocById(int id);
    }
}
