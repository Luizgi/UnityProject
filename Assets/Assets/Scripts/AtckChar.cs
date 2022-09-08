using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtckChar : MonoBehaviour
{ 
    public GameObject Spider;
    public GameObject Orc;
    public GameObject FireSkull;
    public GameObject Slime;
    public int ganhar = 0;
    public GameObject TelaVitoria;
    // Update is called once per fram
    void Start()
    {

    }
    void Update()
    {

        Ganhar();
        AtckOrc();
        AtckSpider();
        AtckSkull();
        AtckSlime();

    }
    public void AtckOrc()
    {
        //Minha Posição
        if (Orc != null) {
            Vector3 CharPosicao = transform.position;
            Vector3 OrcPosicao = Orc.transform.position;
            float distanciaDoOrc = Vector3.Distance(CharPosicao, OrcPosicao);
            if (distanciaDoOrc < 1f && Input.GetKeyDown(KeyCode.K))
            {
                Destroy(Orc.gameObject);
                ganhar++;
                
            }
        }
    }

    public void AtckSpider()
    {
        if (Spider != null)
        {
            Vector3 CharPosicao = transform.position;
            Vector3 SpiderPosicao = Spider.transform.position;
            float distanciaDaSpider = Vector3.Distance(CharPosicao, SpiderPosicao);
            if (distanciaDaSpider < 1f && Input.GetKeyDown(KeyCode.K))
            {
                Destroy(Spider.gameObject);
                ganhar++;
            }
        }
    }
    public void AtckSkull()
    {
        //Minha Posição
        if (FireSkull != null)
        {
            Vector3 CharPosicao = transform.position;
            Vector3 FireSkullPosicao = FireSkull.transform.position;
            float distanciaDaFireSkull = Vector3.Distance(CharPosicao, FireSkullPosicao);
            if (distanciaDaFireSkull < 2f && Input.GetKeyDown(KeyCode.K))
            {
                Destroy(FireSkull.gameObject);
                ganhar++;
            }
        }
    }
    public void AtckSlime()
    {
        //Minha Posição
        if (Slime != null)
        {
            Vector3 CharPosicao = transform.position;
            Vector3 SlimePosicao = Slime.transform.position;
            float distanciaDaSlime = Vector3.Distance(CharPosicao, SlimePosicao);
            if (distanciaDaSlime < 2f && Input.GetKeyDown(KeyCode.K))
            {
                Destroy(Slime.gameObject);
                ganhar++;
            }
        }
    }
    public void Ganhar()
    {
        if(ganhar == 4)
        {
            TelaVitoria.SetActive(true);
        }
    }
}
