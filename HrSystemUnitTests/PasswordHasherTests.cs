using hr_system.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystemUnitTests
{
    [TestFixture]
    class PasswordHasherTests
    {
        private IPasswordHasher _passwordHasher;

        [SetUp]
        public void Setup()
        {
            _passwordHasher = new Sha256Hasher();
        }

        [Test]
        [TestCase("0123429320", "fe80ac1f696ef39f1d451e6f6ddbd4f3fc936614f5553ea33fc20dd34b2c390e")]
        public void Hash_WhenCalled_HashGivenPasswordToSha256Hash(string password, string expected)
        {
            var result = _passwordHasher.Hash(password);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
