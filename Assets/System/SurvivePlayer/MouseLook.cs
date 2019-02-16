
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MouseLookAxis
{

    X,Y

}

public class MouseLook : MonoBehaviour
{
    public bool UseMouseToLook = true;
    public float Speed = 1.5f;
    public MouseLookAxis axis;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UseMouseToLook)
        {
            switch (axis)
            {
                case MouseLookAxis.X:

                    float my = Input.GetAxis("Mouse X") * Speed * Time.deltaTime;



                    transform.Rotate(0f, my, 0f);

                    break;
                case MouseLookAxis.Y:

                    float mx = Input.GetAxis("Mouse Y") * -Speed * Time.deltaTime;

                    transform.Rotate(mx, 0f, 0f);

                    break;
                default:


                    break;
            }
        }
    }
}


    
