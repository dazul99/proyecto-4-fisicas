using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed=3f;
    private Rigidbody rb;
    private GameObject player;
    private Vector3 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        direction = player.transform.position - transform.position;
        direction = Vector3.Normalize(direction);
        rb.AddForce(direction*speed);

        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
