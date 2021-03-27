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

                   
                    try
                    {
                        commentContext.Comments.Add(comment);
                        commentContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ExceptionManager.HandleException(ex);
                        throw new DACException(ex.Message, ex);
                    }


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
           
            List<CommentDTO> commentList = new List<CommentDTO>();
           
            using (BookEventManagementEntities commentContext = new BookEventManagementEntities())
            {
                var comments = commentContext.Comments.Include("Event").Where(comment => comment.EventId == EventId).Select(comment=>comment);

                foreach(var comment in comments)
                {
                    CommentDTO commentDTO = new CommentDTO();
                    EventDTO eventDTO = new EventDTO();
                    EntityConverter.FillDTOFromEntity(comment.Event, eventDTO);
                    commentDTO.Event = eventDTO;
                    EntityConverter.FillDTOFromEntity(comment, commentDTO);
                    commentList.Add(commentDTO);

                }
               
            }
            return commentList;
        }

        public List<CommentDTO> GetAllCommentsOfAUser(string Username)
        {
            List<CommentDTO> commentList = new List<CommentDTO>();
            using (BookEventManagementEntities commentContext = new BookEventManagementEntities())
            {
                var comments = commentContext.Comments.Where(comment => comment.Username==Username.Trim()).Select(comment => comment);

                foreach (var comment in comments)
                {
                    CommentDTO commentDTO = new CommentDTO();
                    EntityConverter.FillDTOFromEntity(comment, commentDTO);
                    commentList.Add(commentDTO);
                }
            }
            return commentList;
        }
    }
}
