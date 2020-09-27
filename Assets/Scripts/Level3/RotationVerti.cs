using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVerti : MonoBehaviour
{
	public Transform Target;
	public float AroundSpeed = 1f;
	// Use this for initialization
	void Start()
	{
	}
	// Update is called once per frame
	void Update()
	{
		this.transform.RotateAround(Target.position, Vector3.forward, AroundSpeed);
	}
}