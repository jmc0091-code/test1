using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    public GameObject jugador;
    //public GameObject camara;
    //private Vector3 initPosjug;
    public Vector3 actPosjug;
    public Vector3 offsetjugdos;
    //public Vector3 offsetjug;
    //private Vector3 initPoscam;

    private Vector3 rot;
    private float rotvert;
    public float channelmultrotvert;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initPosjug = jugador.transform.position;
        //initPoscam = transform.position;
        //transform.position = jugador.transform.position + offsetjugdos;

    }

    // Update is called once per frame
    void Update()
    {
        rot = jugador.transform.eulerAngles;
        rotvert = rot.y;
        actPosjug = jugador.transform.position;

        transform.position = actPosjug + offsetjugdos;
        float ratonX = Input.GetAxis("Mouse X") / channelmultrotvert;
        //transform.RotateAround(actPosjug, Vector3.up, ratonX);
    }
}
