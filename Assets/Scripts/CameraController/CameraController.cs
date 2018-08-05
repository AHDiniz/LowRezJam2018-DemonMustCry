using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float followSpeed;
	public Transform followTarget;

	public void LateUpdate()
	{
		Vector3 origin = transform.position;
		Vector3 target = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
		transform.position = Vector3.Lerp(origin, target, followSpeed * Time.deltaTime);
	}
}
