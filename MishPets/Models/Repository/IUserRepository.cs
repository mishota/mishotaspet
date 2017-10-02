using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> AllUsers { get; }
        IEnumerable<ApplicationUser> OverexposureUsers { get; }
        ApplicationUser GetUser(string UserId);
        void SaveUser(ApplicationUser applicationUser);
    }
}
