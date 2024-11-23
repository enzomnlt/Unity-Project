using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public string text;
    public Text textObject;

    void Start()
    {
        text = "Press 1 to spawn 10 visitors\n" +
                "Press 2 to spawn 25 visitors\n" +
                "Press 3 to spawn 10 wanderers\n" +
                "Press 4 to spawn 25 wanderers\n" +
                "Press 5 to increase number of visitors\n" +
                "Press ESC to quit the game";
        textObject.text = text;
    }

    void Update()
    {
    }
}
