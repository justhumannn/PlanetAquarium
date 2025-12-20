using UnityEngine;
using System.IO; // 파일 입출력을 위해 필요

public class InGameManager : MonoBehaviour
{
    public GameData currentGameData;
    private string saveFilePath;

    void Start()
    {
        // 저장 경로 설정 (C:/Users/사용자/AppData/LocalLow/회사이름/프로젝트이름/savegame.json)
        saveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");

        // 게임 시작 시 기본 데이터 생성
        currentGameData = new GameData();
        Debug.Log("현재 소지금: " + currentGameData.money);
    }

    // 저장하기 버튼 기능
    public void SaveGame()
    {
        // 1. 데이터를 JSON(텍스트) 형태로 변환
        string json = JsonUtility.ToJson(currentGameData, true);

        // 2. 파일로 쓰기
        File.WriteAllText(saveFilePath, json);
        Debug.Log("게임 저장 완료: " + saveFilePath);
    }

    // 불러오기 버튼 기능
    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            // 1. 파일 읽기
            string json = File.ReadAllText(saveFilePath);

            // 2. JSON을 다시 데이터로 변환
            currentGameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("게임 불러오기 완료! 불러온 소지금: " + currentGameData.money);
        }
        else
        {
            Debug.Log("저장된 파일이 없습니다.");
        }
    }

    // 테스트용: 돈 쓰는 기능
    public void SpendMoney()
    {
        currentGameData.money -= 1000;
        Debug.Log("1000원 사용. 남은 돈: " + currentGameData.money);
    }
}