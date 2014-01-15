using UnityEngine;
using System.Collections;

namespace Assets._Scripts.BaseClasses
{
    public class UnitBase : MonoBehaviour
    {
        public void onDeath()
        {
            // increase player gold
            Player.gold = Player.gold + 1;

            // destroy
            Destroy(gameObject);
        }
    }


}
