using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Users
{
    public interface IUser
    {
        string UserName { get; }
        string Email { get; }
        string Name { get; }
        string Surname { get; }
        bool EmailConfirmed { get; }
        string PhoneNumber { get; }
        bool PhoneNumberConfirmed { get; }
    }
}
