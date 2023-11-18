using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool _detected = false;
    Vector2 Direction;
    //public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;
    public LayerMask layer;


    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = (targetPos - (Vector2)Shootpoint.position).normalized;
        RaycastHit2D rayInfo = Physics2D.Raycast(Shootpoint.position, Direction, Range, layer);

        /* DEBUG START */
        Debug.DrawRay(Shootpoint.position, Direction * Range, Color.red);
        /* DEBUG END */
        if (rayInfo)
        {
            print(rayInfo.collider.gameObject.name);
        }
        if (rayInfo && rayInfo.collider.gameObject.name == "Player")
        {

            _detected = true;
        }
        else
        {
            _detected = false;
        }

        if (_detected && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / FireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Shootpoint.position, Range);
    }
}
