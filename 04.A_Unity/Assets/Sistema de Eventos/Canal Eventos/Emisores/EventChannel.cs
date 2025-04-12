using System.Collections.Generic;
using UnityEngine;

namespace SistemaEventos
{
    public class EventChannel<T> : EventChannelBase
    {
        readonly HashSet<EventListener<T>> observers = new();

        public void Invoke(T value)
        {
            if (observers == null)
                return;
            foreach (var observer in observers)
            {
                observer.Raise(value);
            }
        }

        public override void Register(object observer)
        {
            if (observer is EventListener<T> observerListener)
                observers.Add(observerListener);
        }

        public override void Unregister(object observer)
        {
            if (observer is EventListener<T> observerListener)
                observers.Remove(observerListener);
        }
    }


    [CreateAssetMenu(menuName = "Sistema de Eventos/Canal de Eventos/EventChannel", order = 0)]
    public class EventChannel : EventChannelBase
    {
        readonly HashSet<EventListener> observers = new();

        public void Invoke()
        {
            foreach (var observer in observers)
            {
                observer.Raise();
            }
        }

        public override void Register(object observer)
        {
            if (observer is EventListener observerListener)
                observers.Add(observerListener);
        }

        public override void Unregister(object observer)
        {
            if (observer is EventListener observerListener)
                observers.Remove(observerListener);
        }
    }
}