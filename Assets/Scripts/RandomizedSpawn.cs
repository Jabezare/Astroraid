using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedSpawn : MonoBehaviour
{

    public GameObject objectToSpawn;
    public GameObject powerUp;
    public float spawnDelay = 1.0f;
    public int numberOfEnemies;

    public int points = 0;
    GUIStyle UIStyle = new GUIStyle();

    private int enemyCount;
    private Vector3 lastEnemyPosition;

    // Use this for initialization
    void Start()
    {
        UIStyle.fontSize = 40;
        enemyCount = numberOfEnemies;
        PlayerPrefs.SetInt("currentscore", 0);
        Spawn();
    }

    void Update()
    {
        if (enemyCount == 0)
        {
            if (transform.childCount <= 0)
            {
                Instantiate(powerUp, lastEnemyPosition, powerUp.transform.rotation);
                points++;
                PlayerPrefs.SetInt("currentscore", points);
                if (points > PlayerPrefs.GetInt("highscore", 0))
                {
                    PlayerPrefs.SetInt("highscore", points);
                }
                enemyCount = numberOfEnemies;
                Spawn();
            }
        }
    }

    // Update is called once per frame
    void Spawn()
    {
        enemyCount--;
        GameObject instance = Instantiate(objectToSpawn, new Vector3(transform.position.x + Random.insideUnitCircle.x * 5.2f, transform.position.y, transform.position.z), transform.rotation);
        instance.transform.parent = transform;
        if (enemyCount > 0)
        {
            Invoke("Spawn", spawnDelay);
        }
    }

    void Dead(Vector3 position)
    {
        lastEnemyPosition = position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }

    void OnGUI()
    {
        if(FindObjectOfType<GameManager>().gameOver == false)
        {
            GUILayout.Label("Points: " + points.ToString(), UIStyle);
        }
    }
}