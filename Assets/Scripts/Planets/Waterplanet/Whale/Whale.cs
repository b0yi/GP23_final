using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public Transform waterPlanetTF;
    public Transform whaleAttackCenterTF;
    public Transform playerTF;
    public float radius;
    public float shift = 0;
    private float timeCounter;
    public bool attack;
    public float speed = 1;
    public float attackSpeed;

    // Start is called before the first frame update
    void Start()
    {

        timeCounter = shift;
    }

    public void Attack()
    {
        attack = true;
    }

    public void Unattack()
    {
        attack = false;
    }

    void Update()
    {
        if (attack)
        {
            transform.position += (playerTF.position - whaleAttackCenterTF.position).normalized * Time.deltaTime * attackSpeed;

            Vector2 targ = playerTF.position - whaleAttackCenterTF.position;
            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            //transform.rotation = Quaternion.FromToRotation(transform.right, playerTF.position - transform.position);
        }
        else
        {
            timeCounter += Time.deltaTime * speed;
            float x = radius * Mathf.Cos(timeCounter) + waterPlanetTF.position.x;
            float y = radius * Mathf.Sin(timeCounter) + waterPlanetTF.position.y;
            float z = 0;
            transform.SetPositionAndRotation(new Vector3(x, y, z), Quaternion.Euler(0f, 0f, timeCounter * 180f / Mathf.PI + 90f));

        }
    }


}
