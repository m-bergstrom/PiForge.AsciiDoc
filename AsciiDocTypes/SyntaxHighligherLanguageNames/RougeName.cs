namespace PiForge.AsciiDoc.AsciiDocTypes.SyntaxHighligherLanguageNames;

/// <summary>
/// Represents the names of lexers supported by the
/// <a href="https://rouge.jneen.net/">Rouge</a> syntax highlighter
/// </summary>
public class RougeName
{
    /// <summary>
    /// Gets the underlying lexer name for Rouge syntax highlighting
    /// </summary>
    public string Value { get; }

    private RougeName(string value)
    {
        Value = value;
    }

    // ReSharper disable InconsistentNaming
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static RougeName @as = new("actionscript");
    public static RougeName abap = new("abap");
    public static RougeName actionscript = new("actionscript");
    public static RougeName apache = new("apache");
    public static RougeName apib = new("apiblueprint");
    public static RougeName apiblueprint = new("apiblueprint");
    public static RougeName applescript = new("applescript");
    public static RougeName as3 = new("actionscript");
    public static RougeName awk = new("awk");
    public static RougeName bash = new("shell");
    public static RougeName behat = new("gherkin");
    public static RougeName biml = new("biml");
    public static RougeName brainfuck = new("brainfuck");
    public static RougeName bsdmake = new("make");
    public static RougeName bsl = new("bsl");
    public static RougeName c = new("c");
    public static RougeName c_plus_plus = new("cpp");
    public static RougeName c_sharp = new("csharp");
    public static RougeName ceylon = new("ceylon");
    public static RougeName cfc = new("cfscript");
    public static RougeName cfscript = new("cfscript");
    public static RougeName cl = new("common_lisp");
    public static RougeName clj = new("clojure");
    public static RougeName cljs = new("clojure");
    public static RougeName clojure = new("clojure");
    public static RougeName cmake = new("cmake");
    public static RougeName coffee = new("coffeescript");
    public static RougeName coffee_script = new("coffeescript");
    public static RougeName coffeescript = new("coffeescript");
    public static RougeName common_lisp = new("common_lisp");
    public static RougeName conf = new("conf");
    public static RougeName config = new("conf");
    public static RougeName configuration = new("conf");
    public static RougeName console = new("console");
    public static RougeName coq = new("coq");
    public static RougeName cpp = new("cpp");
    public static RougeName cr = new("crystal");
    public static RougeName crystal = new("crystal");
    public static RougeName cs = new("csharp");
    public static RougeName csharp = new("csharp");
    public static RougeName css = new("css");
    public static RougeName cucumber = new("gherkin");
    public static RougeName d = new("d");
    public static RougeName dart = new("dart");
    public static RougeName diff = new("diff");
    public static RougeName digdag = new("digdag");
    public static RougeName django = new("jinja");
    public static RougeName dlang = new("d");
    public static RougeName docker = new("docker");
    public static RougeName dockerfile = new("docker");
    public static RougeName dot = new("dot");
    public static RougeName eiffel = new("eiffel");
    public static RougeName elisp = new("common_lisp");
    public static RougeName elixir = new("elixir");
    public static RougeName elm = new("elm");
    public static RougeName emacs_lisp = new("common_lisp");
    public static RougeName erb = new("erb");
    public static RougeName erl = new("erlang");
    public static RougeName erlang = new("erlang");
    public static RougeName eruby = new("erb");
    public static RougeName esc = new("escape");
    public static RougeName escape = new("escape");
    public static RougeName ex = new("viml");
    public static RougeName exs = new("elixir");
    public static RougeName factor = new("factor");
    public static RougeName fortran = new("fortran");
    public static RougeName fsharp = new("fsharp");
    public static RougeName gherkin = new("gherkin");
    public static RougeName glsl = new("glsl");
    public static RougeName gnumake = new("make");
    public static RougeName go = new("go");
    public static RougeName golang = new("go");
    public static RougeName gradle = new("gradle");
    public static RougeName graphql = new("graphql");
    public static RougeName groovy = new("groovy");
    public static RougeName hack = new("hack");
    public static RougeName HAML = new("haml");
    public static RougeName handlebars = new("handlebars");
    public static RougeName haskell = new("haskell");
    public static RougeName hbs = new("handlebars");
    public static RougeName hcl = new("hcl");
    public static RougeName hh = new("hack");
    public static RougeName hs = new("haskell");
    public static RougeName html = new("html");
    public static RougeName http = new("http");
    public static RougeName hy = new("hylang");
    public static RougeName hylang = new("hylang");
    public static RougeName idlang = new("idlang");
    public static RougeName ignore = new("rust");
    public static RougeName igorpro = new("igorpro");
    public static RougeName ini = new("ini");
    public static RougeName io = new("io");
    public static RougeName irb = new("irb");
    public static RougeName java = new("java");
    public static RougeName javascript = new("javascript");
    public static RougeName jinja = new("jinja");
    public static RougeName jl = new("julia");
    public static RougeName js = new("javascript");
    public static RougeName json = new("json");
    public static RougeName json_doc = new("json-doc");
    public static RougeName jsonnet = new("jsonnet");
    public static RougeName jsp = new("jsp");
    public static RougeName jsx = new("jsx");
    public static RougeName julia = new("julia");
    public static RougeName kdb_plus = new("q");
    public static RougeName kotlin = new("kotlin");
    public static RougeName ksh = new("shell");
    public static RougeName lasso = new("lasso");
    public static RougeName lassoscript = new("lasso");
    public static RougeName latex = new("tex");
    public static RougeName LaTeX = new("tex");
    public static RougeName lhaskell = new("literate_haskell");
    public static RougeName lhs = new("literate_haskell");
    public static RougeName liquid = new("liquid");
    public static RougeName litcoffee = new("literate_coffeescript");
    public static RougeName literate_coffeescript = new("literate_coffeescript");
    public static RougeName literate_haskell = new("literate_haskell");
    public static RougeName lithaskell = new("literate_haskell");
    public static RougeName llvm = new("llvm");
    public static RougeName lua = new("lua");
    public static RougeName m = new("matlab");
    public static RougeName m68k = new("m68k");
    public static RougeName magik = new("magik");
    public static RougeName make = new("make");
    public static RougeName makefile = new("make");
    public static RougeName markdown = new("markdown");
    public static RougeName mathematica = new("mathematica");
    public static RougeName matlab = new("matlab");
    public static RougeName md = new("markdown");
    public static RougeName mf = new("make");
    public static RougeName microsoftshell = new("powershell");
    public static RougeName mkd = new("markdown");
    public static RougeName ml = new("sml");
    public static RougeName moon = new("moonscript");
    public static RougeName moonscript = new("moonscript");
    public static RougeName mosel = new("mosel");
    public static RougeName msshell = new("powershell");
    public static RougeName mustache = new("handlebars");
    public static RougeName mxml = new("mxml");
    public static RougeName nasm = new("nasm");
    public static RougeName nginx = new("nginx");
    public static RougeName nim = new("nim");
    public static RougeName nimrod = new("nim");
    public static RougeName nixos = new("nix");
    public static RougeName no_run = new("rust");
    public static RougeName obj_c = new("objective_c");
    public static RougeName objc = new("objective_c");
    public static RougeName objective_c = new("objective_c");
    public static RougeName objectivec = new("objective_c");
    public static RougeName ocaml = new("ocaml");
    public static RougeName pascal = new("pascal");
    public static RougeName patch = new("diff");
    public static RougeName perl = new("perl");
    public static RougeName php = new("php");
    public static RougeName php3 = new("php");
    public static RougeName php4 = new("php");
    public static RougeName php5 = new("php");
    public static RougeName pl = new("perl");
    public static RougeName plaintext = new("plaintext");
    public static RougeName plist = new("plist");
    public static RougeName posh = new("powershell");
    public static RougeName powershell = new("powershell");
    public static RougeName pp = new("puppet");
    public static RougeName praat = new("praat");
    public static RougeName prolog = new("prolog");
    public static RougeName prometheus = new("prometheus");
    public static RougeName properties = new("properties");
    public static RougeName proto = new("protobuf");
    public static RougeName protobuf = new("protobuf");
    public static RougeName pry = new("irb");
    public static RougeName puppet = new("puppet");
    public static RougeName py = new("python");
    public static RougeName python = new("python");
    public static RougeName q = new("q");
    public static RougeName qml = new("qml");
    public static RougeName r = new("r");
    public static RougeName R = new("r");
    public static RougeName racket = new("racket");
    public static RougeName rb = new("ruby");
    public static RougeName react = new("jsx");
    public static RougeName realbasic = new("xojo");
    public static RougeName rhtml = new("erb");
    public static RougeName rs = new("rust");
    public static RougeName ruby = new("ruby");
    public static RougeName rust = new("rust");
    public static RougeName s = new("r");
    public static RougeName S = new("r");
    public static RougeName sass = new("sass");
    public static RougeName scala = new("scala");
    public static RougeName scheme = new("scheme");
    public static RougeName scss = new("scss");
    public static RougeName sed = new("sed");
    public static RougeName sh = new("shell");
    public static RougeName shell = new("shell");
    public static RougeName shell_session = new("console");
    public static RougeName should_panic = new("rust");
    public static RougeName sieve = new("sieve");
    public static RougeName slim = new("slim");
    public static RougeName smalltalk = new("smalltalk");
    public static RougeName smarty = new("smarty");
    public static RougeName sml = new("sml");
    public static RougeName sqf = new("sqf");
    public static RougeName sql = new("sql");
    public static RougeName squeak = new("smalltalk");
    public static RougeName st = new("smalltalk");
    public static RougeName supercollider = new("supercollider");
    public static RougeName swift = new("swift");
    public static RougeName tap = new("tap");
    public static RougeName tcl = new("tcl");
    public static RougeName terminal = new("console");
    public static RougeName terraform = new("terraform");
    public static RougeName tex = new("tex");
    public static RougeName TeX = new("tex");
    public static RougeName text = new("plaintext");
    public static RougeName tf = new("terraform");
    public static RougeName toml = new("toml");
    public static RougeName ts = new("typescript");
    public static RougeName tsx = new("tsx");
    public static RougeName tulip = new("tulip");
    public static RougeName turtle = new("turtle");
    public static RougeName twig = new("twig");
    public static RougeName typescript = new("typescript");
    public static RougeName udiff = new("diff");
    public static RougeName vala = new("vala");
    public static RougeName vb = new("vb");
    public static RougeName verilog = new("verilog");
    public static RougeName vhdl = new("vhdl");
    public static RougeName vim = new("viml");
    public static RougeName viml = new("viml");
    public static RougeName vimscript = new("viml");
    public static RougeName visualbasic = new("vb");
    public static RougeName vue = new("vue");
    public static RougeName vuejs = new("vue");
    public static RougeName wl = new("mathematica");
    public static RougeName wollok = new("wollok");
    public static RougeName xml = new("xml");
    public static RougeName xojo = new("xojo");
    public static RougeName yaml = new("yaml");
    public static RougeName yml = new("yaml");
    public static RougeName zsh = new("shell");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    // ReSharper restore InconsistentNaming

    /// <summary>
    /// Implicitly converts a <c>RougeName</c> to its underlying
    /// string representation suitable for use in an AsciiDoc
    /// document
    /// </summary>
    /// <param name="rougeName">The <c>RougeName</c> to convert</param>
    /// <returns><paramref name="rougeName"/>'s underlying string
    /// representation</returns>
    public static implicit operator string(RougeName rougeName) => rougeName.Value;
}