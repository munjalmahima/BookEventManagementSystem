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

        public UserDTO GetUser(int UserId)
        {

            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetUser(UserId);
        }

        public List<UserDTO> GetUsers()
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            List<UserDTO> result = userBDC.GetUsers();
            return result;
        }

        public OperationResult<UserDTO> NewUser(UserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.NewUser(userDTO);
        }

    }
}
