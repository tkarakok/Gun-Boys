using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum CharacterType
{
    player,
    enemy
}
public class CharacterController : MonoBehaviour
{
    public CharacterType characterType;
    public Transform firePoint;
    public float force;
    public Image healthBar, damageBar;
    public const float Max_Health = 100;
    public const float Min_Health = 0;

    private float _health;

    private void Start()
    {
        _health = Max_Health;
        UpdateHealthBar();
        if (characterType == CharacterType.enemy)
        {
            StartCoroutine(StartFireForEnemyType());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterType == CharacterType.player)
        {
            Fire(BulletPoolManager.Instance.GetBullet());
        }


    }

    #region HEALTH BAR FUNCTIONS
    
    /// <summary>
    /// if character take damage we calling this func and update helath bar on Player
    /// </summary>
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = _health / 100;
        StartCoroutine(UpdateDamageBar());
    }

    IEnumerator UpdateDamageBar()
    {
        yield return new WaitForSeconds(.1f);
        damageBar.fillAmount = _health / 100;
    }

    #endregion

    /// <summary>
    /// fire function 
    /// </summary>
    /// <param name="bullet"> get bullet in bullet pool manager in queue </param>
    public void Fire(GameObject bullet)
    {
        bullet.transform.position = firePoint.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.TransformDirection(Vector3.forward) * force;
    }

    /// <summary>
    /// if collise a bullet this func. calling both character type 
    /// </summary>
    /// <param name="damage"> damage value </param>
    public void GetDamage(float damage)
    {
        _health -= damage;
        UpdateHealthBar();
        Debug.Log(transform.name + _health);
        if (_health <= Min_Health)
        {
            // game over 
        }
    }


    IEnumerator StartFireForEnemyType()
    {
        while (true)
        {
            yield return new WaitForSeconds(.75f);
            Fire(BulletPoolManager.Instance.GetBullet());
        }
    }
}
