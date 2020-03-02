using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Stats : MonoBehaviour
{
    // Class used to denote character stats in the game.
    [SerializeField]
    float HP, Atk, Def, Int, Drg, Spd; // vars representing Stats
    [SerializeField]
    TMP_Text UIdisp; // textBox that shows UI
    [SerializeField]
    
    
    private float[] all_stats; // array unsed to hold stats
    private string[] stat_names; // array used to hold stat names

    static int counter;

    public void Start()
    {
        // initializes stat arrays
        all_stats = new float[]{HP, Atk, Def, Int, Drg, Spd};
        stat_names = new string[] {"HP", "Atk", "Def", "Int", "Drg", "Spd"};
        counter++;
        // initializes UI Objects
        if(UIdisp)
        {
            UIdisp.text = "Stats" + "\n";
            for(int i = 0; i < all_stats.Length; i++)
            {
                float temp = PlayerPrefs.GetFloat (stat_names[i]);
                PlayerPrefs.SetFloat (stat_names[i] + counter, all_stats[i]);
                UIdisp.text += stat_names[i] + ": " + all_stats[i].ToString() + "\n";
                temp = PlayerPrefs.GetFloat (stat_names[i] + counter);
                Debug.Log(temp + " " + stat_names[i] + counter);
            }
        }
    }

    public float getHP()
    {
        return HP;
    }

    public float getAtk()
    {
        return Atk;
    }

    public float getDrg()
    {
        return Drg;
    }
    public void setStats(float[] new_stats)
    {
        HP = new_stats[0];
        Atk = new_stats[1];
        Def = new_stats[2];
        Int = new_stats[3];
        Drg = new_stats[4];
        Spd = new_stats[5];
    }
    // code used to make stats global
    
    /*public static Stats instance {
        get => _instance;
    }
    private static Stats _instance;
    public static void Init() {
        if (_instance == null) SceneManager.LoadScene("UISceneName", LoadSceneMode.Additive);
    }

    void Awake() {
        Init();
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }*/ 

}
