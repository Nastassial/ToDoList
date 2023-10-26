using MyToDoList.Commands;
using MyToDoList.Data;

namespace MyToDoList;
internal class Menu
{
    public Menu() { }

    public void Start()
    {
        var todoList = new ToDoList();
        List<ICommand> commands = new()
        {
            new ExitCommand(),
            new AddCommand(todoList),
            new DeleteCommand(todoList),
            new MarkAsCompletedCommand(todoList)
        };

        do
        {
            Console.Clear();
            Console.WriteLine("Задачи:");
            PrintList(todoList.ToDoItems());
            Console.WriteLine("Достижения:");
            PrintList(todoList.DoneItems());

            for (int i = 0; i < commands.Count; i++)
            {
                Console.Write(i + ") ");
                Console.WriteLine(commands[i].Description);
            }
            Console.Write("=> ");

            if (int.TryParse(Console.ReadLine(), out int commandId) && commandId >= 0 && commandId < commands.Count)
            {
                commands[commandId].Execute();
            }
            else
            {
                Console.WriteLine("Недопустимое значение");
            }

            todoList.Save();
        } while (true);
    }

    public static void PrintList(List<Data.Task> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(i + "->");
            Console.WriteLine($"{list[i].Description}   {list[i].CompletedTime ?? list[i].CreatedTime}");
        }
    }

    public static void PrintList(ToDoList toDoList)
    {
        Console.WriteLine(toDoList.Load());
    }
}
