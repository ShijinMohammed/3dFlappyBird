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
        offset = target.position - transform.position;
        YSave = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x - offset.x, YSave,target.position.z - offset.z);
    }
}
