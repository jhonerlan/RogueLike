using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador_Mapa : MonoBehaviour
{
    public GameObject roomPrefab; // Prefab para las habitaciones
    public GameObject corridorPrefab; // Prefab para los pasillos
    public int width = 5; // Ancho de la mazmorra
    public int height = 5; // Altura de la mazmorra

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Puedes usar una lógica más compleja para decidir qué tipo de prefab colocar
                GameObject prefabToUse = Random.Range(0f, 1f) > 0.5f ? roomPrefab : corridorPrefab;
                Instantiate(prefabToUse, new Vector3(x * 5, 0, y * 5), Quaternion.identity);
            }
        }
    }
    void GenerateDungeon1()
    {
        DivideAndConquer(0, 0, width, height);
    }

    void DivideAndConquer(int x, int y, int w, int h)
    {
        if (w < 10 || h < 10) return; // Tamaño mínimo

        // Dividir en dos mitades
        int splitX = x + Random.Range(1, w - 1);
        int splitY = y + Random.Range(1, h - 1);

        // Generar habitaciones en cada mitad
        GenerateRoom(x, y, splitX - x, splitY - y);
        GenerateRoom(splitX, splitY, w - (splitX - x), h - (splitY - y));

        // Conectar con pasillos
        GenerateCorridor(new Vector3(splitX * 10, 0, y * 10), new Vector3(splitX * 10, 0, splitY * 10));
        GenerateCorridor(new Vector3(x * 10, 0, splitY * 10), new Vector3(splitX * 10, 0, splitY * 10));
    }

    void GenerateRoom(int x, int y, int w, int h)
    {
        // Implementa la lógica para crear una habitación en el área especificada
    }

    void GenerateCorridor(Vector3 start, Vector3 end)
    {
        // Implementa la lógica para crear un pasillo entre dos puntos
    }
}
