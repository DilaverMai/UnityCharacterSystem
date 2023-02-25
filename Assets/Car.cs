using Character;
using UnityEngine;

public class Car : MonoBehaviour
{
    public JoyStickCar joyStickCar;
    public Transform sitPoint;
    
    public void Sit(Player target)
    {
        var transform1 = target.transform;
        transform1.position = sitPoint.position;
        transform1.rotation = sitPoint.rotation;
        
        transform.parent = target.transform;
        target.playerJoystickController.ChangeState(joyStickCar);
    }
}