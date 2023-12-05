namespace FileManager.Parsers;

public class Arguments
{
    public Arguments()
    {
        Positional = new List<string>();
        Flags = new Dictionary<string, string>();
    }

    public IList<string> Positional { get; }
    public IDictionary<string, string> Flags { get; }

    public void Parse(string[] values)
    {
        if (values is null)
            throw new ArgumentNullException(nameof(values));

        var i = 0;
        while (i < values.Length)
        {
            if (values[i][0] == '-')
            {
                var flag = values[i];
                i++;
                Flags.Add(flag, values[i]);
            }
            else
            {
                Positional.Add(values[i]);
            }

            i++;
        }
    }
}