using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basamak1 : MonoBehaviour
{
    Vector3[] vertices;

    //20 defa RandomTriangle() methodu çağırıldı.
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            RandomTriangle();
        }
    }

    private void RandomTriangle()
    {
        //Random 1 ve 2 aralığında değer alan 3 nokta oluşturuldu.
        vertices = new[]
       {
            new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f)),
            new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f)),
            new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f)),
        };

        //Oluşturulan köşe noktaları konsola yazdırıldı.
        Debug.Log("First vertice: " + vertices[0]);
        Debug.Log("Second vertice: " + vertices[1]);
        Debug.Log("Third vertice: " + vertices[2]);

        //3 noktanın birleşmesiyle oluşan açılar konsola yazdırıldı.
        Debug.Log("First angle: " + Vector3.Angle(vertices[0] - vertices[1], vertices[0] - vertices[2]));
        Debug.Log("Second angle: " + Vector3.Angle(vertices[1] - vertices[0], vertices[1] - vertices[2]));
        Debug.Log("Third angle: " + Vector3.Angle(vertices[2] - vertices[0], vertices[2] - vertices[1]));

    }


}