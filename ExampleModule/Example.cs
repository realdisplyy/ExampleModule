using BepInEx.Configuration;
using Displyy.Utils;
using System;
using UnityEngine.EventSystems;
public class ExternalModule : BaseModule
{
    public override bool Enabled { get; set; } = false;
    public override string Category { get; set; } = "External";
    public override string DisplayName { get; set; } = "External Module";

    public override string GetTooltip()
    {
        return "This is an external module.";
    }
    private void OnEnable()
    {
        Console.WriteLine("External OnEnable");
    }
    private void Update()
    {
        Console.WriteLine("External Update");
    }
    private void OnDisable()
    {
        Console.WriteLine("External OnDisable");
    }

    /*Config stuff
     * example: 
    */
    //private static float howfast;
    public override void ReloadConfiguration()
    {
        //if user changes the config, this will run. for example:
        //howfast = CEhowfast.Value * 1.5f;
    }
/*    private static ConfigEntry<float> CEhowfast;
    private static ConfigEntry<int> CEbuttonToDo;
*/
    public static void BindConfigEntries(string DisplayName)
    {
/*        SettingsHelper settingsHelper = new SettingsHelper();
        CEhowfast = settingsHelper.GetConfigFile().Bind<float>(
        section: DisplayName,
           key: "Speed",
           defaultValue: 15f,
           new ConfigDescription(
           "How fast you fly",
           new AcceptableValueRange<float>(1f, 50f)
        ));
        // What button to make the bool shouldRun true.
        CEbuttonToDo = settingsHelper.GetConfigFile().Bind(
        section: DisplayName,
        key: "Controller button", // has to be named Controller Button
            defaultValue: (int)EasyInput.ControllerButton.bButton,
            description: "What button to fly"
        );*/
    }

}