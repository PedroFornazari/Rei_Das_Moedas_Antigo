using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investimentos : MonoBehaviour
{
    public Banco banco;
    public Tela tela_investimento;
    public Tela tela_investir;
    public GameObject[] barras_ouro;

    public bool investimento_ativo = false;
    float valor_inicial_investido = 0;
    public float valor_atual_investido = 0;
    float variavel_investimento = 0;
    int tempo_inicial_investimento = 0;
    int tempo_atual_investimento = 0;
    float valor_tempo_investimento = 0;

    private void Update()
    {
        if (investimento_ativo)
        {
            Atualiza_Tela_Investimento();
        }

        Atualiza_Barras_Ouro();
    }

    public void Investe()
    {
        Toca_Efeito_Investimento();
        valor_tempo_investimento = tempo_inicial_investimento / 10;
        tempo_atual_investimento = tempo_inicial_investimento;
        valor_atual_investido = valor_inicial_investido;
        investimento_ativo = true;
        tela_investimento.Set_Tela_Active(true);
        tela_investir.Set_Tela_Active(false);
    }

    public void Atualiza_Valor_Investido()
    {
        if(investimento_ativo)
        {
            variavel_investimento = Random.Range(1.0f, 1.5f) + valor_tempo_investimento;
            valor_atual_investido = valor_atual_investido * variavel_investimento;
            valor_atual_investido = Mathf.Round(valor_atual_investido);
            tempo_atual_investimento = tempo_atual_investimento - 1;
            Atualiza_Tela_Investir();
            if (tempo_atual_investimento <= 0)
            {
                Retira_Valor_Investido();
            }
        }
    }

    public void Retira_Valor_Investido()
    {
        Toca_Efeito_Investimento();
        banco.Adiciona_Ouro((int)valor_atual_investido);
        valor_atual_investido = 0;
        valor_tempo_investimento = 0;
        investimento_ativo = false;
        tela_investir.Set_Tela_Active(true);
        tela_investimento.Set_Tela_Active(false);
    }

    public void Atualiza_Tela_Investimento()
    {
        tela_investimento.Set_Text_String("Valor Inicial Investido " + valor_inicial_investido.ToString() + " $", 0);
        tela_investimento.Set_Text_String("Valor Atual " + valor_atual_investido.ToString() + " $", 1);
        tela_investimento.Set_Text_String("Prazo " + tempo_atual_investimento + " Meses ".ToString(), 2);
    }

    public void Atualiza_Tela_Investir()
    {
        tela_investir.Set_Text_String(valor_inicial_investido.ToString(), 0);
        tela_investir.Set_Text_String(tempo_inicial_investimento.ToString(), 1);
    }


    public void Aumenta_Tempo_p_Investir()
    {
        if(tempo_inicial_investimento < 12)
        {
            tempo_inicial_investimento++;
            Atualiza_Tela_Investir();
        }
    }

    public void Diminui_Tempo_p_Investir()
    {
        if(tempo_inicial_investimento > 0)
        {
            tempo_inicial_investimento--;
            Atualiza_Tela_Investir();
        }

    }

    public void Aumenta_Valor_p_Investir()
    {
        if(valor_inicial_investido < banco.Get_Saldo())
        {
            valor_inicial_investido = valor_inicial_investido + 10;
            Atualiza_Tela_Investir();
        }
    }

    public void Diminui_Valor_p_Investir()
    {
        if(valor_inicial_investido > 0)
        {
            valor_inicial_investido--;
            Atualiza_Tela_Investir();
        }
    }

    public void Atualiza_Barras_Ouro()
    {

        // a cada 20 uma barra

        int quantide_barras = (int)valor_atual_investido / 20;


        for (int i = 0; i < quantide_barras; i++)
        {
            barras_ouro[i].SetActive(true);
        }

        for(int i = quantide_barras; i < barras_ouro.Length; i++)
        {
            barras_ouro[i].SetActive(false);
        }

    }

    public void Toca_Efeito_Investimento()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
    }
}
