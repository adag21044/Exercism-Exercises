using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        string result = HandleSpace(identifier);
        result = HandleCTRL(result);
        result = HandleCase(result);
        result = HandleNonLetter(result);
        result = HandleGreekLetter(result);

        return result;
    }

    // 1) Replace spaces with underscores
    public static string HandleSpace(string str)
    {
        return str.Replace(' ', '_');
    }

    // 2) Replace control characters with "CTRL"
    public static string HandleCTRL(string str)
    {
        var sb = new StringBuilder(str.Length);
        foreach (char c in str)
        {
            if (char.IsControl(c))
                sb.Append("CTRL");
            else
                sb.Append(c);
        }
        return sb.ToString();
    }

    // 3) Convert kebab-case to camelCase (remove '-' and uppercase next letter)
    public static string HandleCase(string str)
    {
        var sb = new StringBuilder(str.Length);
        bool makeUpperNext = false;

        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];

            if (c == '-')
            {
                makeUpperNext = true;   // skip '-' and uppercase next letter
                continue;
            }

            if (makeUpperNext)
            {
                sb.Append(char.ToUpper(c));
                makeUpperNext = false;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    // 4) Omit characters that are not letters (keep underscores produced earlier)
    public static string HandleNonLetter(string str)
    {
        var sb = new StringBuilder(str.Length);
        foreach (char c in str)
        {
            if (char.IsLetter(c) || c == '_')
                sb.Append(c);
            // else: skip
        }
        return sb.ToString();
    }

    // 5) Omit Greek lower case letters (α–ω)
    public static string HandleGreekLetter(string str)
    {
        var sb = new StringBuilder(str.Length);
        foreach (char c in str)
        {
            if (!IsGreekLetter(c)) // keep only if NOT a Greek lowercase letter
                sb.Append(c);
        }
        return sb.ToString();
    }

    public static bool IsGreekLetter(char c)
    {
        // Only lowercase Greek letters α (U+03B1) to ω (U+03C9)
        return c >= 'α' && c <= 'ω';
    }
}
