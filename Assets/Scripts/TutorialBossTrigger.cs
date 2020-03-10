using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBossTrigger : MonoBehaviour
{
    public GameObject MainLevel;
    public InitBattle Battle;
    public Moving player;
    private Vector3 movePlace;
    private Animator anim;
    public float speed;
    public float desireDist = 0;
    private float dist;
    public float range = 1;
    public DialogueManager dialogue;
    private bool played = false;
    public CameraFlipper cam;
    public KingScript king;

    public float DesireDist { get => desireDist; set => desireDist = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
    }

    private void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if (dist <= desireDist)
        {
            anim.SetFloat("Speed", 0f);

        }
        else if (!played && dist <= range && dist > desireDist) {
            anim.SetFloat("Speed", 1f);
            king.canMove = true;
            this.transform.LookAt(player.transform);

            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
        }

        if (dist <= desireDist && !played)
        {
            player.StopMovement();
            dialogue.nextDialogue();
            played = true;
        }
        this.transform.position = new Vector3(
            this.transform.position.x,
            Terrain.activeTerrain.SampleHeight(transform.position),
            this.transform.position.z
            );

    }

    public void StartBattle()
    {
        StartCoroutine(VillainAttack());
    }

    IEnumerator VillainAttack()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        cam.FlipCamera();
        yield return new WaitForSeconds(2f);

        Battle.transform.position = new Vector3(
           player.transform.position.x,
           Terrain.activeTerrain.SampleHeight(transform.position) + 12f,
           player.transform.position.z
           );
        MainLevel.SetActive(false);
        Battle.gameObject.SetActive(true);
        Battle.UpdateValues();
    }

}
