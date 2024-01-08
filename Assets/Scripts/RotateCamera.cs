using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private float speed= 10f;

    private float rotate;

    // Update is called once per frame
    void Update()
    {
        rotate = Input.GetAxis("Horizontal");
        transform.Rotate(-Vector3.up, rotate * speed * Time.deltaTime);
        /*
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        }*/


    }
}
