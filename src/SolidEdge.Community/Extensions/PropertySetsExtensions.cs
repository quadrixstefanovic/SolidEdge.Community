using System;
using System.Collections.Generic;

namespace SolidEdgeCommunity.Extensions
{
    /// <summary>
    /// SolidEdgeFileProperties.PropertySets extensions.
    /// </summary>
    public static class PropertySetsExtensions
    {
        ///// <summary>
        ///// Returns all property sets as an IEnumerable.
        ///// </summary>
        ///// <param name="propertySets"></param>
        //public static IEnumerable<SolidEdgeFileProperties.Properties> AsEnumerable(this SolidEdgeFileProperties.PropertySets propertySets)
        //{
        //    List<SolidEdgeFileProperties.Properties> list = new List<SolidEdgeFileProperties.Properties>();

        //    foreach (var properties in propertySets)
        //    {
        //        list.Add((SolidEdgeFileProperties.Properties)properties);
        //    }

        //    return list.AsEnumerable();
        //}

        /// <summary>
        /// Closes an open document with the option to save changes.
        /// </summary>
        /// <param name="propertySets"></param>
        /// <param name="saveChanges"></param>
        public static void Close(this SolidEdgeFileProperties.PropertySets propertySets, bool saveChanges)
        {
            if (saveChanges)
            {
                propertySets.Save();
            }

            propertySets.Close();
        }

        /// <summary>
        /// Adds or modifies a custom property.
        /// </summary>
        internal static SolidEdgeFileProperties.Property InternalUpdateCustomProperty(this SolidEdgeFileProperties.PropertySets propertySets, string propertyName, object propertyValue)
        {
            SolidEdgeFileProperties.Properties customPropertySet = null;
            SolidEdgeFileProperties.Property property = null;

            try
            {
                // Get a reference to the custom property set.
                customPropertySet = (SolidEdgeFileProperties.Properties)propertySets["Custom"];

                // Attempt to get the custom property.
                property = (SolidEdgeFileProperties.Property)customPropertySet[propertyName];

                // If we get here, the custom property exists so update the value.
                property.Value = propertyValue;
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                // If we get here, the custom property does not exist so add it.
                property = (SolidEdgeFileProperties.Property)customPropertySet.Add(propertyName, propertyValue);
            }
            catch
            {
                throw;
            }

            return property;
        }

        /// <summary>
        /// Adds or modifies a custom property.
        /// </summary>
        public static SolidEdgeFileProperties.Property UpdateCustomProperty(this SolidEdgeFileProperties.PropertySets propertySets, string propertyName, bool propertyValue)
        {
            return propertySets.InternalUpdateCustomProperty(propertyName, propertyValue);
        }

        /// <summary>
        /// Adds or modifies a custom property.
        /// </summary>
        public static SolidEdgeFileProperties.Property UpdateCustomProperty(this SolidEdgeFileProperties.PropertySets propertySets, string propertyName, DateTime propertyValue)
        {
            return propertySets.InternalUpdateCustomProperty(propertyName, propertyValue);
        }

        /// <summary>
        /// Adds or modifies a custom property.
        /// </summary>
        public static SolidEdgeFileProperties.Property UpdateCustomProperty(this SolidEdgeFileProperties.PropertySets propertySets, string propertyName, double propertyValue)
        {
            return propertySets.InternalUpdateCustomProperty(propertyName, propertyValue);
        }

        /// <summary>
        /// Adds or modifies a custom property.
        /// </summary>
        public static SolidEdgeFileProperties.Property UpdateCustomProperty(this SolidEdgeFileProperties.PropertySets propertySets, string propertyName, int propertyValue)
        {
            return propertySets.InternalUpdateCustomProperty(propertyName, propertyValue);
        }

        /// <summary>
        /// Adds or modifies a custom property.
        /// </summary>
        public static SolidEdgeFileProperties.Property UpdateCustomProperty(this SolidEdgeFileProperties.PropertySets propertySets, string propertyName, string propertyValue)
        {
            return propertySets.InternalUpdateCustomProperty(propertyName, propertyValue);
        }
        
        /// <summary>
        /// Returns all properties as a Dictionary.
        /// </summary>
        /// <param name="propertySets"></param>
        public static Dictionary<string,string> AsDictionary(this SolidEdgeFramework.PropertySets propertySets)
        {
            var dictionary = new Dictionary<string, string>();
        
            foreach (SolidEdgeFramework.Properties properties in propertySets)
            {
                foreach (SolidEdgeFramework.PropertyEx property in properties)
                {
                    try
                    {
                        if (dictionary.ContainsKey(property.Name)) continue;
                        dictionary.Add(property.Name, property.get_Value().ToString());
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        
            return dictionary;
        }

        /// <summary>
        /// Query properties to get a value.
        /// </summary>
        /// <param name="propertySets"></param>
        /// <param name="propertyName"></param>
        /// <param name="stringComparison"></param>
        public static string GetPropertyValue(this SolidEdgeFramework.PropertySets propertySets, string propertyName, StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            foreach (SolidEdgeFramework.Properties properties in propertySets)
            {
                foreach (SolidEdgeFramework.PropertyEx property in properties)
                {
                    try
                    {
                        if (property.Name.Equals(propertyName, stringComparison)) continue;
                        
                        return property.get_Value().ToString();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            return string.Empty;
        }
    }
}
