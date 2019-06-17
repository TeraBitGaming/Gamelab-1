// using UnityEngine;
// using UnityEngine.UI;

// public class UIScript : using UnityEngine{

// public static UIScript Instance  { get; private set; }

//     void Start() {
//         Instance = this;
//     }

//     [SerializeField]
//     private Text pointsTxt;

//     public void GetPoint()
//     {
//         ManagerScript.Instance.IncrementCounter();
//     }

//     public void Restart()
//     {
//         ManagerScript.Instance.RestartGame();    
//     }

//     public void Increment()
//     {
//         PlayGameScript.IncrementAchievement(GPGSIds.achievement_incremental-achievement, 5);
//     }

//     public void Unlock()
//     {
//         PlayGameScript.UnlockAchievement(GPGSIds.achievement_standard_achievement);
//     }

//     public void ShowAchievements()
//     {
//         PlayGameScript.ShowAchievementsUI();
//     }

//     public void ShowLeaderboards()
//     {
//         PlayGameScript.ShowLeaderboardsUI();
//     }

//     public void UpdatePointsText()
//     {
//         pointsTxt.text = ManagerScript.Counter.ToString();
//     }
// }