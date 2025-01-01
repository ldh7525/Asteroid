using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 startPoint; // 드래그 시작 위치
    private Vector2 endPoint;   // 드래그 종료 위치
    private Rigidbody2D rb;     // Rigidbody2D 참조
    private SpriteRenderer spriteRenderer;
    public float frictionCoefficient; 
    public float bigFrictionCoefficient; 
    public float nowSpeed;
    public float stopSpeed;

    [SerializeField] private float launchForce; // 발사 힘

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        nowSpeed = rb.linearVelocity.magnitude;

        // 드래그 시작
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        // 드래그 끝
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LaunchPlayer();
        }


        //실험용
        if (rb.linearVelocity.magnitude > 0)
        {
            spriteRenderer.color = Color.red; // 이동 중: 빨간색
        }
        else
        {
            spriteRenderer.color = Color.white; // 정지 상태: 흰색
        }
    }

    private void FixedUpdate()
    {
        ApplyFriction();
    }

    private void LaunchPlayer()
    {
        // 드래그 반대 방향 계산
        Vector2 direction = startPoint - endPoint;
        rb.AddForce(direction.normalized * launchForce, ForceMode2D.Impulse);
    }

    private void ApplyFriction()
    {
        if (rb.linearVelocity.magnitude > 4f)
            rb.linearVelocity *= frictionCoefficient;
        else if (rb.linearVelocity.magnitude > stopSpeed)
            rb.linearVelocity *= bigFrictionCoefficient;
        else
            rb.linearVelocity = Vector2.zero;
    }
}
