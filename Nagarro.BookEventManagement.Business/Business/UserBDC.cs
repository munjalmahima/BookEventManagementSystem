using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEventManagement.Shared;

namespace Nagarro.BookEventManagement.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        private readonly IDACFactory dacFactory;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public UserBDC()
            : base(BDCType.UserBDC)
        {
            dacFactory = DACFactory.Instance;
        }

        public UserBDC(IDACFactory dacFactory)
            : base(BDCType.UserBDC)
        {
            this.dacFactory = dacFactory;
        }

        public UserDTO GetUser(int UserId)
        {
            IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
            return userDAC.GetUser(UserId);
        }
        #endregion

        public List<UserDTO> GetUsers()
        {
            IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
            List<UserDTO> result = userDAC.GetUsers();
            return result;
        }

        public OperationResult<UserDTO> NewUser(UserDTO userDTO)
        {
            OperationResult<UserDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<UserValidator, UserDTO>.Validate(userDTO);
                if (validationResult.IsValid)
                {
                    IUserDAC userDAC = (IUserDAC)dacFactory.Create(DACType.UserDAC);
                    UserDTO resultDTO = userDAC.NewUser(userDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<UserDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<UserDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<UserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}

