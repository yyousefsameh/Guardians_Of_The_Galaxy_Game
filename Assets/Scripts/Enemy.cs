using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject shipExplosionParticles;
    [SerializeField] int enemyHealth = 4;
    [SerializeField] int enemyScoreValue = 100;
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessEnemyHit();
    }

    private void ProcessEnemyHit()
    {
        enemyHealth --;
        if (enemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        scoreManager.AddScore(scoreToAdd:enemyScoreValue);
        ExplosionEffect();
        Destroy(this.gameObject);
    }

    private void ExplosionEffect()
    {
        Instantiate(shipExplosionParticles, transform.position, Quaternion.identity);
    }
}
