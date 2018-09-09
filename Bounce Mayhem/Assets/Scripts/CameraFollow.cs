using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public Vector3 cameraOffset;

    public float smoothSpeed = 1f, turnSpeed = 1f;

    public static CameraFollow instance;

    private Vector3 targetPos;

    private void Awake()
    {
        instance = this;
    }

    void Update () {
        targetPos = target.position;

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x + cameraOffset.x, targetPos.y + cameraOffset.y, targetPos.z + cameraOffset.z), smoothSpeed);

        //transform.Rotate(Vector3.Lerp(new Vector3(transform.position.x, 0, 0), new Vector3(0, targetPos.y, 0), turnSpeed));

        
    }


    public void rotateCamera(float direction)
    {
        transform.RotateAround(targetPos, new Vector3(0, targetPos.y, 0), turnSpeed);
    }
}
