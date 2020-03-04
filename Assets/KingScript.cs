using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingScript : MonoBehaviour
{
    public Moving player;
    public float desireDist = 0;
    private float dist;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);

        if (dist <= desireDist+0.3f)
        {
            anim.SetFloat("Speed", 0f);
        }
        else if (dist <= 20f && dist > desireDist)
        {
            anim.SetFloat("Speed", 1f);
            this.transform.LookAt(new Vector3(-2f * player.transform.position.x, player.transform.position.y, player.transform.position.z));
            this.transform.Rotate(new Vector3(0f, 30f, 0f));
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.2f);
        }

    }
}
