using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Rigidbody obstacleRigidbody;
    GameManager gameManager;
    bool hasCollide = false;
    float startTime;

    [SerializeField]
    public float speed = 200f;

    [SerializeField]
    public float spawnZPosition = 100f;

    [SerializeField]
    public float despawnZPosition = -10f;

    [SerializeField]
    public float kbYforce = 100f;

    [SerializeField]
    public float kbZforce = 2000f;

    void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        Respawn();
    }

    void FixedUpdate()
    {
        if (!hasCollide)
        {
            obstacleRigidbody.AddForce(0, 0, -speed);
        }
        else
        {
            obstacleRigidbody.AddForce(0, 0, speed);
        }

        if (transform.position.z > spawnZPosition || 
        transform.position.y < -1 ||
        Time.time - startTime > 10)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < despawnZPosition)
        {
            Destroy(gameObject);
            gameManager.CountRemain(-1);
        }
    }

    private void Respawn()
    {
        startTime = Time.time;
        hasCollide = false;
        obstacleRigidbody.velocity = Vector3.zero;
        obstacleRigidbody.angularVelocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-5, 5), 1, spawnZPosition);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player")
        {
            hasCollide = true;
            obstacleRigidbody.AddForce(0, kbYforce, kbZforce);
        }
    }
}
