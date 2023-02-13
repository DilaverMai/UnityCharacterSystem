using Unity.VisualScripting;
using UnityEngine;

public class SearchTarget<T> : Unit where T : MonoBehaviour
{
    public ControlInput TriggerInput;
    
    public ControlOutput NotFoundOutput;
    public ControlOutput FoundOutput;
    
    public ValueInput SearchRadiusInput;
    public ValueOutput TargetOutput;
    public ValueOutput TargetOutputPosition;
    
    private Transform transform;
    
    protected override void Definition()
    {
        SearchRadiusInput = ValueInput<float>("SearchRadius", 0.1f);
        TriggerInput = ControlInput(nameof(TriggerInput),Finder);

        TargetOutput = ValueOutput<T>(nameof(TargetOutput));
        TargetOutputPosition = ValueOutput<Vector3>(nameof(TargetOutputPosition));

        FoundOutput = ControlOutput(nameof(FoundOutput));
        NotFoundOutput = ControlOutput(nameof(NotFoundOutput));
    }

    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
        transform = instance.component.transform;
    }

    private ControlOutput Finder(Flow flow)
    {
        if(transform == null) return null;
        
        var results = Physics.OverlapSphere(transform.position, flow.GetValue<float>(SearchRadiusInput));

        foreach (var target in results)
        {
            if (!target.TryGetComponent(out T component))
                continue;

            flow.SetValue(TargetOutput, component);
            flow.SetValue(TargetOutputPosition, GetTargetPosition(component));
            return NotFoundOutput;
        }
        
        return null;
    }
    
    private Vector3 GetTargetPosition(T target)
    {
        return target.transform.position;
    }
}
