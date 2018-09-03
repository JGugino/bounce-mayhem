using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public Vector3 cameraOffset;

    public float smoothSpeed = 1f, turnSpeed = 1f;

    public static CameraFollow instance;
    private void Awake()
    {
        instance = this;
    }

    void Update () {
        Vector3 targetPos = target.position;

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x + cameraOffset.x, targetPos.y + cameraOffset.y, targetPos.z + cameraOffset.z), smoothSpeed);
	}

    public void turnCamera(float direction)
    {
        transform.Rotate(Vector3.Lerp(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), new Vector3(0, transform.rotation.x * direction, 0), turnSpeed));
    }

    public void returnToCenter()
    {
        transform.Rotate(Vector3.Lerp(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), Vector3.zero, turnSpeed));
    }
}
