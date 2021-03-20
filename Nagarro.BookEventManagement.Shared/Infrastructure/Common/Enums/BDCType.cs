namespace Nagarro.BookEventManagement.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEventManagement.Business.dll", "Nagarro.BookEventManagement.Business.EventBDC")]
        EventBDC = 1,

        [QualifiedTypeName("Nagarro.BookEventManagement.Business.dll", "Nagarro.BookEventManagement.Business.UserBDC")]
        UserBDC = 2,

        [QualifiedTypeName("Nagarro.BookEventManagement.Business.dll", "Nagarro.BookEventManagement.Business.BookingEnrollmentBDC")]
        BookingEnrollmentBDC = 3,

        [QualifiedTypeName("Nagarro.BookEventManagement.Business.dll", "Nagarro.BookEventManagement.Business.CommentBDC")]
        CommentBDC = 4


    }
}
