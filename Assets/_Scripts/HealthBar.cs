using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
    public Health healthComponent;
    public Texture2D HpBarTexture;
    public float healthBarLength;
    float percentOfHealth;

    void Awake()
    {
        if (healthComponent)
            healthComponent.OnSetHealth += SetText;
        
    }



    void SetText(float health)
    {
        percentOfHealth = healthComponent.currentHealth / healthComponent.maxHealth;
        int timesToRepeatSymbol = (int)(percentOfHealth *10);
        string HealthSymbol = new string('_', timesToRepeatSymbol);

        //GetComponent<TextMesh>().text = "<color=red> Health: " + health.ToString("0") + "/" + healthComponent.maxHealth + "</color>";
        GetComponent<TextMesh>().text = "<color=red>" + HealthSymbol + "  " + timesToRepeatSymbol  +"</color>";        
        
    }

    void Update()
    {

        transform.LookAt(Camera.main.transform);        
    }

}