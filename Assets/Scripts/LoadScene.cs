using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadScene(){
        SceneManager.LoadScene(1);
    }

    public IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
