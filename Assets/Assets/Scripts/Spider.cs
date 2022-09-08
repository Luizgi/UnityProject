using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public List<Sprite> imgAndarEsquerda;
    public List<Sprite> imgAndarDireita;

    public SpriteRenderer MostrarImagem;

    public int index = 0;
    public int count = 0;

    public string texto = "";
    public string destino = "";

    public int posMin;
    public int posMax;

    public int count2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        MostrarImagem = GetComponent<SpriteRenderer>();
        destino = "Direita";
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        BurriceRandomica();
    }

    void BurriceRandomica()
    {
        count2 = count2 + 1;
        if(count2 > 50)
        {
            count2 = 0;
            int numeroDestino = Random.Range(0, 2);
            if(numeroDestino == 0)
            {
                destino = "Esquerda";
            }
            if (numeroDestino == 1)
            {
                destino = "Direita";
            }
        }
    }

    void Movimento()
    {
        if (destino == "Esquerda")
        {
            transform.position = new Vector3(transform.position.x - 0.009f, transform.position.y, transform.position.z);
            texto = "Esquerda";
            Animacao();
        }
        if (destino == "Direita")
        {
            transform.position = new Vector3(transform.position.x + 0.009f, transform.position.y, transform.position.z);
            texto = "Direita";
            Animacao();
        }
    }
    void Animacao()
    {
        count = count + 1;
        if (count > 25)
        {
            index = index + 1;
            if (index > 4)
            {
                index = 0;
            }
            count = 0;
        }
        if (texto == "Esquerda")
        {
            MostrarImagem.sprite = imgAndarEsquerda[index];
        }
        if (texto == "Direita")
        {
            MostrarImagem.sprite = imgAndarDireita[index];
        }
    }
}
