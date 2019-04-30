using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTester : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SwipeDetector.Instance.IsSwiping(Direction.left)){
            Debug.Log("left");
        }
        else if (SwipeDetector.Instance.IsSwiping(Direction.right)){
            Debug.Log("right");
        }
        else if (SwipeDetector.Instance.IsSwiping(Direction.up)){
            Debug.Log("up");
        }
        else if (SwipeDetector.Instance.IsSwiping(Direction.down)){
            Debug.Log("down");
        }
        else if (SwipeDetector.Instance.IsSwiping(Direction.none)){
            Debug.Log("none");
        }
        
    }
}
