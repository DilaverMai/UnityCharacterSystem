using _GAME_.Scripts.Character.Interfaces;
using Character;
using Unity.VisualScripting;
using UnityEngine;

public class MoveUnit<T> : Unit where T: IMovable
{
    private T moveable;
    
    public ControlInput TriggerInput;
    public ValueInput MoveDirectionInput;
    
    
    protected override void Definition()
    {
        MoveDirectionInput = ValueInput<Vector3>("MoveDirection");
        TriggerInput = ControlInput(nameof(TriggerInput), MoveTrigger);    
    }
    private ControlOutput MoveTrigger(Flow arg)
    {
        moveable.Move(arg.GetValue<Vector3>(MoveDirectionInput));
        return null;
    }

    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
        moveable = instance.component.GetComponent<T>();
    }
}