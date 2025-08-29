namespace AsciiDocHelper.AsciiDocTypes.Tables;

/// <summary>
/// The horizontal alignment of an AsciiDoc table column
/// specification
/// </summary>
public class HorizontalAlignment
{
    /// <summary>
    /// Gets the underlying string representation of the AsciiDoc
    /// table column specification's horizontal alignment
    /// </summary>
    public string Value { get; }

    private HorizontalAlignment(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Column content is left-aligned
    /// </summary>
    public static HorizontalAlignment Left = new("<");

    /// <summary>
    /// Column content is centered
    /// </summary>
    public static HorizontalAlignment Center = new("^");

    /// <summary>
    /// Column content is right-aligned
    /// </summary>
    public static HorizontalAlignment Right = new(">");

    /// <summary>
    /// Implicitly converts an <c>HorizontalAlignment</c> to its
    /// underlying string representation suitable for use in an
    /// AsciiDoc document
    /// </summary>
    /// <param name="horizontalAlignment">The
    /// <c>HorizontalAlignment</c> to convert</param>
    /// <returns><paramref name="horizontalAlignment"/>'s underlying
    /// string representation</returns>
    public static implicit operator string(HorizontalAlignment horizontalAlignment) => horizontalAlignment.Value;
}