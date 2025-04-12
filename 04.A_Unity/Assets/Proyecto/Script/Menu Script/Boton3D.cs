using SistemaEventos;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boton3D : MonoBehaviour, IPointerClickHandler
{
    Collider Collider { get; set; }

    [field: Header("Canal de eventos"), Space(10f)]
    [field: SerializeField] EventChannel EmisorPresionarBoton { get; set; }


    protected void Awake()
    {
        Collider = GetComponent<Collider>();
        DesactivarCollider();
    }
    protected void ActivarCollider() => Collider.enabled = true;
    protected void DesactivarCollider() => Collider.enabled = false;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        DesactivarCollider();

        EmisorPresionarBoton?.Invoke();
    }
}
