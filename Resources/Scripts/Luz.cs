using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public float count_time;
    public float count;
    public bool luz_acesa = true;
    public bool luz_desligada = false;

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;

        if(count > count_time)
        {
            count = 0;
            Pisca_Intesidade();
        }

    }

    void Pisca_Intesidade()
    {
        int sorteio = Random.Range(0, 100);

        if (sorteio > 95)
        {
            int i = 0;
            while(i < 20000)
            {
                this.GetComponent<Light>().intensity = (0.20f*i)/20;
                i = i + 15;
            }
            while (i > 1)
            {
                this.GetComponent<Light>().intensity = (0.20f * i) / 20;
                i = i - 15;
            }
            //this.GetComponent<Light>().intensity = 0.20f;
        }



        else if(sorteio > 60 && sorteio < 90)
        {
            this.GetComponent<Light>().intensity = 0.10f;
        }
        else if (sorteio > 40 && sorteio < 60)
        {
            this.GetComponent<Light>().intensity = 0.08f;
        }
        else if (sorteio > 20 && sorteio < 40)
        {
            this.GetComponent<Light>().intensity = 0.05f;
        }
        else if (sorteio > 0 && sorteio < 20)
        {
            this.GetComponent<Light>().intensity = 0.03f;
        }



    }

}
