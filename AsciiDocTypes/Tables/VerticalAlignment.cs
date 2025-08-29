namespace AsciiDocHelper.AsciiDocTypes.Tables;

/// <summary>
/// The vertical alignment of an AsciiDoc table column specification
/// </summary>
public class VerticalAlignment
{
    /// <summary>
    /// Gets the underlying string representation of the AsciiDoc
    /// table column specification's vertical alignment
    /// </summary>
    public string Value { get; }

    private VerticalAlignment(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Column content is top-aligned
    /// </summary>
    public static VerticalAlignment Top = new("<");

    /// <summary>
    /// Column content is centered vertically
    /// </summary>
    public static VerticalAlignment Middle = new("^");

    /// <summary>
    /// Column content is bottom-aligned
    /// </summary>
    public static VerticalAlignment Bottom = new(">");

    /// <summary>
    /// Implicitly converts an <c>VerticalAlignment</c> to its
    /// underlying string representation suitable for use in an
    /// AsciiDoc document
    /// </summary>
    /// <param name="verticalAlignment">The <c>VerticalAlignment</c>
    /// to convert</param>
    /// <returns><paramref name="verticalAlignment"/>'s underlying
    /// string representation</returns>
    public static implicit operator string(VerticalAlignment verticalAlignment) => verticalAlignment.Value;
}