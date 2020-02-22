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
using UnityEngine.SceneManagement;
using System.Collections;

public class WorldChoiceManager : MonoBehaviour {

    public bool JungleHasBeenChosen = false;
    public bool BeachHasBeenChosen = false;



    // Update is called once per frame
    void Update () {

        if(JungleHasBeenChosen == true)
        {
            PlayerPrefs.SetString("WorldChoice", "Jungle");
            SceneManager.LoadScene("GameStaging");
        }
        else if (BeachHasBeenChosen == true)
        {
            PlayerPrefs.SetString("WorldChoice", "Beach");
            SceneManager.LoadScene("GameStaging");
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Start");

                return;
            }
        }


    }

    public void OnClickJungle()
    {
        JungleHasBeenChosen = true;
    }

    public void OnClickBeach()
    {
        BeachHasBeenChosen = true;
    }

    public void onBackPressed()
    {
        SceneManager.LoadScene("Start");
    }
}
