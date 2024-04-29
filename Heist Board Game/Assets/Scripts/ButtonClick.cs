using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour
{
	public Button rollButton;
    public TextMeshProUGUI rollText;

	void Start () {
		Button rb = rollButton.GetComponent<Button>();
		rb.onClick.AddListener(ClickHandler);
	}

	void ClickHandler(){
        int roll  = Random.Range(2, 13);
		rollText.text = "You rolled " + roll.ToString();
	}
}
