using System.Collections.Generic;
using Furion.DatabaseAccessor;

namespace MyTemplate.Core.Models;

public class SysRole:Entity<string>
{
    public SysRole()
    {
        
    }
    public SysRole(string name, string description)
    {
        Name = name;
        Description = description;
        Users = new HashSet<SysUser>();
        SysPermissions= new HashSet<SysPermission>();
        MenuItems = new HashSet<SysMenu>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<SysUser> Users { get; set; }
    public ICollection<SysPermission> SysPermissions { get; set; }
    
    public ICollection<SysMenu> MenuItems { get; set; }
}
