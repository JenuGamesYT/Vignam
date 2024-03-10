using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RutherFord
{
	[RequireComponent(typeof(Rigidbody))]
	public class Atoms : MonoBehaviour
	{
		Nuclear planet;
		Rigidbody rb1;

		void Awake()
		{
			planet = GameObject.FindGameObjectWithTag("Atoms").GetComponent<Nuclear>();
			rb1 = GetComponent<Rigidbody>();

			rb1.useGravity = false;
			rb1.constraints = RigidbodyConstraints.FreezeRotation;
		}

		void FixedUpdate()
		{
			planet.Attract(rb1);
		}
	}
}

