using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;

public static class NPOITool
{
    /// <summary>
    /// 获取Excal里的Sheet
    /// </summary>
    /// <param name="file">文件流</param>
    /// <param name="SheetIndex">Sheet索引</param>
    /// <returns></returns>
    public static ISheet ReadExcalSheet(FileStream file, int SheetIndex = 0)
    {
        IWorkbook workbook = new XSSFWorkbook(file);
        ISheet sheet = workbook.GetSheetAt(0);//获取这个Excal的第一列
        return sheet;
    }

    /// <summary>
    /// 获取Excal里的Sheet
    /// </summary>
    /// <param name="file">文件流</param>
    /// <param name="SheetIndex">Sheet索引</param>
    /// <returns></returns>
    //public static ISheet ReadExcalSheet(IFormFile file, int SheetIndex = 0)
    //{
    //    IWorkbook workbook = new XSSFWorkbook(file.OpenReadStream());
    //    ISheet sheet = workbook.GetSheetAt(0);//获取这个Excal的第一列
    //    return sheet;
    //}

    /// <summary>
    /// 读取Excal
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    //public static IWorkbook ReadExcal(IFormFile file)
    //{
    //    return new XSSFWorkbook(file.OpenReadStream());
    //}

    /// <summary>
    /// 读取Excal
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static IWorkbook ReadExcal(FileStream file)
    {
        return new XSSFWorkbook(file);
    }

    /// <summary>
    /// 创建Excal
    /// </summary>
    /// <returns></returns>
    public static IWorkbook CreateWorkbook()
    {
        return new XSSFWorkbook();
    }

    /// <summary>
    /// 合并单元格
    /// </summary>
    /// <param name="sheet"></param>
    /// <param name="firstRow">开始行</param>
    /// <param name="lastRow">结束行</param>
    /// <param name="firstCol">开始列</param>
    /// <param name="lastCol">结束列</param>
    /// <returns></returns>
    public static ISheet MergeCell(this ISheet sheet, int firstRow, int lastRow, int firstCol, int lastCol)
    {
        sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
        return sheet;
    }

    /// <summary>
    /// 获取Excal byte字符串
    /// </summary>
    /// <param name="workbook"></param>
    /// <returns></returns>
    public static byte[] ReadWorkbookByte(this IWorkbook workbook)
    {
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        var res = ms.ToArray();
        ms.Close();
        return res;
    }

    /// <summary>
    /// 保存Excal文件
    /// </summary>
    /// <param name="workbook"></param>
    /// <param name="Path">路径</param>
    /// <returns></returns>
    public static string SaveExcal(this IWorkbook workbook, string Path)
    {
        using (var fs = File.Create(Path))
        {
            workbook.Write(fs);
        }
        return Path;
    }
}