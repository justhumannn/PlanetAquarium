using UnityEngine;
using System; //이 줄이 꼭 있어야 [Serializable]을 사용할 수 있습니다!

[Serializable]
public class GameData
{
    public int money = 100000;
    public string zooName = "My Aquarium";
}