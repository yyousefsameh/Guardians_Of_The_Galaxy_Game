using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
  [SerializeField] GameObject playerShipExplosionParticles ;
  GameSceneManager gameSceneManager;
  void Start()
  {
    gameSceneManager = FindFirstObjectByType<GameSceneManager>();
   
  }
  private void OnTriggerEnter(Collider other)
    {
        ProcessPlayerDeath();
    }

    private void ProcessPlayerDeath()
    {
        ExplosionEffect();
        Destroy(this.gameObject);
        gameSceneManager.ReloadeLevel();
    }

    private void ExplosionEffect()
    {
        Instantiate(playerShipExplosionParticles, transform.position, Quaternion.identity);
    }
}
