using Nagarro.BookEventManagement.EntityDataModel;
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Data
{
    public class CommentDAC : DACBase, ICommentDAC
    {
        public CommentDAC()
            : base(DACType.CommentDAC)
        {

        }

        public CommentDTO AddNewComment(CommentDTO commentDTO)
        {
            CommentDTO retVal = null;
            try
            {
                using (BookEventManagementEntities commentContext = new BookEventManagementEntities())
                {
                    Comment comment = new Comment();
                    EntityConverter.FillEntityFromDTO(commentDTO, comment);

                    commentContext.Comments.Add(comment);
                    commentContext.SaveChanges();

                    EntityConverter.FillDTOFromEntity(comment, commentDTO);
                    retVal = commentDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<CommentDTO> GetAllCommentsOfAnEvent(int EventId)
        {
            //EventDTO eventDTO = new EventDTO();

            //List <int> commentIdList= new List<int>();

            List<CommentDTO> commentList = new List<CommentDTO>();
            using (BookEventManagementEntities commentContext = new BookEventManagementEntities())
            {
                var comments = commentContext.Comments.Include("Event").Where(ev => ev.EventId == EventId).Select(ev=>ev);

                foreach(var comment in comments)
                {
                    CommentDTO commentDTO = new CommentDTO();
                    /*Console.WriteLine("Comment Entity");
                    Console.WriteLine(comment.Id);
                    Console.WriteLine(comment.Comment1);
                    Console.WriteLine(comment.EventId);
                    
                    Console.WriteLine("Comment DTO");
                    Console.WriteLine(commentDTO.Id);
                    Console.WriteLine(commentDTO.Comment1);
                    Console.WriteLine(commentDTO.EventId);*/
                    EntityConverter.FillDTOFromEntity(comment, commentDTO);
                    commentList.Add(commentDTO);

                }
               
            }
            return commentList;
        }

        public List<CommentDTO> GetAllCommentsOfAUser(int UserId)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            return comments;
        }
    }
}
