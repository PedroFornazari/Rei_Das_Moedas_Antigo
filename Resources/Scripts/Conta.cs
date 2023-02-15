using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conta : MonoBehaviour
{
    public string nome;
    public int valor_total;
    public int parcelas;
    public int parcelas_total;
    public int valor_parcelado;

   public Conta(string n, int vt)
    {
        nome = n;
        valor_total = vt;
    }

    public Conta() { }

    public void Parcelar_Conta(int vezes)
    {
        parcelas = vezes;
        valor_parcelado = valor_total / parcelas;
    }

    public void Diminui_Parcela()
    {
        parcelas = parcelas - 1;
    }
    public void Set_Nome(string n)
    {
        nome = n;
    }
    public void Set_Valor_Total(int x)
    {
        valor_total = x;
    }
    public void Set_Parcelas(int x)
    {
        parcelas_total = x;
        parcelas = x;
    }

    public string Get_Nome()
    {
        return nome;
    }
    public int Get_Valor_Total()
    {
        return valor_total;
    }
    public int Get_Parcelas()
    {
        return parcelas;
    }
    public int Get_Valor_Parcelado()
    {
        return valor_parcelado;
    }
}
