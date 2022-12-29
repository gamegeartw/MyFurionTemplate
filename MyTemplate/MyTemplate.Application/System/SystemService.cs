using Furion.JsonSerialization;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Logging;
using MyTemplate.Core.Models;

namespace MyTemplate.Application;

public class SystemService : ISystemService, ITransient
{
    private readonly IRepository<SysMenu> _sysMenuRepository;
    private readonly ILogger<SystemService> _logger;

    public SystemService(
        IRepository<SysMenu> sysMenuRepository,
        ILogger<SystemService> logger)
    {
        _sysMenuRepository = sysMenuRepository;
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
    public Task<List<MenuItemModel>> GetMenuItemsAsync(string activeUrl)
    {
        var result = new List<MenuItemModel>();
        // TODO 取得側邊選單資料, 並設定 activeUrl

        var menus = _sysMenuRepository.Entities.ProjectToType<MenuItemModel>().ToList();
        
        return Task.FromResult(menus);
    }
    
    public Task<UserModel> Login(string account, string password)
    {
        var result = new UserModel();
        // TODO 登入驗證, 並取得使用者資料
           
        return Task.FromResult(result);
    }

}