using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UrlButton : MonoBehaviour
{
	public Button yourButton;

	public string LinkName;
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Url(LinkName);
	}
	void Url(string a)
    {
        switch (a)
        {
			case "Discord":
				Application.OpenURL("https://discord.gg/DAGBjcEN");
				break;
			case "Youtube":
				Application.OpenURL("https://www.youtube.com/channel/UCyOTWgziv-CzJoo3MBqpK6w");
				break;
			case "Twitch":
				Application.OpenURL("https://www.twitch.tv/hotpaw");
				break;
			default:
				break;
		}
    }
}
