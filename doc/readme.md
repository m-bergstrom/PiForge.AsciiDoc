# AsciiDocHelper

AsciiDocHelper is a small library offering useful extensions for authoring [AsciiDoc](https://AsciiDoc.org/) documents.

## Delimited Block Extensions

AsciiDocHelper's block extension methods extend the `StringBuilder` to emit delimited block start and end boundaries at the beginning and end of a C# `using` block (`Using...End Using` in Visual Basic).

## Usage

### Admonition Block

```csharp
var builder = new StringBuilder();
using (builder.CreateAdmonitionBlock(AdmonitionType.Caution, title: "Cautionary Admonition"))
{
    builder.AppendLine("Wildfires are unplanned fires that burn in natural areas like forests, grasslands or prairies.")
        .AppendLine(
            "These dangerous fires spread quickly and can devastate not only wildlife and natural areas, but also communities.");
}
```

### Comment Block

```csharp
var builder = new StringBuilder();
using (builder.CreateCommentBlock())
{
    builder.AppendLine(
        "The following section should outline the benefits of sea moss (Chondrus crispus) including fiber, appetite control, Parkinson's disease slowing");
}
```

### Example Block

```csharp
var builder = new StringBuilder();
using (builder.CreateExampleBlock("Igneous Rocks"))
{
    builder.AppendLine("image::https://geology.com/rocks/pictures/andesite.jpg[Andesite]");
    builder.AppendLine("image::https://geology.com/rocks/pictures/basalt.jpg[Basalt]");
    builder.AppendLine("image::https://geology.com/rocks/pictures/dacite.jpg[Dacite]");
}
```

### Quote Block

```csharp
var builder = new StringBuilder();
using (builder.CreateQuoteBlock(attribution: "Matthew Bergstrom"))
{
    builder.AppendLine("There's a song about that.");
}
```

### Source Code Block

```csharp
var builder = new StringBuilder();
using (builder.CreateSourceCodeBlock(language: HighlightJsName.curl, lineNumbers: false))
{
    builder.AppendLine("curl http://rinkworks.com/stupid/");
}
```

### Table Block

```csharp
var builder = new StringBuilder();
using (builder.CreateTableBlock(columns: new ColSpec[]
           { new(style: Style.Monospace, width: 1, verticalAlignment:VerticalAlignment.Bottom), new(width: 5), new(width: 4) }))
{
    builder.CreateTableRow("Type", "Meaningless Organic Interpretation", "Actual Usefulness")
        .CreateTableRow("NOTE", @"""I thought you might like to know…""", "Mildly relevant. You’ll ignore it anyway.")
        .CreateTableRow("TIP", @"""Here’s a clever idea you’ll forget immediately.""",
            "Efficiency booster. Rarely applied.")
        .CreateTableRow("IMPORTANT", @"""If you miss this, your system will implode.""", "Critical for success. Still ignored.")
        .CreateTableRow("CAUTION", @"""Proceed carefully, meatbag. Your incompetence awaits.""", "Prevents minor disasters.")
        .CreateTableRow("WARNING", @"""Danger, Will Robinson! Or whatever your name is.""", "Life-threatening. You’ll click it anyway.");
}
```

#### Nested Tables

AsciiDoc's support for nested tables can be invoked by supplying a value for the `outerTableBlock` parameter:

```csharp
var builder = new StringBuilder();
using (var outer = builder.CreateTableBlock(columns: new ColSpec[] { new(multiplier: 2, style: Style.AsciiDoc) },
           title: "Outer Table", headerFooter: TableHeaderFooter.None))
{
    //Outer Table first column
    builder.AppendLine("|");
    using (builder.CreateTableBlock(columns: new[] { new ColSpec(multiplier: 3) }, title: "Inner Table",
               outerTableBlock: outer))
    {
        builder.CreateTableRow(outer /*Required to correctly emit inner table rows*/, "A", "B", "C")
            .CreateTableRow(outer, "...", "...", "...");
    }

    //Outer Table second column
    builder.AppendLine("|");
    using (builder.CreateTableBlock(columns: new[] { new ColSpec(multiplier: 3) }, title: "Inner Table",
               outerTableBlock: outer))
    {
        builder.CreateTableRow(outer, "A", "B", "C")
            .CreateTableRow(outer, "...", "...", "...");
    }
}
```

### Verse Block

```csharp
var builder = new StringBuilder();
using (builder.CreateVerseBlock("Matthew Bergstrom", "Chess"))
{
    builder.AppendLine("The rook's shadow cast")
        .AppendLine("    'Cross the field of ranks and files")
        .AppendLine("O'erglooms the white knight.");
}
```