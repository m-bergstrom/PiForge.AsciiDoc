namespace AsciiDocHelper.AsciiDocTypes.Tables;

/// <summary>
/// The style of an AsciiDoc table column specification
/// </summary>
/// <remarks>Style determines how content within the column is
/// rendered</remarks>
public class Style
{
    /// <summary>
    /// Gets the underlying string representation of the AsciiDoc
    /// table column specification's style
    /// </summary>
    public string Value { get; }

    private Style(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Column or cell content is treated as a nested AsciiDoc
    /// document
    /// </summary>
    public static Style AsciiDoc = new("a");

    /// <summary>
    /// Column or cell content is formatted as a default
    /// paragraph
    /// </summary>
    public static Style Default = new("d");

    /// <summary>
    /// Column or cell content is emphasized (italicized)
    /// </summary>
    public static Style Emphasis = new("e");

    /// <summary>
    /// Column or cell content is formatted as a header
    /// </summary>
    public static Style Header = new("h");

    /// <summary>
    /// Column or cell content is formatted as literal text
    /// </summary>
    public static Style Literal = new("l");

    /// <summary>
    /// Column or cell content is rendered in a monospace font
    /// </summary>
    public static Style Monospace = new("m");

    /// <summary>
    /// Column or cell content is formatted as strong (bold)
    /// </summary>
    public static Style Strong = new("s");

    /// <summary>
    /// Implicitly converts an <c>Style</c> to its underlying string
    /// representation suitable for use in an AsciiDoc document
    /// </summary>
    /// <param name="style">The <c>Style</c> to convert</param>
    /// <returns><paramref name="style"/>'s underlying string
    /// representation</returns>
    public static implicit operator string(Style style) => style.Value;
}