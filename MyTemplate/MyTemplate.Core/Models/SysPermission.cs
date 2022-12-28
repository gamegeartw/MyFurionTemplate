using System.Collections.Generic;
using Furion.DatabaseAccessor;

namespace MyTemplate.Core.Models;

public class SysPermission:Entity
{
    
    public string Title { get; set; }

    public string Description { get; set; }

    public string Slug { get; set; }
    
    public string UrlPath { get; set; }

    
}