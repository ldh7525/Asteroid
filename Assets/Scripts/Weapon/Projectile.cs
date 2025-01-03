using UnityEngine;

public class Projectile : WeaponBase
{
    public override void Attack() // �߻�ü �߻� ����
    {

        // ���� ����� Ÿ�� �˻�
        Transform target = FindNearestTarget();
        Debug.Log("����3");

        // Ÿ���� ���� ��� �ٷ� ��ȯ
        if (target == null) return;
        Debug.Log("����4");


        // �߻�ü �̵� ���� ����
        Vector2 direction = (target.position - transform.position).normalized;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("����5");
            rb.linearVelocity = direction * 10f; // �ӵ� ����
        }


    }
}