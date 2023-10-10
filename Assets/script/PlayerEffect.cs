using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovement.instance.moveSpeed+= speedGiven;
        familierSet.instance.moveSpeed+= speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }
    public IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.moveSpeed -= speedGiven;
        familierSet.instance.moveSpeed -= speedGiven;
    }
    
    public void inverse(float inverseDuration)
    {
        PlayerMovement.instance.moveSpeed*= -1;
        familierSet.instance.moveSpeed*= -1;
        PlayerMovement.instance.isEffectPoulpe =true;
        StartCoroutine(removeInverse(inverseDuration));
    }
     public IEnumerator removeInverse(float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.moveSpeed *= -1;
        familierSet.instance.moveSpeed*= -1;
        PlayerMovement.instance.isEffectPoulpe = false;
    }
    
}
