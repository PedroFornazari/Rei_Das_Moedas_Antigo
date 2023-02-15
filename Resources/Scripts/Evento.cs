using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{
    public string nome;
    public string descricao;
    public int valor;

    public string Get_Nome()
    {
        return nome;
    }

    public string Get_Descricao()
    {
        return descricao;
    }

    public int Get_Valor()
    {
        return valor;
    }
}
