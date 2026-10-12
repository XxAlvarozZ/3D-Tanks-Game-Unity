using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Esto es para usar TextMeshPro

public class MenuManager : MonoBehaviour
{
    [Header("Arrastra aquí los objetos de la pantalla")]
    public TMP_InputField inputNombre; // El cuadro de texto
    public TMP_Dropdown dropdownNiveles; // El menú desplegable

    [Header("Nombres EXACTOS de tus escenas")]
    // ¡OJO! Aquí debes escribir los nombres tal cual aparecen en tu carpeta de Scenes
    public string[] nombresDeEscenas = { "Nivel3_Arena", "Nivel2_Nieve", "Main" };

    // Esta función se ejecutará cuando el jugador haga clic en el botón
    public void BotonJugar()
    {
        // 1. Guardar el nombre del jugador
        string nombre = inputNombre.text;

        // Si el jugador no escribe nada, le ponemos un nombre por defecto
        if (string.IsNullOrEmpty(nombre))
        {
            nombre = "Tanque " + Random.Range(100, 999);
        }

        // Guardamos el nombre en la memoria del juego (PlayerPrefs)
        PlayerPrefs.SetString("NombreJugador", nombre);
        PlayerPrefs.Save();

        // 2. Obtener el nivel elegido en el Dropdown (0, 1 o 2)
        int nivelElegido = dropdownNiveles.value;

        // 3. Cargar la escena correspondiente
        SceneManager.LoadScene(nombresDeEscenas[nivelElegido]);
    }
}