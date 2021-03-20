using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface ICommentDAC : IDataAccessComponent
    {
        CommentDTO AddNewComment(CommentDTO commentDTO);
        List<CommentDTO> GetAllCommentsOfAUser(int UserId);
        List<CommentDTO> GetAllCommentsOfAnEvent(int EventId);
    }
}
