using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    //Lista para andar

    public List<Sprite> imgAndarDireita;
    public List<Sprite> imgAndarEsquerda;
    public List<Sprite> imgAndarBaixo;
    public List<Sprite> imgAndarCima;
    
    public List<Sprite> imgAtckDireita;
    public List<Sprite> imgAtckEsquerda;
    public List<Sprite> imgAtckBaixo;
    public List<Sprite> imgAtckCima;

    public List<Sprite> imgIdleBaixo;
    public List<Sprite> imgIdleCima;
    public List<Sprite> imgIdleDireita;
    public List<Sprite> imgIdleEsquerda;
    public GameObject Player;

    public SpriteRenderer MostrarImagem;

    public int contador;
    public int indice;
    public string texto = "";

    public bool taAtacando = false;
    void Start()
    {
        MostrarImagem = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(taAtacando == true)
        {
            Animacao();
        } else
        {
            Movimento();
            Ataque();
            Animacao();
            Idle();

        }
    }
  
    void Movimento()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            texto = "Direita";
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
            texto = "Esquerda";
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
            texto = "Cima";
          
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);
            texto = "Baixo";
            
        }


    }
    void Ataque()
    {
        if (Input.GetKey(KeyCode.K) && texto == "Direita")
        {
            texto = "AtckDireita";
            indice = 0;           
            taAtacando = true;
        }
        if (Input.GetKey(KeyCode.K) && texto == "Esquerda")
        {
            texto = "AtckEsquerda";
            indice = 0;
            taAtacando = true;
        }
        if (Input.GetKey(KeyCode.K) && texto == "Cima")
        {
            texto = "AtckCima";
            indice = 0;
            taAtacando = true;
        }
        if (Input.GetKey(KeyCode.K) && texto == "Baixo")
        {
            texto = "AtckBaixo";
            indice = 0;
            taAtacando = true;
        }
        
    }

    void Idle()
    {
       if (!Input.anyKey)
        {
            if(texto == "Baixo" || texto == "AtckBaixo")
            {
                texto = "idleBaixo";
            }
            if(texto == "Cima" || texto == "AtckCima")
            {
                texto = "idleCima";
            }
            if (texto == "Direita" || texto == "AtckDireita")
            {
                texto = "idleDireita";
            }
            if (texto == "Esquerda" || texto == "AtckEsquerda")
            {
                texto = "idleEsquerda";
            }

        }


    }
    void Animacao()
    {
        contador = contador + 1;
        if (contador > 50)
        {
            indice = indice + 1;
            if (indice > 3)
            {
                indice = 0;
            }
            contador = 0;
        }

        if (texto == "Cima")
        {
            MostrarImagem.sprite = imgAndarCima[indice];
        }
        if (texto == "Baixo")
        {
            MostrarImagem.sprite = imgAndarBaixo[indice];
        }
        if (texto == "Esquerda")
        {
            MostrarImagem.sprite = imgAndarEsquerda[indice];
        }
        if (texto == "Direita")
        {
            MostrarImagem.sprite = imgAndarDireita[indice];

        }
        if (texto == "AtckDireita")
        {
            MostrarImagem.sprite = imgAtckDireita[indice];
            if(indice == 3)
            {
                texto = "Direita";
                taAtacando = false;
            }
        }
        if (texto == "AtckEsquerda")
        {
            MostrarImagem.sprite = imgAtckEsquerda[indice];
            if (indice == 3)
            {
                texto = "Esquerda";
                taAtacando = false;
            }
        }
        if (texto == "AtckCima")
        {
            MostrarImagem.sprite = imgAtckCima[indice];
            if (indice == 3)
            {
                texto = "Cima";
                taAtacando = false;
            }
        }
        if (texto == "AtckBaixo")
        {
            MostrarImagem.sprite = imgAtckBaixo[indice];
            if (indice == 3)
            {
                texto = "Baixo";
                taAtacando = false;
            }
        }
        if (texto == "idleBaixo")
        {
            MostrarImagem.sprite = imgIdleBaixo[indice];
        }
        if (texto == "idleCima")
        {
            MostrarImagem.sprite = imgIdleCima[indice];
        }
        if (texto == "idleDireita")
        {
            MostrarImagem.sprite = imgIdleDireita[indice];
        }
        if (texto == "idleEsquerda")
        {
            MostrarImagem.sprite = imgIdleEsquerda[indice];
        }
    }
}
