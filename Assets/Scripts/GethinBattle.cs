using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GethinBattle : EnemyBehaviour
{
    public getDamage endGame;
    private Animator anim;
    private Vector3 moveVector;
    public Slider EnemyHealth;
    private CharacterController controller;
    public GameObject menuItems;
    public GameObject attackItems;
    private Vector3 startPosition;
    private Vector3 attackPosition;
    public GameObject player;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private Vector3 gravityVector;
    // Start is called before the first frame update

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
        startPosition = transform.position;
        attackPosition = (player.transform.position - startPosition);
        moveVector = new Vector3((attackPosition.x + 1.9f) / 25f, 0f, (attackPosition.z + 2.4f) / 25f);

    }
    override public void UpdateValues()
    {

        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
        startPosition = transform.position;
        attackPosition = (player.transform.position - startPosition);
        moveVector = new Vector3((attackPosition.x + 1.9f) / 25f, 0f, (attackPosition.z + 2.4f) / 25f);
    }
    override public void AttackAction()
    {
       
        if (EnemyHealth.value > 0f)
        {
            StartCoroutine(VillainAttack());
        }

    }

    IEnumerator VillainAttack()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetFloat("Speed", 1f);
        if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        gravityVector.y = verticalVelocity * Time.deltaTime;
        float timePassed = 0;
        while (timePassed < 0.5f)
        {
            controller.Move(moveVector);
            //controller.Move(gravityVector);
            transform.position = new Vector3(
                transform.position.x,
                Terrain.activeTerrain.SampleHeight(transform.position),
                transform.position.z);
            yield return new WaitForSeconds(0.5f / 40);
            timePassed += Time.deltaTime;
        }

        anim.SetFloat("Speed",0f);
        anim.Play("SwordAttack");
        yield return new WaitForSeconds(1.7f);

        this.transform.position = startPosition;
        menuItems.SetActive(true);
        endGame.DmgPlayer();

        //endGame.RunToBe();
    }
}
