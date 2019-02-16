using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2f;
    public float GravityStrength = 9.8f;


    CharacterController control;
    

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 velf = transform.forward  * MovementSpeed * Time.deltaTime;
        Vector3 velr = transform.right * MovementSpeed * Time.deltaTime;
        Vector3 finalVel = new Vector3();

        

        //back and  forth
        if (Input.GetKey(KeyCode.W))
        {//forward
            
            finalVel += velf;
        }
        else if (Input.GetKey(KeyCode.S))
        {//backward
            finalVel -= velf;
        }

        if (Input.GetKey(KeyCode.A))
        {//left
            finalVel -= velr;
        }
        else if (Input.GetKey(KeyCode.D))
        {//right
            finalVel += velr;
        }

        finalVel -= new Vector3(0, GravityStrength * Time.deltaTime);

        control.Move(finalVel);
        

    }
}

