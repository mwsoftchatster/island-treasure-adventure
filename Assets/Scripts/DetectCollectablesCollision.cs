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

public class DetectCollectablesCollision : MonoBehaviour {

    public AudioClip collectablesClip;

    void Update()
    {
        if ((PlayerPrefs.GetInt("pmIsAchieved") == 0) && (PlayerPrefs.GetInt("pmIsActive") == 1))
        {
            if (PlayerPrefs.GetInt("pm") >= 100)
            {
                PlayerPrefs.SetInt("pmIsAchieved", 1);
                PlayerPrefs.SetInt("pmIsActive", 0);
                PlayerPrefs.SetInt("cbIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("cbIsAchieved") == 0) && (PlayerPrefs.GetInt("cbIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("cb1") == 100) && (PlayerPrefs.GetInt("cb2") == 100))
            {
                PlayerPrefs.SetInt("cbIsAchieved", 1);
                PlayerPrefs.SetInt("cbIsActive", 0);
                PlayerPrefs.SetInt("absIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("absIsAchieved") == 0) && (PlayerPrefs.GetInt("absIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("abs1") == 100) && (PlayerPrefs.GetInt("abs2") == 100))
            {
                PlayerPrefs.SetInt("absIsAchieved", 1);
                PlayerPrefs.SetInt("absIsActive", 0);
                PlayerPrefs.SetInt("mIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("mIsAchieved") == 0) && (PlayerPrefs.GetInt("mIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("m1") == 100) && (PlayerPrefs.GetInt("m2") == 100))
            {
                PlayerPrefs.SetInt("mIsAchieved", 1);
                PlayerPrefs.SetInt("mIsActive", 0);
                PlayerPrefs.SetInt("mgIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("mgIsAchieved") == 0) && (PlayerPrefs.GetInt("mgIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("mg1") == 125) && (PlayerPrefs.GetInt("mg2") == 100))
            {
                PlayerPrefs.SetInt("mgIsAchieved", 1);
                PlayerPrefs.SetInt("mgIsActive", 0);
                PlayerPrefs.SetInt("csIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("csIsAchieved") == 0) && (PlayerPrefs.GetInt("csIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("cs1") == 125) && (PlayerPrefs.GetInt("cs2") == 150))
            {
                PlayerPrefs.SetInt("csIsAchieved", 1);
                PlayerPrefs.SetInt("csIsActive", 0);
                PlayerPrefs.SetInt("bIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("bIsAchieved") == 0) && (PlayerPrefs.GetInt("bIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("b1") == 150) && (PlayerPrefs.GetInt("b2") == 150))
            {
                PlayerPrefs.SetInt("bIsAchieved", 1);
                PlayerPrefs.SetInt("bIsActive", 0);
                PlayerPrefs.SetInt("smIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("smIsAchieved") == 0) && (PlayerPrefs.GetInt("smIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("sm1") == 200) && (PlayerPrefs.GetInt("sm2") == 200))
            {
                PlayerPrefs.SetInt("smIsAchieved", 1);
                PlayerPrefs.SetInt("smIsActive", 0);
                PlayerPrefs.SetInt("qmIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("qmIsAchieved") == 0) && (PlayerPrefs.GetInt("qmIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("qm1") == 250) && (PlayerPrefs.GetInt("sm2") == 250))
            {
                PlayerPrefs.SetInt("qmIsAchieved", 1);
                PlayerPrefs.SetInt("qmIsActive", 0);
                PlayerPrefs.SetInt("cIsActive", 1);
            }
        }
        else if ((PlayerPrefs.GetInt("cIsAchieved") == 0) && (PlayerPrefs.GetInt("cIsActive") == 1))
        {
            if ((PlayerPrefs.GetInt("c1") == 500) && (PlayerPrefs.GetInt("c2") == 450) && (PlayerPrefs.GetInt("c3") == 400))
            {
                PlayerPrefs.SetInt("cIsAchieved", 1);
                PlayerPrefs.SetInt("cIsActive", 0);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //=======================================================================================================
        //bomb -> powder monkey & carpenter&surgeon
        //=======================================================================================================
        if (col.CompareTag("bomb"))
        {
            col.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("pmIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("pm");
                temp += 1;
                PlayerPrefs.SetInt("pm", temp);
            }
            else if(PlayerPrefs.GetInt("csIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("cs2");
                temp += 1;
                PlayerPrefs.SetInt("cs2", temp);
            }
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        //sword -> cabin boy & able bodied soldier & carpenter&surgeon
        //=======================================================================================================
        if (col.CompareTag("sword"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("cbIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("cb1");
                temp += 1;
                PlayerPrefs.SetInt("cb1", temp);
            }
            else if (PlayerPrefs.GetInt("absIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("abs1");
                temp += 1;
                PlayerPrefs.SetInt("abs1", temp);
            }
            else if (PlayerPrefs.GetInt("csIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("cs2");
                temp += 1;
                PlayerPrefs.SetInt("cs2", temp);
            }
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        //rum -> cabin boy & mate & boatswain
        //=======================================================================================================
        if (col.CompareTag("rum"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("cbIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("cb2");
                temp += 1;
                PlayerPrefs.SetInt("cb2", temp);
            }
            else if (PlayerPrefs.GetInt("mIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("m1");
                temp += 1;
                PlayerPrefs.SetInt("m1", temp);
            }
            else if (PlayerPrefs.GetInt("bIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("b2");
                temp += 1;
                PlayerPrefs.SetInt("b2", temp);
            }
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        //coins -> able bodied soldier & mate & master gunner
        //=======================================================================================================
        if (col.CompareTag("coins"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("mIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("m2");
                temp += 1;
                PlayerPrefs.SetInt("m2", temp);
            }
            else if (PlayerPrefs.GetInt("absIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("abs2");
                temp += 1;
                PlayerPrefs.SetInt("abs2", temp);
            }
            else if (PlayerPrefs.GetInt("mgIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("mg2");
                temp += 1;
                PlayerPrefs.SetInt("mg2", temp);
            }
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        //gun -> master gunner & boatswain
        //=======================================================================================================
        if (col.CompareTag("gun"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("bIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("b1");
                temp += 1;
                PlayerPrefs.SetInt("b1", temp);
            }
            else if (PlayerPrefs.GetInt("mgIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("mg1");
                temp += 1;
                PlayerPrefs.SetInt("mg1", temp);
            }
            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //=======================================================================================================


        //=======================================================================================================
        //compass -> sailing master
        //=======================================================================================================
        if (col.CompareTag("compass"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("smIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("sm1");
                temp += 1;
                PlayerPrefs.SetInt("sm1", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        //binocular -> sailing master
        //=======================================================================================================
        if (col.CompareTag("binocular"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("smIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("sm2");
                temp += 1;
                PlayerPrefs.SetInt("sm2", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //========================================================================================================

        //=======================================================================================================
        //flag -> quarter master
        //=======================================================================================================
        if (col.CompareTag("flag"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("qmIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("qm1");
                temp += 1;
                PlayerPrefs.SetInt("qm1", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //========================================================================================================

        //=======================================================================================================
        //map -> quarter master
        //=======================================================================================================
        if (col.CompareTag("map"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("qmIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("qm2");
                temp += 1;
                PlayerPrefs.SetInt("qm2", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //========================================================================================================

        //=======================================================================================================
        //hat -> sailing master
        //=======================================================================================================
        if (col.CompareTag("hat"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("cIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("c1");
                temp += 1;
                PlayerPrefs.SetInt("c1", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //========================================================================================================

        //=======================================================================================================
        //pipe -> quarter master
        //=======================================================================================================
        if (col.CompareTag("pipe"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("cIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("c2");
                temp += 1;
                PlayerPrefs.SetInt("c2", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //========================================================================================================

        //=======================================================================================================
        //parrot -> quarter master
        //=======================================================================================================
        if (col.CompareTag("parrot"))
        {
            col.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("cIsActive") == 1)
            {
                int temp = PlayerPrefs.GetInt("c3");
                temp += 1;
                PlayerPrefs.SetInt("c3", temp);
            }

            if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
            {
                GetComponent<AudioSource>().PlayOneShot(collectablesClip);
            }
        }
        //========================================================================================================
    }
}
