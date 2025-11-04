using UnityEngine;

public class RotacionCamarita : MonoBehaviour
{
    public Transform target;     
    public float distancia = 5f;  
    public float altura = 2f;    
    public float Suavizado = 10f; 

    void LateUpdate()
    {
        if (target == null) return;


        Vector3 desiredPosition = target.position - target.forward * distancia + Vector3.up * altura;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * Suavizado);
        transform.LookAt(target.position + Vector3.up * altura * 0.5f);
    }
}
