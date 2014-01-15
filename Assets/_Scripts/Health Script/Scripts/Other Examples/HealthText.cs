using UnityEngine;
using System.Collections;

public class HealthText : MonoBehaviour {
	public Health healthComponent;

	void Awake() {
		if(healthComponent)
			healthComponent.OnSetHealth += SetText;
	}

	void SetText(float health) {
		GetComponent<TextMesh>().text = "<color=red> Health: " + health.ToString("0") + "/" + healthComponent.maxHealth + "</color>";
	}
}
