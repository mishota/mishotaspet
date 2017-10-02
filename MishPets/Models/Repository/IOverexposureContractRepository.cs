using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishPets.Models.Repository
{
    public interface IOverexposureContractRepository
    {
        IEnumerable<OverexposureContract> AllOverexposureContracts { get; }
        IEnumerable<OverexposureContract> UsersOverexposureContracts(string UserId);
        Task<OverexposureContract> GetOverexposureContract(int OverexposureContractId);
        void SaveOverexposureContract(OverexposureContract OverexposureContract, string UserId);
        Task<OverexposureContract> DeleteOverexposureContract(int OverexposureContractId);
    }
}
