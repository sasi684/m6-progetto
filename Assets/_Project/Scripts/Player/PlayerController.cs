using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _staminaRegenDelay;
    [SerializeField] private float _staminaRegenRate;

    private Camera _camera;
    private Rigidbody _rb;

    private Vector3 _direction;
    private bool _isSprinting;

    private StaminaController _staminaController;
    private float _lastStaminaConsumed;

    private GroundCheck _groundCheck;
    private bool _isJumping;

    private void Awake()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _staminaController = GetComponent<StaminaController>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("PreviousScene", SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _direction = transform.forward * vertical + transform.right * horizontal;
        _direction = _direction.normalized;

        if (CanConsumeStamina()) // If the player has enough stamina, they can run/jump. If not, set the sprint and jump booleans to false
        {
            _isSprinting = Input.GetKey(KeyCode.LeftShift);

            _isJumping = Input.GetButtonDown("Jump");

            if (_isJumping && _groundCheck.IsGrounded) // If the player hits jumo and is touching the ground, they jump
                Jump();
        }
        else
        {
            _isSprinting = false;
            _isJumping = false;
        }

        if (CanGainStamina()) // Regen stamina each frame at a given rate
            _staminaController.GainStamina(_staminaRegenRate * Time.deltaTime);
    }

    private void FixedUpdate() // Move and rotate the player's rigidbody
    {
        Vector3 velocity = CalculateVelocity();
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);

        RotatePlayer();
    }

    private Vector3 CalculateVelocity() // Calculate the velocity if the player is sprinting or not
    {
        if (_isSprinting && _direction != Vector3.zero)
        {
            _staminaController.ConsumeStamina(40f * Time.fixedDeltaTime); // If the player's sprinting, consume stamina
            _lastStaminaConsumed = Time.time;

            return _direction * _moveSpeed * 2;
        }
        else
        {
            return _direction * _moveSpeed;
        }
    }

    private void Jump() // Make a jump and consume a bunch of stamina all at once
    {
        _staminaController.ConsumeStamina(30f);
        _lastStaminaConsumed = Time.time;

        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isJumping = false; // Reset this boolean
    }

    private void RotatePlayer() // Rotate the player around the Y axis only based on the camera rotation
    {
        float cameraRotationYAxis = _camera.transform.rotation.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotationYAxis, 0);
        _rb.MoveRotation(targetRotation);
    }

    private bool CanGainStamina() // The player can regen stamina after a given amount of time
    {
        return Time.time - _lastStaminaConsumed > _staminaRegenDelay;
    }

    private bool CanConsumeStamina() // The player can only consume stamina if the have any
    {
        return _staminaController.GetCurrentStamina() > 0;
    }

}
