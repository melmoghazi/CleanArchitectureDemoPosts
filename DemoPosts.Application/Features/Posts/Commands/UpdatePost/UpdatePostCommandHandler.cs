using AutoMapper;
using DemoPosts.Application.Contracts;
using DemoPosts.Domain;
using MediatR;

namespace DemoPosts.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        //variables
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        //constructor
        public UpdatePostCommandHandler(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //handler
        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post=_mapper.Map<Post>(request);
            await _postRepository.UpdateAsync(post);
        }
    }
}
