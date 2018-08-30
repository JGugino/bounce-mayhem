using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public Vector3 cameraOffset;

    public float smoothSpeed = 1f;

	void Update () {
        Vector3 targetPos = target.position;

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x + cameraOffset.x, targetPos.y + cameraOffset.y, targetPos.z + cameraOffset.z), smoothSpeed);
	}
}
