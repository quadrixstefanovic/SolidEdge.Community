﻿using System;

namespace SolidEdgeCommunity.Extensions
{
    /// <summary>
    /// SolidEdgePart.WeldmentDocument extension methods.
    /// </summary>
    public static class WeldmentDocumentExtensions
    {
        /// <summary>
        /// Returns the version of Solid Edge that was used to create the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Version GetCreatedVersion(this SolidEdgePart.WeldmentDocument document)
        {
            return new Version(document.CreatedVersion);
        }

        /// <summary>
        /// Returns the version of Solid Edge that was used the last time the referenced document was saved.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Version GetLastSavedVersion(this SolidEdgePart.WeldmentDocument document)
        {
            return new Version(document.LastSavedVersion);
        }

        /// <summary>
        /// Returns the properties for the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static SolidEdgeFramework.PropertySets GetProperties(this SolidEdgePart.WeldmentDocument document)
        {
            return document.Properties as SolidEdgeFramework.PropertySets;
        }

        /// <summary>
        /// Returns the summary information property set for the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static SolidEdgeFramework.SummaryInfo GetSummaryInfo(this SolidEdgePart.WeldmentDocument document)
        {
            return document.SummaryInfo as SolidEdgeFramework.SummaryInfo;
        }

        /// <summary>
        /// Returns a collection of variables for the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static SolidEdgeFramework.Variables GetVariables(this SolidEdgePart.WeldmentDocument document)
        {
            return document.Variables as SolidEdgeFramework.Variables;
        }
    }
}
