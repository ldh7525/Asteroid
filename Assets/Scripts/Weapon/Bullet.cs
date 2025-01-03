using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Bullet : Projectile, IWeapon
{
    public float lifeTime = 5f; // �߻�ü�� ���� �ð�

    private void Start()
    {
        // �߻�ü�� ���� �ð� ����
        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��ֹ��� �浹�ϸ� ��ֹ� ����
        if (collision.tag == "DestructibleObstacle")
            Destroy(collision.gameObject);

        // �̿� �ش��ϴ� vfx ����

        // �浹 �� �߻�ü ����
        Destroy(gameObject);
    }

    public override void Attack()
    {
        base.Attack();

        //bullet attack
    }
}
