using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControleCena : MonoBehaviour
{
    public TextMeshProUGUI contadoTexto;

    public GameObject gameOver;

    private int contadorNumero;
    public int passaroIndex;

    public static ControleCena INSTANCE;
    public void Awake()
    {
        INSTANCE = this;
    }

    public void ContadorBloco()
    {
        contadorNumero++;

        if (contadorNumero >= passaroIndex)
        {
            //Debug.Log("Debug");
            //gameOver.SetActive(true);
            SceneManager.LoadScene("Cena1");

        }
        contadoTexto.text = "PASSAROS : " + contadorNumero;
    }

    public void ResetarCena()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
