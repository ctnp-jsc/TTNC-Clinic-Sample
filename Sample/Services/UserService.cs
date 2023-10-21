using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities;

namespace Sample.Services
{
    public class UserService : IUserService
    {
        public string? CurrentUser { get; set; }
    }
}
