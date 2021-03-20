using System;
using Nagarro.BookEventManagement.Shared;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.BusinessFacades
{
    class UserFacade:FacadeBase,IUserFacade
    {
        public UserFacade()
            : base(FacadeType.UserFacade)
        {

        }

        public UserDTO GetUserById(int UserId)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetUserById(UserId);
        }

        public List<UserDTO> GetAllUsers()
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            List<UserDTO> result = userBDC.GetAllUsers();
            return result;
        }

        public OperationResult<UserDTO> RegisterUser(UserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.RegisterUser(userDTO);
        }

        public UserDTO GetUserByEmailAndPassword(string Email, string Password)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetUserByEmailAndPassword(Email,Password);
        }
    }
}
