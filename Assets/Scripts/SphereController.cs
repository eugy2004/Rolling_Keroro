using UnityEngine;
using UnityEngine.InputSystem;

public class SphereController : MonoBehaviour
{
    public float ballForce;
    public float slowDownFactor;
    public Rigidbody rb;

    public RegisterSphere registerSphere;
    public ReproduceSphere reproduceSphere;

    public bool movingLeft = false;
    public bool accelerating = false;

    public float targetXpos = 0f;
    public float targetXneg = 0f;
    public float targetY = 0f;

    public float lastRegisterTime = 0f;
    public float updateInterval = 0.5f; // Time interval in seconds

    public Vector3 startPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        RegisterTime();
    }

    //void Update()
    //{
    //    float currentX = transform.position.x;

    //    RegisterTime();

    //    if (movingLeft && currentX > targetXneg)
    //    {
    //        transform.position += ballSpeed * Time.deltaTime * Vector3.left;
    //    }
    //    else if (!movingLeft && currentX < targetXpos)
    //    {
    //        transform.position += ballSpeed * Time.deltaTime * Vector3.right;
    //    }
    //}

    private void RegisterTime()
    {
        if (Time.time - lastRegisterTime >= updateInterval)
        {
            lastRegisterTime = Time.time;
            SphereData data = new()
            {
                position = transform.position,
                time = Time.time
            };
            registerSphere.RegisterSpherePosition(data);
        }
    }

    public void CheckInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Input detected: " + context.ReadValue<Vector2>());
            Vector2 input = context.ReadValue<Vector2>();
            if (input.y < 0)
            {
                rb.AddForce((Vector3.right * -ballForce), ForceMode.Impulse);
            }
            else if (input.y > 0)
            {
                rb.AddForce((Vector3.right * ballForce), ForceMode.Impulse);
            }

            if (input.x < 0)
            {
                rb.AddForce((Vector3.forward * slowDownFactor), ForceMode.Impulse);
            }
            else if (input.x > 0)
            {
                rb.AddForce((Vector3.forward * -ballForce), ForceMode.Impulse);
            }
        }
    }
}
