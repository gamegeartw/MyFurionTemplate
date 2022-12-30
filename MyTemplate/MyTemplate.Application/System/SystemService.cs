using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTemplate.Core.Models;

namespace MyTemplate.Application;

/// <inheritdoc />
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
    
    /// <summary>
    /// 取得側邊選單
    /// </summary>
    /// <returns></returns>
    public Task<MenuItemModel[]> GetMenuItemsAsync()
    {
        if (App.WebHostEnvironment.IsDevelopment())
        {
            return Task.FromResult(GetTestModel().ToArray());
        }

        return Task.FromResult(_sysMenuRepository.Entities.ProjectToType<MenuItemModel>().ToArray());

    }

    /// <summary>
    /// 假的選單資料
    /// </summary>
    /// <returns></returns>
    private IEnumerable<MenuItemModel> GetTestModel()
    {
        return new List<MenuItemModel>
        {
            new()
            {
                Title = "首頁",
                Icon = "fa fa-home",
                Url = "/Admin/main",
            },
            new()
            {
                Title = "測試Group",
                Icon = "fa fa-list",
                Url = "#",
                SubMenuItems = new List<MenuItemModel>
                {
                    new()
                    {
                        Title = "測試頁面",
                        Icon = "fa fa-circle-o",
                        Url = "/Admin/Main2",
                    },
                    new()
                    {
                        Title = "測試第二層選單",
                        Icon = "fa fa-list",
                        Url = "#",
                        SubMenuItems = new[]
                        {
                            new MenuItemModel
                            {
                                Title = "測試頁面2",
                                Icon = "fa fa-circle-o",
                                Url = "/Admin/Main3",
                            }
                        }
                    },
                }

            }
        };
    }

    public Task<UserModel> Login(string account, string password)
    {
        var result = new UserModel();
        // TODO 登入驗證, 並取得使用者資料
           
        return Task.FromResult(result);
    }

}