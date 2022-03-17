using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Character"))
        {
            
        }
        else if (other.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }
}
