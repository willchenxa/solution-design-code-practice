namespace Result.SimpleTextEditor;

public class SimpleTextEditor
{
    private StringBuilder _text;
    private Stack<string> _history;

    public SimpleTextEditor()
    {
      _text = new StringBuilder();
      _history = new Stack<string>();
    }

    public void Delete(int k)
    {
        _history.Push(_text.ToString());
        if (k >= _text.Length)
            _text.Clear();
        else
            _text.Length -= k;
    }

    public char Print(int k)
    {
        return _text[k - 1];
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            _text.Clear();
            _text.Append(_history.Pop());
        }
    }

    public char Print(int k)
    {
      if (k <= 0 || k > _text.Length)
        throw new ArgumentOutOfRangeException(nameof(k), "Invalid index for print operation");

      return _text[k - 1]; // Convert 1-based index to 0-based
    }

  public void Undo()
  {
    if (_history.Count > 0)
    {
      _text.Clear();
      _text.Append(_history.Pop());
    }
  }

  public string GetCurrentText() => _text.ToString();
}

public class Program
{
  public static void Main()
  {
    int q = int.Parse(Console.ReadLine());
    var editor = new SimpleTextEditor();
    var output = new List<char>();

            for (int i = 0; i < q; i++)
        {
            string[] op = Console.ReadLine().Split(' ');
            switch (op[0])
            {
                case "1":
                    editor.Append(op[1]);
                    break;
                case "2":
                    editor.Delete(int.Parse(op[1]));
                    break;
                case "3":
                    output.Add(editor.Print(int.Parse(op[1])));
                    break;
                case "4":
                    editor.Undo();
                    break;
            }
        }

      // Output all print results
      foreach (char c in output)
      {
        Console.WriteLine(c);
      }
  }
}
