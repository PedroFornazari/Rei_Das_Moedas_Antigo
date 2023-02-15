using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrato : MonoBehaviour
{
    public List<Conta> conta;

    int total_final;
    int total_positivo;
    int total_negativo;
    int dia;
    int mes;
    int ano;


    void Atualiza_Total_Negativo()
    {
        int tamanho_array_conta = conta.Count;
        for (int i = 0; i < tamanho_array_conta; i++)
        {
            int valor_extraido_parcela = conta[i].Get_Valor_Parcelado();
            conta[i].Diminui_Parcela();
            if (conta[i].Get_Parcelas() <= 0)
            {
                conta.RemoveAt(i);
            }

            total_negativo = total_negativo + valor_extraido_parcela;
        }
    }

    public void Atualiza_Total_Final()
    {
        total_final = total_positivo - total_negativo;
    }

    public Conta Get_Conta(int id)
    {
        return conta[id];
    }

    public int Get_Numero_Contas()
    {
        return conta.Count;
    }

    public void Add_Conta(Conta c)
    {
        conta.Add(c);
    }

    public void Set_Total_Positivo(int tp)
    {
        total_positivo = tp;
    }

    public void Set_Data(int d,int m,int a)
    {
        dia = d;
        mes = m;
        ano = a;
    }
}
