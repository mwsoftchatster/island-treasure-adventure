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
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour {

    public Text pm;
    public Text cb1;
    public Text cb2;
    public Text abs1;
    public Text abs2;
    public Text m1;
    public Text m2;
    public Text mg1;
    public Text mg2;
    public Text cs1;
    public Text cs2;
    public Text b1;
    public Text b2;
    public Text sm1;
    public Text sm2;
    public Text qm1;
    public Text qm2;
    public Text c1;
    public Text c2;
    public Text c3;


    void Start () {

        pm.text = PlayerPrefs.GetInt("pm") + "/100";

        cb1.text = PlayerPrefs.GetInt("cb1") + "/100";
        cb2.text = PlayerPrefs.GetInt("cb2") + "/100";

        abs1.text = PlayerPrefs.GetInt("abs1") + "/100";
        abs2.text = PlayerPrefs.GetInt("abs2") + "/100";

        m1.text = PlayerPrefs.GetInt("m1") + "/100";
        m2.text = PlayerPrefs.GetInt("m2") + "/100";

        mg1.text = PlayerPrefs.GetInt("mg1") + "/125";
        mg2.text = PlayerPrefs.GetInt("mg2") + "/100";

        cs1.text = PlayerPrefs.GetInt("cs1") + "/125";
        cs2.text = PlayerPrefs.GetInt("cs2") + "/150";

        b1.text = PlayerPrefs.GetInt("b1") + "/150";
        b2.text = PlayerPrefs.GetInt("b2") + "/150";

        sm1.text = PlayerPrefs.GetInt("sm1") + "/200";
        sm2.text = PlayerPrefs.GetInt("sm2") + "/200";

        qm1.text = PlayerPrefs.GetInt("qm1") + "/250";
        qm2.text = PlayerPrefs.GetInt("qm2") + "/250";

        c1.text = PlayerPrefs.GetInt("c1") + "/500";
        c2.text = PlayerPrefs.GetInt("c2") + "/450";
        c3.text = PlayerPrefs.GetInt("c3") + "/400";

    }

	
}
