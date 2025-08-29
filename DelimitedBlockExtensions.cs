using System;
using System.Linq;
using System.Text;
using AsciiDocHelper.AsciiDocTypes;
using AsciiDocHelper.AsciiDocTypes.SyntaxHighligherLanguageNames;
using AsciiDocHelper.AsciiDocTypes.Tables;
using AsciiDocHelper.Blocks;

namespace AsciiDocHelper;

/// <summary>
/// Extension methods for creating delimited AsciiDoc blocks that
/// emit the ending delimiters when disposed
/// </summary>
public static class DelimitedBlockExtensions
{
    /// <summary>
    /// Creates a delimited block with differentiated start and end
    /// boundaries
    /// </summary>
    /// <param name="builder">The string builder to create the block
    /// with</param>
    /// <param name="startBoundary">The boundary text that marks the
    /// start of the block</param>
    /// <param name="endBoundary">The boundary text that marks the
    /// end of the block</param>
    /// <param name="title">The title of the block</param>
    /// <param name="attributes">Additional attributes that affect
    /// the block</param>
    /// <param name="blockStyle">The block style attribute, if any</param>
    /// <returns>An <see cref="IDisposable"/> that emits the
    /// <paramref name="endBoundary" /> line when disposed</returns>
    public static IDisposable
        CreateDelimitedBlock(this StringBuilder builder, string startBoundary, string endBoundary, string? title = null,
            string? blockStyle = null, params string[] attributes) =>
        new DelimitedBlock(builder, startBoundary, endBoundary, title, blockStyle, attributes.ToList());

    /// <summary>
    /// Creates a delimited block
    /// </summary>
    /// <param name="builder">The string builder to create the block
    /// with</param>
    /// <param name="boundary">The boundary text that marks the
    /// start and end of the block</param>
    /// <param name="title">The title of the block</param>
    /// <param name="blockStyle">The block style attribute, if any</param>
    /// <param name="attributes">Additional attributes that affect
    /// the block</param>
    /// <returns>An <see cref="IDisposable"/> that emits the
    /// <paramref name="boundary" /> line when disposed</returns>
    public static IDisposable CreateDelimitedBlock(this StringBuilder builder, string boundary, string? title = null,
        string? blockStyle = null, params string[] attributes) =>
        new DelimitedBlock(builder, boundary, title, blockStyle, attributes.ToList());

    /// <summary>
    /// Creates an
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/blocks/admonitions/">admonition</a>
    /// block
    /// </summary>
    /// <param name="builder">The string builder to create the
    ///     admonition block with</param>
    /// <param name="admonitionType">The <see cref="AdmonitionType"/>
    ///     to create the block for</param>
    /// <param name="title">The title of the admonition block</param>
    /// <param name="attributes">Additional attributes that affect
    ///     the admonition block</param>
    /// <returns>An <see cref="IDisposable"/> that ends the
    /// admonition block when disposed</returns>
    public static IDisposable CreateAdmonitionBlock(this StringBuilder builder, string admonitionType,
        string? title = null, params string[] attributes) =>
        new DelimitedBlock(builder, "====", title, admonitionType, attributes.ToList());

    /// <summary>
    /// Creates a
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/comments/">comment</a>
    /// block
    /// </summary>
    /// <param name="builder">The string builder to create the
    /// comment block with</param>
    /// <returns>An <see cref="IDisposable"/> that ends the comment
    /// block when disposed</returns>
    public static IDisposable CreateCommentBlock(this StringBuilder builder) => new DelimitedBlock(builder, "////");

    /// <summary>
    /// Creates an
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/blocks/example-blocks/">example</a>
    /// block
    /// </summary>
    /// <param name="builder">The string builder to create the
    /// example block with</param>
    /// <param name="title">The title of the example block</param>
    /// <param name="attributes">Additional attributes that affect
    /// the example block</param>
    /// <returns>An <see cref="IDisposable"/> that ends the example
    /// block when disposed</returns>
    public static IDisposable CreateExampleBlock(this StringBuilder builder, string? title = null,
        params string[] attributes) =>
        new DelimitedBlock(builder, "====", title, "example", attributes.ToList());

