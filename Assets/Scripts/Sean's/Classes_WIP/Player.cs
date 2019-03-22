using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Please attach this script AND charamove.cs to the player sprite(WIP).
    /// </summary>
    private PlayerClass playerClass;
    private CharacterMovement movement;

    private void Awake()
    {
        playerClass = null;

    }
}
