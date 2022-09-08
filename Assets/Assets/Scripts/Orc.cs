using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    public GameObject Heroi;
    private SpriteRenderer MostrarImagem;
    public List<Sprite> imgAndarCima;
    public List<Sprite> imgAndarBaixo;
    public List<Sprite> imgAndarDireita;
    public List<Sprite> imgAndarEsquerda;
    public float diferencaX;
    public float diferencaY;
    public bool ataque = false;
    public List<Sprite> imgAtkCima;
    public List<Sprite> imgAtkDireita;
    public List<Sprite> imgAtkEsquerda;
    public List<Sprite> imgAtkBaixo;
    public string direcao;
    public int contadorParaAtacar;
    public int movimentoAtaque;
    public int indiceAtk;
    public int contador = 0;
    public int indice = 0;

    public int contadorMorte = 0;
    public GameObject TELADERROTA;

    void Start()
    {
        Heroi = GameObject.FindGameObjectWithTag("Player");
        MostrarImagem = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ataque == true)
        {
            Atacando();
        }
        else
        {
            Perseguir();
            VerHeroi();
        }

        if(contadorMorte == 5)
        {
            Destroy(Heroi);
            TELADERROTA.SetActive(true);
        }
        
    }
    void Atacando()
    {
        contadorParaAtacar++;
        if (contadorParaAtacar > 60)
        {

            movimentoAtaque++;
            float distancia = Vector3.Distance(transform.position, Heroi.transform.position);
            
                if (direcao == "Esquerda")
                {

                    if (movimentoAtaque> 90)
                    {
                        indiceAtk++;
                        movimentoAtaque = 0;
                    }
                    if (indiceAtk >= imgAtkEsquerda.Count)
                    {
                    //Meu ataque terminou
                        if (distancia <= 2f)
                        {
                        contadorMorte++;
                        }
                        indiceAtk = 0;
                    ataque = false;
                    contadorParaAtacar = 0;

                    }
                MostrarImagem.sprite = imgAtkEsquerda[indiceAtk];

            }
                if (direcao == "Direita")
                {
                if (movimentoAtaque > 90)
                {
                    indiceAtk++;
                    movimentoAtaque = 0;

                }
                if (indiceAtk >= imgAtkDireita.Count)
                {
                    //Meu ataque terminou
                    if (distancia <= 2f)
                    {
                        contadorMorte++;
                    }
                    indiceAtk = 0;
                    ataque = false;
                    contadorParaAtacar = 0;

                }
                MostrarImagem.sprite = imgAtkDireita[indiceAtk];
            }
                if (direcao == "Cima")
                {
                if (movimentoAtaque > 90)
                {
                    indiceAtk++;
                    movimentoAtaque = 0;
                }
                if (indiceAtk >= imgAtkCima.Count)
                {
                    //Meu ataque terminou
                    if (distancia <= 2f)
                    {
                        contadorMorte++;
                    }
                    indiceAtk = 0;
                    ataque = false;
                    contadorParaAtacar = 0;

                }
                MostrarImagem.sprite = imgAtkCima[indiceAtk];
            }
                if (direcao == "Baixo")
                {
                if (movimentoAtaque > 90)
                {
                    indiceAtk++;
                    movimentoAtaque = 0;
                }
                if (indiceAtk >= imgAtkBaixo.Count)
                {
                    //Meu ataque terminou
                    if (distancia <= 2f)
                    {
                        contadorMorte++;
                    }
                    indiceAtk = 0;
                    ataque = false;
                    contadorParaAtacar = 0;

                }
                MostrarImagem.sprite = imgAtkBaixo[indiceAtk];
            }
                

            
        }
    }

    void Perseguir()
    {
        float distancia = Vector3.Distance(transform.position, Heroi.transform.position);
        if(distancia < 3 && distancia > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Heroi.transform.position, 0.0005f);

        }else if (distancia <= 2f)
        {
            ataque = true;
        }

    }


    void VerHeroi()
    {
        float posXheroi = Heroi.transform.position.x;
        float posYheroi = Heroi.transform.position.y;
        float posXmonstro = transform.position.x;
        float posYmonstro = transform.position.y;

        diferencaX = posXmonstro - posXheroi;
        if(diferencaX < 0)
        {
            diferencaX = diferencaX * -1;
        }

        diferencaY = posYmonstro - posYheroi;
        if(diferencaY < 0)
        {
            diferencaY = diferencaY * -1;
        }

        if(diferencaX > diferencaY)
        {
            if (posXmonstro > posXheroi)
            {
                direcao = "Esquerda";
                Animacao();
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            }
            else
            {
                direcao = "Direita";
                Animacao();
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (posYmonstro > posYheroi)
            {
                direcao = "Baixo";
                Animacao();
                transform.position = new Vector3(transform.position.x , transform.position.y - 0.01f, transform.position.z);
            }
            else
            {
                direcao = "Cima";
                Animacao();
                transform.position = new Vector3(transform.position.x , transform.position.y + 01f, transform.position.z);
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

        if (direcao == "Cima")
        {
            MostrarImagem.sprite = imgAndarCima[indice];
        }
        if (direcao == "Baixo")
        {
            MostrarImagem.sprite = imgAndarBaixo[indice];
        }
        if (direcao == "Esquerda")
        {
            MostrarImagem.sprite = imgAndarEsquerda[indice];
        }
        if (direcao == "Direita")
        {
            MostrarImagem.sprite = imgAndarDireita[indice];

        }
    }
}
