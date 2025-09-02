using System;
using System.Text;

namespace PiForge.AsciiDoc;

/// <summary>
/// Extension methods for authoring AsciiDoc lines more easily
/// </summary>
public static class LineExtensions
{
    /// <summary>
    /// Creates an AsciiDoc table row
    /// </summary>
    /// <param name="builder">The string builder to create the table
    /// row with</param>
    /// <param name="outerTableBlock">The return from an outer
    /// <see cref="DelimitedBlockExtensions.CreateTableBlock(System.Text.StringBuilder,PiForge.AsciiDoc.AsciiDocTypes.Tables.ColSpec[],PiForge.AsciiDoc.AsciiDocTypes.Tables.TableHeaderFooter,string?,System.IDisposable?,string[])"/>
    /// call</param>
    /// <param name="cellsContents">The content of the row's cells</param>
    /// <returns>The builder used to create the table row</returns>
    public static StringBuilder CreateTableRow(this StringBuilder builder, IDisposable? outerTableBlock,
        params string[] cellsContents)
    {
        var divider = outerTableBlock == null ? "|" : "!";
        if (cellsContents.Length > 0)
            builder.AppendLine($"{divider}{string.Join($" {divider}", cellsContents)}");

        return builder;
    }

    /// <summary>
    /// Creates an AsciiDoc table row
    /// </summary>
    /// <param name="builder">The string builder to create the table
    /// row with</param>
    /// <param name="cellsContents">The content of the row's cells</param>
    /// <returns>The builder used to create the table row</returns>
    public static StringBuilder CreateTableRow(this StringBuilder builder,
        params string[] cellsContents) => CreateTableRow(builder, null, cellsContents);
}