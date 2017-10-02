using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishPets.Models;

namespace MishPets.Models.Repository
{
    public interface IKindOfPetPepository
    {
        IEnumerable<KindOfPet> AllKinds { get; }
        Task<KindOfPet> GetKind(int KindOfPetId);
    }
}
