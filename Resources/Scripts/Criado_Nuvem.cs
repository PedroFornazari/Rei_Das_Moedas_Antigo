using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criado_Nuvem : MonoBehaviour
{
    public float contador_spawn;
    public float tempo_spawn;
    public GameObject nuvem_original;

    void Update()
    {
        Conta_Tempo();
    }

    void Conta_Tempo()
    {
        contador_spawn = contador_spawn + Time.deltaTime;
        if (contador_spawn >= tempo_spawn)
        {
            int sorteio_posicao = Random.Range(100, 400);
            Vector3 new_position = new Vector3(this.transform.localPosition.x, sorteio_posicao, this.transform.localPosition.z);
            GameObject nova_nuvem = Instantiate(nuvem_original);
            nova_nuvem.transform.position = new_position;
            contador_spawn = 0;
        }
    }
}
