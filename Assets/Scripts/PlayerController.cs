using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform worldCenter;
    [SerializeField] Transform distantPoint;
    [SerializeField] Joystick joystick;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput;
        float horizontalInput;
        if (DataBox.Instance.isPC)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            verticalInput = joystick.Vertical;
            horizontalInput = joystick.Horizontal;
        }

        if (!GameManager.Instance.isAnotherControllerOn)
        {
            _rigidbody.AddForce(worldCenter.transform.forward * speed * verticalInput);
            _rigidbody.AddForce(worldCenter.transform.right * speed * horizontalInput);
        }
        else
        {
            _rigidbody.AddForce(worldCenter.transform.forward * speed * verticalInput);
        }

        if(transform.position.y < -3)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SizeEnlarger"))
        {
            transform.localScale *= 1.2f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SizeReducing"))
        {
            transform.localScale *= 0.8f;
            Destroy(other.gameObject);
        }
    }
}
