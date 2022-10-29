using UnityEngine;

public class EnemySetActive : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player) && !_enemy.IsDie)
        {
            _enemy.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Player player) && !_enemy.IsDie)
        {
            _enemy.enabled = false; 
        }
    }
}
