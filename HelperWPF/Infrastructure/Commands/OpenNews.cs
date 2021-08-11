using System;
using HelperWPF.Infrastructure.Commands.Base;

namespace HelperWPF.Infrastructure.Commands
{
    internal class OpenNews : Command
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public OpenNews(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
