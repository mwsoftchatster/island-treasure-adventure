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
using UnityEngine.UI;
using System.Collections;

public class DetectCollision : MonoBehaviour {

    public int score { get; set; }
    public int bestScore { get; set; }

    public bool touchedSpikes { get; set; }
    public int shieldCounter = 0;

    public Text scoreText;

    public int twicePowerUpCounter = 0;

    public bool twicePowerUpEnabled = false;

    public bool magnetPowerUpEnabled = false;

    public AudioClip twicePowerUpClip;

    public AudioClip magnetPowerUpClip;



    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if ((collision.gameObject.tag == "ObstacleSmall") || (collision.gameObject.tag == "ObstacleBig"))
    //    {
    //        if (PlayerPrefs.GetInt("shield") == 1)
    //        {
    //            collision.gameObject.SetActive(false);
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();

        if (col.CompareTag("Treasure"))
        {
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().Play();
            }

            if (twicePowerUpEnabled == true && twicePowerUpCounter < 21)
            {
                score += 2;
                twicePowerUpCounter++;
            }
            if (twicePowerUpCounter == 21)
            {
                twicePowerUpEnabled = false;
                twicePowerUpCounter = 0;
            }
            if (twicePowerUpEnabled == false)
            {
                score++;
            }

            col.gameObject.SetActive(false);
            scoreText.text = "SCORE : " + score;
        }
        else if (col.CompareTag("2xPowerUp"))
        {
            col.gameObject.SetActive(false);
            twicePowerUpEnabled = true;
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("Magnetpowerup"))
        {
            col.gameObject.SetActive(false);
            magnetPowerUpEnabled = true;
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(magnetPowerUpClip);
            }
        }

        else if (col.CompareTag("cantTouchThis"))
        {
            if (PlayerPrefs.GetInt("shield") == 1)
            {
                shieldCounter++;
                col.gameObject.SetActive(false);
                if (shieldCounter == 5)
                {
                    shieldCounter = 0;
                    PlayerPrefs.SetInt("shield", 0);
                }
            }
            else
            {
                touchedSpikes = true;
            }
        }
        else if (col.CompareTag("BagOfDiamonds"))
        {
            score += 20;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("BunchOfDiamonds"))
        {
            score += 15;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("ChestOfDiamonds"))
        {
            score += 25;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("PileOfDiamonds"))
        {
            score += 10;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("PouchOfDiamonds"))
        {
            score += 15;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("BagOfGold"))
        {
            score += 20;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("ChestOfGold"))
        {
            score += 25;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("MountOfGold"))
        {
            score += 15;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("PileOfGold"))
        {
            score += 10;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
        else if (col.CompareTag("PouchOfGold"))
        {
            score += 15;
            scoreText.text = "SCORE : " + score;
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(twicePowerUpClip);
            }
        }
    }


}
