
using MyToDoList.Data;

namespace MyToDoList.Commands;

internal class MarkAsCompletedCommand : ICommand
{
    private readonly IToDoList _toDoList;

    public string Description => "Пометить задачу как выполненную";

    public MarkAsCompletedCommand(IToDoList toDoList)
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
                _toDoList.MarkAsCompleted(taskId);
                break;
            }
        } while (true);
    }
}
