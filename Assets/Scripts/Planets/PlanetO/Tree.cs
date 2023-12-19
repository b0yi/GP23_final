using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject fruitPrefab;  // 樹上的果實預置體
    private bool isFruitAvailable = true;  // 判斷果實是否可用的標誌
    public float regenerationTime = 300f;  // 重新生成果實所需的時間（秒）
    private float elapsedTime = 0f;  // 經過的時間

    void Start()
    {
        SpawnFruit();
    }

    void Update()
    {
        if (!isFruitAvailable)
        {
            // 如果果實不可用，計時並在一定時間後重新生成果實
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= regenerationTime)
            {
                isFruitAvailable = true;
                elapsedTime = 0f;
                SpawnFruit();
            }
        }
    }
    void SpawnFruit()
    {
        if (isFruitAvailable)
        {
            // 生成果實並將其設置在樹的位置
            GameObject fruit = Instantiate(fruitPrefab, transform.position, Quaternion.identity);
            fruit.transform.parent = transform;
            isFruitAvailable = false;
        }
    }

    public void FruitEaten()
    {
        // 設置果實不可用，開始計時
        isFruitAvailable = false;
        elapsedTime = 0f;
    }

}
