namespace AsciiDocHelper.AsciiDocTypes;

/// <summary>
/// Specifies the type of an AsciiDoc admonition
/// </summary>
public sealed class AdmonitionType
{
    /// <summary>
    /// Gets the string representation of the AsciiDoc admonition
    /// </summary>
    public string Value { get; }

    private AdmonitionType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// A "note" admonition for information worth highlighting
    /// </summary>
    public static AdmonitionType Note = new("NOTE");

    /// <summary>
    /// A "tip" admonition for helpful advice or best practices
    /// </summary>
    public static AdmonitionType Tip = new("TIP");

    /// <summary>
    /// An "important" admonition for crucial information
    /// </summary>
    public static AdmonitionType Important = new("IMPORTANT");

    /// <summary>
    /// A "caution" admonition for avoiding potential issues
    /// </summary>
    public static AdmonitionType Caution = new("CAUTION");

    /// <summary>
    /// A "warning" admonition to look out for danger or serious
    /// consequences
    /// </summary>
    public static AdmonitionType Warning = new("WARNING");

    /// <summary>
    /// Implicitly converts an <c>AdmonitionType</c> to its
    /// underlying string representation suitable for use in an
    /// AsciiDoc document
    /// </summary>
    /// <param name="admonitionType">The <c>AdmonitionType</c> to
    /// convert</param>
    /// <returns><paramref name="admonitionType"/>'s underlying
    /// string representation</returns>
    public static implicit operator string(AdmonitionType admonitionType) => admonitionType.Value;
}