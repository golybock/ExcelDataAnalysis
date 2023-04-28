using System;
using System.Windows.Input;

namespace ExcelDataAnalysis.Models.Command;

public class CommandHandler : ICommand
{
    private readonly Action _action;
    private Func<bool> _canExecute;

    public CommandHandler(Action action, Func<bool> canExecute)
    {
        _action = action;
        _canExecute = canExecute;
    }

    public CommandHandler(Action action)
    {
        _action = action;
        _canExecute = () => true;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _action();
    }
}

public class CommandHandler<T> : ICommand
{
    private readonly Func<T, bool> _canExecute;
    private readonly Action<T> _execute;

    public CommandHandler(Action<T> execute, Func<T, bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute((T) parameter);
    }

    public void Execute(object parameter)
    {
        _execute((T) parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}