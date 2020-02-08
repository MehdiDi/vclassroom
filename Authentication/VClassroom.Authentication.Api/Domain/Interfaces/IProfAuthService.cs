using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VClassroom.Authentication.Api.Domain.Interfaces
{
    interface IProfAuthService
    {
        string Login();
        string Register();
    }
}
