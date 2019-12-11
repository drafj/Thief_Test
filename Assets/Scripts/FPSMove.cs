using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FPSMove : MonoBehaviour
{

    public FPSAim mFPSAim;//se crea instancia publica para usar una variable de otra clase

    public float velocity = 7f;//variable para establecer la velocidad de movimiento

    private void Start()
    {
        mFPSAim = gameObject.transform.GetChild(0).gameObject.GetComponent<FPSAim>();
    }

    public IEnumerator VampireFreeze()//activa el ataque del vampiro (si este toca al heroe) que se basa en ralentizar al heroe hasta el punto de dejarlo inmovil por unos segundos
    {
        velocity = 4;
        yield return new WaitForSeconds(0.2f);
        velocity = 3;
        yield return new WaitForSeconds(0.2f);
        velocity = 2;
        yield return new WaitForSeconds(0.2f);
        velocity = 1;
        yield return new WaitForSeconds(0.2f);
        velocity = 0;

        if (velocity == 0)
        {
            yield return new WaitForSeconds(2);
            velocity = 5;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "vampire")
        {
            StartCoroutine(VampireFreeze());
        }
    }

    void Update()
    {
        // if (!Heroe.saCabo)
        // {
            if (Input.GetKey(KeyCode.W))//se obtiene la tecla para ir hacia adelante y se crea una condicional para moverse
            {
                transform.position += transform.forward * velocity * Time.deltaTime;//se mueve hacia adelante si se da la condicional anterior
            }
            if (Input.GetKey(KeyCode.S))//se obtiene la tecla para ir hacia atras y se crea una condicional para moverse
            {
                transform.position -= transform.forward * velocity * Time.deltaTime;//se mueve hacia atras si se da la condicional anterior
            }
            if (Input.GetKey(KeyCode.D))//se obtiene la tecla para ir hacia la derecha y se crea una condicional para moverse
            {
                transform.position += transform.right * velocity * Time.deltaTime;//se mueve hacia la derecha si se da la condicional anterior
            }
            if (Input.GetKey(KeyCode.A))//se obtiene la tecla para ir hacia la izquierda y se crea una condicional para moverse
            {
                transform.position -= transform.right * velocity * Time.deltaTime;//se mueve hacia la izquierda si se da la condicional anterior   
            }
        //}

        transform.eulerAngles = new Vector3(0,mFPSAim.mouseX,0);//se rota el objeto en X junto con el X del mouse para que cuando rote la camara tambien rote el objeto
        
    }
}
