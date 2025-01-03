using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
   
    // �ڵ� ����: ���� ����� "Obstacle" �±׸� ���� ������Ʈ�� Transform ��ȯ
    public Transform FindNearestTarget()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("DestructibleObstacle");
        Transform nearest = null;
        float shortestDistance = Mathf.Infinity;
        Debug.Log("����");
        foreach (var obstacle in obstacles)
        {
            float distance = Vector2.Distance(transform.position, obstacle.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = obstacle.transform;
            }
        }
        Debug.Log("����2");
        return nearest;
    }

    // �߻� �޼���: ��ü���� ���� ������ ���� Ŭ�������� ����
    public abstract void Attack();
}
