using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiftciHareket : MonoBehaviour
{
    public float yurumeHizi = 5f;
    public float kosmaHizi = 10f;

    public float donusHiz = 200f;
    public float ziplamaGucu = 50f;

    public AudioSource audioSource;

    private Animator animator;
    private Rigidbody rb;

    private bool havada = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb =   GetComponent<Rigidbody>();
    }


    void Update()
    {
        var hareketHiz = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            hareketHiz = yurumeHizi;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            hareketHiz = yurumeHizi;
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            hareketHiz = yurumeHizi;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            hareketHiz = yurumeHizi;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            hareketHiz = kosmaHizi;
        }

        
        transform.Translate(Vector3.forward * hareketHiz * Time.deltaTime);
        animator.SetFloat("HareketHiz", hareketHiz);



        if (Input.GetKeyDown(KeyCode.Space) && havada == false)
        {
            havada = true;
            audioSource.Play();
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            animator.SetBool("Zipla", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ziplama bitti");
        animator.SetBool("Zipla", false);
        havada = false;
    }
}
