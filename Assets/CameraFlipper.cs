using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlipper : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FlipCamera()
    {
        subCamera.transform.rotation = mainCamera.transform.rotation;
        subCamera.transform.position = mainCamera.transform.position;
        subCamera.enabled = true;
        mainCamera.enabled = false;
        StartCoroutine(SubFlip());
    }

    IEnumerator SubFlip()
    {
        float timePassed = 0f;
        do
        {
            subCamera.transform.Rotate(0f, 0f, 9f);
            yield return new WaitForSeconds(1f / 360f);
            timePassed += Time.deltaTime;
        } while (timePassed < 1.49f);
        subCamera.transform.rotation = mainCamera.transform.rotation;
        subCamera.transform.position = mainCamera.transform.position;
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }
}
