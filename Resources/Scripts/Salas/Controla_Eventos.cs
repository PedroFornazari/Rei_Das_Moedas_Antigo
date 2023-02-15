using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_Eventos : MonoBehaviour
{
    public Banco banco;

    public List<Evento> evento;
    int numero_eventos;
    int id_evento_sorteado = 0;
    public bool evento_ativado = false;
    public Tela tela_evento;

    public void Sorteia_Ocorre_Evento()
    {
        int sorteio = Random.Range(0, 10000);

        if(sorteio > 9990)
        {
            Toca_Efeito_Evento();
            Sorteia_Evento();
            evento_ativado = true;
        }
    }

    public void Sorteia_Evento()
    {
        numero_eventos = evento.Count;
        id_evento_sorteado = Random.Range(0, numero_eventos);
        Aciona_Evento();
    }

    public void Aciona_Evento()
    {
        tela_evento.Set_Tela_Active(true);
        tela_evento.Set_Text_String(evento[id_evento_sorteado].Get_Nome(),0);
        tela_evento.Set_Text_String(evento[id_evento_sorteado].Get_Descricao(),1);
    }

    public void Confirma_Evento()
    {
        Conta conta_a_pagar;
        conta_a_pagar = new Conta(evento[id_evento_sorteado].Get_Nome(),
            (evento[id_evento_sorteado].Get_Valor()));
        banco.Adiciona_Nova_Conta(conta_a_pagar);
        tela_evento.Set_Tela_Active(false);
        evento_ativado = false;
    }

    public bool Get_Se_Evento_Ativado()
    {
        return evento_ativado;
    }

    public void Toca_Efeito_Evento()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
    }
}
