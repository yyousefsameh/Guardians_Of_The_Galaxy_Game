using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 playerMovementInput;


    void Update()
    {
        PlayerMovement();
    }


    public void OnMove(InputValue value)
    {
        playerMovementInput = value.Get<Vector2>();

    }

    void PlayerMovement()
    {
        ProccessPlayerTranslationMovement();
        ProccessPlayerRotation();
    }


    void ProccessPlayerTranslationMovement()
    {
        float playerMovementSpeed = 30f;
        float playerXOffset = playerMovementInput.x * Time.deltaTime * playerMovementSpeed,
         playerYOffset = playerMovementInput.y * Time.deltaTime * playerMovementSpeed;

        float playerRawXPosition = transform.localPosition.x + playerXOffset,
        playerRawYPosition = transform.localPosition.y + playerYOffset;

        float playerXPositionMin = -20f, playerXPositionMax = 20f, playerYPositionMin = -3f, playerYPositionMax = 20f;

        float playerXNewPositionClamped = Mathf.Clamp(playerRawXPosition, playerXPositionMin, playerXPositionMax),
        playerYNewPositionClamped = Mathf.Clamp(playerRawYPosition, playerYPositionMin, playerYPositionMax);
        transform.localPosition = new Vector3(playerXNewPositionClamped, playerYNewPositionClamped, 0f);
    }
    void ProccessPlayerRotation()
    {
        float playerPitchFactor = -14f, playerRollFactor = -16f, playerRotationSpeed = 4f;

        float playerPitch = playerMovementInput.y * playerPitchFactor,

        playerRoll = playerMovementInput.x * playerRollFactor;

        Quaternion playerTargetRotation = Quaternion.Euler(playerPitch, 0f, playerRoll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, playerTargetRotation, Time.deltaTime * playerRotationSpeed);


    }
}
