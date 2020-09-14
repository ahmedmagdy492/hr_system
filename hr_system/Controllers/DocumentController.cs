using hr_system.Attributes;
using hr_system.Models;
using hr_system.Repository;
using hr_system.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace hr_system.Controllers
{
    [OAuthAuthorize]
    [RoutePrefix("api")]
    public class DocumentController : ApiController
    {
        private readonly IDocumentService _documentService;
        private readonly IEmployeeService _employeeService;

        public DocumentController(
            IDocumentService documentService,
            IEmployeeService employeeService
            )
        {
            this._documentService = documentService;
            this._employeeService = employeeService;
        }

        // POST /api/Document/docs
        [Route("docs")]
        [HttpPost]
        public IHttpActionResult AddDocument(AddDocumentViewModel model)
        {
            if (model.Document == null) return BadRequest("Object is null");
            if (model.DocFile == null) return BadRequest("Provided Doc File is null");

            var employee = _employeeService.GetById(model.EmployeeId);
            if (employee == null) return NotFound();

            // save the document file to the server /Content/docs directory
            string filePath = Utility.Utility.SaveToDisk(HttpContext.Current, model.DocFile, "~/Content/docs");

            // saving only the image name
            model.Document.DocumentPath = filePath;

            _documentService.Add(model.Document, model.DocTypeId, model.EmployeeId);
            return Ok();
        }

        // POST /api/Document/types
        [Route("types")]
        [HttpPost]
        public IHttpActionResult AddDocumentType([FromBody]DocumentType docType)
        {
            if (docType == null) return BadRequest("Object is null");

            _documentService.AddType(docType);
            return Ok();
        }

        // GET /api/Document/docs
        [Route("docs")]
        [HttpGet]
        public IHttpActionResult GetDocs([FromUri]int empId)
        {
            var employee = _employeeService.GetById(empId);
            if (employee == null) return NotFound();

            return Ok(_documentService.GetAll(empId));
        }

        // GET /api/Document/types
        [Route("types")]
        [HttpGet]
        public IHttpActionResult GetTypes()
        {
            return Ok(_documentService.GetAllTypes().ToList());
        }

        // DELETE /api/Document/docs
        [Route("types")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var doc = _documentService.GetDocById(id);
            if (doc == null) return NotFound();

            // TODO: delete the associated document from the server

            _documentService.DeleteDoc(doc);

            return Ok();
        }
    }
}
