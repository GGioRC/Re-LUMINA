using UnityEngine;

namespace SistemaEventos
{
    [CreateAssetMenu(menuName = "Sistema de Eventos/Canal de Eventos/GameObjectChannel", order = 7)]
    public class GameObjectEventChannel : EventChannel<GameObject> { }
}