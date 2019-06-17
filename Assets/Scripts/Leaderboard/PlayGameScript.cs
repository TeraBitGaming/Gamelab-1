// using GooglePlayGames;
// using GooglePlayGames.BasicApi;
// using UnityEngine;

// public class PlayGamesScript : MonoBehaviour {

//     //Use this for initialization
//     void Start () 
//     {
//         PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
//         PlayGamePlatform.InitializeInstance(config);
//         PlayGamePlatform.Activate();

//         SignIn();
//     }

//     void SignIn() 
//     {
//         Social.localUser.Authenticate(success => { });
//     }

//     #region Achievements
//     public static void UnlockAchievement(string id)
//     {
//         Social.ReportProgress(id, 100, success => { });
//     }
    
//     public static void IncrementAchievement(string id, int stepsToIncrement)
//     {
//         PlayGamePlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
//     }

//     public static void ShowAchievementsUI()
//     {
//         Social.ShowAchievementsUI();
//     }
//     #endregion /Achievements


//     #region Leaderboards
   
//    public static void ShowLeaderboardsUI()
//     {
//         Social.ShowLeaderboardUI();
//     }

//     public static void 
//     #endregion /Leaderboards


// }