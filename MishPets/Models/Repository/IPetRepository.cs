using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishPets.Models;

namespace MishPets
{
    public interface IPetRepository
    {
        IEnumerable<Pet> AllPets { get; }
        IEnumerable<Pet> HomelessPets { get; }
        IEnumerable<Pet> ForOverexposurePets { get; }
        IEnumerable<Pet> FilterPets(string kind, string male, string age);
        IEnumerable<Pet> SearchPets(string term);
        Task<Pet> GetPet(int PetId);
        void SavePet(Pet Pet, int PetId);
        Task<Pet> DeletePet(int PetId);
    }
}
