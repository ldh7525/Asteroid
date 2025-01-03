using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Bullet : Projectile, IWeapon
{
    public float lifeTime = 5f; // 발사체의 생존 시간

    private void Start()
    {
        // 발사체의 생존 시간 설정
        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 장애물과 충돌하면 장애물 제거
        if (collision.tag == "DestructibleObstacle")
            Destroy(collision.gameObject);

        // 이에 해당하는 vfx 생성

        // 충돌 후 발사체 제거
        Destroy(gameObject);
    }

    public override void Attack()
    {
        base.Attack();

        //bullet attack
    }
}
