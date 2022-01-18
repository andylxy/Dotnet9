﻿using AutoMapper;
using Dotnet9.Albums;
using Dotnet9.Blogs;
using Dotnet9.Categories;
using Dotnet9.Tags;

namespace Dotnet9.Blazor;

public class Dotnet9BlazorAutoMapperProfile : Profile
{
    public Dotnet9BlazorAutoMapperProfile()
    {
        CreateMap<AlbumDto, UpdateAlbumDto>();
        CreateMap<BlogPostDto, UpdateBlogPostDto>();
        CreateMap<CategoryDto, UpdateCategoryDto>();
        CreateMap<TagDto, UpdateTagDto>();
    }
}