using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public float moveSpeed;
    
    public float rotationSpeed;

    public float acceleratetime=3.0f;
    private float elapsedtime=0.0f;
    private Vector2 direction;
    public GameObject target;
    private float currentspeed;

    private void Update()
    {
        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        elapsedtime+=Time.deltaTime;
        float percentage=elapsedtime/acceleratetime;
        Vector2 cursorPos = target.transform.position;
        currentspeed=Mathf.Lerp(1.0f,moveSpeed,percentage);
        //print(currentspeed);
        if(percentage>1)
            percentage=1;
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, currentspeed * Time.deltaTime);

    }
}               
