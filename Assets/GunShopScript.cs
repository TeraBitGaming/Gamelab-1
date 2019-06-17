using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShopScript : MonoBehaviour
{

    public bool wipe;
    public bool addMoni;

    private bool purchaseDone = false;

     [SerializeField]
    private Text textField;

     [SerializeField]
    private Image weaponImage;

    public Weapon usingWeapon;
    public Weapon stdWeapon;

    public void buyGun(Weapon gunToBuy){
        if(PlayerPrefs.GetInt("Money") > gunToBuy.purchaseCost){
            purchaseDone = false;
                
            if(gunToBuy.name == "Pistol"){
                if(PlayerPrefsX.GetBool("unlockedSinglePistol") == true){
                    usingWeapon = gunToBuy;
                    weaponImage.sprite = usingWeapon.image;
                    PlayerPrefs.SetInt("WeaponInt", 0);
                } else if (PlayerPrefsX.GetBool("unlockedSinglePistol") != true){
                    PlayerPrefsX.SetBool("unlockedSinglePistol", true);
                    purchaseDone = true;
                }
            }
            
            if(gunToBuy.name == "Dual-Pistol"){
                if(PlayerPrefsX.GetBool("unlockedDualPistol") == true){
                    usingWeapon = gunToBuy;
                    weaponImage.sprite = usingWeapon.image;
                    PlayerPrefs.SetInt("WeaponInt", 1);
                } else if (PlayerPrefsX.GetBool("unlockedDualPistol") != true){
                    PlayerPrefsX.SetBool("unlockedDualPistol", true);
                    purchaseDone = true;
                }
            }
            
            if(gunToBuy.name == "Revolver"){
                if(PlayerPrefsX.GetBool("unlockedRevolver") == true){
                    usingWeapon = gunToBuy;
                    weaponImage.sprite = usingWeapon.image;
                    PlayerPrefs.SetInt("WeaponInt", 2);
                } else if (PlayerPrefsX.GetBool("unlockedRevolver") != true){
                    PlayerPrefsX.SetBool("unlockedRevolver", true);
                    purchaseDone = true;
                }
            }
            
            if(gunToBuy.name == "Sniper"){
                if(PlayerPrefsX.GetBool("unlockedSniper") == true){
                    usingWeapon = gunToBuy;
                    weaponImage.sprite = usingWeapon.image;
                    PlayerPrefs.SetInt("WeaponInt", 3);
                } else if (PlayerPrefsX.GetBool("unlockedSniper") != true){
                    PlayerPrefsX.SetBool("unlockedSniper", true);
                    purchaseDone = true;
                }
            }
            
            if(gunToBuy.name == "Shotgun"){
                if(PlayerPrefsX.GetBool("unlcokedShotgun") == true){
                    usingWeapon = gunToBuy;
                    weaponImage.sprite = usingWeapon.image;
                    PlayerPrefs.SetInt("WeaponInt", 4);
                } else if (PlayerPrefsX.GetBool("unlcokedShotgun") != true){
                    PlayerPrefsX.SetBool("unlcokedShotgun", true);
                    purchaseDone = true;
                }
            }

            if(gunToBuy.name == "Minigun"){
                if(PlayerPrefsX.GetBool("unlockedMinigun") == true){
                    usingWeapon = gunToBuy;
                    weaponImage.sprite = usingWeapon.image;
                    PlayerPrefs.SetInt("WeaponInt", 5);
                } else if (PlayerPrefsX.GetBool("unlockedMinigun") != true){
                    PlayerPrefsX.SetBool("unlockedMinigun", true);
                    purchaseDone = true;
                }
            }

            if(purchaseDone == true){
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - gunToBuy.purchaseCost);
            }
        }   
    }


    // Start is called before the first frame update
    void Start()
    {
        if(wipe == true){
            PlayerPrefsX.SetBool("unlockedDualPistol", false);
            PlayerPrefsX.SetBool("unlockedRevolver", false);
            PlayerPrefsX.SetBool("unlockedSniper", false);
            PlayerPrefsX.SetBool("unlcokedShotgun", false);
            PlayerPrefsX.SetBool("unlockedMinigun", false);
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("WeaponInt", 0);
            usingWeapon = stdWeapon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        textField.text = PlayerPrefs.GetInt("Money").ToString();
        if(addMoni == true){
            PlayerPrefs.SetInt("Money", 10000);
        }
    }
}
