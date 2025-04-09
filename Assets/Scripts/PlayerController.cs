using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    //TODO: Attributes
    [Header("Components")]
    public Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [Range(0.1f,5.0f),Tooltip("Its a walk speed")]public float _walkSpeed = 1f;
    public float _runSpeed = 2f;
    [Space(10)]
    public float _jumpForce = 10f;
    

    private Vector2 _movementInput;
    private float _speed;
    private bool _isRunning = false;

    #region Input System
    private InputSystem_Actions _input;

    void Awake()
    {
        _input = new InputSystem_Actions();

        _speed = _walkSpeed;
    }

    void OnEnable()
    {
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
    }
    #endregion

    /// <summary>
    /// An Unity Input system event that is called when the player presses the Move-related button.
    /// </summary>
    /// <param name="value">value from Player Input -1 - 1</param>
    void OnMove(InputValue value){
        _movementInput = value.Get<Vector2>();
    }


    void Start()
    {
        _input.Player.Sprint.started += ctx => {_isRunning = true; _speed = _runSpeed; _animator.SetBool("isRunning", true);};
        _input.Player.Sprint.canceled += ctx => {_isRunning = false; _speed = _walkSpeed; _animator.SetBool("isRunning", false);};
        _input.Player.Jump.performed += ctx => {_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); _animator.SetTrigger("jump");};
    }

    // TODO: Make it easier to read
    void FixedUpdate()
    {
        if (_isRunning)
        {
            _speed = _runSpeed;
        }
        else if (!_isRunning)
        {
            _speed = _walkSpeed;
        }

        _speed = _isRunning ? _runSpeed : _walkSpeed;

        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        movement *= _speed * 0.1f;
        transform.Translate(movement, Space.Self);

        if (_movementInput != Vector2.zero)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        
        Vector3 direction = new Vector3(_movementInput.x, 0, _movementInput.y);
        if (direction != Vector3.zero)
        {
            _animator.transform.forward = direction;
        }
    }
    private void OllisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
        }
    }
}
