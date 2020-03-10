using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainBattle : EnemyBehaviour
{
    public getDamage loserLoad;
    private Animator anim;
    public GameObject menuItems;
    public GameObject attackItems;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
    }
    override public void UpdateValues()
    {
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
    }
    override public void AttackAction()
    {
        StartCoroutine(VillainAttack());



    }

    IEnumerator VillainAttack()
    {
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(2f);
        loserLoad.DmgPlayer(5f);

        if(loserLoad.GetPlayerHealth() > 0f) { 
            attackItems.SetActive(false);
            menuItems.SetActive(true);
        }
        else
        {
            StartCoroutine(loserLoad.LoadAsynchronously());
        }
    }
}
