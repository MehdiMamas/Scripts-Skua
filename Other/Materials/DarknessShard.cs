/*
name: DarknessShard
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
using Skua.Core.Interfaces;

public class DarknessShard
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreDailies Dailies
{
    get => _Dailies ??= new CoreDailies();
    set => _Dailies = value;
}
public CoreDailies _Dailies;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetShard();

        Core.SetOptions(false);
    }

    public void GetShard(int quant = 3)
    {
        if (Core.CheckInventory("Darkness Shard", quant))
            return;

        if (!Core.CheckInventory("Crypto Token", 3))
            Dailies.CryptoToken();
        Core.BuyItem("curio", 1539, "Darkness Shard", 3);
    }
}
