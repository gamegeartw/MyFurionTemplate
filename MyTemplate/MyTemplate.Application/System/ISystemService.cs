using Microsoft.AspNetCore.Html;

namespace MyTemplate.Application;

public interface ISystemService
{
    string GetDescription();

    /// <summary>
    /// 取得側邊選單
    /// </summary>
    /// <param name="activeUrl"></param>
    /// <returns></returns>
    Task<List<MenuItemModel>> GetMenuItemsAsync(string activeUrl);

    Task<UserModel> Login(string account, string password);

}