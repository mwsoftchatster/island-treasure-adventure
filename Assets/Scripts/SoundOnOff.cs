/*
  Copyright (C) 2016 - 2020 MWSOFT
  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SoundOnOff : MonoBehaviour {

    public Image myImage;

    void Awake()
    {
        myImage = GameObject.Find("Sound").GetComponent<Button>().GetComponent<Image>();

        if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
        {
            ChangeImage("on");
            GameObject.Find("Background").GetComponent<AudioSource>().Play();
        }
        else
        {
            PlayerPrefs.SetString("SoundOnOff", "Off");
            GameObject.Find("Background").GetComponent<AudioSource>().Pause();
            ChangeImage("off");
        }
    }

    public void OnClick()
    {

        if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
        {
            PlayerPrefs.SetString("SoundOnOff", "Off");
            GameObject.Find("Background").GetComponent<AudioSource>().Pause();
            ChangeImage("off");
        }
        else
        {
            PlayerPrefs.SetString("SoundOnOff", "On");
            GameObject.Find("Background").GetComponent<AudioSource>().Play();
            ChangeImage("on");
        }

    }

    public void ChangeImage(string newImageTitle)
    {
        myImage.sprite = Resources.Load<Sprite>(newImageTitle);
    }

}
