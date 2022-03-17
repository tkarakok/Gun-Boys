using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : Singleton<BulletPoolManager>
{
    [System.Serializable]
    public struct Bullet{
        public GameObject bulletPrefab;
        public Queue<GameObject> bulletsQueue;
        public int totalBullet;
        public Transform parent;
    }

    public Bullet bulletPool;
    

    private void Awake() {
        bulletPool.bulletsQueue = new Queue<GameObject>();

        for (int i = 0; i < bulletPool.totalBullet; i++)
        {
            GameObject bullet = Instantiate(bulletPool.bulletPrefab);
            bullet.transform.SetParent(bulletPool.parent);
            bullet.SetActive(false);
            bulletPool.bulletsQueue.Enqueue(bullet);
        }
    }

    /// <summary>
    /// we get a bullet if enemy or player do fire in queue
    /// </summary>
    /// <returns></returns>
    public GameObject GetBullet()
    {
        GameObject bullet = bulletPool.bulletsQueue.Dequeue();
        bullet.transform.SetParent(null);
        bullet.SetActive(true);
        bulletPool.bulletsQueue.Enqueue(bullet);
        return bullet;
    }

}
