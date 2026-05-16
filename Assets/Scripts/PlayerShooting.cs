using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    bool isPlayerFiring;
    [Header("Player Laser Weapons")]
    [SerializeField] GameObject[] playerLaserWeapons;
    ParticleSystem[] playerLaserWeaponsParticles;
    ParticleSystem.EmissionModule[] playerLaserWeaponEmissions;

    [Header("Player Laser Weapons Aim Settings")]

    [SerializeField] GameObject playerLaserWeaponCrosshair, playerLaserWeaponTargetPoint;
    [SerializeField] float targetPointZDistance=250f;


    void Start()
    {
        InitializePlayerLaserWeapons();
        DisableCursor();

    }
    private void Update()
    {
        ProcessFiring();
        
    }
    public void OnFire(InputValue value)
    {
        isPlayerFiring = value.isPressed;

    }

    void DisableCursor()
    {
        Cursor.visible = false;
    }

    

    private void InitializePlayerLaserWeapons()
    {
        playerLaserWeaponsParticles = new ParticleSystem[playerLaserWeapons.Length];
        playerLaserWeaponEmissions = new ParticleSystem.EmissionModule[playerLaserWeapons.Length];

        for (int i = 0; i < playerLaserWeapons.Length; i++)
        {
            playerLaserWeaponsParticles[i] = playerLaserWeapons[i].GetComponent<ParticleSystem>();
            playerLaserWeaponEmissions[i] = playerLaserWeaponsParticles[i].emission;
        }
    }



    void ProcessFiring()
    {
        for (int i = 0; i < playerLaserWeapons.Length; i++)
        {
            playerLaserWeaponEmissions[i].enabled = isPlayerFiring;
        }

        MoveCrosshair();
        MoveTargetPoint();
        AimPlayerLaserWeapons();
    }

    void MoveCrosshair()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        playerLaserWeaponCrosshair.transform.position = mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new (Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetPointZDistance);
        playerLaserWeaponTargetPoint.transform.position = Camera.main.ScreenToWorldPoint(targetPointPosition);

    }

    void AimPlayerLaserWeapons()
    {
      foreach (GameObject playerLaserWeapon in playerLaserWeapons)
        {
            Vector3 playerLaserWeaponDirection = playerLaserWeaponTargetPoint.transform.position - this.transform.position;
            Quaternion playerLaserWeaponRotation = Quaternion.LookRotation(playerLaserWeaponDirection);
            playerLaserWeapon.transform.rotation = playerLaserWeaponRotation;
        }
    }



}
