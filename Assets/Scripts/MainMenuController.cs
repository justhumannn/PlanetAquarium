using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동을 위해 필수!

public class MainMenuController : MonoBehaviour
{
    // 게임 시작 버튼을 누르면 실행될 함수
    public void GameStart()
    {
        // "GameScene"이라는 이름의 씬을 불러옵니다.
        SceneManager.LoadScene("GameScene");
    }

    // 종료 버튼을 누르면 실행될 함수
    public void QuitGame()
    {
        Debug.Log("게임이 종료되었습니다."); // 에디터에서는 안 꺼지므로 확인용 메시지 출력
        Application.Quit();
    }
}