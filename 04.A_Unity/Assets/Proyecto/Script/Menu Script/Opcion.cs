using SistemaEventos;
using UnityEngine;
using UnityEngine.EventSystems;

public class Opcion : Boton3D
{
    [field: SerializeField, Tooltip("Depende del objeto")] EventChannel EmisorPresionarOpcionBoton { get; set; }
    
    [field: Space(5f)]
    [field: SerializeField] EventListener ReceptorMostrarOpcionesLogo { get; set; }
    [field: SerializeField] EventListener ReceptorPresionarOpcionBoton { get; set; }


    void Start()
    {
        ReceptorMostrarOpcionesLogo.AddAction(ActivarCollider);
        ReceptorPresionarOpcionBoton.AddAction(DesactivarCollider);
    }
    void OnDestroy()
    {
        ReceptorMostrarOpcionesLogo.RemoveAction(ActivarCollider);
        ReceptorPresionarOpcionBoton.RemoveAction(DesactivarCollider);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        
        EmisorPresionarOpcionBoton?.Invoke();
    }
}
