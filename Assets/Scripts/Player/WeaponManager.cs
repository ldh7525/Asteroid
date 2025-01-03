using UnityEditor.Search;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // ���� ������ �迭
    public GameObject currentWeapon; // ���� ���� ���� ���� (������)

    // �ִ� źȯ �� (�б� ����)
    public int MaxAmmo { get; private set; } = 10;

    // ���� źȯ �� (�б� ����)
    private int currentAmmo;

    public int CurrentAmmo
    {
        get => currentAmmo;
        private set => currentAmmo = Mathf.Clamp(value, 0, MaxAmmo); // 0�� MaxAmmo ���̷� ����
    }

    // ���� �������� ���� (�б� ����)
    public bool CanAttack => CurrentAmmo > 0;


    void Start()
    {
        CurrentAmmo = MaxAmmo; // ���� �� źȯ ����

        // �⺻ ���⸦ ����
        if (weaponPrefabs.Length > 0)
        {
            currentWeapon = weaponPrefabs[0];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AttackCommand(); // �������̽����� ����� Attack
        }

        // Ư�� Ű�� ���� ���� ���� (��: 1, 2, 3 Ű)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0); // ù ��° ����� ����
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1); // �� ��° ����� ����
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapon(2); // �� ��° ����� ����
        }
    }

    // źȯ �Һ�
    public void ConsumeAmmo()
    {
        CurrentAmmo--;
    }

    // źȯ ����
    public void Reload(int amount)
    {
        CurrentAmmo += amount; // Clamping���� �ʰ� ����
    }

    private void SwapWeapon(int weaponIndex)
    {
        // ���� �ε����� ������ ����� �������� ����
        if (weaponIndex < 0 || weaponIndex >= weaponPrefabs.Length)
        {
            Debug.LogWarning("Invalid weapon index: " + weaponIndex);
            return;
        }

        // ���ο� ���� Ȱ��ȭ
        currentWeapon = weaponPrefabs[weaponIndex];

         // IWeapon �������̽��� ���� ���� Ȯ��
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
        // ���� �Ұ����� ��� �ٷ� ��ȯ
        if (!CanAttack) return;
        //����ó�� - null���
        if (currentWeapon == null) return;

        //������ instantiate���ֱ�. 
        GameObject weaponObject = Instantiate(currentWeapon, transform.position, Quaternion.identity);

        // źȯ �Һ�
        ConsumeAmmo();

        // IWeapon �������̽��� ���� ���� �޼��� ȣ��
        var weaponScript = weaponObject.GetComponent<IWeapon>();
        if (weaponScript != null)
        {
            weaponScript.Attack(); // �������̽� �޼��� ȣ��
            Debug.Log("Attack executed for weapon: " + currentWeapon.name);
        }
        else
        {
            Debug.LogWarning("No IWeapon script found on weapon: " + currentWeapon.name);
        }
    }
}
