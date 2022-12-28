using System;

namespace MyTemplate.Core.Helper;

/// <summary>
/// 常用工具類
/// </summary>
public static class CommonHelper
{
    /// <summary>
    /// 檢查是否擁有指定的權限
    /// </summary>
    /// <param name="value"></param>
    /// <param name="requireLimit"></param>
    /// <returns></returns>
    public static bool CheckLimit<T>(int value,T requireLimit) where T:Enum
    {
        return ((Limit) value).HasFlag(requireLimit);
    }

    /// <summary>
    /// 取得日期文字的表示方式
    /// </summary>
    /// <param name="date">時間</param>
    /// <param name="showTime">顯示時分秒</param>
    /// <returns></returns>
    public static string GetDateString(this DateTime date,bool showTime=false)
    {
        return date.ToString(showTime ? "yyyy-MM-dd HH:mm:ss" : "yyyy-MM-dd");
    }
    
    /// <summary>
    /// 增加權限
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="permission"></param>
    /// <returns></returns>
    public static Limit SetPermission(this Limit limit,Limit permission)
    {
        return limit | permission;
    }
    
    /// <summary>
    /// 移除權限
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="permission"></param>
    /// <returns></returns>
    public static Limit RemovePermission(this Limit limit,Limit permission)
    {
        return limit & ~permission;
    }
}