using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tela : MonoBehaviour
{
    public Texture background_texture;

    public List<Text> texto;

    public void Set_Tela_Active(bool b)
    {
        this.gameObject.SetActive(b);
    }

    public void Set_Text_Active(bool b,int id)
    {
        texto[id].gameObject.SetActive(b);
    }
    public void Set_Text_String(string s, int id)
    {
        texto[id].text = s;
    }

    public Text Get_Text(int id)
    {
        return texto[id];
    }
    
    public int Get_Text_List_Size()
    {
        return texto.Count;
    }
}
