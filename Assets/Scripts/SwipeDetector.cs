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

    stop = 50,
}

public class SwipeDetector : MonoBehaviour
{
    private static SwipeDetector instance;
    public static SwipeDetector Instance{get {return instance;}}
    

    public Direction Direction{set;get;}

    private Vector3 touchPos;
    private float vertSwipeResist = .3f;
    private float horSwipeResist = .2f;

    private Camera cam;

    void Start(){
        instance = this;
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        Direction = Direction.none;

        if (Input.GetMouseButtonDown (0)){
            touchPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp (0)){
            Vector2 deltaSwipe = touchPos - cam.ScreenToViewportPoint(Input.mousePosition);

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
