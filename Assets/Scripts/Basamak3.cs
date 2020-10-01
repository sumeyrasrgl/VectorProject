using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Basamak3 : MonoBehaviour
{
    void Start()
    {

        //10 adet random üçgen oluşturuldu. 
        List<CreateTriangle> vertices = new List<CreateTriangle>();
        for (int i = 0; i < 10; i++)
        {
            CreateTriangle triangle = RandomTriangle(i);
            vertices.Add(triangle);

        }

        Color rndColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //Sıralanmadan önceki hali çizdirildi.
        vertices.ForEach(triangle => {
            Debug.DrawLine(triangle.Vector1, triangle.Vector2, rndColor, 100);
            Debug.DrawLine(triangle.Vector2, triangle.Vector3, rndColor, 100);
            Debug.DrawLine(triangle.Vector1, triangle.Vector3, rndColor, 100);
        });

        //Üçgenlerin açıları büyükten küçüğe göre sıralandı.
        vertices = vertices.OrderByDescending(triangle => triangle.MaxAngle).ToList<CreateTriangle>();

        Color rndColor2 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //Üçgenlerin açılarına göre büyükten küçüğe olacak şekilde yeni pozisyonlarında çizdirildi.
        vertices = newTrianglesPosition(vertices);
        vertices.ForEach(triangle => {
            Debug.DrawLine(triangle.Vector1, triangle.Vector2, rndColor2, 100);
            Debug.DrawLine(triangle.Vector2, triangle.Vector3, rndColor2, 100);
            Debug.DrawLine(triangle.Vector1, triangle.Vector3, rndColor2, 100);
        });


    }

    public CreateTriangle RandomTriangle(int basePoint)
    {
        CreateTriangle vertices = new CreateTriangle();
        float max = 0.9f;
        float min = 0.1f;

        //Random 3 nokta oluşturuldu.En büyük kenar 1 birim olacak şekilde normalizasyon yapıldı.

        vertices.Vector1 = new Vector3(basePoint, 0, 0);
        vertices.Vector2 = new Vector3(basePoint + 1, 0, 0);
        vertices.Vector3 = new Vector3(Random.Range(min, max) + basePoint, Random.Range(min, max), Random.Range(0, 0));

        //Noktalar arasındaki açılar hesaplandı.
        float firstAngle = Vector3.Angle(vertices.Vector1 - vertices.Vector2, vertices.Vector1 - vertices.Vector3);
        float secondAngle = Vector3.Angle(vertices.Vector2 - vertices.Vector1, vertices.Vector2 - vertices.Vector3);
        float thirdAngle = Vector3.Angle(vertices.Vector3 - vertices.Vector1, vertices.Vector3 - vertices.Vector2);

        //En büyük açı hesaplandı.
        //En büyük birim 1 olduğu için her zaman bu kenarın karşısındaki yani 3. noktanın oluşturduğu açı en büyük açı olur.
        vertices.MaxAngle = Vector3.Angle(vertices.Vector3 - vertices.Vector1, vertices.Vector3 - vertices.Vector2);

        return vertices;
    }

    //Oluşturulan random üçgenlerin noktaları ve en büyük açısı bir yapı içinde tutuldu.
    public struct CreateTriangle
    {
        public Vector3 Vector1;
        public Vector3 Vector2;
        public Vector3 Vector3;
        public float MaxAngle;
    }

    //Üçgenlerin yeni pozisyonu 
    public List<CreateTriangle> newTrianglesPosition(List<CreateTriangle> triangles)
    {

        for (int i = 0; i < triangles.Count; i++)
        {
            var triangle = triangles[i];
            //1.noktanın x i değişmemesi için 
            var vectorx = triangle.Vector1.x;


            triangle.Vector1 = new Vector3(i, 0, 0);
            triangle.Vector2 = new Vector3(i + 1, 0, 0);
            //Üçgenin yeni pozisyonunda 3.noktanın x'i sıralamasına göre kaydırıldı.Y 'si değişmedi.
            triangle.Vector3 = new Vector3(i + (triangle.Vector3.x - vectorx), triangle.Vector3.y, 0);
            triangles[i] = triangle;
        }
        return triangles;
    }
}