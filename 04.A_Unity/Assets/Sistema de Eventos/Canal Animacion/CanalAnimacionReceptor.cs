using System.Collections.Generic;
using UnityEngine;

namespace SistemaEventos
{
    public class CanalAnimacionReceptor : MonoBehaviour
    {
        [field: SerializeField] List<CanalAnimacion> CanalAnimacion { get; set; } = new();

        public void DispararEventoAnimacion(string NombreCanal)
        {
            CanalAnimacion CanalEncontrado = CanalAnimacion.Find(busqueda => busqueda.NombreCanal == NombreCanal);
            
            if(CanalEncontrado == null) return;

            CanalEncontrado?.Canal?.Invoke();
        }
    }
}