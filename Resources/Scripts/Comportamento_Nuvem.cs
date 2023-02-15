using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamento_Nuvem : MonoBehaviour
{
    public float velocidade;
    public bool lado;

    // Update is called once per frame
    void Update()
    {
        if(lado == true)
        {
            Move_Nuvem_Direita();
        }
        else
        {
            Move_Nuvem_Esquerda();
        }
    }

    void Move_Nuvem_Direita()
    {
        this.transform.position = new Vector3(this.transform.position.x + velocidade, this.transform.position.y, this.transform.position.z);
    }

    void Move_Nuvem_Esquerda()
    {
        this.transform.position = new Vector3(this.transform.localPosition.x - velocidade, this.transform.localPosition.y, this.transform.localPosition.z);
    }
}
