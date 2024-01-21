using System.Runtime.CompilerServices;
using System.Text;

namespace Builder;

class HTMLElement
{
    public string Name, Text;
    public List<HTMLElement> Elements = new List<HTMLElement>();
    private const int indentSize = 2;

    public HTMLElement()
    {

    }

    public HTMLElement(string name, string text)
    {
        Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        sb.AppendLine($"{i}<{Name}>");

        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.AppendLine(Text);
        }

        foreach (var e in Elements)
        {
            sb.Append(e.ToStringImpl(indent + 1));
        }

        sb.AppendLine($"{i}</{Name}>");

        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }
}

public class HTMLBuilder
{
    private readonly string rootName;
    HTMLElement root = new HTMLElement();

    public HTMLBuilder(string rootName)
    {
        this.rootName = rootName;
        root.Name = rootName;
    }

    public HTMLBuilder AddChild(string childName, string childText)
    {
        var e = new HTMLElement(childName, childText);
        root.Elements.Add(e);
        return this;
    }

    public override string ToString()
    {
        return root.ToString();
    }

    public void Clear()
    {
        root = new HTMLElement { Name = rootName };
    }
}

class Program
{
    static void Main(string[] args)
    {
        var hello = "hello";
        var sb = new StringBuilder();
        sb.Append("<p>");
        sb.Append(hello);
        sb.Append("</p>");
        System.Console.WriteLine(sb);

        var words = new[] { "hello", "world" };
        sb.Clear();
        sb.Append("<ul>");
        foreach (var word in words)
        {
            sb.AppendFormat("<li>{0}</li>", word);
        }
        sb.Append("</ul>");
        System.Console.WriteLine(sb);

        var builder = new HTMLBuilder("ul");
        builder
        .AddChild("li", "hello")
        .AddChild("li", "world");
        System.Console.WriteLine(builder.ToString());
    }
}
