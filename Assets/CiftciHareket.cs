using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiftciHareket : MonoBehaviour
{
    public float hiz = 5f;

    public float gravity = -9.81f;
    public float donusHiz = 200f;
    public float ziplamaGucu = 5f;

    private Animator animator;
    private Rigidbody rb;
    private CharacterController cc;

    public float ySpeed = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        rb =   GetComponent<Rigidbody>();
    }


    void Update()
    {

        var hareketVektor = Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical");
        

        if(hareketVektor != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(hareketVektor);
            animator.SetBool("Yuruyor", true);

        }
        else
        {
            animator.SetBool("Yuruyor", false); 
        }

        if (cc.isGrounded)
        {
            ySpeed = -1f;
            if (Input.GetButton("Jump"))
            {
                ySpeed = ziplamaGucu;
                animator.SetBool("Zipla", true);
            }
            else
            {
                animator.SetBool("Zipla", false);
            }

            animator.SetBool("Dusuyor",false);
        }
        else
        {
            ySpeed += gravity * Time.deltaTime;
            animator.SetBool("Dusuyor", true);  
        }
        
        hareketVektor.y = ySpeed;
        cc.Move(hareketVektor * hiz * Time.deltaTime);
    }


}
