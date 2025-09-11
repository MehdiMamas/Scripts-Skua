/*
name: Friendship Dailies
description: This bot does all the friendship based dailies in battleodium and greyguard
tags: daily, dailies, friendship, battleodium, greyguard
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Friendship.cs
using Skua.Core.Interfaces;

public class FriendshipDailies
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private static CoreDailies Daily { get => _Daily ??= new CoreDailies(); set => _Daily = value; }
    private static CoreDailies _Daily;
    private static Friendship FR { get => _FR ??= new Friendship(); set => _FR = value; }
    private static Friendship _FR;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(Daily.frGiftNames.Concat(Daily.frRewards));
        Core.SetOptions();

        doFriendShipDailies();
    }

    public void doFriendShipDailies()
    {
        FR.CompleteStory();
        Daily.Friendships();
    }
}
