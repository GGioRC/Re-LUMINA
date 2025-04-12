using System;
using UnityEngine;
using UnityEngine.Events;

namespace SistemaEventos
{
    public abstract class EventListener<T> : EventListenerBase
    {
        [field: SerializeField] EventChannel<T> EventChannel { get; set; }
        [field: SerializeField] Action<T> Event { get; set; }

        protected override void Register() => EventChannel.Register(this);
        protected override void Unregister() => EventChannel.Unregister(this);

        public void AddAction(Action<T> _action)
        {
            if (_action is Action<T> action)
                Event += action;
        }
        public void RemoveAction(Action<T> _action)
        {
            if (_action is Action<T> action)
                Event -= action;
        }

        public void Raise(T value) => Event?.Invoke(value);
    }

    public class EventListener : EventListenerBase
    {
        [field: SerializeField] EventChannel EventChannel { get; set; }
        [field: SerializeField] Action Event { get; set; }

        protected override void Register() => EventChannel.Register(this);
        protected override void Unregister() => EventChannel.Unregister(this);

        public void AddAction(Action _action)
        {
            if (_action is Action action)
                Event += action;
        }
        public void RemoveAction(Action _action)
        {
            if (_action is Action action)
                Event -= action;
        }

        public void Raise() => Event?.Invoke();
    }
}