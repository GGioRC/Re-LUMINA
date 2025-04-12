using SistemaEventos;
using UnityEngine;

public class PresionaContinuar : Boton3D
{
    [field: Space(5f)]
    [field: SerializeField] EventListener ReceptorTerminarPresentarLogo { get; set; }
    [field: SerializeField] EventListener ReceptorReiniciarAnimacionLogo { get; set; }


    void Start()
    {
        ReceptorTerminarPresentarLogo.AddAction(ActivarCollider);
        ReceptorReiniciarAnimacionLogo.AddAction(DesactivarCollider);
    }
    void OnDestroy()
    {
        ReceptorTerminarPresentarLogo.RemoveAction(ActivarCollider);
        ReceptorReiniciarAnimacionLogo.RemoveAction(DesactivarCollider);
    }
}
