using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVetor : MonoBehaviour
{
    public GameObject PontoA;
    public GameObject PontoB;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 A = PontoA.transform.position;
        Vector3 B = PontoB.transform.position;
        float x = Vector3.Distance(A, B) / 2;
        Vector3 P = LerpByDistance(A, B, x);

        transform.position = new Vector3(P.x, P.y, -10);
        GetComponent<Camera>().orthographicSize = x + 2;
    }

    public Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
    {
        Vector3 P = x * Vector3.Normalize(B - A) + A;
        return P;
    }

}