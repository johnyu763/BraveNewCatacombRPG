using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobScript : EnemyBehaviour
{
    public getDamage lose;
    public GameObject player;
    public Slider EnemyHealth;
    private Vector3 startPosition;
    private Vector3 attackPosition;
    public GameObject menuItems;
    public GameObject attackItems;
    public float minHeight;
    private Vector3 moveVector;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + minHeight, transform.position.z);
        startPosition = transform.position;
        attackPosition = (player.transform.position - startPosition);
       
        moveVector = new Vector3((attackPosition.x) / 25f, 0f, (attackPosition.z) / 25f);
    }
    override public void UpdateValues()
    {
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + minHeight, transform.position.z);
        startPosition = transform.position;
        attackPosition = (player.transform.position - startPosition);

        moveVector = new Vector3((attackPosition.x) / 25f, 0f, (attackPosition.z) / 25f);
    }
    override public void AttackAction()
    {
        if(EnemyHealth.value > 0f)
        {
            StartCoroutine(VillainAttack());
        }


    }

    IEnumerator VillainAttack()
    {

        yield return new WaitForSeconds(0.75f);
        float timePassed = 0;
        while (timePassed < 0.5f)
        {
            controller.Move(moveVector);
            transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + minHeight, transform.position.z);
            yield return new WaitForSeconds(0.5f / 40);
            timePassed += Time.deltaTime;
        }
        this.transform.position = startPosition;
        menuItems.SetActive(true);
        lose.DmgPlayer();
        //lose.RunWin();
    }
}
