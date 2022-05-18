using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [Space]
    [SerializeField] private GameObject _currentGun;
    [SerializeField] private GameObject _collectedGun;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Vector3 _jump;

    private bool _isGrounded;

    public static int Ammo
    {
        get;
        private set;
    }

    private Vector3 _playerMovement;

    private void Awake()
    {
        Ammo = 0;
        _jump = new Vector3(0, 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        SwapGun();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MyTags.AmmoTag))
            Ammo += 20;
    }

    private void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }

    private void PlayerMove()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        _playerMovement = new Vector3(x, 0, z);

        Vector3 _moveVector = transform.TransformDirection(_playerMovement) * _speed;
        _rb.velocity = new Vector3(_moveVector.x, _rb.velocity.y, _moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(_jumpForce * _jump, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void SwapGun()
    {
        if (CollectGun.GunCollected)
        {
            _currentGun.SetActive(false);
            _collectedGun.SetActive(true);
        }
    }

    public static void ReduceAmmo() => Ammo--;
}