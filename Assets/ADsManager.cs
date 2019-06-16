using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class ADsManager : MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-4277426308340439~9222591273";
#else
        string appId = "unexpected_platform";
#endif
        MobileAds.Initialize(appId);

        RequestAd();
    }

    private void RequestAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4277426308340439/6019334122";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed(object sender, EventArgs e)
    {
        Time.timeScale = 1;
        interstitial.Destroy();
    }

    public void HandleOnAdOpened(object sender, EventArgs e)
    {
        Time.timeScale = 0;
    }

    public void ShowAd()
    {
        if(this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
