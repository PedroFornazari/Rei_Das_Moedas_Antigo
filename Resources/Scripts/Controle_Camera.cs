using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Camera : MonoBehaviour
{
    public GameObject interface_armazem;
    public GameObject interface_trono;
    public GameObject interface_tesouraria;
    public GameObject interface_investimentos;
    public GameObject interface_objetivos;

    public GameObject armazem_colisor;
    public GameObject trono_colisor;
    public GameObject tesouraria_colisor;
    public GameObject investimentos_colisor;
    public GameObject objetivos_colisor;

    public int altura_maxima_camera = 0;
    public int altura_minima_camera = 0;

    public int velocidade_scroll;


    public void Update()
    {
        Arrasta_Camera();

        if (this.GetComponent<BoxCollider>().bounds.Intersects(armazem_colisor.GetComponent<BoxCollider>().bounds))
        {
            interface_armazem.SetActive(true);
        }
        else if (this.GetComponent<BoxCollider>().bounds.Intersects(trono_colisor.GetComponent<BoxCollider>().bounds))
        {
           // interface_trono.SetActive(true);
        }
        else if (this.GetComponent<BoxCollider>().bounds.Intersects(tesouraria_colisor.GetComponent<BoxCollider>().bounds))
        {
            interface_tesouraria.SetActive(true);
        }
        else if (this.GetComponent<BoxCollider>().bounds.Intersects(investimentos_colisor.GetComponent<BoxCollider>().bounds))
        {
            interface_investimentos.SetActive(true);
        }
        else if (this.GetComponent<BoxCollider>().bounds.Intersects(objetivos_colisor.GetComponent<BoxCollider>().bounds))
        {
            interface_objetivos.SetActive(true);
        } 
        else
        {
            interface_armazem.SetActive(false);
            interface_tesouraria.SetActive(false);
            //interface_trono.SetActive(false);
            interface_investimentos.SetActive(false);
            interface_objetivos.SetActive(false);
        }

        

        
    }

    public void Arrasta_Camera()
    {
        if (Input.GetAxis("Mouse Y") > 0)
        {
            if (this.transform.position.y < altura_maxima_camera && Input.GetMouseButton(0))
            {
                Vector3 new_camera_position = new Vector3(this.transform.localPosition.x, this.transform.position.y + velocidade_scroll, -10);
                this.transform.position = new_camera_position;
            }
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            if(this.transform.position.y > altura_minima_camera && Input.GetMouseButton(0))
            {
                Vector3 new_camera_position = new Vector3(this.transform.localPosition.x, this.transform.position.y - velocidade_scroll, -10);
                this.transform.position = new_camera_position;
            }
        }

    }


}
