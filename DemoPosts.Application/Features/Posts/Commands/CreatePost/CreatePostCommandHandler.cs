using AutoMapper;
using DemoPosts.Application.Contracts;
using DemoPosts.Domain;
using MediatR;

namespace DemoPosts.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        //variables
        public readonly IPostRepository _postRepository;
        public readonly IMapper _mapper;

        //constructor
        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //handler
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            //map
            var post = _mapper.Map<Post>(request);
            //validate
            CreatePostCommandValidator validator = new CreatePostCommandValidator();
            var result = await validator.ValidateAsync(request);
            //check validation errors
            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid.");
            }
            //add
            post = await _postRepository.AddAsync(post);
            //return Guid value
            return post.Id;
        }
    }
}
