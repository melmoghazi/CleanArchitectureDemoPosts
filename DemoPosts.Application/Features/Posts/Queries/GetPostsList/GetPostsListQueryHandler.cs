﻿using AutoMapper;
using DemoPosts.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPosts.Application.Features.Posts.Queries.GetPostsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<GetPostsListViewModel>>
    {
        //variables
        public readonly IPostRepository _postRepository;
        public readonly IMapper _mapper;
        
        //Constructor
        public GetPostsListQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //Handler
        public async Task<List<GetPostsListViewModel>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllPostsAsync(true);
            return _mapper.Map<List<GetPostsListViewModel>>(allPosts);
            
        }
    }
}
