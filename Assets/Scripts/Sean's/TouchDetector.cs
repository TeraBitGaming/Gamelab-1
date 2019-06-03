using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    private Vector2 dir;
    private PlayerCharacter pc;

    [SerializeField]
    private GameObject tutorial;

    private void Start()
    {
        pc = FindObjectOfType<PlayerCharacter>();
    }

    private bool showTutorial = true;

    private void fadeTutorialOut()
    {
        if(showTutorial == true)
        {
            showTutorial = false;
            tutorial.GetComponent<Animator>().SetTrigger("fadeOutTutorial");
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (FindObjectOfType<PlayerCharacter>())
            {
                fadeTutorialOut();
                //dir = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);
                dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pc.gameObject.transform.position;
                FindObjectOfType<PlayerCharacter>().Attack(dir);
                //print(dir);
            }
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if(FindObjectOfType<PlayerCharacter>())
                {
                    fadeTutorialOut();
                    dir = Camera.main.ScreenToWorldPoint(touch.position) - pc.gameObject.transform.position;
                    // - new Vector2(Screen.width / 2, Screen.height / 2)
                    FindObjectOfType<PlayerCharacter>().Attack(dir);
                    //print(dir);
                }
            }
        }
#endif
    }

}
