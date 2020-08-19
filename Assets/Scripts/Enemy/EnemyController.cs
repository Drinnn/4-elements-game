using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float maxDistanceFromPlayer;
    [SerializeField] private float moveSpeed;

    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) > maxDistanceFromPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, moveSpeed * Time.deltaTime);
        }
    }

}
