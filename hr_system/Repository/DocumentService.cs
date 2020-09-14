using hr_system.Data;
using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class DocumentService : IDocumentService
    {
        private readonly HrDbModel _context;

        public DocumentService(HrDbModel context)
        {
            this._context = context;
        }

        public Document Add(Document doc, int docTypeId, int empId)
        {
            doc.EmployeeId = empId;
            doc.DocTypeId = docTypeId;
            var createdDoc = _context.Documents.Add(doc);
            _context.SaveChanges();
            return createdDoc;
        }

        public DocumentType AddType(DocumentType docType)
        {
            var newDocType = _context.DocumentTypes.Add(docType);
            _context.SaveChanges();
            return newDocType;
        }

        public IEnumerable<Document> GetAll(int empId)
        {
            return _context.Documents.Where(d => d.EmployeeId == empId);
        }

        public IEnumerable<DocumentType> GetAllTypes()
        {
            return _context.DocumentTypes;
        }
    }
}