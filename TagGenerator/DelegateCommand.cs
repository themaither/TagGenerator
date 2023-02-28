using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TagGenerator;
public class DelegateCommand : ICommand
{

    public event EventHandler? CanExecuteChanged;

    public Action<object?> Action { get; }

    public DelegateCommand(Action<object?> action)
    {
        Action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        Action.Invoke(parameter);
    }
}
