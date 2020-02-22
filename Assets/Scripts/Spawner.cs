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

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject[] enemiesAndObstacles;
    public GameObject[] treasures;
    public GameObject[] characters;
    public GameObject spikes;
    public GameObject spikesBig;
    public GameObject parrot;
    public GameObject box;
    public GameObject boxSpykes;
    public GameObject[] obstacleBig;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1.1f, 1.7f);
    public static int previousChoice;
    public int indianCounter;
    public int spawnsCounter = 0;
    

    // Use this for initialization
    void Start () {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
        
	}

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);

        int obstacleChoice = Random.Range(1, 9);
        while(obstacleChoice == previousChoice)
        {
            obstacleChoice = Random.Range(1, 9);
        }

        if (((spawnsCounter % 10) == 0) && (spawnsCounter != 0))
        {
            obstacleChoice = 9;
            spawnsCounter = 0;
        }
        //active = false;
        if (active)
        {
            var newTransform = transform;
            GameObjectUtil gameObjectUtil = new GameObjectUtil();

            switch (obstacleChoice)
            {
                case 1:
                    spawnsCounter++;
                    previousChoice = 1;
                    gameObjectUtil.Instantiate(spikes, newTransform.position);
                    gameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(newTransform.position.x + 30, newTransform.position.y));                   
                    break;
                case 2:
                    spawnsCounter++;
                    previousChoice = 2;
                    gameObjectUtil.Instantiate(spikesBig, newTransform.position);
                    gameObjectUtil.Instantiate(obstacleBig[Random.Range(0, obstacleBig.Length)], new Vector3(newTransform.position.x + 35, newTransform.position.y));                    
                    break;
                case 3:
                    previousChoice = 3;
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(enemiesAndObstacles[Random.Range(0, enemiesAndObstacles.Length)], newTransform.position);
                    break;
                case 4:
                    previousChoice = 4;
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(parrot, new Vector3(newTransform.position.x, newTransform.position.y + 300));
                    break;
                case 5:
                    spawnsCounter++;
                    previousChoice = 5;
                    gameObjectUtil.Instantiate(boxSpykes, newTransform.position);
                    gameObjectUtil.Instantiate(box, new Vector3(newTransform.position.x + 45, newTransform.position.y));
                    break;
                case 6:
                    previousChoice = 6;
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(enemiesAndObstacles[Random.Range(0, enemiesAndObstacles.Length)], newTransform.position);
                    break;
                case 7:
                    previousChoice = 7;
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(enemiesAndObstacles[Random.Range(0, enemiesAndObstacles.Length)], newTransform.position);
                    break;
                case 8:
                    previousChoice = 8;
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(characters[Random.Range(0, characters.Length)], newTransform.position);
                    break;
                case 9:
                    spawnsCounter++;
                    gameObjectUtil.Instantiate(treasures[Random.Range(0, treasures.Length)], newTransform.position);
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
