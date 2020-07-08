using System;
using Xamarin.Forms;

namespace Seamgen.Essentials.EventToCommandBehavior
{
    /// <summary>
    /// Behavior base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        /// <summary>
        /// The associated object
        /// </summary>
        public T AssociatedObject { get; private set; }

        /// <summary>
        /// On attached to
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        /// <summary>
        /// On detaching from
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        /// <summary>
        /// On binding context changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        /// <summary>
        /// On binding context changed
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
