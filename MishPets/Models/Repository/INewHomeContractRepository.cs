using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public interface INewHomeContractRepository
    {
        IEnumerable<NewHomeContract> AllNewHomeContracts { get; }
        Task<NewHomeContract> GetNewHomeContract(int NewHomeContractId);
        void SaveNewHomeContract(NewHomeContract NewHomeContract, string UserId);
        Task<NewHomeContract> DeleteNewHomeContract(int NewHomeContractId);
    }
}
