using hr_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_system.Repository
{
    public interface IRegisterService
    {
        bool CanRegister(RegisterViewModel model);
        bool Register(RegisterViewModel model);
    }
}
