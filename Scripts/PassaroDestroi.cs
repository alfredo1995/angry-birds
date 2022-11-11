using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaroDestroi : MonoBehaviour
{
    bool passaroColidiu;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!passaroColidiu && !collision.CompareTag("Bomba"))
        {
            Destroy(gameObject);

            ControleCena.INSTANCE.ContadorBloco();

            passaroColidiu = true;
        }
    }

}

