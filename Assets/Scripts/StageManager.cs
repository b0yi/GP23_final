using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stage
{
    Intro = 0,      // �S���b�Y, �����I�� O
    ToCatPlanet,    // �I�쯫�_�F��Ĳ�o (���Y preview), �b�Y ��, �����I O
    ToWaterPlanet,  // ��ܫ�Ĳ�o (���Y preview), �b�Y ��, �����I O
    ToMazePlanet,   // ��ܫ�Ĳ�o (���Y preview), �b�Y �g�c, �����I O
    Maze,           // �g�c�P�y���aĲ�o, �S���b�Y, �����I �g�c����
    ToDragonPlanet, // 
    Dragon,         // �g�c�P�y���aĲ�o, �S���b�Y, �����I �s�P
}


public class StageManager : MonoBehaviour
{
    public Stage stage;

    public void UpdateStage()
    {
        stage += 1;
    }

    void Start()
    {
        stage = Stage.Intro;
    }

    void Update()
    {

    }
}