    /// <summary>
    /// Creates a
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/blocks/blockquotes/">quote</a>
    /// block
    /// </summary>
    /// <param name="builder">The string builder to create the
    /// quote block with</param>
    /// <param name="attribution">The author of or source for the
    /// quote (<i>e.g.</i>, E. M. Rhodes, J. R. R. Tolkien,
    /// P. C. Wren)</param>
    /// <param name="citation">The source for the quote
    /// (<i>e.g.</i>, Trusty Knaves, The Fellowship of the Ring,
    /// Beau Geste)</param>
    /// <param name="title">The title of the quote block
    /// (<i>e.g.</i>, the setting or context surrounding the quote)</param>
    /// <param name="attributes">Additional attributes that affect
    /// the quote block</param>
    /// <returns>An <see cref="IDisposable"/> that ends the quote
    /// block when disposed</returns>
    public static IDisposable CreateQuoteBlock(this StringBuilder builder, string? attribution = null,
        string? citation = null, string? title = null, params string[] attributes)
    {
        var attributeList = attributes.ToList();
        if (!string.IsNullOrEmpty(attribution) &&
            !attributeList.Contains(attribution, StringComparer.InvariantCultureIgnoreCase))
            attributeList.Insert(0, attribution);
        if (!string.IsNullOrEmpty(citation) &&
            !attributeList.Contains(citation, StringComparer.InvariantCultureIgnoreCase))
            attributeList.Insert(Math.Min(1, attributeList.Count), citation);
        return new DelimitedBlock(builder, "____", title, "quote", attributeList);
    }

    /// <summary>
    /// Creates a
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/verbatim/source-blocks/">source code</a>
    /// block (preserves indents and line breaks
    /// </summary>
    /// <param name="builder">The string builder to create the
    /// source code block with</param>
    /// <param name="language">The language to use for syntax
    /// highlighting</param>
    /// <param name="lineNumbers">Whether to include line numbers in
    /// the listing</param>
    /// <param name="attributes">Additional attributes that affect
    /// the source code block</param>
    /// <returns>An <see cref="IDisposable"/> that ends the source
    /// code block when disposed</returns>
    /// <remarks>The language names for different syntax highlighters
    /// are available as members of the <see cref="CodeRayName"/>,
    /// <see cref="PygmentsName"/>, <see cref="RougeName"/>, and
    /// <see cref="HighlightJsName"/> types. Use the members
    /// associated with the highlighter in use.</remarks>
    public static IDisposable CreateSourceCodeBlock(this StringBuilder builder, string? language = null,
        bool lineNumbers = true, params string[] attributes)
    {
        var attributeList = attributes.ToList();
        if (lineNumbers)
            attributeList.Add("%linenums");
        return new DelimitedBlock(builder, "----", null,
            string.Join(",", new[] { "source", language }.Where(a => !string.IsNullOrEmpty(a))), attributeList);
    }

    /// <summary>
    /// Creates a
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/tables/build-a-basic-table/">table</a>
    /// </summary>
    /// <param name="builder">The string builder to create the table
    /// with</param>
    /// <param name="columns">The table's columns, each described
    /// with a column specifier string</param>
    /// <param name="headerFooter">Whether to treat the first and/or
    /// final rows as header and/or footer rows</param>
    /// <param name="title">The title of the table</param>
    /// <param name="outerTableBlock">The return from an outer
    /// <see cref="CreateTableBlock(System.Text.StringBuilder,string[],AsciiDocHelper.AsciiDocTypes.Tables.TableHeaderFooter,string?,System.IDisposable?,string[])"/>
    /// call</param>
    /// <param name="attributes">Additional attributes that affect
    /// the table</param>
    /// <returns>An <see cref="IDisposable"/> that ends the table
    /// when disposed</returns>
    /// <remarks>
    /// <h3>Columns</h3>
    /// <p>At their simplest, column specifiers are values that
    /// specify the proportional widths of the columns.</p>
    /// <p>
    /// <i>The following <c>columns</c> value would specify
    /// that the table's first column would occupy half of the
    /// horizontal space while the remaining three columns would
    /// divide the other half equally:</i>
    /// </p>
    ///
    /// <code>
    /// ["3", "1" "1", "1"]
    /// </code>
    ///
    /// <p>For more information on table columns, see
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/tables/add-columns/">the documentation</a>.
    /// </p>
    ///
    /// <h3>Table Nesting</h3>
    /// <p>To invoke AsciiDoc's limited support for nested tables
    /// (<b>don't</b>), simply use the return value from the outer
    /// table's
    /// <see cref="CreateTableBlock(System.Text.StringBuilder,string[],AsciiDocHelper.AsciiDocTypes.Tables.TableHeaderFooter,string?,System.IDisposable?,string[])"/>
    /// call as the <paramref name="outerTableBlock"/> parameter
    /// value.</p>
    /// <code>
    /// using (var outerTable = builder.CreateTableBlock(...)) // Starts the outer table (|===)
    /// {
    ///     using (var innerTable = builder.CreateTableBlock(outerTableBlock: outerTable)) // Starts the inner table (!===)
    ///     {
    ///     } // Ends the inner table (!===)
    /// } // Ends the outer table (|===)
    /// </code>
    /// </remarks>
    public static IDisposable CreateTableBlock(this StringBuilder builder, string[]? columns = null,
        TableHeaderFooter headerFooter = TableHeaderFooter.Header, string? title = null,
        IDisposable? outerTableBlock = null, params string[] attributes)
    {
        var attributeList = attributes.ToList();

        if (columns?.Length > 0 &&
            !attributeList.Any(a => a.StartsWith(@"cols=""", StringComparison.InvariantCultureIgnoreCase)))
            attributeList.Add($@"cols=""{string.Join(",", columns)}""");
        if (headerFooter.HasFlag(TableHeaderFooter.Header) &&
            !attributeList.Contains("%header", StringComparer.InvariantCultureIgnoreCase))
            attributeList.Add("%header");
        if (headerFooter.HasFlag(TableHeaderFooter.Footer) &&
            !attributeList.Contains("%footer", StringComparer.InvariantCultureIgnoreCase))
            attributeList.Add("%footer");
        return new DelimitedBlock(builder, outerTableBlock != null ? "!===" : "|===", title, null, attributeList);
    }


