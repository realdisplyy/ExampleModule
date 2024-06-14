using System;
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
}