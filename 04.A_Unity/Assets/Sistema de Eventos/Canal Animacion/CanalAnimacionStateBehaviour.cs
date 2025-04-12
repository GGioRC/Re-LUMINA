using System;
using System.Linq;
using UnityEngine;

namespace SistemaEventos
{

    public class CanalAnimacionStateBehaviour : StateMachineBehaviour
    {
        [Header("Linea de Tiempo"), Space(5f)]
        [SerializeField] string NombreCanal;
        [field: SerializeField, Range(0f, 1f)] float EsperaParaDesencadenar { get; set; }
        bool EsDesencadenado { get; set; }
        float TiempoActual { get; set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => EsDesencadenado = false;
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (EsperaParaDesencadenar == 1) return;

            TiempoActual = stateInfo.normalizedTime % 1f;

            if (!EsDesencadenado && TiempoActual >= EsperaParaDesencadenar)
            {
                NotificarReceptores(animator);
                EsDesencadenado = true;
            }
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!EsDesencadenado && EsperaParaDesencadenar == 1)
                NotificarReceptores(animator);

            EsDesencadenado = false;
        }

        void NotificarReceptores(Animator animator)
        {
            CanalAnimacionReceptor Receptor = animator.GetComponent<CanalAnimacionReceptor>();

            Receptor.DispararEventoAnimacion(NombreCanal);
        }
    }
}