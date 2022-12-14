namespace MyTemplate.Application;

/// <summary>
/// 側邊選單Dto
/// </summary>
[Serializable]
public class MenuItemModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }

    public string Url { get; set; }

    public string Path { get; set; }

    public IEnumerable<MenuItemModel> SubMenuItems { get; set; }
}