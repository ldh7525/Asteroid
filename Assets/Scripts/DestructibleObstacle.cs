using UnityEngine;

public class DestructibleObstacle : MonoBehaviour
{
    public void TakeDamage()
    {
        // ��ֹ� �ı� ����
        Destroy(gameObject);
    }
}
