using BepInEx.Configuration;
using Displyy.Utils;
using System;
using UnityEngine.EventSystems;
public class ExternalModule : BaseModule
{
    #region Variables
    public override bool Enabled { get; set; } = false;
    public override string Category { get; set; } = "External";
    public override string DisplayName { get; set; } = "External Module";

    public override string GetTooltip()
    {
        return "This is an external module.";
    }
    #endregion
    private void OnEnable()
    {

    }
    private void Update()
    {

    }
    private void OnDisable()
    {

    }

    #region Configuration
    public override void ReloadConfiguration()
    {
       
    }
    public static void BindConfigEntries(string DisplayName)
    {

    }
    #endregion
}