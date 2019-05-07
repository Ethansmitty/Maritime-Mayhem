using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print("entered");
    }

    private void OnTriggerExit(Collider other)
    {
        print("exited");
    }
}
