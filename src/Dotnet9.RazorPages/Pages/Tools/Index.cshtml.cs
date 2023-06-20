

namespace Dotnet9.RazorPages.Pages.Tools;

public class IndexModel : PageModel
{
    public List<ToolItem>? Items;

    public async Task OnGet([FromServices] ISystemClientService systemClientService)
    {
        var siteInfo  = await systemClientService.GetSiteInfoAsync();
        Items = new List<ToolItem>()
        {
            new("ʱ���", $"{siteInfo?.AssetsRemotePath}/tools/timestamp.png", "ʱ���ת����ҳ��ʹ��Blazor�������ʱ�޷�����", "/tools/timestamp", 0)
        };
    }
}