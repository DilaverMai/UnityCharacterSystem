using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Character
{
    public class AttackerWithSkill : Attacker,ISkillable
    {
        [BoxGroup("Skill Data")]
        public UsingSkillData[] usingSkillData;
        [BoxGroup("Skill Data")]
        public List<Skill> skills = new List<Skill>();
        
        public override void Initialize()
        {
            base.Initialize();
            SkillInit();
        }
        
        public void SkillInit()
        {
            foreach (var skill in usingSkillData)
                skills.Add(new Skill(skill, this));
        }
        
        public Skill GetReadySkill()
        {
            return skills.FirstOrDefault(skill => skill._skillStat == Skill.SkillStat.Ready);
        }

        public override void Attack(IDamageable healthSystem, float targetDistance = 0)
        {
            base.Attack(healthSystem, targetDistance);
            var skill = GetReadySkill();

            skill?.SpawnSkill(transform);
        }
        
        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
        
            if(usingSkillData.Length == 0) return;
            
            Handles.color = Color.magenta;
            foreach (var skill in skills)
            {
                var position = transform.position;
                var forward = transform.forward;
            
                Handles.Label(position + (forward * skill.SkillRange) ,
                    skill.SkillName + "CoolDown:" + skill.CurrentCoolTime.ToString("0.00"), EditorStyles.boldLabel);
                Handles.DrawWireArc(position, Vector3.up, forward, skill.SkillAngle, skill.SkillRange, 7.5f);
                Handles.DrawWireArc(position, Vector3.up, forward, -skill.SkillAngle, skill.SkillRange, 7.5f);
            }
        }
    }

}