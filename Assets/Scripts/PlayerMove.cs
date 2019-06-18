using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    public float defaultSpeed;
    public float alteredSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private bool isJumping;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        defaultSpeed = movementSpeed;
        alteredSpeed = defaultSpeed;
    }
    private void Update()
    {
        PlayerMovement();
    }
    public void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * alteredSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * alteredSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();

    }

    public void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;

        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
        isJumping = false;
    }


}