    /// <summary>
    /// Creates a
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/tables/build-a-basic-table/">table</a>
    /// </summary>
    /// <param name="builder">The string builder to create the table
    /// with</param>
    /// <param name="columns">The table's columns, each described
    /// with a <see cref="ColSpec"/></param>
    /// <param name="headerFooter">Whether to treat the first and/or
    /// final rows as header and/or footer rows</param>
    /// <param name="title">The title of the table</param>
    /// <param name="outerTableBlock">The return from an outer
    /// <see cref="CreateTableBlock(System.Text.StringBuilder,ColSpec[],AsciiDocHelper.AsciiDocTypes.Tables.TableHeaderFooter,string?,System.IDisposable?,string[])"/>
    /// call</param>
    /// <param name="attributes">Additional attributes that affect
    /// the table</param>
    /// <returns>An <see cref="IDisposable"/> that ends the table
    /// when disposed</returns>
    /// <remarks>
    /// <h3>Table Nesting</h3>
    /// <p>To invoke AsciiDoc's limited support for nested tables
    /// (<b>don't</b>), simply use the return value from the outer
    /// table's
    /// <see cref="CreateTableBlock(System.Text.StringBuilder,ColSpec[],AsciiDocHelper.AsciiDocTypes.Tables.TableHeaderFooter,string?,System.IDisposable?,string[])"/>
    /// call as the <paramref name="outerTableBlock"/> parameter
    /// value.</p>
    /// <code>
    /// using (var outerTable = builder.CreateTableBlock(...)) // Starts the outer table (|===)
    /// {
    ///     using (var innerTable = builder.CreateTableBlock(outerTableBlock: outerTable)) // Starts the inner table (!===)
    ///     {
    ///     } // Ends the inner table (!===)
    /// } // Ends the outer table (|===)
    /// </code>
    /// </remarks>
    public static IDisposable CreateTableBlock(this StringBuilder builder, ColSpec[]? columns = null,
        TableHeaderFooter headerFooter = TableHeaderFooter.Header, string? title = null,
        IDisposable? outerTableBlock = null, params string[] attributes) =>
        CreateTableBlock(builder, columns?.Select(c => (string)c).ToArray(), headerFooter, title, outerTableBlock,
            attributes);

    /// <summary>
    /// Creates a
    /// <a href="https://docs.AsciiDoctor.org/AsciiDoc/latest/blocks/verses/">verse</a>
    /// block (preserves indents and line breaks)
    /// </summary>
    /// <param name="builder">The string builder to create the
    /// verse block with</param>
    /// <param name="attribution">The author of or source for the
    /// verse (<i>e.g.</i>, Ogden Nash, Rudyard Kipling)</param>
    /// <param name="citation">The source for the verse
    /// (<i>e.g.</i>, Very Like a Whale,
    /// The Last of the Light Brigade)</param>
    /// <param name="attributes">Additional attributes that affect
    /// the verse block</param>
    /// <returns>An <see cref="IDisposable"/> that ends the verse
    /// block when disposed</returns>
    public static IDisposable CreateVerseBlock(this StringBuilder builder, string? attribution = null,
        string? citation = null, params string[] attributes)
    {
        var attributeList = attributes.ToList();
        if (!string.IsNullOrEmpty(attribution) &&
            !attributeList.Contains(attribution, StringComparer.InvariantCultureIgnoreCase))
            attributeList.Insert(0, attribution);
        if (!string.IsNullOrEmpty(citation) &&
            !attributeList.Contains(citation, StringComparer.InvariantCultureIgnoreCase))
            attributeList.Insert(Math.Min(1, attributeList.Count), citation);
        return new DelimitedBlock(builder, "____", null, "verse", attributeList);
    }
}