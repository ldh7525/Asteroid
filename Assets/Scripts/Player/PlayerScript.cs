using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerScript: MonoBehaviour
{
    private Vector2 startPoint; // 드래그 시작 위치
    private Vector2 endPoint;   // 드래그 종료 위치
    private Rigidbody2D rb;     // Rigidbody2D 참조
    private SpriteRenderer spriteRenderer;

    bool isPlayerPowerUp;

    public float frictionCoefficient; 
    public float bigFrictionCoefficient; 
    public float nowSpeed;
    public float stopSpeed;

    [SerializeField] private float launchForce; // 발사 힘

    private void Awake()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPlayerPowerUp) // 플레이어가 파워업 상태가 아닌 경우
        {
            GameStateManager.Instance.GameOver(); // 게임 종료 처리
        }
        else // 파워업 상태인 경우
        {
            var obstacleScript = collision.gameObject.GetComponent<IObstacle>();
            // 충돌한 객체에서 IObstacle 인터페이스를 구현한 스크립트를 가져옴

            if (obstacleScript != null) // 가져온 스크립트가 존재하면
            {
                obstacleScript.DestroyEffect(); // 인터페이스 메서드 호출
                Debug.Log("obstacleScript.DestroyEffect(); // 인터페이스 메서드 호출");
            }
            else // 인터페이스를 구현하지 않은 객체일 경우
            {
                Debug.LogWarning("null"); // 경고 메시지 출력
            }

            Destroy(collision.gameObject); // 충돌한 객체 제거
        }
    }

}
