using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EditorWindows;

public static class TypeEx
{
    /// <summary>
    /// 获取编辑器下的所有窗口
    /// </summary>
    /// <param name="self">编辑器的类型</param>
    /// <returns></returns>
    public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
    {
        return AppDomain.CurrentDomain.GetAssemblies() //找到CurrentDomain区域下的所有EditorWindow
            .Where(assembly => assembly.FullName.StartsWith("Assembly"))
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(self));
    }

    /// <summary>
    /// 获取编辑器下的指定Attribute的窗口
    /// </summary>
    /// <param name="self">编辑器的类型</param>
    /// <typeparam name="TClassAttribute">Attribute的泛型</typeparam>
    /// <returns></returns>
    public static IEnumerable<Type> GetSubTypesWithClassAttribute<TClassAttribute>(this Type self)
        where TClassAttribute : Attribute
    {
        return GetSubTypesInAssemblies(self)
            .Where(type => type.GetCustomAttribute<TClassAttribute>() != null);
    }
}