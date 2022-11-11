using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Estilingui : MonoBehaviour
{
    public LineRenderer[] faixas;
    public Transform[] pontasFaixa;
    public Transform faixaParada;
    public Transform faixaCentro;

    public Vector3 extremidadeFaixa;

    public float tamanhoFaixa;

    bool mousePrecionado;

    public GameObject bolaPrefabs;

    public GameObject bolaGO;

    public float descolamentoBola;

    Rigidbody2D bola;
    Collider2D bolaColide;

    public float force;
    void Start()
    {
        faixas[0].positionCount = 2;
        faixas[1].positionCount = 2;
        faixas[0].SetPosition(0, pontasFaixa[0].position);
        faixas[1].SetPosition(0, pontasFaixa[1].position);

        CriarBolas();
    }
    void CriarBolas()
    {
        bolaGO = Instantiate(bolaPrefabs);
        bola = bolaGO.GetComponent<Rigidbody2D>();
        bolaColide = bola.GetComponent<Collider2D>();
        bolaColide.enabled = false;

        bola.isKinematic = true;

        bolaGO.transform.localRotation = Quaternion.identity;

        ResetarPosicao();
    }
    void Update()
    {
        if (mousePrecionado)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            extremidadeFaixa = Camera.main.ScreenToWorldPoint(mousePosition);
            extremidadeFaixa = faixaCentro.position + Vector3.ClampMagnitude(extremidadeFaixa - faixaCentro.position, tamanhoFaixa);

            FaixaPosicoes(extremidadeFaixa);

            if (bolaColide)
            {
                bolaColide.enabled = true;
            }
        }
        else
        {
            ResetarPosicao();
        }
    }
    private void OnMouseDown()
    {
        mousePrecionado = true;
    }

    private void OnMouseUp()
    {
        mousePrecionado = false;

        AitrarBolas();
        extremidadeFaixa = faixaParada.position;
    }
    void AitrarBolas()
    {
        if(bola == null)
        {
            return;
        }
        bola.isKinematic = false;
        Vector3 bolaForce = (extremidadeFaixa - faixaCentro.position) * force * -1;
        //bola.velocity = bolaForce;
        bola.AddForce(bolaForce, ForceMode2D.Impulse);

        bola.GetComponent<Bola>().BolaInicializada();

        bola = null;
        bolaColide = null;
        Invoke("CriarBolas", 2);


    }
    void ResetarPosicao()
    {
        extremidadeFaixa = faixaParada.position;
        FaixaPosicoes(extremidadeFaixa);
    }
    void FaixaPosicoes(Vector3 position)
    {
        faixas[0].SetPosition(1, position);
        faixas[1].SetPosition(1, position);

        if (bola)
        {
            Vector3 dir = position - faixaCentro.position;

            bola.transform.position = position + dir.normalized * descolamentoBola;
            bola.transform.right = -dir.normalized;
        }
    }
}
