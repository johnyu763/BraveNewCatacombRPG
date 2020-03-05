using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBattle : MonoBehaviour
{
    public BattleActions Player;
    public MobScript Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateValues()
    {
        Player.UpdateValues();
        Enemy.UpdateValues();
    }
}
