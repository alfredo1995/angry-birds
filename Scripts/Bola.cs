using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = Vector3.zero; 
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Passaro"))
        {
            Invoke("DeletarBola", 1);
        }
    }

    public void DeletarBola()
    {   
        Destroy(this.gameObject);
    }

    public void BolaInicializada()
    {
        Invoke("DeletarBola", 2);

    }
}
