//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Material_pared : MonoBehaviour
//{

//    public int nivel;

//    public Room_Template template;

//    private Material material_pared;

//    void Start()
//    {
//        nivel = Random.Range(0, template.materials_pared.Length);
//        material_pared = template.materials_piso[nivel];
//        GetComponent<Renderer>().material = material_pared;
//        //Material();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void Material()
//    {

//        Debug.Log(nivel+"pared");
//        if (nivel == 0)
//        {
//            material_pared = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_pared;
//        }
//        else if (nivel == 1)
//        {
//            material_pared = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_pared;
//        }
//        else if (nivel == 2)
//        {
//            material_pared = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_pared;
//        }
//        else if (nivel == 3)
//        {
//            material_pared = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_pared;
//        }
//        else if (nivel == 4)
//        {
//            material_pared = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_pared;
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_pared : MonoBehaviour
{
    public int nivel;
    public Room_Template template;

    private Renderer renderer;

    void Start()
    {
        // Inicializar el Renderer
        renderer = GetComponent<Renderer>();

        // Asignar un material aleatorio en el inicio
        ApplyRandomMaterial();
    }

    void ApplyRandomMaterial()
    {
        // Asegúrate de que la longitud del array sea válida para evitar errores
        if (template.materials_pared.Length > 0)
        {
            // Genera un índice aleatorio basado en la cantidad de materiales disponibles
            nivel = Random.Range(0, template.materials_pared.Length);
            Debug.Log(nivel + " pared");

            // Asigna el material basado en el índice generado
            if (nivel >= 0 && nivel < template.materials_pared.Length)
            {
                renderer.material = template.materials_pared[nivel];
            }
        }
        else
        {
            Debug.LogWarning("El array de materiales para paredes está vacío.");
        }
    }
}

