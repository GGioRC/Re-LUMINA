using SistemaEventos;
using UnityEngine;

public class AnimacionLogo : MonoBehaviour
{

    //  Animacion
    Animator Animator { get; set; }
    int IdReiniciarAnimacion { get; set; }
    int IdReproducirEntrada { get; set; }
    int IdSeleccionarOpciones { get; set; }
    int IdOpcion1 { get; set; }
    int IdOpcion2 { get; set; }
    int IdOpcion3 { get; set; }


    [field: Header("Canal de eventos"), Space(10f)]
    [field: SerializeField] EventListener ReceptorPresionaContinuar { get; set; }
    [field: Space(5f)]
    [field: SerializeField] EventListener ReceptorOpcion1 { get; set; }
    [field: SerializeField] EventListener ReceptorOpcion2 { get; set; }
    [field: SerializeField] EventListener ReceptorOpcion3 { get; set; }


    void Awake()
    {
        Animator = GetComponent<Animator>();
        IdReiniciarAnimacion = Animator.StringToHash("Reiniciar animacion");
        IdReproducirEntrada = Animator.StringToHash("Reproducir entrada");
        IdSeleccionarOpciones = Animator.StringToHash("Seleccionar opciones");
        IdOpcion1 = Animator.StringToHash("C_Opcion 1");
        IdOpcion2 = Animator.StringToHash("C_Opcion 2");
        IdOpcion3 = Animator.StringToHash("C_Opcion 3");
    }
    void Start()
    {
        ReceptorPresionaContinuar.AddAction(SeleccionarOpciones);
        ReceptorOpcion1.AddAction(ReproducirOpcion1);
        ReceptorOpcion2.AddAction(ReproducirOpcion2);
        ReceptorOpcion3.AddAction(ReproducirOpcion3);
    }
    void OnDestroy()
    {
        ReceptorPresionaContinuar.RemoveAction(SeleccionarOpciones);
        ReceptorOpcion1.RemoveAction(ReproducirOpcion1);
        ReceptorOpcion2.RemoveAction(ReproducirOpcion2);
        ReceptorOpcion3.RemoveAction(ReproducirOpcion3);
    }

    void ReiniciarAnimacion() => Animator.SetTrigger(IdReiniciarAnimacion);
    void ReproducirEntrada() => Animator.SetTrigger(IdReproducirEntrada);
    void SeleccionarOpciones() => Animator.SetTrigger(IdSeleccionarOpciones);
    void ReproducirOpcion1() => Animator.Play(IdOpcion1);
    void ReproducirOpcion2() => Animator.Play(IdOpcion2);
    void ReproducirOpcion3() => Animator.Play(IdOpcion3);
}
