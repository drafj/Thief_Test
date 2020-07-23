using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FPSMove : MonoBehaviour
{

    public FPSAim mFPSAim;//se crea instancia publica para usar una variable de otra clase

    private Rigidbody rgbd;
    private Vector3 moveDirection = new Vector3();
    float horizontalMove;
    float verticalMove;
    public float velocity = 7f;//variable para establecer la velocidad de movimiento

    private void Start()
    {
        mFPSAim = gameObject.transform.GetChild(0).gameObject.GetComponent<FPSAim>();
        rgbd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        moveDirection = (horizontalMove * transform.right + verticalMove * transform.forward).normalized;

        
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0,mFPSAim.mouseX,0);//se rota el objeto en X junto con el X del mouse para que cuando rote la camara tambien rote el objeto
        rgbd.velocity = moveDirection * velocity * Time.deltaTime;
    }
}
