using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    Vector3 newPos = new Vector3();

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {
            newPos.x = followTarget.position.x;
            newPos.y = this.transform.position.y;
            newPos.z = followTarget.position.z;

            this.transform.position = newPos;
        }
    }
}
