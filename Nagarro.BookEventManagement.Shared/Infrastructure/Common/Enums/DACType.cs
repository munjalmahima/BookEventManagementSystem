namespace Nagarro.BookEventManagement.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEventManagement.Data.dll", "Nagarro.BookEventManagement.Data.EventDAC")]
        EventDAC = 1,

        [QualifiedTypeName("Nagarro.BookEventManagement.Data.dll", "Nagarro.BookEventManagement.Data.UserDAC")]
        UserDAC = 2,

        [QualifiedTypeName("Nagarro.BookEventManagement.Data.dll", "Nagarro.BookEventManagement.Data.BookingEnrollmentDAC")]
        BookingEnrollmentDAC = 3,

        [QualifiedTypeName("Nagarro.BookEventManagement.Data.dll", "Nagarro.BookEventManagement.Data.CommentDAC")]
        CommentDAC = 4

    }
}
