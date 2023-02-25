using Character;
using Unity.VisualScripting;
using UnityEngine;

public class RouteUnit : Unit
{
    public ControlInput RouteInput;
    public ValueInput RouteDirectionInput;
    
    protected override void Definition()
    {
        RouteDirectionInput = ValueInput<Vector3>("RouteDirection");
        RouteInput = ControlInput(nameof(RouteInput), RouteTrigger);
    }
    private ControlOutput RouteTrigger(Flow arg)
    {
        
        
        return null;
    }
}