using MediatR;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDetailsOutputModel?>
    {
        public int Id { get; private set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
