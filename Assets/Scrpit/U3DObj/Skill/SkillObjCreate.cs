﻿using UnityEngine;
using System.Collections;


//Un 与数据结合接口
/// <summary>
/// 技能对象创建器(U3D)
/// </summary>
public class SkillObjCreate : MonoBehaviour {
    
    /// <summary>
    /// 技能预制
    /// </summary>
    public GameObject skillPrefab;

    /// <summary>
    /// 技能发射点
    /// </summary>
    protected Vector3 skillCreateP;

    /// <summary>
    /// 时间
    /// </summary>
    protected float timeCount = 0;
    /// <summary>
    /// 冷却时间
    /// </summary>
    protected float coldtime = 1;
    /// <summary>
    /// 冷却标记
    /// </summary>
    protected bool f_Cold = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
        if (!f_Cold)
        {
            if (Input.GetAxis("Skill1") > 0.01f)
            {
                GameObject skillObj = Instantiate(skillPrefab);

                skillObj.transform.forward = this.transform.forward;
                skillObj.transform.position = this.transform.position + this.transform.forward * 4;
                f_Cold = true;
            }
        }
        else
        {
            if (timeCount >= coldtime)
            {
                timeCount = 0;
                f_Cold = false;
            }
            else
                timeCount += Time.deltaTime;
        }
    }

}
