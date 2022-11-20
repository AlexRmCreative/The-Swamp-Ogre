using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MyPublicMethods
{
    Animator animator;
    Camera mainCam;
    [SerializeField] Chracter player;
    [SerializeField] Collider2D swordCol;
    [SerializeField] Collider2D objectiveCol;
    List<GameObject> armas = new List<GameObject>();
    float normalSpeed;
    //horizontal
    float h;
    //vertical
    float v;


    private void Start() {
        mainCam = Camera.main;
        player = GetComponent<Chracter>();
        animator = GetComponent<Animator>();
        //Metodo para obtener un objeto mediante su tag, recorriendo todos los gameobjects desde el parent y los añade a su lista correspondiente
        GetChildObject(transform, "Arma", armas);
        normalSpeed = player.Speed;
    }
    private void Update()   
    {
        mainCam.transform.position = new Vector3(transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
        Atacar();
        Mover();
        Debug.Log(player.IsAtking);
    }

    void Atacar()
    {
        if (Input.GetButtonDown("Fire1") && h != 0 || Input.GetButtonDown("Fire1") && v != 0)
        {
            player.IsAtking = true;
            animator.Play("Run Slashing");
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            player.IsAtking = true;
            animator.Play("Slashing");
        }
        else
        {
            player.IsAtking = false;
        }
    }
    void Mover()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        transform.Translate(h * player.Speed * Time.deltaTime, v * player.Speed * Time.deltaTime, 0);

        if (h != 0 || v != 0)
        {
            animator.SetFloat("movSpeed", player.Speed);
        }
        else
        {
            animator.SetFloat("movSpeed", h);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.Speed = player.Speed * 20 / 100;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                player.Speed = normalSpeed;
            }
    }
}
