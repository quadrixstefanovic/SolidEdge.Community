﻿using System;

namespace SolidEdgeCommunity.Extensions
{
    /// <summary>
    /// SolidEdgeAssembly.AssemblyDocument extension methods.
    /// </summary>
    public static class AssemblyDocumentExtensions
    {
        /// <summary>
        /// Returns the version of Solid Edge that was used to create the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Version GetCreatedVersion(this SolidEdgeAssembly.AssemblyDocument document)
        {
            return new Version(document.CreatedVersion);
        }

        /// <summary>
        /// Returns the version of Solid Edge that was used the last time the referenced document was saved.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Version GetLastSavedVersion(this SolidEdgeAssembly.AssemblyDocument document)
        {
            return new Version(document.LastSavedVersion);
        }

        /// <summary>
        /// Returns the properties for the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static SolidEdgeFramework.PropertySets GetProperties(this SolidEdgeAssembly.AssemblyDocument document)
        {
            return document.Properties as SolidEdgeFramework.PropertySets;
        }

        /// <summary>
        /// Returns the summary information property set for the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static SolidEdgeFramework.SummaryInfo GetSummaryInfo(this SolidEdgeAssembly.AssemblyDocument document)
        {
            return document.SummaryInfo as SolidEdgeFramework.SummaryInfo;
        }

        /// <summary>
        /// Returns a collection of variables for the referenced document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static SolidEdgeFramework.Variables GetVariables(this SolidEdgeAssembly.AssemblyDocument document)
        {
            return document.Variables as SolidEdgeFramework.Variables;
        }
        
        /// <summary>
        /// Returns the count of occurrences and all sub-occurrences for the referenced document.
        /// Simplified sub-assemblies are treated as a single occurrence.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static int GetOccurrenceCount(this SolidEdgeAssembly.AssemblyDocument document)
        {
            var count = 0;

            foreach (SolidEdgeAssembly.Occurrence occurrence in document.Occurrences)
            {
                count++;

                if (!occurrence.Subassembly || occurrence.UseSimplified) continue;
                
                foreach (SolidEdgeAssembly.SubOccurrence subOccurrence in occurrence.SubOccurrences)
                {
                    count++;

                    if (subOccurrence.Subassembly)
                    {
                        SubOccurrenceCount(subOccurrence);
                    }
                }
            }

            return count;

            void SubOccurrenceCount(SolidEdgeAssembly.SubOccurrence occurrence)
            {
                foreach (SolidEdgeAssembly.SubOccurrence subOccurrence in occurrence.SubOccurrences)
                {
                    count++;

                    if (!subOccurrence.Subassembly || subOccurrence.UseSimplified) continue;
                    
                    SubOccurrenceCount(subOccurrence);
                }
            }
        }
    }
}
