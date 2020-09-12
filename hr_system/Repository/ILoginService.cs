using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_system.Repository
{
    public interface ILoginService
    {
        bool CanLogin(string username, string password);
    }
}
