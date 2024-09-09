using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    public bool noChao;
    Rigidbody rb; 
    private AudioSource source;
    
    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (!noChao && collision.gameObject.tag == "Chão")
       {
            noChao = true;
       }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direção = new Vector3(h, 0, v);
        rb.AddForce(direção * velocidade * Time.deltaTime, ForceMode.Impulse);
        

        if(Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            //pulo
            source.Play();

            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;

        }

        if (transform.position.y <= -0.3)
        {
            //jogador caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
