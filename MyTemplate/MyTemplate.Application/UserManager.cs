using System.Security.Claims;
using MyTemplate.Core.Models;

namespace MyTemplate.Application;

public class UserManager:ITransient
{
    private readonly IRepository<SysPermission> _permissionRepository;
    private readonly IRepository<SysRole> _roleRepository;
    private readonly IRepository<SysUser> _userRepository;

    public UserManager(
        IRepository<SysPermission> permissionRepository,
        IRepository<SysRole> roleRepository,
        IRepository<SysUser> userRepository)
    {
        _permissionRepository = permissionRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
    }
    

    /// <summary>
    /// 加入角色
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public Task AddRoleAsync(string userId,string roleId)
    {
        var user= _userRepository.Where(m=>m.Id==userId).Include(m=>m.Roles).First();
        if(user.Roles.All(m => m.Id !=roleId))
        {
            var role = _roleRepository.Find(roleId);
            user.Roles.Add(role);
            return _userRepository.UpdateAsync(user);
        }
        
        return Task.CompletedTask;
    }

    /// <summary>
    /// 移除角色
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public Task RemoveRoleAsync(string userId,string roleId)
    {
        var user= _userRepository.Where(m=>m.Id==userId).Include(m=>m.Roles).First();
        var role = user.Roles.FirstOrDefault(m => m.Id == roleId);
        if(role!=null)
        {
            user.Roles.Remove(role);
            return _userRepository.UpdateAsync(user);
        }
        
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// 登入
    /// </summary>
    /// <param name="account"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="AppFriendlyException"></exception>
    public async Task<List<Claim>> LoginAsync(string account, string password)
    {
        var user =await _userRepository.FirstOrDefaultAsync(m => m.Name == account) ?? await _userRepository.FirstAsync(m => m.Email == account);

        if (password.Equals(user.Password, StringComparison.CurrentCultureIgnoreCase) )
        {
            throw Oops.Bah("密碼錯誤");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Role, user.Roles.Select(m => m.Name).Aggregate((a, b) => a + "," + b))
        };
        return claims;
    }
    
    public Task RegisterAsync(string account,string email, string password)
    {
        var user = new SysUser
        {
            Name = account,
            Password = password,
            Email = email,
            Roles = new List<SysRole>
            {
                _roleRepository.Where(m => m.Name == "User").First()
            }
        };
        return _userRepository.InsertAsync(user);
    }
    
    public void UpdatePassword(string userId,string password)
    {
        var user = _userRepository.Find(userId);
        user.Password = password;
        _userRepository.Update(user);
    }
    
    public Task UpdatePasswordAsync(string userId,string password)
    {
        var user = _userRepository.Find(userId);
        user.Password = password;
        return _userRepository.UpdateAsync(user);
    }
    
    public Task SetPermission(string userId,string permission)
    {
        var user = _userRepository.Find(userId);
        var permissionList = permission.Split(',').Select(m => _permissionRepository.Find(m)).ToList();
        
        return _userRepository.UpdateAsync(user);
    }
}