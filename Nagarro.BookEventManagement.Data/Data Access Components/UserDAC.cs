using Nagarro.BookEventManagement.EntityDataModel;
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
           : base(DACType.UserDAC)
        {

        }

        public UserDTO NewUser(UserDTO userDTO)
        {
            UserDTO retVal = null;
            try
            {
                using (BookEventManagementEntities dbContext = new BookEventManagementEntities())
                {
                    User u = new User();
                    EntityConverter.FillEntityFromDTO(userDTO, u);

                    dbContext.Users.Add(u);
                    dbContext.SaveChanges();

                    EntityConverter.FillDTOFromEntity(u, userDTO);
                    retVal = userDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> userList = new List<UserDTO>();
            using (var context = new BookEventManagementEntities())
            {
                foreach (var u in context.Users)
                {
                    UserDTO userDTO = new UserDTO();
                    EntityConverter.FillDTOFromEntity(u, userDTO);
                    userList.Add(userDTO);
                }
                return userList;
            }
        }

        public UserDTO GetUser(int UserId)
        {
            UserDTO userDTO = new UserDTO();
            List<UserDTO> userList = GetUsers();
            foreach (var a in userList)
            {
                if (a.Id == UserId)
                {
                    EntityConverter.FillDTOFromEntity(a,userDTO);
                }
            }
            return userDTO;
        }


    }
}
