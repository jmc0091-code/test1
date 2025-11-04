using System.Runtime.CompilerServices;
using UnityEngine;

public class movimientoDisp : MonoBehaviour
{
    public float velMov = 0;
    public float sensRat = 0;
    public GameObject prefabBala;
    public GameObject puntoDisparo;
    public float fuerzaBala;

    public float contadorEnem;

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update ejecutándose");
        float tecladoEnX = Input.GetAxis("Horizontal");
        float tecladoEnY = Input.GetAxis("Vertical");

        transform.Translate(tecladoEnX * velMov * Time.deltaTime, 0, tecladoEnY * velMov * Time.deltaTime);

        float movX = (Input.GetAxis("Mouse X"));

        transform.Rotate(0, movX * sensRat, 0);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bala = Instantiate(prefabBala, puntoDisparo.transform.position, puntoDisparo.transform.rotation);
            Rigidbody rbBala = bala.GetComponent<Rigidbody>();
            rbBala.AddForce(puntoDisparo.transform.forward * fuerzaBala, ForceMode.Impulse);
            Destroy(bala, 5f);
        }
        //Debug.Log(contadorEnem);

    }
}
