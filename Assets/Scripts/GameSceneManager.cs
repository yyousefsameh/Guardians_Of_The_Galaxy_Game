using System.Collections;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadeLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }

    IEnumerator ReloadLevelRoutine(float timeToWait = 2f)
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);  
    }

}
