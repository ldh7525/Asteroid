using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; } // �̱��� �ν��Ͻ�

    public bool isGameOver;
    public bool isGamePaused;

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ��� ������ ����
        }

        DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ����
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
