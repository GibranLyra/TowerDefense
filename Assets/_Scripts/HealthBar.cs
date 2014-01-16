using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public string playerName;
    private GUIStyle enemyLabelStyle;
    private Health healthScript;
    private float healthBarLength;

    private int healthBarLeft = 100;    
    private int healthBarTop = 30;

    private int enemyLabelTop;
    private int enemyLabelLeft = 100;

    private int labelTop;
    private int labelLeft = 50;

    public Transform AboveOf;    //What is the  object that the bar will be above
    

    void Awake()
    {
        setEnemyGUIStyle();

        healthScript = (Health)transform.parent.gameObject.GetComponent("Health");

        labelTop = healthBarTop + 3;
        enemyLabelTop = healthBarTop + 56;
    }
    void Update()
    {
        healthBarLength = (healthScript.currentHealth / healthScript.maxHealth) * 100;
    }

    void OnGUI()
    {
        //worldPosition = new Vector3(myTransform.position.x, myTransform.position.y + adjustment, myTransform.position.z);
        Vector3 screenPosition =  Camera.main.WorldToScreenPoint(AboveOf.position);

        //creating a ray that will travel forward from the camera's position    
        var ray = new Ray(Camera.main.transform.position, transform.forward);        
        var forward = transform.TransformDirection(Vector3.forward);
        float distance = Vector3.Distance(Camera.main.transform.position, transform.position); //gets the distance between the camera, and the intended target we want to raycast to

        //if something obstructs our raycast, that is if our characters are no longer 'visible,' dont draw their health on the screen.
        if (!Physics.Raycast(ray, distance))
        {
            //HealthBarColor
            GUI.color = Color.red;
            GUI.HorizontalScrollbar(new Rect(screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - healthBarTop, 100, 0), 0, healthScript.currentHealth, 0, healthScript.maxHealth); //displays a healthbar
            //FontColor Health Label
            GUI.color = Color.white;         
            GUI.Label(new Rect(screenPosition.x - labelLeft / 2, Screen.height - screenPosition.y - labelTop, 100, 100), healthScript.currentHealth + "/" + healthScript.maxHealth); //displays health in text format
            //Enemy Name Label
            GUI.Label(new Rect(screenPosition.x - enemyLabelLeft / 2, Screen.height - screenPosition.y - enemyLabelTop, 100, 100), playerName, enemyLabelStyle); //displays health in text format
        }
    }

    void setEnemyGUIStyle()
    {
        enemyLabelStyle = new GUIStyle();
        enemyLabelStyle.normal.textColor = Color.green;
        enemyLabelStyle.fontSize = 12;
        enemyLabelStyle.fontStyle = FontStyle.Bold;
        enemyLabelStyle.clipping = TextClipping.Overflow;
        enemyLabelStyle.alignment = TextAnchor.MiddleCenter;
    }

}