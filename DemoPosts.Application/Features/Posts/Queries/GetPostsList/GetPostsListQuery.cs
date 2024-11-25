using MediatR;

namespace DemoPosts.Application.Features.Posts.Queries.GetPostsList
{
    public class GetPostsListQuery : IRequest<List<GetPostsListViewModel>>
    {
    }
}
