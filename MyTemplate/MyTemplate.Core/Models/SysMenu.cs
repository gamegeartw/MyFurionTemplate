using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTemplate.Core.Models;

public class SysMenu:Entity<Guid>,IEntityTypeBuilder<SysMenu>
{
    /// <summary>
    /// 功能選單名稱
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 路徑
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 圖標
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 可用功能
    /// </summary>
    public int Slug { get; set; } 
    public bool Enable { get; set; }
    /// <summary>
    /// 父層選單
    /// </summary>
    public SysMenu Parent { get; set; }
    
    /// <summary>
    /// 子層選單
    /// </summary>
    public ICollection<SysMenu> Children { get; set; }

    public void Configure(EntityTypeBuilder<SysMenu> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.ToTable("SysMenu");
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        entityBuilder.Property(x => x.Url).IsRequired().HasMaxLength(50);
        entityBuilder.Property(x => x.Icon).IsRequired().HasMaxLength(50);
        entityBuilder.Property(x => x.Slug).IsRequired().HasMaxLength(50);
        entityBuilder.Property(x => x.Enable).IsRequired();
        entityBuilder.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey("ParentId");
    }
}