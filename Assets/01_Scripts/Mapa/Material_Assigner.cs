using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Assigner : MonoBehaviour
{
//    public Room_Template template;

//    private Renderer floorRenderer;
//    private Renderer wallRenderer;

//    private int nivel;

//    void Start()
//    {
//        // Inicializar los Renderers usando etiquetas
//        floorRenderer = GameObject.FindGameObjectWithTag("Piso").GetComponent<Renderer>();
//        wallRenderer = GameObject.FindGameObjectWithTag("Pared").GetComponent<Renderer>();

//        // Aplicar un material aleatorio al inicio
//        AssignRandomMaterial();
//    }

//    void AssignRandomMaterial()
//    {
//        // Asegúrate de que los arrays tengan elementos
//        if (template.materials_piso.Length > 0 && template.materials_pared.Length > 0)
//        {
//            // Generar un índice aleatorio
//            nivel = Random.Range(0, Mathf.Min(template.materials_piso.Length, template.materials_pared.Length));
//            Debug.Log("Nivel: " + nivel);

//            // Asignar el material para el piso
//            floorRenderer.material = template.materials_piso[nivel];

//            // Asignar el material para la pared
//            wallRenderer.material = template.materials_pared[nivel];
//        }
//        else
//        {
//            Debug.LogWarning("Uno o ambos arrays de materiales están vacíos.");
//        }
//    }
}
