using UnityEngine;

public class InstantAttack : WeaponBase
{


    public override void Attack() //범위공격하기
    {

        // 가장 가까운 타겟 검색
        Transform target = FindNearestTarget();

        // 타겟이 없는 경우 바로 반환
        if (target == null) return;

        // vfx 출력 + 범위 공격(타겟 방향으로)

    }

}
