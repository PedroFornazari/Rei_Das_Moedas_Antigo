using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    public Banco banco;
    public Armazem armazem;
    public Investimentos investimentos;
    public Controla_Eventos controla_eventos;
    public Controle_Camera controle_camera;

    //Tempo
    public Tela tela_tempo;
    public float tempo = 0;
    public float dia = 1;
    public float mes = 1;
    public float ano = 1650;


    //vitoria derrota
    public int valor_vitoria = 25000;
    public int prazo_derrota = 1650;
    public int contador_derrota = 0;

    private void Update()
    {
        if(this.GetComponent<Controle_Menus>().Get_Jogo_Pausado() == false)
        {
            Avanca_Tempo();
        }
    }

    public void Avanca_Tempo()
    {
        tempo = tempo + Time.deltaTime;
        if(tempo > 1)
        {
            Condicao_Derrota();
            dia = dia + 1;
            tempo = 0;

            controla_eventos.Sorteia_Ocorre_Evento();

            if (dia > 30)
            {
                Condicao_Vitoria();
                mes = mes + 1;
                dia = 1;

                armazem.Perde_Comida();
                armazem.Perde_Bebida();
                investimentos.Atualiza_Valor_Investido();
                banco.Atualiza_Banco();

                if (mes > 12)
                {
                    ano = ano + 1;
                    mes = 1;
                }
            }
        }

        tela_tempo.Set_Text_String(((int)dia).ToString() + " /", 0);
        tela_tempo.Set_Text_String(((int)mes).ToString() + " /", 1);
        tela_tempo.Set_Text_String(((int)ano).ToString(), 2);
    }

    public void Condicao_Vitoria()
    {
        if (banco.Get_Saldo() > valor_vitoria)
        {
            {
                this.GetComponent<Controle_Menus>().Ativa_Tela_Vitoria();
            }
        }
    }

    public void Condicao_Derrota()
    {
        if (armazem.Get_Quantidade_Bebida() < 0 || armazem.Get_Quantidade_Comida() < 0)
        {
            contador_derrota++;
        }
        else contador_derrota = 0;

        if(contador_derrota > 30 || ano > prazo_derrota)
        {
            this.GetComponent<Controle_Menus>().Ativa_Tela_Derrota();
        }
    }
        
}
