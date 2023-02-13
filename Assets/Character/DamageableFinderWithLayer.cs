using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class DamageableFinderWithLayer: MonoBehaviour, IInitializable, IUpdater, IFinder<IDamageable>
    {
        [BoxGroup("Find Data")]
        public float Radius = 10f;
        [BoxGroup("Find Data")]
        public float Angle = 45f;
        [BoxGroup("Find Data")]
        public LayerMask TargetMask;
        
        [BoxGroup("After Find Data")]
        public float AfterFindAngle = 90f;
        [BoxGroup("After Find Data")]
        public float AfterFindRadius = 5f;
    
        [BoxGroup("Current Data"),ShowInInspector,ReadOnly]
        private float _currentAngle;
        [BoxGroup("Current Data"),ShowInInspector,ReadOnly]   
        private float _currentRadius;
        [BoxGroup("Current Data"),ShowInInspector,ReadOnly]
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

        public void Initialize()
        {
            _currentAngle = Angle;
            _currentRadius = Radius;
        }
    
        public IDamageable FindTarget()
        {
            var results = Physics.OverlapSphere(transform.position, _currentRadius,TargetMask);
            
            if (results.Length == 0) return Target = null;
            
            foreach (var col in results)
            {
                var direction = (col.transform.position - transform.position).normalized;
                var angle = Vector3.Angle(transform.forward, direction);

                if (!(angle <= _currentAngle))
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
        public void AfterFind()
        {
            _currentAngle = AfterFindAngle;
            _currentRadius = AfterFindRadius;
        }
        public void Reset()
        {
            _currentAngle = Angle;
            _currentRadius = Radius;
        }
    
        public void OnUpdate()
        {
            if(Target != null) 
                AfterFind();
            else Reset();
        }
    
        private void OnDrawGizmos()
        {
            Handles.DrawWireDisc(transform.position, Vector3.up, Radius, 10f);
            Handles.color = Color.blue;

            if (Application.isPlaying)
            {
                Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, _currentAngle, _currentRadius, 7.5f);
                Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, -_currentAngle, _currentRadius, 7.5f);
            }
            else
            {
                Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, Angle, Radius, 7.5f);
                Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, -Angle, Radius, 7.5f);
            }

            if (Target != null)
            {
                Handles.DrawLine(transform.position,Target.transform.position);
                Handles.Label((Target.transform.position + transform.position) * .5f, Vector3.Distance(transform.position, Target.transform.position).ToString("F2"));
            }
        
        }
    }
}