namespace MyTemplate.Application;

public class UserModel
{
    public UserModel()
    {
        this.Roles = new List<RoleModel>();
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IEnumerable<RoleModel> Roles { get; set; }
}

public class RoleModel
{
    public string RoleId { get; set; }
    public string RoleName { get; set; }
}