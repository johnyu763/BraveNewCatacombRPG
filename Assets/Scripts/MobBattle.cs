using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MobBattle : MonoBehaviour
{
    public Slider PlayHealth;
    public Slider EnemyHealth;
    public GameObject LevelOne;
    public InitBattle Battle;
    public GameObject menuItems;
    public GameObject attackItems;
    public Moving player;
    public CameraFlipper cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cam.FlipCamera();
        StartCoroutine(BattleStartRoutine());
    }

    IEnumerator BattleStartRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        LevelOne.SetActive(false);
        this.gameObject.SetActive(false);
        Battle.gameObject.SetActive(true);
        Battle.transform.position = new Vector3(
           player.transform.position.x,
           Terrain.activeTerrain.SampleHeight(transform.position) + 12f,
           player.transform.position.z
           );
        Battle.UpdateValues();
        PlayHealth.value = 1f;
        EnemyHealth.value = 1f;
        attackItems.SetActive(false);
        menuItems.SetActive(true);
    }

}
