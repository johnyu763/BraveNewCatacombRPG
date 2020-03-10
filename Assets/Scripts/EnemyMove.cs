using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private Vector3 playerPos;
    private Vector3 moveDir;
    private float dist;
    public float speed;
    //Start is called before the first frame update
    private void Update()
    {
        dist = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (dist <= 75)
        {
            enemy.transform.LookAt(player.transform);
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed);
        }
        enemy.transform.position = new Vector3(enemy.transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + 1.5f, enemy.transform.position.z);
    }

}

