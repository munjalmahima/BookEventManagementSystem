using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface ICommentBDC:IBusinessDomainComponent
    {
        OperationResult<CommentDTO> AddNewComment(CommentDTO commentDTO);
        List<CommentDTO> GetAllCommentsOfAUser(string Username);
        List<CommentDTO> GetAllCommentsOfAnEvent(int EventId);
    }
}
