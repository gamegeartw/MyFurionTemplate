using System;

namespace MyTemplate.Core;

[Flags]
public enum Limit
{
    /// <summary>
    /// 讀取
    /// </summary>
    Read=1,
    /// <summary>
    /// 寫入
    /// </summary>
    Write=2,
    /// <summary>
    /// 刪除
    /// </summary>
    Delete=4,
    /// <summary>
    /// 全部權限
    /// </summary>
    All=Read|Write|Delete
}