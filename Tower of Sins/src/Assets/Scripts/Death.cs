using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject Bar;
    public GameObject Panel;

    public void Die()
    {
        Time.timeScale = 0;
        Bar.SetActive(false);
        Panel.SetActive(true);
    }

    public void End()
    {
        SceneManager.LoadScene("Menu");
    }
}
