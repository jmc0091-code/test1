using UnityEngine;

public class Rotaccione : MonoBehaviour
{
    public float rotaccione = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotaccione, 0);
    }
}
