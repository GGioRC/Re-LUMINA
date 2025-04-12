using System;
using UnityEngine;

namespace SistemaEventos
{
    public abstract class EventListenerBase : MonoBehaviour
    {
        protected void Awake() => Register();
        protected void OnDestroy() => Unregister();
        protected void OnEnable() => Register();
        protected void OnDisable() => Unregister();

        protected abstract void Register();
        protected abstract void Unregister();
    }
}