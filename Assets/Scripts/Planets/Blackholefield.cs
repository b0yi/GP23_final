using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
[ExecuteInEditMode]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Blackholefield : MonoBehaviour
{
    /// <summary>  </summary>
    public const float          GRAVITY_PULL    = 40.0f;
    /// <summary>  </summary>
    private const float         SWIRLSTRENGTH   = 5f;

    // ------------------------------------------------
    /// <summary>  </summary>
    private float               _gravityRadius  = 7.0f;    
    /// <summary>  </summary>
    private List<Rigidbody2D>   _rigidBodies    = new List<Rigidbody2D>();
    // ------------------------------------------------

#if UNITY_EDITOR     
    void Update()
    {
        if( Application.isPlaying == false )
        {
            _gravityRadius = 
                GetComponent<CircleCollider2D>().radius;
        }
    }
#endif 

    private void LateUpdate()
    {    
        UpdateBlackHole();
    }


    /// <summary>
    /// Attract objects towards an area when they come within the bounds of a collider.
    /// This function is on the physics timer so it won't necessarily run every frame.
    /// </summary>
    /// <param name="in_other">Any object within reach of gravity's collider</param>
    void OnTriggerEnter2D(Collider2D in_other)
    {
        if ( in_other.attachedRigidbody != null 
            && _rigidBodies != null )
        {                
            //to get them nice and swirly, use the perpendicular to the direction to the vortex
            Vector3 direction = transform.position - in_other.attachedRigidbody.transform.position;
            var tangent = Vector3.Cross(direction, Vector3.forward).normalized * SWIRLSTRENGTH;

            in_other.attachedRigidbody.velocity = tangent;            
            _rigidBodies.Add( in_other.attachedRigidbody );
        }
    }

    private void UpdateBlackHole()
    {
        if( _rigidBodies != null )
        {
            for (int i = 0; i < _rigidBodies.Count; i++)
            {
                if( _rigidBodies[i] != null )
                {
                    CalculateMovement( _rigidBodies[i] );
                }
            }
        }
    }

    

    private void CalculateMovement(
        Rigidbody2D in_rb
    )
    {
        float distance = Vector3.Distance(transform.position,in_rb.transform.position); 
        float gravityIntensity =distance/ _gravityRadius;

        in_rb.AddForce((transform.position - in_rb.transform.position)*gravityIntensity * in_rb.mass* GRAVITY_PULL* Time.deltaTime);
        
        in_rb.drag += 0.0001f;
        
        Debug.DrawRay(in_rb.transform.position, transform.position - in_rb.transform.position);


        if( distance <= 0.1f )
        {
            _rigidBodies.Remove( in_rb );

            Destroy( in_rb.gameObject );
        }
    }
}
