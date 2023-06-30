using System.Linq;

namespace SolidEdgeCommunity.Extensions;

public static class SheetsExtensions
{
    /// <summary>
    /// Returns sheet object with a given name
    /// </summary>
    /// <param name="sheets"></param>
    /// <param name="name"></param>
    /// <param name="sectionType"></param>
    /// <returns></returns>
    public static SolidEdgeDraft.Sheet? GetSheetByName(this SolidEdgeDraft.Sheets sheets, string name, SolidEdgeDraft.SheetSectionTypeConstants sectionType = SolidEdgeDraft.SheetSectionTypeConstants.igWorkingSection)
    {
        return sheets.Cast<SolidEdgeDraft.Sheet>().FirstOrDefault(sheet => sheet.Name == name && sheet.SectionType == sectionType);
    }
    
    /// <summary>
    /// Returns sheet object with given number
    /// </summary>
    /// <param name="sheets"></param>
    /// <param name="number"></param>
    /// <param name="sectionType"></param>
    /// <returns></returns>
    public static SolidEdgeDraft.Sheet? GetSheetByNumber(this SolidEdgeDraft.Sheets sheets, int number, SolidEdgeDraft.SheetSectionTypeConstants sectionType = SolidEdgeDraft.SheetSectionTypeConstants.igWorkingSection)
    {
        return sheets.Cast<SolidEdgeDraft.Sheet>().FirstOrDefault(sheet => sheet.Number == number && sheet.SectionType == sectionType);
    }
}