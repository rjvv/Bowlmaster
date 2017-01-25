using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

	void OnTriggerExit (Collider other)
	{

		if (other.attachedRigidbody.GetComponent<Pin> ()) {
			Destroy (other.attachedRigidbody.gameObject);
		}

	}





}
