using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MishPets.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;



namespace MishPets.Models.Repository
{
    public class UserRepository: IUserRepository
    {
        private ApplicationDbContext _context;
        private System.Data.Entity.IDbSet<ApplicationUser> _ApplicationUsers;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _ApplicationUsers = _context.Users;
        }
        public IEnumerable<ApplicationUser> AllUsers { get { return _ApplicationUsers; } }
        public IEnumerable<ApplicationUser> OverexposureUsers { get { return _ApplicationUsers.Where(u => u.FlagОverexposure == 1); } }
        public ApplicationUser GetUser(string UserId)
        {
            return _ApplicationUsers.Find(UserId);
        }

        public void SaveUser(ApplicationUser applicationUser)
        {
            _context.Entry(applicationUser).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}