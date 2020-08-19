using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Projectiles")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;

    [Header("Configuration")]
    [SerializeField] private float bodyOffset;
    [SerializeField] private float startTimeBetweenShots;


    public Vector2 ActualPlayerMovement { get; set; }

    private Vector2 _upShoot = new Vector2(0f, 1f);
    private Vector2 _rightShoot = new Vector2(1f, 0f);
    private Vector2 _downShoot = new Vector2(0f, -1f);
    private Vector2 _leftShoot = new Vector2(-1f, 0f);
    private float _timeBetweenShots;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _timeBetweenShots <= 0)
        {
            CheckProjectileDirection();
        }

        _timeBetweenShots -= Time.deltaTime;
    }

    private void CheckProjectileDirection()
    {
        switch (ActualPlayerMovement)
        {
            case Vector2 v when v.Equals(_upShoot):
                SpawnProjectile(new Vector2(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y + bodyOffset), ProjectileDirection.UP);
                break;
            case Vector2 v when v.Equals(_rightShoot):
                SpawnProjectile(new Vector2(projectileSpawnPoint.position.x + bodyOffset, projectileSpawnPoint.position.y), ProjectileDirection.RIGHT);
                break;
            case Vector2 v when v.Equals(_downShoot):
                SpawnProjectile(new Vector2(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y - bodyOffset), ProjectileDirection.DOWN);
                break;
            case Vector2 v when v.Equals(_leftShoot):
                SpawnProjectile(new Vector2(projectileSpawnPoint.position.x - bodyOffset, projectileSpawnPoint.position.y), ProjectileDirection.LEFT);
                break;
            default:
                SpawnProjectile(new Vector2(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y - bodyOffset), ProjectileDirection.DOWN);
                break;
        }
    }

    private void SpawnProjectile(Vector2 position, ProjectileDirection direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        projectileController.Direction = direction;
        _timeBetweenShots = startTimeBetweenShots;
    }

}
