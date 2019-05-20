using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    private Vector2 dir;
    private PlayerCharacter pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerCharacter>();
    }

         private void FixedUpdate()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            //dir = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pc.gameObject.transform.position;
            FindObjectOfType<PlayerCharacter>().Attack(dir);
            //print(dir);
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                dir = Camera.main.ScreenToWorldPoint(touch.position) - pc.gameObject.transform.position;
                FindObjectOfType<PlayerCharacter>().Attack(dir);
                //print(dir);
            }
        }
#endif
    }

}
