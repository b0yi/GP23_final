using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stage
{
    Intro = 0,      // 沒有箭頭, 重生點為 O
    ToCatPlanet,    // 碰到神奇東西觸發 (鏡頭 preview), 箭頭 貓, 重生點 O
    ToWaterPlanet,  // 對話後觸發 (鏡頭 preview), 箭頭 水, 重生點 O
    ToMazePlanet,   // 對話後觸發 (鏡頭 preview), 箭頭 迷宮, 重生點 O
    Maze,           // 迷宮星球落地觸發, 沒有箭頭, 重生點 迷宮附近
    Dragon,         // 迷宮星球落地觸發, 沒有箭頭, 重生點 龍星
}


public class StageManager : MonoBehaviour
{
    [DisplayOnly] public Stage stage;

    void UpdateStage()
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
