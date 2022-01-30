using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndStage : MonoBehaviour
{
    public GameObject Text;
    public GameObject Portal;
    void Update()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        if (monsters.Length == 0)
        {
            Text.SetActive(true);
            Portal.SetActive(true);
        }
    }
}
