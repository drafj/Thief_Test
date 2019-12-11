using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FPSAim : MonoBehaviour
{

    public float mouseX;//variable para usar el eje x del mouse
    public float mouseY;//variable para usar el eje x del mouse
    public float limitMax = -90;//variable para ponerle el limite maximo en el que puede mover la camara en Y
    public float limitMin = 80;//variable para ponerle el limite minimo en el que puede mover la camara en Y
    public bool mouseInvertido;//variable booleano para activar y desactivar la camara invertida
    public float sensibility = 3;//variable para configurar la sensibilidad de la camara
    float limitRotation;//variable para establecer los limites de la camara en Y


    void Update()
    {
        // if (!Heroe.saCabo)
        // {
            float XRot = Input.GetAxisRaw("Mouse X");//se establece el movimiento X de la camara junto con la sensibilidad
            mouseX += XRot * sensibility;



            float YRot = Input.GetAxisRaw("Mouse Y");//se establece el movimiento Y de la camara junto con la sensibilidad
            float camRot = YRot * sensibility;

            if (mouseInvertido)//se crea la condicional para verificar si el usuario quiere o no la camara invertida
            {
                limitRotation += camRot;
            }
            else
            {
                limitRotation -= camRot;
            }
        //}
        
        limitRotation = Mathf.Clamp(limitRotation,limitMax,limitMin);//se limita para la rotacion de la camara en Y

        transform.eulerAngles = new Vector3(limitRotation,mouseX,0);//mueve la camara con las variables anteriormentes creadas que utilizan el movimiento en X y Y del mouse
    }
}
