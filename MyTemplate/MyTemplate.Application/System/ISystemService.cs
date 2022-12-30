using Microsoft.AspNetCore.Html;

namespace MyTemplate.Application;

public interface ISystemService
{

    /// <summary>
    /// 取得側邊選單
    /// </summary>
    /// <returns></returns>
    Task<MenuItemModel[]> GetMenuItemsAsync();

    Task<UserModel> Login(string account, string password);

}