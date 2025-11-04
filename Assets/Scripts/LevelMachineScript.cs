using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class LevelMachineScript : MonoBehaviour
{
    public float contadorEnem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int thresh = 4;

    public Button botonSiguiente;
    public TextMeshProUGUI mensaje;
    public TextMeshProUGUI contadorInterfaz;
    void Start()
    {
        if (botonSiguiente != null) botonSiguiente.gameObject.SetActive(false);
        if (mensaje != null) mensaje.gameObject.SetActive(false);

        if (botonSiguiente != null)
        {
            botonSiguiente.onClick.RemoveAllListeners();
            botonSiguiente.onClick.AddListener(ClickSiguiente);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int indiceEscena = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(contadorEnem);
        if (indiceEscena == 2)
        {
            if(contadorEnem >= thresh)
            {
                Victoria();
            }
            else
            {
                OcultarHud();
            }
        }
        else
        {
            if (contadorEnem >= thresh)
            {
                Siguiente();
            }
            else{
                OcultarHud();
            }
        }
        if (contadorInterfaz != null)
        {
            contadorInterfaz.gameObject.SetActive(true);
            contadorInterfaz.text = "Puntos: " + contadorEnem + "/4";
        }

    }
    void Siguiente()
    {
        if (mensaje != null) mensaje.gameObject.SetActive(false);
        if (botonSiguiente != null) botonSiguiente.gameObject.SetActive(true);
    }

    void Victoria()
    {
        if (botonSiguiente != null) botonSiguiente.gameObject.SetActive(false);
        if (mensaje != null)
        {
            mensaje.gameObject.SetActive(true);
            mensaje.text = "Has ganado loquete";

        }
    }
    void OcultarHud()
    {
        if (mensaje != null) mensaje.gameObject.SetActive(false);
        if (botonSiguiente != null) botonSiguiente.gameObject.SetActive(false);
    }
    void ClickSiguiente()
    {
        int scActual = SceneManager.GetActiveScene().buildIndex;
        int siguiente = scActual + 1;
        if (siguiente < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguiente);
        }
    }


}
