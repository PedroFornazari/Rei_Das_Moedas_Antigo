using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armazem : MonoBehaviour
{
    public GameObject interface_armazem;
    public Tela tela_armazem;
    public Tela tela_compra_mantimentos;

    public int quantidade_comida_armazenada = 0;
    public int quantidade_bebida_armazenada = 0;

    public GameObject[] saco_comida;
    public GameObject[] barril_bebida;

    public int quantidade_comida_comprada = 0;
    public int quantidade_bebida_comprada = 0;
    public int valor_comida = 2;
    public int valor_bebida = 4;

    public Banco banco;
    Conta conta_a_pagar;

    void Update()
    {
        Atualiza_Tela_Compra_Mantimentos();
        Atualiza_Tela_Quantidade_Suprimentos();
        Atualiza_Quantidade_Modelos_Bebida();
        Atualiza_Quantidade_Modelos_Comida();
    }

    public void Atualiza_Tela_Quantidade_Suprimentos()
    {
        tela_armazem.Set_Text_String("Sacos de Farinha " + quantidade_comida_armazenada.ToString(), 0);
        tela_armazem.Set_Text_String("Barris de Vinho " + quantidade_bebida_armazenada.ToString(), 1);
    }

    public void Atualiza_Quantidade_Modelos_Comida()
    {
        for (int i = 0; i < saco_comida.Length; i++)
        {
            saco_comida[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < quantidade_comida_armazenada; i++)
        {
            saco_comida[i].gameObject.SetActive(true);
        }
    }

    public void Atualiza_Quantidade_Modelos_Bebida()
    {
        for (int i = 0; i < barril_bebida.Length; i++)
        {
            barril_bebida[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < quantidade_bebida_armazenada; i++)
        {
            barril_bebida[i].gameObject.SetActive(true);
        }
    }

    public void Adiciona_Comida(int quantidade)
    {
        if (quantidade_comida_armazenada + quantidade < saco_comida.Length)
        {
            quantidade_comida_armazenada = quantidade_comida_armazenada + quantidade;

            Toca_Efeito_Consome_Suprimentos();
        }
    }

    public void Adiciona_Bebida(int quantidade)
    {
        if (quantidade_bebida_armazenada + quantidade < barril_bebida.Length)
        {
            quantidade_bebida_armazenada = quantidade_bebida_armazenada + quantidade;
        }
    }

    public void Perde_Comida()
    {
        quantidade_comida_armazenada = quantidade_comida_armazenada - 1;
        Toca_Efeito_Consome_Suprimentos();
    }

    public void Perde_Bebida()
    {
        quantidade_bebida_armazenada = quantidade_bebida_armazenada - 1;
    }

    public void Atualiza_Tela_Compra_Mantimentos()
    {
        tela_compra_mantimentos.Set_Text_String(quantidade_comida_comprada.ToString(), 0);
        tela_compra_mantimentos.Set_Text_String(quantidade_bebida_comprada.ToString(), 1);
        tela_compra_mantimentos.Set_Text_String(valor_comida.ToString() + "$", 2);
        tela_compra_mantimentos.Set_Text_String(valor_bebida.ToString() + "$", 3);
    }

    public void Aumenta_Quantidade_Comida_Comprada()
    {
        if (quantidade_comida_comprada < saco_comida.Length)
        {
            quantidade_comida_comprada = quantidade_comida_comprada + 1;
        }
    }
    public void Aumenta_Quantidade_Bebida_Comprada()
    {
        if (quantidade_bebida_comprada < barril_bebida.Length)
        {
            quantidade_bebida_comprada = quantidade_bebida_comprada + 1;
        }
    }
    public void Diminui_Quantidade_Comida_Comprada()
    {
        if (quantidade_comida_comprada > 0)
        {
            quantidade_comida_comprada = quantidade_comida_comprada - 1;
        }
    }
    public void Diminiu_Quantidade_Bebida_Comprada()
    {
        if (quantidade_bebida_comprada > 0)
        {
            quantidade_bebida_comprada = quantidade_bebida_comprada - 1;
        }
    }

    public void Fecha_Compra_Mantimentos()
    {
        Adiciona_Comida(quantidade_comida_comprada);
        Adiciona_Bebida(quantidade_bebida_comprada);
        conta_a_pagar = new Conta("Mantimentos",
            (quantidade_bebida_comprada * valor_bebida) + (quantidade_comida_comprada * valor_comida));
        banco.Adiciona_Nova_Conta(conta_a_pagar);
    }

    public void Ativa_Tela_Armazem()
    {
        interface_armazem.gameObject.SetActive(true);
    }

    public void Desativa_Tela_Armazem()
    {
        interface_armazem.gameObject.SetActive(false);
    }

    public void Toca_Efeito_Consome_Suprimentos()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
    }

    public int Get_Quantidade_Comida()
    {
        return quantidade_comida_armazenada;
    }

    public int Get_Quantidade_Bebida()
    {
        return quantidade_bebida_armazenada;
    }
}
