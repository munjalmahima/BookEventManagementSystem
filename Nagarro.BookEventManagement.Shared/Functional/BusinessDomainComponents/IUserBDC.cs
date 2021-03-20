using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IUserBDC : IBusinessDomainComponent
    {
        OperationResult<UserDTO> RegisterUser(UserDTO UserDTO);
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int UserId);
        UserDTO GetUserByEmailAndPassword(string Email, string Password);
    }
}
