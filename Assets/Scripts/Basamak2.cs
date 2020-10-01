using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basamak2 : MonoBehaviour
{
    Vector3[] vertices;

    void Start()
    {
        RandomTriangle();
    }

    private void RandomTriangle()
    {
        //Random 3 nokta oluşturuldu.
        vertices = new[]
       {
            new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f)),
            new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f)),
            new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f)),
        };

        //Hesaplanan alan konsolda yazdırıldı.
        Debug.Log("Area Calculate: " + Area(vertices[0], vertices[1], vertices[2]));

    }

    //Oluşturulan noktalar arasında kalan kısım(üçgen) alanı hesaplandı.
    public float Area(Vector3 point1, Vector3 point2, Vector3 point3)
    {
        float res = Mathf.Pow(((point2.x * point1.y) - (point3.x * point1.y) - (point1.x * point2.y) + (point3.x * point2.y) + (point1.x * point3.y) - (point2.x * point3.y)), 2.0f);
        res += Mathf.Pow(((point2.x * point1.z) - (point3.x * point1.z) - (point1.x * point2.z) + (point3.x * point2.z) + (point1.x * point3.z) - (point2.x * point3.z)), 2.0f);
        res += Mathf.Pow(((point2.y * point1.z) - (point3.y * point1.z) - (point1.y * point2.z) + (point3.y * point2.z) + (point1.y * point3.z) - (point2.y * point3.z)), 2.0f);
        return Mathf.Sqrt(res) * 0.5f;

    }

}