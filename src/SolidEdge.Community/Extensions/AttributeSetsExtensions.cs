using System;
using System.Linq;

namespace SolidEdgeCommunity.Extensions;

public static class AttributeSetsExtensions
{
    /// <summary>
    /// Determine whether the specified AttributeSet exists
    /// </summary>
    /// <param name="attributeSets"></param>
    /// <param name="name"></param>
    /// <param name="stringComparison"></param>
    /// <returns></returns>
    public static bool Exists(this SolidEdgeFramework.AttributeSets attributeSets, string name, StringComparison stringComparison = StringComparison.CurrentCulture)
    {
        if (attributeSets.Count < 1) return false;
            
        return attributeSets.Cast<SolidEdgeFramework.AttributeSet>().Any(attributeSet => attributeSet.SetName.Equals(name, stringComparison));
    }
}