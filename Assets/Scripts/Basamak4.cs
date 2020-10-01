using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basamak4 : MonoBehaviour
{
    Vector3[] vertices;

    void Start()
    {
        //20 adet üçgen üst üste binecek şekilde renkli oluşturuldu.
        for (int i = 0; i < 20; i++)
        {
            RandomTriangle();

            //Oluşturulan her üçgen için farklı random bir Color oluşturuldu.
            Color rndColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            //Oluşturulan üçgenler üst üste gelecek renkli bir şekilde sahnede çizdirildi.
            Debug.DrawLine(vertices[0], vertices[1], rndColor, 100);
            Debug.DrawLine(vertices[1], vertices[2], rndColor, 100);
            Debug.DrawLine(vertices[0], vertices[2], rndColor, 100);
        }

    }

    private void RandomTriangle()
    {
        float max = 0.9f;
        float min = 0.1f;

        //Random 3 nokta oluşturuldu. En büyük kenar yatayda 1 birim olacak şekilde normalizasyon yapıldı.
        vertices = new[]
        {
            new Vector3(0, 0, 0).normalized,
            new Vector3(1, 0, 0).normalized,
            new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(1, 1)),

        };


    }



}