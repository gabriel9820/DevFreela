using MediatR;

namespace DevFreela.Application.Commands.CreateProjectComment
{
    public class CreateProjectCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
