using System;

namespace AsciiDocHelper.AsciiDocTypes.Tables;

/// <summary>
/// Represents the presence or absence of header and footer
/// formatting for AsciiDoc tables
/// </summary>
[Flags]
public enum TableHeaderFooter
{
    /// <summary>
    /// Neither header nor footer formatting
    /// </summary>
    None = 0,

    /// <summary>
    /// Header row formatting
    /// </summary>
    Header = 1,

    /// <summary>
    /// Footer row formatting
    /// </summary>
    Footer = 2
}