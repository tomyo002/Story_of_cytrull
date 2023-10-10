using UnityEngine.UI;
using UnityEngine;

public class helthBar : MonoBehaviour
{
   public Slider slider;
   public Gradient gradient;
   public Image fil;

    public void SetMaxHealth(int health)
    {
        slider.maxValue= health;
        slider.value= health;

        fil.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;

        fil.color = gradient.Evaluate(slider.normalizedValue);
    }
}
