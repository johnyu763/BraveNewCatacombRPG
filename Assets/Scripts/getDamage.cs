using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getDamage : MonoBehaviour
{
    [SerializeField]
    Stats PlayerStats, EnemyStats;
    public GameObject mainScreen;
    public Slider PlayerHealth;
    public Slider EnemyHealth;
    public GameObject battle;
    public GameObject LoadingScreen;
    public Slider progressSlider;
    public Text progressText;
    public Button SpecialAttack;
    public bool canSpecial;
    // Start is called before the first frame update
    void Start()
    {
        float HP = PlayerPrefs.GetFloat("HP1");
        float Atk = PlayerPrefs.GetFloat("Atk1");
        float Def = PlayerPrefs.GetFloat("Def1");
        float Int = PlayerPrefs.GetFloat("Int1");
        float Drg = PlayerPrefs.GetFloat("Drg1");
        float Spd = PlayerPrefs.GetFloat("Spd1");
        float EXP = PlayerPrefs.GetFloat("EXP1");
        float [] all_stats = new float[]{HP, Atk, Def, Int, Drg, Spd, EXP};
        PlayerStats.setStats(all_stats);
        PlayerHealth.maxValue = PlayerStats.getHP();
        PlayerHealth.value = PlayerHealth.maxValue;
        EnemyHealth.maxValue = EnemyStats.getHP();
        EnemyHealth.value = EnemyHealth.maxValue;
    }

    public float GetPlayerHealth()
    {
        return PlayerHealth.value;
    }

    public void RunProcess()
    {
        StartCoroutine(LoadAsynchronously());
    }
    public void RunToBe()
    {
        StartCoroutine(ToBeCont());
    }

    public void DmgEnemy(float mult)
    {
        Debug.Log("Enemy Health: "+EnemyHealth.value);
        Debug.Log("Max Enemy Health: "+EnemyHealth.maxValue);
        var damage = Random.Range(0.2f, 0.35f) * mult * PlayerStats.getAtk();
        if (EnemyHealth.value - damage > 0f) {
            EnemyHealth.value -= damage;
        }
        else if(EnemyHealth.value - damage <= 0f)
        {
            StartCoroutine(WinRoutine());
        }

    }
    public void DmgPlayer(float mult=1f)
    {
        Debug.Log("Player Health: "+PlayerHealth.value);
        Debug.Log("Max Player Health: "+PlayerHealth.maxValue);
        var damage = Random.Range(0.2f, 0.35f)*EnemyStats.getAtk();
        if (PlayerHealth.value-damage > 0f)
        {
            PlayerHealth.value -= damage*mult;
        }
        else if(PlayerHealth.value - damage <= 0f)
        {
            PlayerHealth.value = 0f;
        }

        if(canSpecial && PlayerHealth.value <= 0.35f)
        {
            SpecialAttack.interactable = true;
            SpecialAttack.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Special";
        }
        else
        {
            SpecialAttack.interactable = false;
            SpecialAttack.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "???";
        }


    }

    public void HealPlayer()
    {
        if ((PlayerHealth.value + 0.25f*PlayerStats.getDrg()) > PlayerHealth.maxValue)
        {
            PlayerHealth.value = PlayerHealth.value;
        }
        else
        {
            PlayerHealth.value += 0.25f*PlayerStats.getDrg();
        }
    }

    private IEnumerator SubDmgEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        EnemyHealth.value -= Random.Range(0f, 0.25f); ;
    }
    private IEnumerator SubDmgPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerHealth.value -= Random.Range(0f, 0.25f);
    }
    private IEnumerator SubHealPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        if (PlayerHealth.value > 0.75f)
        {
            PlayerHealth.value = 1f;
        }
        else
        {
            PlayerHealth.value += 0.25f;
        }
    }
    private IEnumerator WinRoutine()
    {
        EnemyHealth.value = 0f;
        yield return new WaitForSeconds(1.5f);
        PlayerStats.addEXP(EnemyStats.getHP());
        EnemyHealth.value = EnemyHealth.maxValue;
        PlayerHealth.value = PlayerHealth.maxValue;
        battle.SetActive(false);
        mainScreen.SetActive(true);
    }
    private IEnumerator ToBeCont()
    {
        EnemyHealth.value = 0f;
        yield return new WaitForSeconds(1f);
        battle.SetActive(false);
        LoadingScreen.SetActive(true);
    }
    public IEnumerator LoadAsynchronously()
    {
        battle.SetActive(false);
        LoadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level 1", LoadSceneMode.Single);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            progressSlider.value = progress;
            progressText.text = (progress * 100f).ToString("n2") + "%";
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
