using AutoMapper;
using DemoPosts.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPosts.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, GetPostDetailViewModel>
    {
        //variables
        public readonly IPostRepository _postRepository;
        public readonly IMapper _mapper;

        //constructor
        public GetPostDetailQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //Handler
        public async Task<GetPostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var postDetail = await _postRepository.GetByIdAsync(request.PostId);
            return _mapper.Map<GetPostDetailViewModel>(postDetail);
        }
    }
}
