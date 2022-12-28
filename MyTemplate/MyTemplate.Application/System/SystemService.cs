using Furion.JsonSerialization;
using Microsoft.Extensions.Logging;

namespace MyTemplate.Application;

public class SystemService : ISystemService, ITransient
{
    private readonly ILogger<SystemService> _logger;

    public SystemService(ILogger<SystemService> logger)
    {
        _logger = logger;
    }
    public string GetDescription()
    {
        return "让 .NET 开发更简单，更通用，更流行。";
    }

    /// <summary>
    /// 取得側邊選單
    /// </summary>
    /// <param name="activeUrl"></param>
    /// <returns></returns>
    public Task<List<MenuItemModel>> GetAdminMenuItemsAsync(string activeUrl)
    {
        var result = new List<MenuItemModel>();
        // TODO 取得側邊選單資料, 並設定 activeUrl,目前還在考慮是用DB還是用XML管理
        
        
        return Task.FromResult(result);
    }
    
    public Task<UserModel> Login(string account, string password)
    {
        var result = new UserModel();
        // TODO 登入驗證, 並取得使用者資料
           
        return Task.FromResult(result);
    }

}