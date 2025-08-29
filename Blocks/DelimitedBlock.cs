using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiDocHelper.Blocks;

/// <summary>
/// Represents an AsciiDoc block element. When created with a
/// <see cref="StringBuilder"/>, it emits the beginning block text;
/// when disposed, it emits the ending block text.
/// </summary>
public class DelimitedBlock : IDisposable
{
    private readonly StringBuilder _Builder;
    private readonly string _EndBoundary;

    /// <summary>
    /// Creates a delimited block and emits the
    /// <paramref name="title"/> (if supplied),
    /// <paramref name="attributeList"/> (if supplied), and
    /// <paramref name="boundary"/> lines
    /// </summary>
    /// <param name="builder">The string builder to create the block
    /// with</param>
    /// <param name="boundary">The boundary text that marks the
    /// start and end of the block</param>
    /// <param name="title">The title of the block</param>
    /// <param name="blockStyle">The block style attribute, if any</param>
    /// <param name="attributeList">Additional attributes that affect
    /// the block</param>
    /// <remarks>When disposed, the delimited block emits the
    /// <paramref name="boundary"/> line to define the end of the
    /// block</remarks>
    public DelimitedBlock(StringBuilder builder, string boundary, string? title = null,
        string? blockStyle = null, List<string>? attributeList = null) : this(builder, boundary, boundary, title, blockStyle, attributeList)
    {
    }

    /// <summary>
    /// Creates a delimited block and emits the
    /// <paramref name="title"/> (if supplied),
    /// <paramref name="attributeList"/> (if supplied), and
    /// <paramref name="startBoundary"/> lines
    /// </summary>
    /// <param name="builder">The string builder to create the block
    /// with</param>
    /// <param name="startBoundary">The boundary text that marks the
    /// start of the block</param>
    /// <param name="endBoundary">The boundary text that marks the
    /// end of the block</param>
    /// <param name="title">The title of the block</param>
    /// <param name="blockStyle">The block style attribute, if any</param>
    /// <param name="attributeList">Additional attributes that affect
    /// the block</param>
    /// <remarks>When disposed, the delimited block emits the
    /// <paramref name="endBoundary"/> line to define the end of the
    /// block</remarks>
    public DelimitedBlock(StringBuilder builder, string startBoundary, string endBoundary, string? title = null,
        string? blockStyle = null, List<string>? attributeList = null)
    {
        _Builder = builder;
        _EndBoundary = endBoundary;

        if (title?.Length > 0)
            _Builder.AppendLine("." + title);

        var shortHandAttributes =
            attributeList?.Where(a => a.StartsWith("%") || a.StartsWith("#") || a.StartsWith(".")) ?? [];
        var otherAttributes =
            attributeList?.Where(a => !(a.StartsWith("%") || a.StartsWith("#") || a.StartsWith("."))) ?? [];
        var combinedAttributes = otherAttributes.Prepend(string.Join(string.Empty, shortHandAttributes))
            .Where(a => !string.IsNullOrEmpty(a)).ToList();
        if (!string.IsNullOrEmpty(blockStyle))
            combinedAttributes.Insert(0, blockStyle);

        if (combinedAttributes?.Count > 0)
            builder.AppendLine($"[{string.Join(",", combinedAttributes)}]");

        _Builder.AppendLine(startBoundary);
    }

    /// <summary>
    /// Emits the ending block text when disposing
    /// </summary>
    /// <param name="disposing">Whether disposing (as opposed to
    /// calling from a class finalizer)</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _Builder.AppendLine(_EndBoundary);
    }

    /// <summary>
    /// Emits the ending block text
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}