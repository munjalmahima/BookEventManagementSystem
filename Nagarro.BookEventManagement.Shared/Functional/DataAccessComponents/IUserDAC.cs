using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        UserDTO NewUser(UserDTO UserDTO);
        List<UserDTO> GetUsers();
        UserDTO GetUser(int UserId);

    }
}
