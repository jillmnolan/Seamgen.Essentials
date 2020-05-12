using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Seamgen.Essentials.EventToCommandBehavior
{
    /// <summary>
    /// A command that is debounced. 
    /// </summary>
    public class DebouncedCommand : ICommand
    {
        private const uint defaultThreshold = 2000;

        private readonly ICommand _internalCommand;
        private Timer _timer;

        /// <summary>
        /// Event handler
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="threshold"></param>
        public DebouncedCommand(Action action, uint threshold = defaultThreshold)
        {
            _internalCommand = new Command(action);
            Setup(threshold);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="threshold"></param>
        public DebouncedCommand(Action<object> action, uint threshold = defaultThreshold)
        {
            _internalCommand = new Command(action);
            Setup(threshold);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="execute"></param>
        /// <param name="threshold"></param>
        public DebouncedCommand(Action<object> action, Func<object, bool> execute, uint threshold = defaultThreshold)
        {
            _internalCommand = new Command(action, execute);
            Setup(threshold);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="execute"></param>
        /// <param name="threshold"></param>
        public DebouncedCommand(Action action, Func<bool> execute, uint threshold = defaultThreshold)
        {
            _internalCommand = new Command(action, execute);
            Setup(threshold);
        }

        private void Setup(uint threshold)
        {
            _timer = new Timer(threshold)
            {
                AutoReset = false
            };
            _timer.Elapsed += (arg1, arg2) =>
            {
                this.CanExecuteChanged(this, new EventArgs());
                _timer.Stop();
            };

            _internalCommand.CanExecuteChanged += (arg1, arg2) =>
            {
                this.CanExecuteChanged(this, arg2);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return !_timer.Enabled && _internalCommand.CanExecute(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (!_timer.Enabled)
            {
                _timer.Start();
                _internalCommand.Execute(parameter);
            }
        }
    }
}
