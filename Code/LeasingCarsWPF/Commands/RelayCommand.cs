using System;

namespace LeasingCarsWPF.Commands
{
    public class RelayCommand : BaseCommand
    {
        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public override void Execute(object? parameter)
        {
            _action.Invoke();
        }
    }
}