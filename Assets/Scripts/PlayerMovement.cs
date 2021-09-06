using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Vector3 hitScale = new Vector3(0.1f, 0.1f, 0.1f);

    [SerializeField]
    private float scaleDelaySec = 0.1f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(direction, 0, 0);
        transform.position += movement * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.CountScore(1);
            transform.localScale += hitScale;
            Invoke("ResetScale", scaleDelaySec);
        }
        
    }

    void ResetScale()
    {
        Vector3 originalScale = new Vector3(1, 1, 1);
        transform.localScale = originalScale;
    }
}
