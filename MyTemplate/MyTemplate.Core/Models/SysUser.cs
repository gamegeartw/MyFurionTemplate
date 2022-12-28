using System.Collections.Generic;
using Furion.DatabaseAccessor;

namespace MyTemplate.Core.Models;

public class SysUser:Entity<string>
{
    public SysUser()
    {
        Roles= new HashSet<SysRole>();
    }
    
    public SysUser(string name, string password)
    {
        Name = name;
        Password = password;
        Roles= new HashSet<SysRole>();
    }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public ICollection<SysRole> Roles { get; set; }
}