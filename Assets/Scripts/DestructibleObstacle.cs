using UnityEngine;

public class DestructibleObstacle : MonoBehaviour
{
    public void TakeDamage()
    {
        // 장애물 파괴 로직
        Destroy(gameObject);
    }
}
