using UnityEngine;

public class InstantAttack : WeaponBase
{


    public override void Attack() //���������ϱ�
    {

        // ���� ����� Ÿ�� �˻�
        Transform target = FindNearestTarget();

        // Ÿ���� ���� ��� �ٷ� ��ȯ
        if (target == null) return;

        // vfx ��� + ���� ����(Ÿ�� ��������)

    }

}
