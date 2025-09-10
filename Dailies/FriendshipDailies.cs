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
private CoreDailies Daily
{
    get => _Daily ??= new CoreDailies();
    set => _Daily = value;
}
private CoreDailies _Daily;

private Friendship FR
{
    get => _FR ??= new Friendship();
    set => _FR = value;
}
private Friendship _FR;


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
