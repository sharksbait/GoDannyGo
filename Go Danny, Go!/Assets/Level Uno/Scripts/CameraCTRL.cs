using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCTRL : MonoBehaviour
{
    private Transform obj;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Obj").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 obj_position = transform.position;
        obj_position.x = obj.position.x;
        obj_position.x += offset;
        transform.position = obj_position;
    }
}
