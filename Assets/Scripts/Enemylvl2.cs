using UnityEngine;

public class Enemylvl2 : MonoBehaviour
{
    public GameObject cuboFractured;
    public LevelMachineScript mDp;
    public float VelRotacion = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
 
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

    void Update()
    {
        transform.Rotate(0, VelRotacion, 0);
    }

}
