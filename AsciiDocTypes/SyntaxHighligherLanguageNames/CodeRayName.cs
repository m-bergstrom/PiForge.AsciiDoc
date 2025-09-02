namespace PiForge.AsciiDoc.AsciiDocTypes.SyntaxHighligherLanguageNames;

/// <summary>
/// Represents the names of languages supported by the
/// <a href="http://coderay.rubychan.de/">CodeRay</a> syntax
/// highlighter
/// </summary>
public class CodeRayName
{
    /// <summary>
    /// Gets the underlying language name for CodeRay syntax
    /// highlighting
    /// </summary>
    public string Value { get; }

    private CodeRayName(string value)
    {
        Value = value;
    }

    // ReSharper disable InconsistentNaming
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static CodeRayName C = new("c");
    public static CodeRayName C_Plus_Plus = new("c++");
    public static CodeRayName Clojure = new("clojure");
    public static CodeRayName CSS = new("css");
    public static CodeRayName Delphi = new("delphi");
    public static CodeRayName diff = new("diff");
    public static CodeRayName ERB = new("erb");
    public static CodeRayName Go = new("go");
    public static CodeRayName Groovy = new("groovy");
    public static CodeRayName HAML = new("haml");
    public static CodeRayName HTML = new("html");
    public static CodeRayName Java = new("java");
    public static CodeRayName JavaScript = new("javascript");
    public static CodeRayName JSON = new("json");
    public static CodeRayName Lua = new("lua");
    public static CodeRayName PHP = new("php");
    public static CodeRayName Python = new("python");
    public static CodeRayName Ruby = new("ruby");
    public static CodeRayName Sass = new("sass");
    public static CodeRayName SQL = new("sql");
    public static CodeRayName Taskpaper = new("taskpaper");
    public static CodeRayName XML = new("xml");
    public static CodeRayName YAML = new("yaml");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    // ReSharper restore InconsistentNaming

    /// <summary>
    /// Implicitly converts a <c>CodeRayName</c> to its underlying
    /// string representation suitable for use in an AsciiDoc
    /// document
    /// </summary>
    /// <param name="codeRayName">The <c>CodeRayName</c> to convert</param>
    /// <returns><paramref name="codeRayName"/>'s underlying string
    /// representation</returns>
    public static implicit operator string(CodeRayName codeRayName) => codeRayName.Value;
}