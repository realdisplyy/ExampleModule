# External Module for Displyy Mod Menu

This guide explains how to create and set up an external module for the Displyy Mod Menu in Gorilla Tag.

## Overview

You can use this to add new features or mods to the Displyy Mod Menu for Gorilla Tag.

### Key Components

1. **Enabled**: Boolean to set if the module is active. If `true`, the module will be enabled on startup.
2. **Category**: Specifies the category the module belongs to.
3. **DisplayName**: The name of the module.
4. **Tooltip**: Provides a short description or help text for the module.

### Unity MonoBehaviour Methods

- **OnEnable**: Called when the module is enabled.
- **Update**: Called every frame.
- **FixedUpdate**: Called at fixed time intervals, usually 50 times per second, but this can be changed.
- **OnDisable**: Called when the module is disabled.
- You can also use other Unity functions typically available in a MonoBehaviour class.

### Configuration

- **ReloadConfiguration**: Called when the user changes settings in the module's configuration tab.
- **BindConfigEntries**: Binds configuration settings like speed or controller button actions. This gets called automatically to link the configuration settings to the config file.

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
        this.aliases.Add("Example"); // When the user searches for the module, it will also show up.
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
        // Called once when the module gets enabled.
    }

    private void Update()
    {
        // Called every frame once enabled.

        // Example: Fly method with controller button functionality
        // if (shouldRun) // shouldRun gets set to true when, for example, the 'B' button is pressed.
        // {
        //     GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * howfast * Time.deltaTime;
        //     GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // }
    }

    private void OnDisable()
    {
        // Called once when the module gets disabled.
    }

    // Configuration settings
    // Example usage below

    // This variable controls the speed, e.g., how fast you fly.
    // private static float howfast;

    public override void ReloadConfiguration()
    {
        // Called when the user changes the configuration
        // Example usage:
        // howfast = CEhowfast.Value * 1.5f;

        // For the controller button example to work so that the shouldRun bool gets set to true when the controller button is pressed:
        // controllerButtonToRun = CEbuttonToDo.Value;
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

        // Bind the 'Controller button' setting for making it so when that controller button gets pressed the 'shouldRun' variable gets set to true.
        // CEbuttonToDo = settingsHelper.GetConfigFile().Bind(
        //     section: DisplayName,
        //     key: "Controller button", // The name must be "Controller Button"
        //     defaultValue: (int)EasyInput.ControllerButton.bButton,
        //     description: "Which button to press to fly"
        // );
    }
}
```

### More Examples

```csharp
public ExternalModule()
{
    this.enumManagerBase.InitializeEnum<ExampleEnum>("example enum"); // must contain the word 'enum' for it to work.
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
        key: "Box type enum", // must contain the word 'enum' for it to work
        defaultValue: (int)ExampleEnum.Option1,
        description: "Example options"
    );
}

private void Update()
{
    // Called every frame once enabled.

    // Example 1: Using a switch statement
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

    // Example 2: Using an if statement
    if (CEExampleEnum.Value == (int)ExampleEnum.Option1)
    {
        // Option 1 code
    }
}
```

### Explanation

- **OnEnable**: Runs when the module is enabled. Add any initialization code here.
- **Update**: Runs every frame. Use it to check for conditions like button presses.
- **OnDisable**: Runs when the module is disabled. Add any cleanup code here.
- **ReloadConfiguration**: Runs when the user changes settings. Updates variables based on new settings.
- **BindConfigEntries**: Binds configuration entries. Uses `SettingsHelper` to create settings like speed and controller buttons.

## Installation

1. Build your module into a `.dll` file.
2. Place the `.dll` file in the following path: `Gorilla Tag/Displyy/Modules`.
3. Inject Displyy Mod Menu
4. Your module should not show up in Displyy Mod Menu.
This is how you can create and set up your own external modules for the Displyy Mod Menu in Gorilla Tag.

## Instructions for Developers

Once your module is working, please send your code to displyy (displyy4) on Discord. I will add it to the mod menu. Just send the `.cs` file(s).
