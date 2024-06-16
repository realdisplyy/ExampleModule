# External Module for Displyy Mod Menu

This README explains how to create and configure an external module for the Displyy Mod Menu in Gorilla Tag.

## Overview

This allows you to add new modules/features/mods to Displyy Mod Menu for Gorilla Tag.

### Key Components

1. **Enabled**: Boolean to set if the module is active. If `true`, the module will be enabled on startup.
2. **Category**: Specifies the category the module belongs to.
3. **DisplayName**: The name of the module.
4. **Tooltip**: Provides a short description or help text for the module.

### Unity MonoBehaviour Methods

- **OnEnable**: Called when the module is enabled.
- **Update**: Called every frame.
- **FixedUpdate** Called at fixed time intervals, typically 50 times per second by default, but this can be configured.
- **OnDisable**: Called when the module is disabled.
You can also use other Unity functions typically available in a MonoBehaviour class.

### Configuration

- **ReloadConfiguration**: This method is called whenever the user changes settings in the modules configuration tab.
- **BindConfigEntries**: Binds configuration settings such as speed or controller button actions. This gets called automatically to bind the configuration settings to the config file.

## Code Example + Explanation

```csharp
using BepInEx.Configuration;
using Displyy.Utils;
using System;
using UnityEngine.EventSystems;

public class ExternalModule : BaseModule
{
    public ExternalModule()
    {
        this.modIsFor = ModIsFor.Both; // If set to menu it will only show up in the menu and not in the GUI. 
        this.aliases.Add("Example"); // When user searches for module it will also show up
    }
    public override bool Enabled { get; set; } = false;
    public override string Category { get; set; } = "External";
    public override string DisplayName { get; set; } = "External Module";

    public override string GetTooltip()
    {
        return "This is an external module.";
    }

    private void OnEnable()
    {
        // Gets called once when module gets enabled.
    }

    private void Update()
    {
        // Gets called every frame once enabled.

        // For example a fly method with controller button functionality:
        // if (shouldRun) //shouldRun gets set to true when in this example the 'B' button is pressed. (Or if the user has changed the default configuration then it could be any controller button)
        // {
        //    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * fast * Time.deltaTime;
        //    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // }
    }

    private void OnDisable()
    {
        // Gets called once when module gets disabled.
    }

    // Configuration settings
    // Example usage is provided below

    // This variable controls the speed of for say how fast you fly.
    // private static float howfast;

    public override void ReloadConfiguration()
    {
        // This method runs when the user changes the configuration
        // Example usage:
        // howfast = CEhowfast.Value * 1.5f;

        // For the controller button example to work so that the shouldRun bool gets set to true when the controller button is pressed:
        //  controllerButtonToRun = CEbuttonToDo.Value;
    }

    // Configuration entries for settings
    // private static ConfigEntry<float> CEhowfast;
    // private static ConfigEntry<int> CEbuttonToDo;

    public static void BindConfigEntries(string DisplayName)
    {
        // SettingsHelper helps manage configuration settings
        // SettingsHelper settingsHelper = new SettingsHelper();

        // Bind the 'Speed' setting
        // CEhowfast = settingsHelper.GetConfigFile().Bind<float>(
        //     section: DisplayName,
        //     key: "Speed",
        //     defaultValue: 15f,
        //     new ConfigDescription(
        //         "How fast you fly",
        //         new AcceptableValueRange<float>(1f, 50f)
        //     )
        // );

        // Bind the 'Controller button' setting for making it so when that controller button gets pressed the 'shouldRun' variable gets set to true. Here when the 'B' button on the controller gets pressed the variable 'shouldRun' gets set to true.
        // CEbuttonToDo = settingsHelper.GetConfigFile().Bind(
        //     section: DisplayName,
        //     key: "Controller button", // The name must be "Controller Button"
        //     defaultValue: (int)EasyInput.ControllerButton.bButton,
        //     description: "Which button to press to fly"
        // );
    }
}
```

### More 
```csharp
    public ExternalModule()
    {
        this.enumManagerBase.InitializeEnum<ExampleEnum>("example enum"); // has to contain the word 'enum' for it to work.
    }

    public enum ExampleEnum
    {
        Option1,
        Option2,
        Option3
    }

    private static ConfigEntry<int> CEExampleEnum;
     public static void BindConfigEntries(string DisplayName)
     {
         CEExampleEnum = SettingsManager.configFile.Bind<int>(
             section: DisplayName,
             key: "Box type enum", // Has to contain the word 'enum' for it to work
             defaultValue: (int)ExampleEnum.Option1,
             description: "Example options"
         );
    }

    private void Update()
    {
        // Executed every frame once enabled.

        // Example 1: Using switch statement
        switch (CEExampleEnum.Value)
        {
            case (int)ExampleEnum.Option1:
                // Option 1 code
                break;
            case (int)ExampleEnum.Option2:
                // Option 2 code
                break;
            case (int)ExampleEnum.Option3:
                // Option 3 code
                break;
        }

        // Example 2: Using if statement
        if (CEExampleEnum.Value == (int)ExampleEnum.Option1)
        {
            // Option 1 code
        }
    }
```

### Explanation

- **OnEnable**: This method runs when the module gets enabled. It can contain any code you need to execute at that moment.
- **Update**: This method runs every frame. You can check for certain conditions, like if a button is pressed.
- **OnDisable**: This method runs when the module gets disabled.
- **ReloadConfiguration**: This method is called when the user changes the settings. It updates variables based on the new settings.
- **BindConfigEntries**: This method binds configuration entries. It uses `SettingsHelper` to create settings for things like speed and controller buttons.

## Installation

1. Build your module into a `.dll` file.
2. Place the `.dll` file in the following path: `Gorilla Tag/Displyy/Modules`.

This is how you can create and configure your own external modules for the Displyy Mod Menu in Gorilla Tag.

## Instructions for developers
Once your module is working, please send your code to displyy (displyy4) on Discord. I will add it to the mod menu. Just send the .cs file(s).
