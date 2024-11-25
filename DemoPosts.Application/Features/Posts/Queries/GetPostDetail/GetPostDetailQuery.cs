using MediatR;

namespace DemoPosts.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQuery : IRequest<GetPostDetailViewModel>
    {
        public Guid PostId { get; set; }
    }
}
