using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToTutorial : MonoBehaviour
{
    public GameObject Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroCorountine());
    }

    IEnumerator IntroCorountine()
    {
        yield return new WaitForSeconds(25f);
        Tutorial.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
