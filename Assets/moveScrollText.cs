using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScrollText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currPos = this.transform.position;
        Debug.Log(Vector3.Angle(currPos, transform.forward));
        //this.transform.position = new Vector3(currPos.x, currPos.y+0.005f, currPos.z-0.06f);
    }

}
