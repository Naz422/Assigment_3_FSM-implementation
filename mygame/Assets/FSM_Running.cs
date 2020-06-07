using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FSM_Running : MonoBehaviour
{
    public bool collide;
    public float energatic;
    public bool moving;
    public bool running;


    void OnTriggerEnter(Collider other)
    {


        if (other.transform.tag == "cyl")
        {
            collide = true;
            energatic = energatic - 15;

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        energatic = 100;
        running = false;
        collide = false;
        moving = false;
        // fpc = GameObject.FindObjectOfType<FirstPersonController>();



    }

    // Update is called once per frame
    void Update()
    {
        //Change state
        if (GameObject.FindObjectOfType<FirstPersonController>().m_CharacterController.velocity == Vector3.zero)
        {

            running = false;
            moving = true;



        }
        else if (GetComponent<FirstPersonController>().m_IsWalking)
        {

            running = true;
            moving = false;

        }
    }
}

// Start is called before the first frame update


// Update is called once per frame

