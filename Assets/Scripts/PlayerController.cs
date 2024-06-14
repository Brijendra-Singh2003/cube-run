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
        if (transform.position.y < -10 || (!isAlive && rigidbody.velocity.Equals(Vector3.zero))) GameOver();

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Accelerate();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Decelerate();
        }

        direction -= direction * 4 * Time.deltaTime;
        if (speed > minSpeed)
            speed -= speed * 0.2f * Time.deltaTime;
    }

    public void MoveLeft()
    {
        if (isAlive)
            direction -= (handling - direction) * Time.deltaTime * (speed + minSpeed) / 48;
    }
    public void MoveRight()
    {
        if (isAlive)
            direction += (handling - direction) * Time.deltaTime * (speed + minSpeed) / 48;
    }

    public void Accelerate()
    {
        if (speed < topSpeed && isAlive)
            speed += acceleration * Time.deltaTime;
    }
    public void Decelerate()
    {
        if (speed > minSpeed && isAlive)
            speed -= speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(!isAlive) return;

        Vector3 angle = transform.rotation.eulerAngles;
        Vector3 velocity = rigidbody.velocity;

        angle.y = direction * 50f * Time.deltaTime;
        velocity.x = direction;
        velocity.z = speed;

        transform.rotation = Quaternion.Euler(angle);
        rigidbody.velocity = velocity;

        gameManager.PlayerScores(((int)transform.position.z));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" && isAlive)
        {
            isAlive = false;
        }
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}
