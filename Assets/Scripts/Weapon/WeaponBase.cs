using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
   
    // 자동 조준: 가장 가까운 "Obstacle" 태그를 가진 오브젝트의 Transform 반환
    public Transform FindNearestTarget()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("DestructibleObstacle");
        Transform nearest = null;
        float shortestDistance = Mathf.Infinity;
        Debug.Log("측정");
        foreach (var obstacle in obstacles)
        {
            float distance = Vector2.Distance(transform.position, obstacle.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = obstacle.transform;
            }
        }
        Debug.Log("측정2");
        return nearest;
    }

    // 추상 메서드: 구체적인 공격 로직은 하위 클래스에서 구현
    public abstract void Attack();
}
