using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stage
{
    LearningMove = 0,   // 一開始還沒按下鍵盤
    LearningJump,       // 
    OnOriginPlanet,     // 會移動了
    Stele,
    LearningLaunch,     //
    ToCatPlanet,        // 
    Kitten,           // 
    Cat,             // 
    ToWaterPlanet,      // 
    Water,              // 
    ToMazePlanet,       // 
    Maze,               // 
    ToDragonPlanet,     // 
    Dragon,             // 
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
        stage = Stage.LearningMove;
    }

    void Update()
    {

    }
}
