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

public class TimeManager : MonoBehaviour {

	public void ManipulateTime(float newTime, float duration){

		if (Time.timeScale == 0)
			Time.timeScale = 0.1f;

		StartCoroutine (FadeTo (newTime, duration));
	}

	IEnumerator FadeTo(float value, float time){

		for (float t = 0f; t < 1; t += Time.deltaTime / time) {

			Time.timeScale = Mathf.Lerp(Time.timeScale, value, t);

			if(Mathf.Abs(value - Time.timeScale) < .01f){
				Time.timeScale = value;
                break;
			}

			yield return null;
		}

	}

}
