using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType{
        player,
        enemy
    }
public class CharacterController : MonoBehaviour
{
    public CharacterType characterType;
    public Transform firePoint;
    public float force;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Backspace) && characterType == CharacterType.player)
        {
            Fire(BulletPoolManager.Instance.GetBullet());
        }
    }

    public  void Fire(GameObject bullet)
    {
        bullet.transform.position = firePoint.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.TransformDirection(Vector3.forward) * force;
    }
}
