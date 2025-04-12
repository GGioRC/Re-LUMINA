using UnityEngine;

namespace SistemaEventos
{
    public abstract class EventChannelBase : ScriptableObject
    {
        public abstract void Register(object observer);
        public abstract void Unregister(object observer);
    }
}