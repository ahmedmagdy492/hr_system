using hr_system.Controllers;
using hr_system.Repository;
using hr_system.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace HrSystemUnitTests.Controllers
{
    [TestFixture]
    public class AddDocumentToDBMethodTests
    {
        private DocumentController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new DocumentController(new DocumentService(new hr_system.Data.HrDbModel()), new EmployeeService(new hr_system.Data.HrDbModel()));
        }

        [Test]
        public void AddDocument_DocumentIsNull_ReturnBadRequestObjcet()
        {
            AddDocumentViewModel model = new AddDocumentViewModel
            {
                Document = null
            };

            var result = _controller.AddDocument(model);

            Assert.That(result, Is.TypeOf<BadRequestErrorMessageResult>());
        }

        [Test]
        public void AddDocument_EmployeeIsNull_ReturnNotFound()
        {
            AddDocumentViewModel model = new AddDocumentViewModel
            {
                Document = new hr_system.Models.Document(),
                EmployeeId = 89012843
            };

            var result = _controller.AddDocument(model);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void AddDocument_DocFileIsNull_ReturnBadRequest()
        {
            AddDocumentViewModel model = new AddDocumentViewModel
            {
                Document = new hr_system.Models.Document(),
                EmployeeId = 89012843,
                DocFile = null
            };

            var result = _controller.AddDocument(model);

            Assert.That(result, Is.TypeOf<BadRequestErrorMessageResult>());
        }
    }
}
