using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainBattle : MonoBehaviour
{
    public getDamage loserLoad;
    private Animator anim;
    public GameObject menuItems;
    public GameObject attackItems;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AttackAction()
    {
        menuItems.SetActive(false);
        attackItems.SetActive(false);
        StartCoroutine(VillainAttack());
        menuItems.SetActive(true);

    }

    IEnumerator VillainAttack()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(2f);
        loserLoad.DmgPlayer();
    }
}
