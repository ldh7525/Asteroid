using UnityEngine;

public class Projectile : WeaponBase
{
    public override void Attack() // 발사체 발사 공격
    {

        // 가장 가까운 타겟 검색
        Transform target = FindNearestTarget();
        Debug.Log("측정3");

        // 타겟이 없는 경우 바로 반환
        if (target == null) return;
        Debug.Log("측정4");


        // 발사체 이동 방향 설정
        Vector2 direction = (target.position - transform.position).normalized;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("측정5");
            rb.linearVelocity = direction * 10f; // 속도 설정
        }


    }
}