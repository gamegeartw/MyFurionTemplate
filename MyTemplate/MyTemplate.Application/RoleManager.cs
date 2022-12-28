using Microsoft.Extensions.Logging;
using MyTemplate.Core.Models;

namespace MyTemplate.Application;

public class RoleManager
{
    private readonly ILogger<RoleManager> _logger;
    private readonly IRepository<SysPermission> _repositoryPermission;
    private readonly IRepository<SysRole> _repository;

    public RoleManager(
        ILogger<RoleManager> logger,
        IRepository<SysPermission> repositoryPermission,
        IRepository<SysRole> repository)
    {
        _logger = logger;
        _repositoryPermission = repositoryPermission;
        _repository = repository;
    }
    
    public Task<SysRole> GetRoleByIdAsync(int id)
    {
        return _repository.FindAsync(id);
    }
    
    public Task<SysRole> GetRoleByNameAsync(string name)
    {
        return _repository.FirstOrDefaultAsync(r => r.Name == name);
    }
    
    /// <summary>
    /// 建立角色
    /// </summary>
    /// <param name="roleName"></param>
    /// <param name="description"></param>
    /// <param name="permissions"></param>
    /// <returns></returns>
    public Task CreateRoleAsync(string roleName,string description,List<SysPermission> permissions=null)
    {
        try
        {
            using (var transaction = _repository.Database.BeginTransaction())
            {
                var role = new SysRole(roleName, description);
        
                _repository.InsertNow(role);
               

                return  transaction.CommitAsync();
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "建立角色失敗");
            return Task.FromException(e);
        }
    }

}