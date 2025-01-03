using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; } // 싱글톤 인스턴스

    public bool isGameOver;
    public bool isGamePaused;

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스가 있으면 삭제
        }

        DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
    }

    public void GameStart()
    {
        isGameOver = false;
        isGamePaused = false;
        Debug.Log("Game Start");
    }
}
