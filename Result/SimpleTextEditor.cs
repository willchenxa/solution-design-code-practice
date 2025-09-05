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

  public void Append(string w)
  {
    // Save current state for undo
    _history.Push(_text.ToString());
    _text.Append(w);
  }

  public void Delete(int k)
  {
    if (k <= 0) return;

    // Save current state for undo
    _history.Push(_text.ToString());

    if (k >= _text.Length)
    {
      _text.Clear();
    }
    else
    {
      _text.Length -= k;
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
      string[] operation = Console.ReadLine().Split(' ');
      int opType = int.Parse(operation[0]);

      try
      {
        switch (opType)
        {
          case 1: // Append
            string w = operation[1];
            editor.Append(w);
            break;

          case 2: // Delete
            int k = int.Parse(operation[1]);
            editor.Delete(k);
            break;

          case 3: // Print
            int printIndex = int.Parse(operation[1]);
            char character = editor.Print(printIndex);
            output.Add(character);
            break;

          case 4: // Undo
            editor.Undo();
            break;
        }
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine($"Error processing operation {i + 1}: {ex.Message}");
      }
    }

    // Output all print results
    foreach (char c in output)
    {
      Console.WriteLine(c);
    }
  }
}


// using System;
// using System.Collections.Generic;
// using System.IO;
// class Solution
// {
//  static void Main(String[] args)
//  {
//   int numOfOperations = Convert.ToInt32(Console.ReadLine());
//   //Console.WriteLine(numOfOperations);
//   string originalStr = "";
//   Stack<string> results = new Stack<string>();
//   for (int i = 0; i < numOfOperations; i++)
//   {
//    //Console.WriteLine(i);
//    var input = Console.ReadLine();
//    string[] ops = input.Split(" ");
//    var operation = Convert.ToInt32(ops[0]);
//    // if(ops.Length > 1)
//    //     Console.WriteLine($"{ops[0]}, {ops[1]}");
//    // else
//    //     Console.WriteLine($"{ops[0]}");
//    switch (operation)
//    {
//     case 1: results.Push(originalStr); originalStr = appendString(originalStr, ops[1]); break;
//     case 2: results.Push(originalStr); originalStr = deleteChars(originalStr, Convert.ToInt32(ops[1])); break;
//     case 3: printChar(originalStr, ops[1]); break;
//     case 4: originalStr = results.Pop(); break;
//     default: break;
//    }

//    //Console.WriteLine(originalStr);
//   }
//  }

//  private static string appendString(string originalStr, string appendedStr)
//  {
//   return originalStr + appendedStr;
//  }

//  private static void printChar(string originalStr, string index)
//  {
//   int i = Convert.ToInt32(index);
//   //Console.WriteLine(i);
//   if (i > originalStr.Length)
//    return;

//   Console.WriteLine(originalStr[i - 1]);
//  }
//  private static string deleteChars(string originalStr, int numOfChars)
//  {
//   if (numOfChars >= originalStr.Length)
//    return string.Empty;
//   var index = originalStr.Length - numOfChars;

//   if (index <= 0)
//    return "";

//   return originalStr[..index];
//  }

// }
