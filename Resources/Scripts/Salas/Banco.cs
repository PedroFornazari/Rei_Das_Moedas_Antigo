using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banco : MonoBehaviour
{
    public List<Conta> conta;
    public int saldo;
    public int renda;
    int total_final;
    int total_positivo;
    int total_negativo;

    public GameObject interface_tesouraria;
    public Tela tela_total;
    public Tela tela_extrato;
    public Tela tela_paga_conta;

    Conta nova_conta;
    int parcelas_nova_conta = 0;
    public bool ativa_tela_paga_conta = false;

    public List<Extrato> extrato;
    Extrato novo_extrato;
    public int extrato_atual_mes;
    public int extrato_mostrado_id;


    private void Start()
    {
        Atualiza_Banco();
    }

    public void Set_Data_Extrato(int dia,int mes,int ano)
    {
        novo_extrato.Set_Data(dia, mes, ano);
    }

    private void Update()
    {
        if (ativa_tela_paga_conta)
        {
            Atualiza_Tela_Paga_Conta();
        }
    }

    public void Atualiza_Banco()
    {
        Atualiza_Contas();

        total_positivo = renda;
        total_final = total_positivo - total_negativo;
        saldo = saldo + total_final;

        Atualiza_Tela_Extrato();
        Atualiza_Tela_Total();

        total_negativo = 0;
        total_positivo = 0;
        total_final = 0;
    }

    public void Atualiza_Contas()
    {
        
        int tamanho_array_conta = conta.Count;
        for (int i = 0; i < tamanho_array_conta; i++)
        {
            Toca_Efeito_Banco();
            int valor_extraido_parcela = conta[i].Get_Valor_Parcelado();
            conta[i].Diminui_Parcela();
            if (conta[i].Get_Parcelas() <= 0)
            {
                conta.RemoveAt(i);
            }

            total_negativo = total_negativo + valor_extraido_parcela;
        }
    }

    public void Adiciona_Nova_Conta(Conta c)
    {
        nova_conta = c;
        ativa_tela_paga_conta = true;
        tela_paga_conta.Set_Tela_Active(true);
        tela_paga_conta.Set_Text_String(nova_conta.Get_Nome(), 0);
        tela_paga_conta.Set_Text_String(nova_conta.Get_Valor_Total().ToString(), 1);
    }

    public void Confirma_Nova_Conta()
    {
        nova_conta.Parcelar_Conta(parcelas_nova_conta);
        conta.Add(nova_conta);
        nova_conta = null;
        ativa_tela_paga_conta = false;
        tela_paga_conta.Set_Tela_Active(false);
    }


    public void Adiciona_Ouro(int ouro)
    {
        saldo = saldo + ouro;
    }

    public int Get_Saldo()
    {
        return saldo;
    }

    public void Ativa_Interface_Tesouraria()
    {
        interface_tesouraria.gameObject.SetActive(true);
    }

    public void Desativa_Interface_Tesouraria()
    {
        interface_tesouraria.gameObject.SetActive(false);
    }

    public void Aumenta_Parcelas_Nova_Conta()
    {
        if (parcelas_nova_conta < 5)
        {
            parcelas_nova_conta++;
        }
    }

    public void Diminui_Parcelas_Nova_Conta()
    {
        if (parcelas_nova_conta > 0)
        {
            parcelas_nova_conta--;
        }
    }

    public void Atualiza_Tela_Extrato()
    {
        int id = 0;

        for (int i = 0; i < conta.Count; i++)
        {
            tela_extrato.Set_Text_String(
                conta[id].Get_Nome() + " - " +
                conta[id].Get_Valor_Parcelado().ToString() + "/" +
                conta[id].Get_Parcelas().ToString(),
                i);

            tela_extrato.Set_Text_Active(true, i);
            id = id + 1;
        }

        for(int i = conta.Count; i < tela_extrato.Get_Text_List_Size(); i++)
        {
            tela_extrato.Set_Text_Active(false, i);
        }
    }

    public void Atualiza_Tela_Total()
    {
        tela_total.Set_Text_String("Saldo Total " + saldo.ToString(), 0);
    }

    public void Atualiza_Tela_Paga_Conta()
    {
        tela_paga_conta.Set_Text_String(parcelas_nova_conta.ToString(), 2);
    }

    public void Toca_Efeito_Banco()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
    }
}
