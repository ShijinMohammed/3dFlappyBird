using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private float YSave;

    // Start is called before the first frame update
    void Start()
    {
        // Find the offset of the camera from the flappy bird
        offset = target.position - transform.position;
        // Save the Y axis position that the camera is placed on
        YSave = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Move camera position as flappy bird moves in the X direction
        transform.position = new Vector3(target.position.x - offset.x, YSave,target.position.z - offset.z);
    }
}
