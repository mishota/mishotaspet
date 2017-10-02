using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MishPets.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MishPets.Models.Repository
{
    public class KindOfPetRepository: IKindOfPetPepository
    {
        private ApplicationDbContext _context;
        private DbSet<KindOfPet> _KindOfPets;

        public KindOfPetRepository(ApplicationDbContext context)
        {
            _context = context;
            _KindOfPets = _context.KindOfPets;
        }

        public IEnumerable<KindOfPet> AllKinds { get { return _KindOfPets; } }

        public async Task<KindOfPet> GetKind(int KindOfPetId)
        {
            return await _KindOfPets.FindAsync(KindOfPetId);
        }
    }
}