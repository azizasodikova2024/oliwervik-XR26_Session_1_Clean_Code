using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
