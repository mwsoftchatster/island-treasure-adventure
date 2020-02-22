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

public class TiledBackground : MonoBehaviour {
    //this size has to be in the power of 2, 4 , 8, 16 ... 
    public int textureWidth = 1024;
    public int textureHeight = 645;

    //track whether you can resize vertically or horizontally
    public bool scaleHorizontially = true;
    public bool scaleVertically = true;

    private PixelPerfectCamera pixelPerfectCamera;




    // Use this for initialization
    void Start () {
        pixelPerfectCamera = GameObject.Find("Main Camera").GetComponent<PixelPerfectCamera>();
        //calculate how many tiles fit within the width and height of the current screen
        var newWidth = !scaleHorizontially ? 1 : Mathf.Ceil(Screen.width / (textureWidth * pixelPerfectCamera.scale));
        var newHeight = !scaleVertically ? 1 : Mathf.Ceil(Screen.height / (textureHeight * pixelPerfectCamera.scale));

        //change scale of the Quad based on this new width and new height
        transform.localScale = new Vector3(newWidth * textureWidth, newHeight * textureHeight, 1);

        //tell the material that it has new texture scale
        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);


    }

}
