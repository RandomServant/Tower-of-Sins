using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTheGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Menu");
    }
}
