using System;
using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
    public GameObject Panel;
    public GameObject Portal;

    private void Start()
    {
        Panel.SetActive (true);
        StartCoroutine(End());
    }

    public void StoryEnd () 
    {
        Panel.SetActive (false);
        Portal.SetActive (true);
    }
    
    IEnumerator End()
    {
        yield return new WaitForSeconds(76);
        StoryEnd();
    }
}
    
    
