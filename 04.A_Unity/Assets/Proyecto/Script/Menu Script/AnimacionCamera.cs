using SistemaEventos;
using UnityEngine;

public class AnimacionCamera : MonoBehaviour
{
    //  Animacion
    Animator Animator { get; set; }
    int IdReiniciarAnimacion { get; set; }
    int IdOpcion1 { get; set; }
    int IdOpcion2 { get; set; }
    int IdOpcion3 { get; set; }


    [field: Header("Canal de eventos"), Space(10f)]
    [field: SerializeField] EventListener ReceptorRegresarMenu { get; set; }
    [field: Space(5f)]
    [field: SerializeField] EventListener ReceptorOpcion1 { get; set; }
    [field: SerializeField] EventListener ReceptorOpcion2 { get; set; }
    // [field: SerializeField] EventListener ReceptorOpcion3 { get; set; }

    void Awake()
    {
        Animator = GetComponent<Animator>();
        IdReiniciarAnimacion = Animator.StringToHash("Reiniciar animacion");
        IdOpcion1 = Animator.StringToHash("Opcion 1");
        IdOpcion2 = Animator.StringToHash("Opcion 2");
        IdOpcion3 = Animator.StringToHash("Opcion 3");
    }
    void Start()
    {
        ReceptorRegresarMenu.AddAction(ReiniciarAnimacion);
        ReceptorOpcion1.AddAction(ReproducirOpcion1);
        ReceptorOpcion2.AddAction(ReproducirOpcion2);
        // ReceptorOpcion3.AddAction(ReproducirOpcion3);
    }
    void OnDestroy()
    {
        ReceptorRegresarMenu.RemoveAction(ReiniciarAnimacion);
        ReceptorOpcion1.RemoveAction(ReproducirOpcion1);
        ReceptorOpcion2.RemoveAction(ReproducirOpcion2);
        // ReceptorOpcion3.RemoveAction(ReproducirOpcion3);
    }

    void ReiniciarAnimacion() => Animator.SetTrigger(IdReiniciarAnimacion);

    void ReproducirOpcion1() => Animator.SetTrigger(IdOpcion1);
    void ReproducirOpcion2() => Animator.SetTrigger(IdOpcion2);
    void ReproducirOpcion3() => Animator.SetTrigger(IdOpcion3);
}
