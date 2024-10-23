using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration;
    public float handling;
    public float topSpeed;
    public float minSpeed;
    public GameManager gameManager;
    public Transform body;
    
    private float speed;
    private Vector3 startingPoint;
    private float direction;
    private new Rigidbody rigidbody;
    private bool isAlive;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        startingPoint = transform.position;
    }

    private void OnEnable()
    {
        speed = minSpeed;
        direction = 0f;
        isAlive = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(startingPoint, Quaternion.identity);
    }

    private void Update()
    {
        if (transform.position.y < -10 || (!isAlive && rigidbody.velocity == Vector3.zero))
        {
            GameOver();
            return;
        }

        if(isAlive)
            direction += Input.acceleration.x * handling * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.D)) {
            direction += 0.25f * handling * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A)) {
            direction -= 0.25f * handling * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.W)) {
            Accelerate();
        }
        else if(Input.GetKey(KeyCode.S)) {
            Decelerate();
        }

        direction -= direction * 12f * Time.deltaTime;

        if (speed > minSpeed)
            speed -= speed * 0.2f * Time.deltaTime;

        if(transform.position.y > startingPoint.y) isAlive = false;
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

        Vector3 velocity = rigidbody.velocity;

        velocity.x = direction;
        velocity.z = speed;

        body.localEulerAngles = new(
            body.localEulerAngles.x,
            body.localEulerAngles.y,
            direction * 24f * Time.deltaTime
        );

        transform.eulerAngles = new(
            transform.eulerAngles.x,
            0f,
            transform.eulerAngles.z
        );
        rigidbody.velocity = velocity;

        if (speed > 17.5f)
        {
            gameManager.PlayerScores((int)transform.position.z);
        }

        gameManager.SetSpeedText((int)(speed * 18 / 5));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isAlive && other.gameObject.TryGetComponent<Obsticle>(out Obsticle obsticle))
        {
            if(speed - obsticle.speed > 4f)
                isAlive = false;
            else
                obsticle.OnHit();
        }
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}
