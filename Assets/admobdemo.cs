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
using admob;
public class admobdemo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Admob.Instance().bannerEventHandler += onBannerEvent;
        Admob.Instance().interstitialEventHandler += onInterstitialEvent;
        Admob.Instance().rewardedVideoEventHandler += onRewardedVideoEvent;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (0, 0, 100, 60), "initadmob")) {
            Admob ad = Admob.Instance();
          
            ad.initAdmob("YOUR_VALUE_HERE", "YOUR_VALUE_HERE");
          
         //   ad.setTesting(true);
		}
        if (GUI.Button(new Rect(120, 0, 100, 60), "showInterstitial"))
        {
            Admob ad = Admob.Instance();
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial();
            }
        }
        if (GUI.Button(new Rect(240, 0, 100, 60), "showRewardVideo"))
        {
            Admob ad = Admob.Instance();
            if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
                ad.loadRewardedVideo("YOUR_VALUE_HERE");
            }
        }
        if (GUI.Button(new Rect(240, 100, 100, 60), "showbanner"))
        {
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
        }
        if (GUI.Button(new Rect(240, 200, 100, 60), "showbannerABS"))
        {
            Admob.Instance().showBannerAbsolute(AdSize.SmartBanner, 0, 30);
        }
        if (GUI.Button(new Rect(240, 300, 100, 60), "hidebanner"))
        {
            Admob.Instance().removeBanner();
        }
	}
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "   " + msg);
    }
}
