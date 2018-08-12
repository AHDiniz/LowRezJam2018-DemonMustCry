using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float followSpeed;
	public Transform followTarget;

	public void LateUpdate()
	{
		transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
	}
}
