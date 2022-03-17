using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Character"))
        {
            other.GetComponent<CharacterController>().GetDamage(10);
            EffectManager.Instance.ExplosionEffect(EffectManager.Instance.GetEffect(2), other.transform.position);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Obstacle"))
        {
            EffectManager.Instance.ExplosionEffect(EffectManager.Instance.GetEffect(0), other.transform.position);
            gameObject.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            EffectManager.Instance.ExplosionEffect(EffectManager.Instance.GetEffect(1), other.transform.position);
        }
    }
}
