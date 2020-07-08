using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Seamgen.Essentials.Forms
{
    /// <summary>
    /// A custom pop-up alert
    /// </summary>
    public partial class AlertPopUp : PopupPage, INotifyPropertyChanged
    {
        private string _alertMessage;
        /// <summary>
        /// The text displayed in the alert pop-up underneath the title
        /// </summary>
        public string AlertMessage
        {
            get => _alertMessage;
            set => SetProperty(ref _alertMessage, value);
        }

        private string _okButtonText;
        /// <summary>
        /// The text displayed as the Ok button
        /// </summary>
        public string OkButtonText
        {
            get => _okButtonText;
            set => SetProperty(ref _okButtonText, value);
        }

        private ICommand _okButtonCommand;
        /// <summary>
        /// The command executed when the OK button is tapped
        /// </summary>
        public ICommand OkButtonCommand
        {
            get => _okButtonCommand;
            set => SetProperty(ref _okButtonCommand, value);
        }

        private string _cancelButtonText;
        /// <summary>
        /// The text displayed as the Ok button
        /// </summary>
        public string CancelButtonText
        {
            get => _cancelButtonText;
            set => SetProperty(ref _cancelButtonText, value);
        }

        private ICommand _cancelButtonCommand;
        /// <summary>
        /// The command executed when the OK button is tapped
        /// </summary>
        public ICommand CancelButtonCommand
        {
            get => _cancelButtonCommand;
            set => SetProperty(ref _cancelButtonCommand, value);
        }

        /// <summary/>
        /// <param name="title">Title</param>
        /// <param name="alertMessage">Message</param>
        /// <param name="okButton">Confirm button text</param>
        /// <param name="cancelButton">Cancel button text</param>
        /// <param name="iconImageName">Icon image name</param>
        public AlertPopUp(string title, string alertMessage, Tuple<string, ICommand> okButton, Tuple<string, ICommand> cancelButton, string iconImageName = null)
        {
            InitializeComponent();

            this.BindingContext = this;

            this.Title = title;
            this.AlertMessage = alertMessage;
            this.OkButtonText = okButton.Item1;
            this.OkButtonCommand = okButton.Item2;
            this.CancelButtonText = cancelButton.Item1;
            this.CancelButtonCommand = cancelButton.Item2;
            this.IconImageSource = iconImageName;
        }

        #region BindableBase

        /// <summary>
        /// Bindable Base Set Property
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="storage">Storage</param>
        /// <param name="value">Value</param>
        /// <param name="propertyName">Property Name</param>
        /// <returns><c>true</c>, if the property was set</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
