using UnityEngine;

public class ScriptEnemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float contador;
    public float destroyEnemiethresh = 1f;
    public Transform suelo;
    private Vector3 destino;
    public float velocidad = 1f;

    public GameObject cuboFractured;
    public LevelMachineScript mDp;
    void Start()
    {

        if (mDp == null)
            mDp = Object.FindFirstObjectByType<LevelMachineScript>();

        destino = GenerarDestinoAleatorio();


        Destroy(gameObject, destroyEnemiethresh);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        Vector3 direccion = destino - transform.position;
    }

    Vector3 GenerarDestinoAleatorio()
    {
        
        Vector3 tamaño = suelo.localScale;
        Vector3 centro = suelo.position;

        float ancho = 10f * tamaño.x; 
        float largo = 10f * tamaño.z;
        float x = Random.Range(centro.x - ancho / 2f, centro.x + ancho / 2f);
        float z = Random.Range(centro.z - largo / 2f, centro.z + largo / 2f);
        float y = transform.position.y; 

        return new Vector3(x, y, z);
    }
    void RecibirDisparo()
    {
        GameObject destruido = Instantiate(cuboFractured, transform.position, transform.rotation);
        Rigidbody[] fragmentos = destruido.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in fragmentos)
        {
            rb.AddExplosionForce(20f, transform.position, 5f, 1f, ForceMode.Impulse);
        }
        Destroy(destruido, 5f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bala"))
        {
            mDp.contadorEnem++;
            RecibirDisparo();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
