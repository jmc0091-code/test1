using UnityEngine;
using UnityEngine.Rendering;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;      
    public int cantidad = 5;            
    public Transform suelo;
    public float multiplierspawnZone = 10f;
    public float offsetencimaplano = 1f;
    public float timingEnemigos = 1f;
    private float contador;
    private int contadorCantidad = 0;

    void Start()
    {

    }

    private void Update()
    {
        contador += Time.deltaTime;
        if (contador >= timingEnemigos && contadorCantidad<cantidad)
        {
            SpawnEnemigo();
            contador = 0f;
            contadorCantidad++;
        }
    }

    void SpawnEnemigo()
    {
        Vector3 tamaño = suelo.localScale;
        Vector3 centro = suelo.position;

        float ancho = multiplierspawnZone * tamaño.x;
        float largo = multiplierspawnZone * tamaño.z;

        float x = Random.Range(centro.x - ancho / 2f, centro.x + ancho / 2f);
        float z = Random.Range(centro.z - largo / 2f, centro.z + largo / 2f);
        float y = centro.y + offsetencimaplano;

        Vector3 posicion = new Vector3(x, y, z);

        


        Instantiate(enemyPrefab, posicion, Quaternion.identity);
    }
}
