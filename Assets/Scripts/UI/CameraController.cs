using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject focus;


    void Update()
    {
        Vector3 offset = new Vector3(0, 0, -1);
        this.transform.position = focus.transform.position + offset;
    }


}
