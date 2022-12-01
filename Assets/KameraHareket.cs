using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0f, 10f, -12f);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
