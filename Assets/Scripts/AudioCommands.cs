using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioCommands : MonoBehaviour
{ 
    public GameObject cameraTarget;   //SpherePointer
    private bool goStraight = false;
    private bool fiveFeetLeft = false;

    // Update is called once per frame
    void Update()
    {
        if(cameraTarget.transform.position.z >= 8.2f && cameraTarget.transform.position.z <= 8.3f)
        {
            if (!goStraight)
            {
                FindObjectOfType<AudioManager>().Play("GoStraight");
                goStraight = true;
            }
        }

        if (cameraTarget.transform.position.z >= 9.2f && cameraTarget.transform.position.z <= 9.3f)
        {
            if (!fiveFeetLeft)
            {
                FindObjectOfType<AudioManager>().Play("FiveFeetLeft");
                fiveFeetLeft = true;
            }
        }
    }
}
