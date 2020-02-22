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

//Automatically resizes camera based on the screen that it is being played on
public class PixelPerfectCamera : MonoBehaviour {

    public float pixelsToUnits = 1f;//one unit in Unity is equal to 1 pixel
    public float scale = 1f;
    public Vector2 nativeResolution = new Vector2(1024, 645);

    //is called before Start()
    void Awake () {
        var camera = GetComponent<Camera>();

        if (camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelsToUnits *= scale;
            //in Unity the zero position is in the middle of the screen so you need to get the total height and divide it by 2
            //then you need to divide that by pixelsToUnits so that camera size would increase and camera would zoom in
            camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
        }
	}

}
