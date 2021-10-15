using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject EnemyPref, spawnPoint /*BossPref*/;
    public GameObject[] turrels;
    private int hp = 10;
    public float spawnTime = 10f;
    bool canBeenDestroed = false;
    public Animator anim;
    int i = 0;
    public int Zone = 0;


    void TakeDamage(int damage = 1)
    {
        if (canBeenDestroed)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator SpawnEnemy()
    {
        switch (Zone)
        {
            case 1:
                if (PlayerPrefs.GetInt("2") == 0)
                {
                    while (true)
                    {
                        GameObject Enemy = Instantiate(EnemyPref, spawnPoint.transform.position, Quaternion.identity);
                        enemies.Add(Enemy);
                        yield return new WaitForSeconds(spawnTime);
                    }
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("2") == 1)
                {
                    while (true)
                    {
                        GameObject Enemy = Instantiate(EnemyPref, spawnPoint.transform.position, Quaternion.identity);
                        enemies.Add(Enemy);
                        yield return new WaitForSeconds(spawnTime);
                    }
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("3") == 1)
                {
                    while (true)
                    {
                        GameObject Enemy = Instantiate(EnemyPref, spawnPoint.transform.position, Quaternion.identity);
                        enemies.Add(Enemy);
                        yield return new WaitForSeconds(spawnTime);
                    }
                }
                break;

        }

    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        //GameObject Boss = Instantiate(BossPref, spawnPoint.transform.position, Quaternion.identity);
        //enemies.Add(Boss);
    }

    void Update()
    {
        if (i < 1)
        {
            if (turrels[0] == null && turrels[1] == null && enemies.Count == 0)
            {
                anim.SetTrigger("open");
                canBeenDestroed = true;
                i++;
            }
        }
    }

}