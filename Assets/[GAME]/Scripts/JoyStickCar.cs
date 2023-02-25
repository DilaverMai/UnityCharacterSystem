using Character;
using UnityEngine;

[CreateAssetMenu(menuName = "Create JoyStickCar", fileName = "JoyStickCar", order = 0)]
public class JoyStickCar: CharacterControllerState
{
    public override void Move(Vector3 position)
    {
        TargetPosition = CalculateMovement(ref position);
        
        Rotation(ref position);
        CharacterController.Move(TargetPosition);
    }

    public override void Rotation(ref Vector3 position)
    {
        //calculate angle by joystick input
        var angle = Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg;
        if(angle == 0) return;
        
        //rotate character
        CharacterController.transform.rotation = 
            Quaternion.RotateTowards(CharacterController.transform.rotation, 
                Quaternion.Euler(0, angle, 0), 
                position.magnitude *  playerControllerData.rotationSpeed);
    }

    public override void Jump(Vector3 centerPoint)
    {
        
    }

    public override Vector3 CalculateMovement(ref Vector3 input)
    {
        var transform = CharacterController.transform;
        var pos = transform.forward * (input.magnitude * playerControllerData.moveSpeed * Time.fixedDeltaTime);
        pos.y = playerControllerData.gravity * Time.fixedDeltaTime;
        return pos;
    }
}