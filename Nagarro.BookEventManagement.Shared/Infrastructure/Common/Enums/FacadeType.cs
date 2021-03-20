using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Nagarro.BookEventManagement.BusinessFacades.dll", "Nagarro.BookEventManagement.BusinessFacades.EventFacade")]
        EventFacade = 1,

        [QualifiedTypeName("Nagarro.BookEventManagement.BusinessFacades.dll", "Nagarro.BookEventManagement.BusinessFacades.UserFacade")]
        UserFacade = 2,

        [QualifiedTypeName("Nagarro.BookEventManagement.BusinessFacades.dll", "Nagarro.BookEventManagement.BusinessFacades.BookingEnrollmentFacade")]
        BookingEnrollment = 3,

        [QualifiedTypeName("Nagarro.BookEventManagement.BusinessFacades.dll", "Nagarro.BookEventManagement.BusinessFacades.CommentFacade")]
        CommentFacade = 4




    }
}
