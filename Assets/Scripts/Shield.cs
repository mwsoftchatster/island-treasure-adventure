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

public class Shield : MonoBehaviour {

    public GameObject aura;
    public AudioClip shieldClip;
    GameObjectUtil gameObjectUtil;

    void Start()
    {
        gameObjectUtil = new GameObjectUtil();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("shield"))
        {

            PlayerPrefs.SetInt("shield", 1);
            col.gameObject.SetActive(false);
            gameObjectUtil.Instantiate(aura, transform.position);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(shieldClip);
            }

        }

    }


    void Update()
    {
        if (PlayerPrefs.GetInt("shield") == 1)
        {           
            aura = GameObject.FindGameObjectWithTag("aura");
            aura.transform.position = transform.position;
        }
        else
        {
            aura.SetActive(false);
        }
    }
}
