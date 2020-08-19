using UnityEngine;

public enum ProjectileDirection
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}

public class ProjectileController : MonoBehaviour
{
    public ProjectileDirection Direction { get; set; }

    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        switch (Direction)
        {
            case ProjectileDirection.UP:
                transform.Translate(transform.up * speed * Time.deltaTime);
                break;
            case ProjectileDirection.RIGHT:
                transform.Translate(transform.right * speed * Time.deltaTime);
                break;
            case ProjectileDirection.DOWN:
                transform.Translate(transform.up * -1 * speed * Time.deltaTime);
                break;
            case ProjectileDirection.LEFT:
                transform.Translate(transform.right * -1 * speed * Time.deltaTime);
                break;
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
