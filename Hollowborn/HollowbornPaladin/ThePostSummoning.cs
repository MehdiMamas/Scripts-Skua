/*
name: HBP - The Post Summoning
description: does the 'the post summoning' part of hollowborn Paladin
tags: hollowborn paladin, hollowborn, the post summoning, hollowborn paladin character page badge
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Hollowborn/CoreHollowborn.cs
//cs_include Scripts/Hollowborn/HollowbornPaladin/CoreHollowbornPaladin.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Chaos/DrakathsArmor.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Chaos/AscendedDrakathGear.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/TowerOfDoom.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Story/Artixpointe.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class ThePostSummoning
{
    public IScriptInterface Bot => IScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
public CoreHollowborn HB
{
    get => _HB ??= new CoreHollowborn();
    set => _HB = value;
}
public CoreHollowborn _HB;

public CoreHollowbornPaladin HBPal
{
    get => _HBPal ??= new CoreHollowbornPaladin();
    set => _HBPal = value;
}
public CoreHollowbornPaladin _HBPal;

public CoreFarms Farm
{
    get => _Farm ??= new CoreFarms();
    set => _Farm = value;
}
public CoreFarms _Farm;

public CoreStory Story
{
    get => _Story ??= new CoreStory();
    set => _Story = value;
}
public CoreStory _Story;


    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        HBPal.GetAll();

        Core.SetOptions(false);
    }
}
