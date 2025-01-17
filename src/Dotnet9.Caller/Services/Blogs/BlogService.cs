﻿namespace Dotnet9.Caller.Services.Blogs;

public class BlogService : HttpClientCallerBase
{
    protected override string Prefix { get; set; } = "/api/blogs";
    protected override string BaseAddress { get; set; }

    public BlogService(IOptions<ServiceCallerOptions> option)
    {
        BaseAddress = option.Value.BaseAddress;
    }

    protected override void UseHttpClientPost(MasaHttpClientBuilder masaHttpClientBuilder)
    {
        masaHttpClientBuilder.AddMiddleware<RealIpMiddleware>();
    }

    public async Task<GetBlogListByKeywordsResponse?> GetBlogBriefListByKeywordsAsync(
        string? keywords, int pageSize = 10,
        int current = 1)
    {
        var url = $"search?";
        if (!keywords.IsNullOrWhiteSpace())
        {
            url += $"keywords={WebUtility.UrlEncode(keywords)}";
            url += "&";
        }

        url += $"page={current}&pageSize={pageSize}";
        return await Caller.GetAsync<GetBlogListByKeywordsResponse>(url);
    }

    public async Task<List<BlogArchive>?> GetArchivesAsync()
    {
        return await Caller.GetAsync<List<BlogArchive>>("archives");
    }

    public async Task<List<BlogBrief>?> GetRecommendAsync()
    {
        return await Caller.GetAsync<List<BlogBrief>>("recommend");
    }

    public async Task<List<BlogBrief>?> GetHistoryHotAsync()
    {
        return await Caller.GetAsync<List<BlogBrief>>("historyhot");
    }

    public async Task<List<BlogBrief>?> GetWeekHotAsync()
    {
        return await Caller.GetAsync<List<BlogBrief>>("weekhot");
    }

    public async Task<List<BlogSearchCountDto>?> GetTopKeywordsAsync()
    {
        return await Caller.GetAsync<List<BlogSearchCountDto>>("topkeywords");
    }

    public async Task<BlogDetails?> GetBlogDetailsBySlugAsync(string slug)
    {
        return await Caller.GetAsync<BlogDetails>(slug);
    }

    public async Task<BlogCountBrief?> GetBlogCountBriefAsync()
    {
        return await Caller.GetAsync<BlogCountBrief>("countBrief");
    }
}