using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private float speed = 10f;
    private float forwardInput;
    private bool power = false;
    [SerializeField] private GameObject focalPointGO;

    [SerializeField] private float force = 20f;


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            power = true;
            StartCoroutine(PowerupCount());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && power)
        {
            Rigidbody enemyrigid = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 direct = collision.gameObject.transform.position - transform.position;
            enemyrigid.AddForce(direct.normalized * force, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCount()
    {
        yield return new WaitForSeconds(6);
        power = false;
    }
}
