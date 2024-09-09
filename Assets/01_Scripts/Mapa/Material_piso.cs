//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Material_piso : MonoBehaviour
//{
//    public int nivel;

//    public  Room_Template template;

//    private Material material_piso;


//    void Start()
//    {
//        Material();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void Material()
//    {
//        nivel = Random.Range(0, template.materials_piso.Length);
//        Debug.Log(nivel+"piso");
//        if (nivel == 0)
//        {
//            material_piso = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_piso;
//        }
//        else if (nivel == 1)
//        {
//            material_piso = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_piso;
//        }
//        else if (nivel == 2)
//        {
//            material_piso = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_piso;
//        }
//        else if (nivel == 3)
//        {
//            material_piso = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_piso;
//        }
//        else if (nivel == 4)
//        {
//            material_piso = template.materials_piso[nivel];
//            GetComponent<Renderer>().material = material_piso;
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_piso : MonoBehaviour
{
    public int nivel;

    public Room_Template template;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        ApplyRandomMaterial();
    }

    void ApplyRandomMaterial()
    {
        // Aseg�rate de que la longitud del array sea v�lida para evitar errores
        if (template.materials_piso.Length > 0)
        {
            // Genera un �ndice aleatorio basado en la cantidad de materiales disponibles
            nivel = Random.Range(0, template.materials_piso.Length);
            Debug.Log(nivel + " piso");

            // Asigna el material basado en el �ndice generado
            if (nivel >= 0 && nivel < template.materials_piso.Length)
            {
                renderer.material = template.materials_piso[nivel];
            }
        }
        else
        {
            Debug.LogWarning("El array de materiales est� vac�o.");
        }
    }
}

