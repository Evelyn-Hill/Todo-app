using System;
namespace TodoApp;

public class Program
{

    struct Todo
    {
        public string Title;
        public string Task;
    }

    static string TodosPath { get; set; } = "./tododata";

    static void Main(string[] argv)
    {

        if (argv[0] == "-a")
        {
            Todo td = new()
            {
                Title = "task",
                Task = "do thing",
            };

            WriteTodo(td);
        }

        if (argv[0] == "-r")
        {
            foreach (string todo in FetchTodos())
            {
                Console.WriteLine(todo);
            }
        }
    }


    static void WriteTodo(Todo todo)
    {
        if (!File.Exists(TodosPath))
        {
            using (StreamWriter sw = File.CreateText(TodosPath))
            {
                sw.WriteLine($"{todo.Title}: {todo.Task}");
            }
        }
    }

    static string[] FetchTodos()
    {
        string[] toReturn = [];

        string? todoString;

        using (StreamReader sr = File.OpenText(TodosPath))
        {
            while ((todoString = sr.ReadLine()) != null)
            {
                toReturn.Append(todoString);
                Console.WriteLine($"Added {todoString}");
            }
        }

        return toReturn;
    }
}

