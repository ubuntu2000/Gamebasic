using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameBasic
{


    public class GameManager : MonoBehaviour
    {
       public float m_spawnTime;
       public Enemy[] enemyPrefabs;
       private bool m_IsGameOver;
       private int m_score;

        public int Score { get => m_score; set => m_score = value; }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {



        }
        IEnumerator SpawnEnemy()
        {
            while(!m_IsGameOver)
            {
                if(enemyPrefabs != null && enemyPrefabs.Length >0 )
                {
                    int randIdx = Random.Range(0, enemyPrefabs.Length);
                    Enemy enemyPrefab = enemyPrefabs[randIdx];
                    if(enemyPrefab)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(m_spawnTime);
           }
            
        }
    }
}