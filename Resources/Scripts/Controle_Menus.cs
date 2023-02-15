using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Menus : MonoBehaviour
{
    public GameObject Interface_Menu_Inicial;
    public GameObject Interface_Jogo;
    public GameObject Tela_Mini_Menu;

    public GameObject Tela_Creditos;
    public GameObject Tela_Menu_Inicial;
    public GameObject Tela_Instrucoes;

    public GameObject Tela_Vitoria;
    public GameObject Tela_Derrota;

    public bool jogo_pausado = true;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Ativa_Mini_Menu();
        }
    }

    public void Ativa_Interface_Menu_Inicial()
    {
        Interface_Menu_Inicial.SetActive(true);
        jogo_pausado = true;
        Desativa_Interface_Jogo();
        Desativa_Mini_Menu();

        Tela_Vitoria.SetActive(false);
        Tela_Derrota.SetActive(false);
    }

    public void Ativa_Interface_Jogo()
    {
        Interface_Jogo.SetActive(true);
        jogo_pausado = false;
        Desativa_Interface_Menu_Inicial();
        Desativa_Mini_Menu();
    }

    public void Ativa_Mini_Menu()
    {
        Tela_Mini_Menu.SetActive(true);
        jogo_pausado = true;
        Desativa_Interface_Jogo();
    }

    public void Desativa_Interface_Menu_Inicial()
    {
        Interface_Menu_Inicial.SetActive(false);
    }


    public void Desativa_Interface_Jogo()
    {
        Interface_Jogo.SetActive(false);
    }

    public void Desativa_Mini_Menu()
    {
        Tela_Mini_Menu.SetActive(false);
    }

    public void Vai_Tela_Creditos()
    {
        Tela_Creditos.SetActive(true);
        Tela_Menu_Inicial.SetActive(false);
        Tela_Instrucoes.SetActive(false);
    }

    public void Vai_Tela_Instrucoes()
    {
        Tela_Instrucoes.SetActive(true);
        Tela_Creditos.SetActive(false);
        Tela_Menu_Inicial.SetActive(false);
    }

    public void Vai_Tela_Inicial()
    {
        Tela_Menu_Inicial.SetActive(true);
        Tela_Creditos.SetActive(false);
        Tela_Instrucoes.SetActive(false);
    }

    public void Ativa_Tela_Vitoria()
    {
        Tela_Vitoria.SetActive(true);
    }

    public void Ativa_Tela_Derrota()
    {
        Tela_Vitoria.SetActive(true);
    }

    public void Encerra_Jogo()
    {
        Application.Quit();
    }

    public bool Get_Jogo_Pausado()
    {
        return jogo_pausado;
    }
}
