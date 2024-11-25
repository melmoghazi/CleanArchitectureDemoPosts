using AutoMapper;
using DemoPosts.Application.Contracts;
using MediatR;

namespace DemoPosts.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        //variables
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        //constructor
        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //handler
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            await _postRepository.DeleteAsync(post);
        }
    }
}
