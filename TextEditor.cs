using System;

class TextState
{
    public string Content { get; set; }
    public TextState Previous { get; set; }
    public TextState Next { get; set; }

    public TextState(string content)
    {
        Content = content;
        Previous = null;
        Next = null;
    }
}

class TextEditor
{
    private TextState current;
    private TextState head;
    private TextState tail;
    private int historySize;
    private int maxHistorySize;
    
    public TextEditor(int maxSize = 10)
    {
        maxHistorySize = maxSize;
        historySize = 0;
        AddState("");
    }

    public void AddState(string content)
    {
        TextState newState = new TextState(content);
        
        if (head == null)
        {
            head = tail = current = newState;
            historySize = 1;
            return;
        }

        if (current != tail)
        {
            tail = current;
            tail.Next = null;
        }

        newState.Previous = tail;
        tail.Next = newState;
        tail = newState;
        current = newState;

        historySize++;
        
        if (historySize > maxHistorySize)
        {
            head = head.Next;
            head.Previous = null;
            historySize--;
        }
    }

    public string Undo()
    {
        if (current?.Previous == null)
            return current?.Content ?? "";

        current = current.Previous;
        return current.Content;
    }

    public string Redo()
    {
        if (current?.Next == null)
            return current?.Content ?? "";

        current = current.Next;
        return current.Content;
    }

    public string GetCurrentState()
    {
        return current?.Content ?? "";
    }

    public void DisplayHistory()
    {
        TextState temp = head;
        int stateNumber = 1;
        
        while (temp != null)
        {
            string currentMarker = (temp == current) ? " (current)" : "";
            Console.WriteLine($"State {stateNumber}: {temp.Content}{currentMarker}");
            temp = temp.Next;
            stateNumber++;
        }
    }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor(5);

        editor.AddState("Hello");
        editor.AddState("Hello world");
        editor.AddState("Hello world!");
        
        Console.WriteLine("Current state: " + editor.GetCurrentState());
        
        Console.WriteLine("\nUndo: " + editor.Undo());
        Console.WriteLine("Undo: " + editor.Undo());
        
        Console.WriteLine("\nRedo: " + editor.Redo());
        
        editor.AddState("Hello world!!");
        
        Console.WriteLine("\nFinal History:");
        editor.DisplayHistory();
    }
}