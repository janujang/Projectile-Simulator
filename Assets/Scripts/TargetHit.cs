using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider hitObject)
    {
        if (hitObject.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
