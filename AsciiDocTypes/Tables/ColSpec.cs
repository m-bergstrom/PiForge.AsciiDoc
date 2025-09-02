namespace PiForge.AsciiDoc.AsciiDocTypes.Tables;

/// <summary>
/// Used to customize the width, alignment, and formatting of
/// AsciiDoc table columns
/// </summary>
public struct ColSpec
{
    /// <summary>
    /// Gets the number of columns to repeat this specification for
    /// </summary>
    public int Multiplier { get; }

    /// <summary>
    /// Gets the horizontal alignment (&lt;, ^, &gt;) for this column
    /// specification (see <see cref="PiForge.AsciiDoc.AsciiDocTypes.Tables.HorizontalAlignment"/>)
    /// </summary>
    public string HorizontalAlignment { get; }

    /// <summary>
    /// Gets the vertical alignment (^, ., v) for this column
    /// specification (see <see cref="PiForge.AsciiDoc.AsciiDocTypes.Tables.VerticalAlignment"/>)
    /// </summary>
    public string VerticalAlignment { get; }

    /// <summary>
    /// Gets the relative width for this column specification
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the style (<i>e.g.</i>, a, d, h) for this column
    /// specification (see <see cref="PiForge.AsciiDoc.AsciiDocTypes.Tables.Style"/>)
    /// </summary>
    public string Style { get; }

    /// <summary>
    /// Creates a new <c>ColSpec</c>
    /// </summary>
    /// <param name="multiplier">The number of columns to repeat this
    /// specification for</param>
    /// <param name="horizontalAlignment">The horizontal alignment
    /// (&lt;, ^, &gt;) for this column specification
    /// (see <see cref="PiForge.AsciiDoc.AsciiDocTypes.Tables.HorizontalAlignment"/>)</param>
    /// <param name="verticalAlignment">The vertical alignment
    /// (^, ., v) for this column specification
    /// (see <see cref="PiForge.AsciiDoc.AsciiDocTypes.Tables.VerticalAlignment"/>)</param>
    /// <param name="width">The relative width for this column
    /// specification</param>
    /// <param name="style">The style (<i>e.g.</i>, a, d, h) for this
    /// column specification
    /// (see <see cref="PiForge.AsciiDoc.AsciiDocTypes.Tables.Style"/>)</param>
    public ColSpec(int? multiplier = null, string? horizontalAlignment = null,
        string? verticalAlignment = null,
        int? width = null, string? style = null)
    {
        Multiplier = multiplier ?? 1;
        HorizontalAlignment = horizontalAlignment ?? Tables.HorizontalAlignment.Left;
        VerticalAlignment = verticalAlignment ?? Tables.VerticalAlignment.Top;
        Width = width ?? 1;
        Style = style ?? Tables.Style.Default;
    }

    /// <summary>
    /// Implicitly converts an<c>ColSpec</c> to its
    /// underlying string representation suitable for use in an
    /// AsciiDoc document
    /// </summary>
    /// <param name="colSpec">The
    /// <c>ColSpec</c> to convert</param>
    /// <returns><paramref name="colSpec"/>'s underlying
    /// string representation</returns>
    public static implicit operator string(ColSpec colSpec) =>
        $"{colSpec.Multiplier}*{colSpec.HorizontalAlignment}.{colSpec.VerticalAlignment}{colSpec.Width}{colSpec.Style}";
}