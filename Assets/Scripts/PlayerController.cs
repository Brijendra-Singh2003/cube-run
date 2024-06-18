using UnityEngine;

public class playerController : MonoBehaviour
{
    public float acceleration;
    public float handling;
    public float topSpeed;
    public float minSpeed;
    public GameManager gameManager;
    
    private float speed;
    private float direction;
    private new Rigidbody rigidbody;
    private bool isAlive;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        speed = minSpeed;
        direction = 0f;
        isAlive = true;
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.up;
    }

    private void Update()
    {
        if (transform.position.y < -10 || (!isAlive && rigidbody.velocity == Vector3.zero))
        {
            GameOver();
            return;
        }

        if (isAlive)
        {
            direction += Input.acceleration.x * handling * speed * Time.deltaTime;
        }

        direction -= direction * 12f * Time.deltaTime;

        if (speed > minSpeed)
            speed -= speed * 0.2f * Time.deltaTime;
    }

    public void Accelerate()
    {
        if (speed < topSpeed && isAlive)
        {
            speed += acceleration * Time.deltaTime;
        }
    }

    public void Decelerate()
    {
        if (speed > minSpeed && isAlive)
        {
            speed -= speed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive) return;

        Vector3 angle = transform.rotation.eulerAngles;
        Vector3 velocity = rigidbody.velocity;

        angle.y = direction * 50f * Time.deltaTime;
        velocity.x = direction;
        velocity.z = speed;

        transform.rotation = Quaternion.Euler(angle);
        rigidbody.velocity = velocity;

        if (speed > 17.5f)
        {
            gameManager.PlayerScores((int)transform.position.z);
        }

        gameManager.SetSpeedText((int)(speed * 18 / 5));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle") && isAlive)
        {
            isAlive = false;
        }
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}
