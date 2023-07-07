using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI Healthext;
    public int Health = 0;
    public int MaxHealth=0;
    public Earth earth;
    private void Start()
    {
    }
    public void AddHealth(int health,int maxhealth)
    {
        Health += health;
        MaxHealth += maxhealth;
        earth.UpdateHealthTextScript();
        UpdateHealthText(health, maxhealth);
    }

    public void UpdateHealthText(int health, int maxhealth)
    {
        Healthext.text = $"{health}/{maxhealth}";
    }
}