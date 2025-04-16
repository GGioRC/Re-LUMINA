using SistemaEventos;
using UnityEngine;

public class AnimacionLogo : MonoBehaviour
{

    //  Animacion
    Animator Animator { get; set; }

    int IdReiniciarAnimacion { get; set; }
    int IdReproducirEntrada { get; set; }

    int IdMostrarOpciones { get; set; }

    int IdDirigirOpcion1 { get; set; }
    int IdIniciarJuego { get; set; }
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
        IdMostrarOpciones = Animator.StringToHash("Seleccionar opciones");

        IdDirigirOpcion1 = Animator.StringToHash("C_Dirigir Opcion 1");
        IdIniciarJuego = Animator.StringToHash("Iniciar juego");
        IdOpcion3 = Animator.StringToHash("C_Opcion 3");
    }
    void Start()
    {
        ReceptorPresionaContinuar.AddAction(MostrarOpciones);
        ReceptorOpcion1.AddAction(ReproducirOpcion1);
        ReceptorOpcion2.AddAction(IniciarJuego);
        ReceptorOpcion3.AddAction(ReproducirOpcion3);
    }
    void OnDestroy()
    {
        ReceptorPresionaContinuar.RemoveAction(MostrarOpciones);
        ReceptorOpcion1.RemoveAction(ReproducirOpcion1);
        ReceptorOpcion2.RemoveAction(IniciarJuego);
        ReceptorOpcion3.RemoveAction(ReproducirOpcion3);
    }

    void ReiniciarAnimacion() => Animator.SetTrigger(IdReiniciarAnimacion);
    void ReproducirEntrada() => Animator.SetTrigger(IdReproducirEntrada);

    void MostrarOpciones() => Animator.SetTrigger(IdMostrarOpciones);

    void ReproducirOpcion1() => Animator.Play(IdDirigirOpcion1);
    void IniciarJuego() => Animator.SetTrigger(IdIniciarJuego);
    void ReproducirOpcion3() => Animator.Play(IdOpcion3);
}
