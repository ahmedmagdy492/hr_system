using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_system.Repository
{
    public interface IPhoneNumberService
    {
        void AddPhoneNumber(int employeeId, string phoneNumber);
    }
}
