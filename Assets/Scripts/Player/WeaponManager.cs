using UnityEditor.Search;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // 무기 프리팹 배열
    public GameObject currentWeapon; // 현재 장착 중인 무기 (프리팹)

    // 최대 탄환 수 (읽기 전용)
    public int MaxAmmo { get; private set; } = 10;

    // 현재 탄환 수 (읽기 전용)
    private int currentAmmo;

    public int CurrentAmmo
    {
        get => currentAmmo;
        private set => currentAmmo = Mathf.Clamp(value, 0, MaxAmmo); // 0과 MaxAmmo 사이로 제한
    }

    // 공격 가능한지 여부 (읽기 전용)
    public bool CanAttack => CurrentAmmo > 0;


    void Start()
    {
        CurrentAmmo = MaxAmmo; // 시작 시 탄환 충전

        // 기본 무기를 선택
        if (weaponPrefabs.Length > 0)
        {
            currentWeapon = weaponPrefabs[0];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AttackCommand(); // 인터페이스에서 갖고온 Attack
        }

        // 특정 키를 눌러 무기 변경 (예: 1, 2, 3 키)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0); // 첫 번째 무기로 변경
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1); // 두 번째 무기로 변경
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapon(2); // 세 번째 무기로 변경
        }
    }

    // 탄환 소비
    public void ConsumeAmmo()
    {
        CurrentAmmo--;
    }

    // 탄환 충전
    public void Reload(int amount)
    {
        CurrentAmmo += amount; // Clamping으로 초과 방지
    }

    private void SwapWeapon(int weaponIndex)
    {
        // 무기 인덱스가 범위를 벗어나면 실행하지 않음
        if (weaponIndex < 0 || weaponIndex >= weaponPrefabs.Length)
        {
            Debug.LogWarning("Invalid weapon index: " + weaponIndex);
            return;
        }

        // 새로운 무기 활성화
        currentWeapon = weaponPrefabs[weaponIndex];

         // IWeapon 인터페이스를 통해 무기 확인
        var weaponScript = currentWeapon.GetComponent<IWeapon>();
        if (weaponScript != null)
        {
            Debug.Log("Weapon swapped to: " + currentWeapon.name);
        }
        else
        {
            Debug.LogWarning("No IWeapon script found on weapon: " + currentWeapon.name);
        }
    }

    private void AttackCommand()
    {
        // 공격 불가능한 경우 바로 반환
        if (!CanAttack) return;
        //예외처리 - null경우
        if (currentWeapon == null) return;

        //프리팹 instantiate해주기. 
        GameObject weaponObject = Instantiate(currentWeapon, transform.position, Quaternion.identity);

        // 탄환 소비
        ConsumeAmmo();

        // IWeapon 인터페이스를 통해 공격 메서드 호출
        var weaponScript = weaponObject.GetComponent<IWeapon>();
        if (weaponScript != null)
        {
            weaponScript.Attack(); // 인터페이스 메서드 호출
            Debug.Log("Attack executed for weapon: " + currentWeapon.name);
        }
        else
        {
            Debug.LogWarning("No IWeapon script found on weapon: " + currentWeapon.name);
        }
    }
}
