using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    private int combo = 0;

    [SerializeField]
    private Sprite[] numbers;

    int FirstPosition;
    int SecondPosition;
    int ThirdPosition;

    [SerializeField]
    SpriteRenderer Sprite1;

    [SerializeField]
    SpriteRenderer Sprite2;

    [SerializeField]
    SpriteRenderer Sprite3;

    public void AddToCombo(){
        combo += 1;
        CalculateComboNumbers(combo);
    }

    public void ResetCombo(){
        combo = 0;
        CalculateComboNumbers(combo);
    }

    private void CalculateComboNumbers(int combo){
    FirstPosition = 0;
    SecondPosition = 0;
    ThirdPosition = 0;
        for(int a = 0; a < combo; a++){
            FirstPosition += 1;

            if (FirstPosition >= 10){
                FirstPosition = 0;
                SecondPosition += 1;
            
                if (SecondPosition >= 10){
                    SecondPosition = 0;
                    ThirdPosition += 1;
                }
            }
        }
        Sprite1.sprite = numbers[FirstPosition];
        Sprite2.sprite = numbers[SecondPosition];
        Sprite3.sprite = numbers[ThirdPosition];
    }
}
