/*
name: CarveTheUnidentifiedGemStone[Member]
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class CarveTheUnidentifiedGemStone
{

    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreNation Nation
{
    get => _Nation ??= new CoreNation();
    set => _Nation = value;
}
public CoreNation _Nation;



    public string OptionsStorage = "CarveTheUnidentifiedGemStone";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        CoreBots.Instance.SkipOptions,
        new Option<ChooseReward>("ChooseReward", "Choose Your Reward", "Pick A Reward", ChooseReward.All),
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoCarveTheUnidentifiedGemStone();

        Core.SetOptions(false);
    }

    public void DoCarveTheUnidentifiedGemStone()
    {
        ChooseReward reward = Bot.Config?.Get<ChooseReward>("ChooseReward") ?? default;
        if (reward == ChooseReward.All)
            Nation.CarveUniGemStone();
        else
            Nation.CarveUniGemStone(reward.ToString());
    }

    private enum ChooseReward
    {
        Dark_Crystal_Shard,
        Diamond_of_Nulgath,
        Gem_of_Nulgath,
        Blood_Gem_of_the_Archfiend,
        All,
    }
}
