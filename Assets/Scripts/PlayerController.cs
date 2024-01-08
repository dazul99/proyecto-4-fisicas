using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private float speed = 10f;
    private float forwardInput;

    [SerializeField] private GameObject focalPointGO;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        rigid.AddForce(focalPointGO.transform.forward * speed * forwardInput);

    }
}
