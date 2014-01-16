using UnityEngine;
using System.Collections;

public class TowerSlot : MonoBehaviour
{
    public GUISkin skin = null;

    bool gui = false;

    // Tower prefab
    public Turret turretPrefab = null;

    void OnGUI()
    {
        if (gui)
        {
            GUI.skin = skin;

            // get 3d position on screen        
            Vector3 v = Camera.main.WorldToScreenPoint(transform.position);

            // convert to gui coordinates
            v = new Vector2(v.x, Screen.height - v.y);

            // creation menu for tower
            int width = 200;
            int height = 40;
            Rect r = new Rect(v.x - width / 2, v.y - height / 2, width, height);
            GUI.contentColor = (Player.gold >= turretPrefab.buildPrice ? Color.green : Color.red);
            GUI.Box(r, "Build " + turretPrefab.name + "(" + turretPrefab.buildPrice + " gold)");

            // mouse not down anymore and mouse over the box? then build the tower                
            if (Event.current.type == EventType.MouseUp &&
                r.Contains(Event.current.mousePosition) &&
                Player.gold >= turretPrefab.buildPrice)
            {
                // decrease gold
                Player.gold -= turretPrefab.buildPrice;

                // instantiate
                Instantiate(turretPrefab, transform.position, Quaternion.identity);

                // disable gameobject
                gameObject.SetActive(false);
            }
        }
    }

    public void OnMouseDown()
    {
        gui = true;
    }


    public void OnMouseUp()
    {
        gui = false;
    }
}