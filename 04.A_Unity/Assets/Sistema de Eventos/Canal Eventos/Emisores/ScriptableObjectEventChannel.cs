using UnityEngine;

namespace SistemaEventos
{
    [CreateAssetMenu(menuName = "Sistema de Eventos/Canal de Eventos/ScriptableObjectChannel", order = 8)]
    public class ScriptableObjectEventChannel : EventChannel<ScriptableObject> { }
}