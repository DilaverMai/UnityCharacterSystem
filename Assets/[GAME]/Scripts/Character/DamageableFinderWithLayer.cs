using _GAME_.Scripts.Character;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class DamageableFinderWithLayer: MonoBehaviour, IFinder<IDamageable>
    {
       public FinderData FinderData;
       public FinderData AfterFindData;
       
       [ShowInInspector, ReadOnly]
       public FinderData CurrentData
       {
           get {
               return Target != null ? AfterFindData : FinderData;
           }
       }

       [BoxGroup("Current Data"), ShowInInspector, ReadOnly]
       public IDamageable Target;

       [BoxGroup("Events")]
       public UnityEvent OnFindTarget;
       [BoxGroup("Events")]
       public UnityEvent OnLostTarget;
       
       public float TargetDistance
        {
            get
            {
                if(Target == null) return -1f;
                
                return Vector3.Distance(transform.position, Target.transform.position);
            }
        }
        
        public IDamageable FindTarget()
        {
            var results = Physics.OverlapSphere(transform.position, CurrentData.Radius,CurrentData.TargetMask);
            
            if (results.Length == 0) return Target = null;
            
            foreach (var col in results)
            {
                var direction = (col.transform.position - transform.position).normalized;
                var angle = Vector3.Angle(transform.forward, direction);

                if (!(angle <= CurrentData.Angle))
                    continue;

                if(Target == null)
                    OnFindTarget?.Invoke();
            
                return Target = col.GetComponent<IDamageable>();
            }
            
            if(Target != null)
                OnLostTarget?.Invoke();
            
            return Target = null;
        }
    
        public Vector3 GetTargetPosition()
        {
            return Target.transform.position;
        }

        private void OnDrawGizmos()
        {
            if(CurrentData == null) return;
            
            Handles.DrawWireDisc(transform.position, Vector3.up, CurrentData.Radius, 10f);
            Handles.color = Color.blue;

            Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, CurrentData.Angle, CurrentData.Radius, 7.5f);
            Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, -CurrentData.Angle, CurrentData.Radius, 7.5f);

            if (Target != null)
            {
                Handles.DrawLine(transform.position,Target.transform.position);
                Handles.Label((Target.transform.position + transform.position) * .5f, Vector3.Distance(transform.position, Target.transform.position).ToString("F2"));
            }
        
        }
    }

}