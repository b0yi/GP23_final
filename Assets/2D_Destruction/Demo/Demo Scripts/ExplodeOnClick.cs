using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour 
{

	private Explodable _explodable;
	public GameObject finalitem;
	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}

	void Update()
    {
        if(finalitem==null)
		{
			_explodable.explode();
			ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
			ef.doExplosion(transform.position);
		}
    }

// 	void OnMouseDown()
// 	{
		
// 	}
}
