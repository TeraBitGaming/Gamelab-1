using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction 
{
    none = 0,
    left = 1,
    right = 2,
    up = 4,
    down = 8,

    upLeft = 5,
    upRight = 6,
    downLeft = 9,
    downRight = 10,
}

public class SwipeDetector : MonoBehaviour
{
    private static SwipeDetector instance;
    public static SwipeDetector Instance{get {return instance;}}
    

    public Direction Direction{set;get;}

    private Vector3 touchPos;
    private float vertSwipeResist = 25.0f;
    private float horSwipeResist = 15.0f;

    void Start(){
        instance = this;
    }

    void FixedUpdate()
    {
        Direction = Direction.none;

        if (Input.GetMouseButtonDown (0)){
            touchPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp (0)){
            Vector2 deltaSwipe = touchPos - Input.mousePosition;

            if (Mathf.Abs (deltaSwipe.x) > vertSwipeResist){
                Direction |= (deltaSwipe.x < 0) ? Direction.right : Direction.left;
            }

            if (Mathf.Abs (deltaSwipe.y) > horSwipeResist){
                Direction |= (deltaSwipe.y < 0) ? Direction.up : Direction.down;
            }
        }
    }

    public bool IsSwiping(Direction dir) {
        return (dir == Direction);
    }
}
