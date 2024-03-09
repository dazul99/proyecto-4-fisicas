using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1f;
    private Rigidbody enemyRigidbody;
    
    private GameObject player;

    private float lowerLimit = -3f;

    private SpawnManager spawnManager;
    private PlayerController playerController;
    private GameManager gameManager;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!playerController.GetIsGameOver())
        {
            GoToPlayer();
        }

        if (transform.position.y < lowerLimit)
        {
            gameManager.defeated++;
            spawnManager.EnemyDestroyed();
            Destroy(gameObject);
        }
    }

    private void GoToPlayer()
    {
        // Direction = destino - origen
        // destino = posición del player
        // origen = posición del enemigo
        Vector3 direction = player.transform.position -
                            transform.position;
        direction = direction.normalized;
        enemyRigidbody.AddForce(direction * speed);
    }
}
