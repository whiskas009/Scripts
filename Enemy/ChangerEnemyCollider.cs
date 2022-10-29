using UnityEngine;

public class ChangerEnemyCollider : MonoBehaviour
{
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public void SetColliderSize(Vector3 _enemyColliderSize)
    {
        _collider.size = _enemyColliderSize;
    }
}
