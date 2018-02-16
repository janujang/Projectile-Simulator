using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessFeedback : MonoBehaviour
{
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            source.Play();
        }
    }
}
