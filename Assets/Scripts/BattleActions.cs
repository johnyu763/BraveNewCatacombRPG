using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActions : MonoBehaviour
{
    public getDamage dmg;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private Vector3 startPosition;
    private Vector3 attackPosition;
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveVector;
    private Vector3 gravityVector;

    public EnemyBehaviour enemy;
    public Camera mainCamera;
    public Camera subCamera;
    public Camera healCamera;
    public GameObject menuItems;
    public GameObject attackItems;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
        startPosition = transform.position;
        attackPosition = (enemy.transform.position - startPosition);
        moveVector = new Vector3((attackPosition.x-offset.x)/25f, 0f,(attackPosition.z-offset.z)/25f);

    }

    public void UpdateValues()
    {
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
        startPosition = transform.position;
        attackPosition = (enemy.transform.position - startPosition);
        moveVector = new Vector3((attackPosition.x - 1.9f) / 25f, 0f, (attackPosition.z - 1.9f) / 25f);
    }

    public void SpinAttack()
    {
        menuItems.SetActive(false);
        attackItems.SetActive(false);
        StartCoroutine(SpinCoroutine());
    }

    public void DropAttack()
    {
        menuItems.SetActive(false);
        attackItems.SetActive(false);
        StartCoroutine(DropCoroutine());
    }
    public void SpecialAttack()
    {

        menuItems.SetActive(false);
        attackItems.SetActive(false);
        subCamera.enabled = true;
        mainCamera.enabled = false;
        StartCoroutine(SpecialCoroutine());
    }
    public void Heal()
    {
        menuItems.SetActive(false);
        attackItems.SetActive(false);
        healCamera.enabled = true;
        mainCamera.enabled = false;
        anim.SetTrigger("Heal");
        StartCoroutine(HealPlayer());
    }

    IEnumerator HealPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        dmg.HealPlayer();
        mainCamera.enabled = true;
        healCamera.enabled = false;
        enemy.AttackAction();

    }

    IEnumerator SpinCoroutine()
    {
        anim.SetBool("Run", true);
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
        while(timePassed < 0.5f) {
            controller.Move(moveVector);
            //controller.Move(gravityVector);
            transform.position = new Vector3(
                transform.position.x, 
                Terrain.activeTerrain.SampleHeight(transform.position), 
                transform.position.z);
            yield return new WaitForSeconds(0.5f / 40);
            timePassed += Time.deltaTime;
        }

        anim.SetBool("Run", false);
        anim.SetTrigger("Spinkick");

        yield return new WaitForSeconds(1f);

        this.transform.position = startPosition;
        dmg.DmgEnemy(1f);
        enemy.AttackAction();

    }

    IEnumerator DropCoroutine()
    {
        anim.SetBool("Run", true);
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

        anim.SetBool("Run", false);
        anim.SetTrigger("Dropkick");


        yield return new WaitForSeconds(1f);

        this.transform.position = startPosition;
        dmg.DmgEnemy(1f);
        enemy.AttackAction();

    }

    IEnumerator SpecialCoroutine()
    {
        anim.SetTrigger("Special");
        yield return new WaitForSeconds(1f);
        mainCamera.enabled = true;
        subCamera.enabled = false;
        dmg.DmgEnemy(5f);
        enemy.AttackAction();
    }
}
