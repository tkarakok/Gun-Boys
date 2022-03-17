using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    [System.Serializable]
    public struct Effect{
        public GameObject particlePrefab;
        public Queue<GameObject> particlesQueue;
        public int size;
        public Transform parent;
    }

    public Effect[] effectsPool;

    private void Awake() {
        for (int i = 0; i < effectsPool.Length; i++)
        {
            effectsPool[i].particlesQueue = new Queue<GameObject>();
            for (int j = 0; j < effectsPool[i].size; j++)
            {
                GameObject particles = Instantiate(effectsPool[i].particlePrefab);
                particles.transform.SetParent(effectsPool[i].parent);
                particles.SetActive(false);
                effectsPool[i].particlesQueue.Enqueue(particles);
            }
        }
    }

    /// <summary>
    /// we get effect for collision 
    /// </summary>
    /// <param name="type"> index value </param>
    /// <returns></returns>
    public GameObject GetEffect(int type){
        // 0 - Obstacle - 1 - Bullet - 2 - Character
        GameObject effect = effectsPool[type].particlesQueue.Dequeue();
        effect.SetActive(true);
        effectsPool[type].particlesQueue.Enqueue(effect);
        return effect;
    }


    /// <summary>
    /// we play effect
    /// </summary>
    /// <param name="effect"> ecplosion effect</param>
    /// <param name="position"> effect position </param>
    public void ExplosionEffect(GameObject effect, Vector3 position)
    {
        effect.transform.position = position;
        effect.GetComponent<ParticleSystem>().Play();
    }
}
