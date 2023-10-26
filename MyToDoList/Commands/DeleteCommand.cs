
using MyToDoList.Data;

namespace MyToDoList.Commands;

internal class DeleteCommand : ICommand
{
    private readonly IToDoList _toDoList;

    public string Description => "Удалить задачу";

    public DeleteCommand(IToDoList toDoList)
    {
        _toDoList = toDoList;
    }

    public void Execute()
    {
        do
        {
            Console.WriteLine("Введите номер задачи");

            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                _toDoList.Delete(taskId);
                break;
            }
        } while (true);
    }
}
