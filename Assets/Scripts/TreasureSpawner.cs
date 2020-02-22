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

public class TreasureSpawner : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject twicePowerUp;
    public GameObject magnetPowerUp;
    public GameObject shield;
    public GameObject player;
    public float delay = 2.0f;
    public bool active = true;
    public bool twiceHasBeenUsed = false;
    public bool magnetHasBeenUsed = false;
    public bool shieldHasBeenUsed = false;
    public Vector2 delayRange = new Vector2(1, 2);
    public int twiceCounter = 0;
    public int magnetCounter = 0;
    public int shieldCounter = 0;
    public GameObject binocular;
    public GameObject compass;
    public GameObject hat;
    public GameObject gun;
    public GameObject bomb;
    public GameObject map;
    public GameObject sword;
    public GameObject coins;
    public GameObject rum;
    public GameObject flag;
    public GameObject parrot;
    public GameObject pipe;
    public int spawnsCounter = 0;
    public int pmIsActive = 0;
    public int cbIsActive = 0;
    public int absIsActive = 0;
    public int mIsActive = 0;
    public int mgIsActive = 0;
    public int csIsActive = 0;
    public int bIsActive = 0;
    public int smIsActive = 0;
    public int qmIsActive = 0;
    public int cIsActive = 0;
    public string currentAchievement = "";

    // Use this for initialization
    void Start()
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
    }


    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
            GameObjectUtil gameObjectUtil = new GameObjectUtil();

            var newTransform = transform;

            int treasureCounter = Random.Range(1, 8);

            if (twiceHasBeenUsed)
            {
                twiceCounter++;

                if(twiceCounter == 30)
                {
                    twiceHasBeenUsed = false;
                    twiceCounter = 0;
                }
            }

            if (magnetHasBeenUsed)
            {
                magnetCounter++;

                if(magnetCounter == 30)
                {
                    magnetHasBeenUsed = false;
                    magnetCounter = 0;
                }
            }

            if (shieldHasBeenUsed)
            {
                shieldCounter++;

                if (shieldCounter == 30)
                {
                    shieldHasBeenUsed = false;
                    shieldCounter = 0;
                }
            }

            if (spawnsCounter == 12)
            {
                treasureCounter = 8;
                spawnsCounter = 0;

                int pmTest = PlayerPrefs.GetInt("pm");
                if (pmTest < 100)
                {
                    PlayerPrefs.SetInt("pmIsActive", 1);
                }
                pmIsActive = PlayerPrefs.GetInt("pmIsActive");
                if (pmIsActive == 1)
                {
                    currentAchievement = "pm";
                }

                cbIsActive = PlayerPrefs.GetInt("cbIsActive");
                if (cbIsActive == 1)
                {
                    currentAchievement = "cb";
                }

                absIsActive = PlayerPrefs.GetInt("absIsActive");
                if (absIsActive == 1)
                {
                    currentAchievement = "abs";
                }

                mIsActive = PlayerPrefs.GetInt("mIsActive");
                if (mIsActive == 1)
                {
                    currentAchievement = "m";
                }

                mgIsActive = PlayerPrefs.GetInt("mgIsActive");
                if (mgIsActive == 1)
                {
                    currentAchievement = "mg";
                }

                csIsActive = PlayerPrefs.GetInt("csIsActive");
                if (csIsActive == 1)
                {
                    currentAchievement = "cs";
                }

                bIsActive = PlayerPrefs.GetInt("bIsActive");
                if (bIsActive == 1)
                {
                    currentAchievement = "b";
                }

                smIsActive = PlayerPrefs.GetInt("smIsActive");
                if (smIsActive == 1)
                {
                    currentAchievement = "sm";
                }

                qmIsActive = PlayerPrefs.GetInt("qmIsActive");
                if (qmIsActive == 1)
                {
                    currentAchievement = "qm";
                }

                cIsActive = PlayerPrefs.GetInt("cIsActive");
                if (cIsActive == 1)
                {
                    currentAchievement = "c";
                }
            }

            switch (treasureCounter)
            {
                case 1:
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
                    break;
                case 2:
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 50, newTransform.position.y));
                    break;
                case 3:
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 50, newTransform.position.y));
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 100, newTransform.position.y));
                    break;
                case 4:
                    spawnsCounter++;
                    int treasurePos = Random.Range(1, 4);

                    if(treasurePos == 1)
                    {
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 50, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 100, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 150, newTransform.position.y));
                    }
                    else if(treasurePos == 2)
                    {
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 50, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 100, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 150, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 200, newTransform.position.y));
                    }
                    else if (treasurePos == 3)
                    {
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 50, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 100, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 150, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 200, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 250, newTransform.position.y));
                        gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 300, newTransform.position.y));
                    }

                    break;
                case 5:
                    if (twiceHasBeenUsed == false) {
                        spawnsCounter++;
                        gameObjectUtil.Instantiate(twicePowerUp, newTransform.position);
                        twiceHasBeenUsed = true;
                    }
                    break;
                case 6:
                    if (magnetHasBeenUsed == false)
                    {
                        spawnsCounter++;
                        gameObjectUtil.Instantiate(magnetPowerUp, newTransform.position);
                        magnetHasBeenUsed = true;   
                    }
                    break;
                case 7:
                    if (shieldHasBeenUsed == false)
                    {
                        spawnsCounter++;
                        gameObjectUtil.Instantiate(shield, newTransform.position);
                        shieldHasBeenUsed = true;
                    }
                    break;
                case 8:
                    switch (currentAchievement)
                    {
                        case "pm":
                            gameObjectUtil.Instantiate(bomb, newTransform.position);
                            break;
                        case "cb":
                            int cbChoice = Random.Range(1, 3);
                            if(cbChoice == 1)
                            {
                                if(PlayerPrefs.GetInt("cb1") < 100)
                                {
                                    gameObjectUtil.Instantiate(sword, newTransform.position);
                                }
                                else if(PlayerPrefs.GetInt("cb2") < 100)
                                {
                                    gameObjectUtil.Instantiate(rum, newTransform.position);
                                }    
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("cb2") < 100)
                                {
                                    gameObjectUtil.Instantiate(rum, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("cb1") < 100)
                                {
                                    gameObjectUtil.Instantiate(sword, newTransform.position);
                                }
                            }              
                            break;
                        case "abs":
                            int absChoice = Random.Range(1, 3);
                            if (absChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("abs1") < 100)
                                {
                                    gameObjectUtil.Instantiate(sword, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("abs2") < 100)
                                {
                                    gameObjectUtil.Instantiate(coins, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("abs2") < 100)
                                {
                                    gameObjectUtil.Instantiate(coins, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("abs1") < 100)
                                {
                                    gameObjectUtil.Instantiate(sword, newTransform.position);
                                }
                            }
                            break;
                        case "m":
                            int mChoice = Random.Range(1, 3);
                            if (mChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("m1") < 100)
                                {
                                    gameObjectUtil.Instantiate(rum, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("m2") < 100)
                                {
                                    gameObjectUtil.Instantiate(coins, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("m2") < 100)
                                {
                                    gameObjectUtil.Instantiate(coins, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("m1") < 100)
                                {
                                    gameObjectUtil.Instantiate(rum, newTransform.position);
                                }
                            }
                            break;
                        case "mg":
                            int mgChoice = Random.Range(1, 3);
                            if (mgChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("mg1") < 125)
                                {
                                    gameObjectUtil.Instantiate(gun, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("mg2") < 100)
                                {
                                    gameObjectUtil.Instantiate(coins, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("mg2") < 100)
                                {
                                    gameObjectUtil.Instantiate(coins, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("mg1") < 125)
                                {
                                    gameObjectUtil.Instantiate(gun, newTransform.position);
                                }
                            }
                            break;
                        case "cs":
                            int csChoice = Random.Range(1, 3);
                            if (csChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("cs1") < 125)
                                {
                                    gameObjectUtil.Instantiate(sword, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("cs2") < 150)
                                {
                                    gameObjectUtil.Instantiate(bomb, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("cs2") < 150)
                                {
                                    gameObjectUtil.Instantiate(bomb, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("cs1") < 125)
                                {
                                    gameObjectUtil.Instantiate(sword, newTransform.position);
                                }
                            }
                            break;
                        case "b":
                            int bChoice = Random.Range(1, 3);
                            if (bChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("b1") < 150)
                                {
                                    gameObjectUtil.Instantiate(gun, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("b2") < 150)
                                {
                                    gameObjectUtil.Instantiate(rum, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("b2") < 150)
                                {
                                    gameObjectUtil.Instantiate(rum, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("b1") < 150)
                                {
                                    gameObjectUtil.Instantiate(gun, newTransform.position);
                                }
                            }
                            break;
                        case "sm":
                            int smChoice = Random.Range(1, 3);
                            if (smChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("sm1") < 200)
                                {
                                    gameObjectUtil.Instantiate(compass, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("sm2") < 200)
                                {
                                    gameObjectUtil.Instantiate(binocular, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("sm2") < 200)
                                {
                                    gameObjectUtil.Instantiate(binocular, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("sm1") < 200)
                                {
                                    gameObjectUtil.Instantiate(compass, newTransform.position);
                                }
                            }
                            break;
                        case "qm":
                            int qmChoice = Random.Range(1, 3);
                            if (qmChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("qm1") < 250)
                                {
                                    gameObjectUtil.Instantiate(flag, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("qm2") < 250)
                                {
                                    gameObjectUtil.Instantiate(map, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("qm2") < 250)
                                {
                                    gameObjectUtil.Instantiate(map, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("qm1") < 250)
                                {
                                    gameObjectUtil.Instantiate(flag, newTransform.position);
                                }
                            }
                            break;
                        case "c":
                            int cChoice = Random.Range(1, 4);
                            if (cChoice == 1)
                            {
                                if (PlayerPrefs.GetInt("c1") < 500)
                                {
                                    gameObjectUtil.Instantiate(hat, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("c2") < 450)
                                {
                                    gameObjectUtil.Instantiate(pipe, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("c3") < 400)
                                {
                                    gameObjectUtil.Instantiate(parrot, newTransform.position);
                                }
                            }
                            else if(cChoice == 2)
                            {
                                if (PlayerPrefs.GetInt("c2") < 450)
                                {
                                    gameObjectUtil.Instantiate(pipe, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("c1") < 500)
                                {
                                    gameObjectUtil.Instantiate(hat, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("c3") < 400)
                                {
                                    gameObjectUtil.Instantiate(parrot, newTransform.position);
                                }
                            }
                            else
                            {
                                if (PlayerPrefs.GetInt("c3") < 400)
                                {
                                    gameObjectUtil.Instantiate(parrot, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("c1") < 500)
                                {
                                    gameObjectUtil.Instantiate(hat, newTransform.position);
                                }
                                else if (PlayerPrefs.GetInt("c2") < 450)
                                {
                                    gameObjectUtil.Instantiate(pipe, newTransform.position);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;

            }

            ResetDelay();
        }

        StartCoroutine(EnemyGenerator());
    }

    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }
}
