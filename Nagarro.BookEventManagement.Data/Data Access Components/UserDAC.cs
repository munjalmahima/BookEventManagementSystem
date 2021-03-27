﻿using Nagarro.BookEventManagement.EntityDataModel;
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

        public UserDTO RegisterUser(UserDTO userDTO)
        {
            UserDTO retVal = null;
            try
            {
                using (BookEventManagementEntities userContext = new BookEventManagementEntities())
                {
                    User u = new User();
                    EntityConverter.FillEntityFromDTO(userDTO, u);

                    try
                    {
                        userContext.Users.Add(u);
                        userContext.SaveChanges();
                    }

                    catch (Exception ex)
                    {
                        ExceptionManager.HandleException(ex);
                        throw new DACException(ex.Message, ex);
                    }

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

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> userList = new List<UserDTO>();
            using (var userContext = new BookEventManagementEntities())
            {
                foreach (var u in userContext.Users)
                {
                    UserDTO userDTO = new UserDTO();
                    EntityConverter.FillDTOFromEntity(u, userDTO);
                    userList.Add(userDTO);
                }
                return userList;
            }
        }

        public UserDTO GetUserById(int UserId)
        {
            UserDTO userDTO = new UserDTO();
            using (var userContext = new BookEventManagementEntities())
            {
                var result = userContext.Users.FirstOrDefault(user => user.Id == UserId);
                if (result != null)
                {
                    EntityConverter.FillDTOFromEntity(result, userDTO);
                }
            }
            return userDTO;
        }

        public UserDTO GetUserByEmailAndPassword(string Email, string Password)
        {
            UserDTO userDTO = new UserDTO();
            using (var userContext = new BookEventManagementEntities())
            {
                var result = userContext.Users.FirstOrDefault(user => user.Email==Email && user.Password==Password);
                if (result != null)
                {
                    EntityConverter.FillDTOFromEntity(result, userDTO);
                }
            }
            return userDTO;
        }
    }
}
