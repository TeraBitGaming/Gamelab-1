using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagementScript : MonoBehaviour
{
    public Scene dungen;
    public int gold;
    public int wood;
    public int stone;
    public int iron;

    public GameObject goldSlider;
    public GameObject woodSlider;
    public GameObject stoneSlider;
    public GameObject ironSlider;

    public GameObject blacksmith;
    public GameObject house;
    public GameObject library;
    public GameObject inn;

    //Modify the amount of gold the village has.
    public void changeGold(int addition){
        gold = (int)Mathf.Clamp(gold += addition, 0, Mathf.Infinity);
    }

    //Modify the amount of wood the village has.
    public void changeWood(int addition){
        wood = (int)Mathf.Clamp(wood += addition, 0, Mathf.Infinity);
    }

    //Modify the amount of stone the village has.
    public void changeStone(int addition){
        stone = (int)Mathf.Clamp(stone += addition, 0, Mathf.Infinity);
    }

    //Modify the amount of iron the village has.
    public void changeIron(int addition){
        iron = (int)Mathf.Clamp(iron += addition, 0, Mathf.Infinity);
    }

    //Should be in its own seperate script, but for now exists within this script; 
    //basically hides everything that doesn't have the "screenName" tag as their tag.
    public void setScreen(string screenName){
        if (screenName == "none"){
            blacksmith.SetActive(false);
            house.SetActive(false);
            library.SetActive(false);
            inn.SetActive(false);
        } else if(screenName == "dungeon"){
            SceneManager.LoadScene("RandomGeneration");
        } else if (screenName != "none"){
            if(blacksmith.tag != screenName){
                blacksmith.SetActive(false);
            } else {
                blacksmith.SetActive(true);
            }

            if(house.tag != screenName){
            house.SetActive(false);
            } else {
                house.SetActive(true);
            }

            if(library.tag != screenName){
            library.SetActive(false);
            } else {
                library.SetActive(true);
            }

            if(inn.tag != screenName){
            inn.SetActive(false);
            } else {
                inn.SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldSlider.GetComponent<SliderManager>().setCurrentValue(gold);
        woodSlider.GetComponent<SliderManager>().setCurrentValue(wood);
        stoneSlider.GetComponent<SliderManager>().setCurrentValue(stone);
        ironSlider.GetComponent<SliderManager>().setCurrentValue(iron);
    }
}
