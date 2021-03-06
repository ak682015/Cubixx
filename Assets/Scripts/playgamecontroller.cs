﻿using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;

public class playgamecontroller : MonoBehaviour
{
    public static playgamecontroller instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }
    void Start()
    {
        Authenticate();
    }

    void Authenticate()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("success");
            }
        });
    }
    public static void posttoleaderboard(int score)
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            Social.ReportScore(score, GPGSIds.leaderboard_leaderboard, (bool success) =>
            {

            });
        }
    }

    public void showleaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }

}