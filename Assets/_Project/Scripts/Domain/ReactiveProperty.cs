using System;
using System.Collections.Generic;

namespace VB
{
    public class ReactiveProperty<T>
    {
        private T _value;
        private List<Action<T>> _subscribers = new List<Action<T>>();

        public ReactiveProperty(T initialValue)
        {
            _value = initialValue;
        }

        public T Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<T>.Default.Equals(_value, value))
                {
                    _value = value;
                    NotifySubscribers();
                }
            }
        }

        public void Subscribe(Action<T> subscriber)
        {
            if (subscriber != null)
            {
                _subscribers.Add(subscriber);
                subscriber(_value);
            }
        }

        private void NotifySubscribers()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber(_value);
            }
        }
    }
}
