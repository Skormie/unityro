﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/**
 * Taken from RoSpriteData.cs at RoRebuild
 * 
 * 
 */
public static class AnimationHelper {


    public static bool IsFourDirectionAnimation(EntityType type, SpriteMotion motion) {

        if (type != EntityType.PC) {
            return false;
        }

        switch (motion) {
            case SpriteMotion.Idle:
            case SpriteMotion.Sit:
            case SpriteMotion.Walk:
                return false;
            default:
                return true;
        }
    }

    public static int GetFourDirectionSpriteIndexForAngle(Direction facing, float cameraRotation) {
        cameraRotation += 45f * (int)facing;
        if(cameraRotation > 360)
            cameraRotation -= 360;
        if(cameraRotation < 0)
            cameraRotation += 360;

        var index = Mathf.FloorToInt(cameraRotation / 45f);

        if(index > 7)
            index = 0;

        return Mathf.Clamp(index, 0, 7);
    }

    public static int GetSpriteIndexForAngle(Direction facing, float cameraRotation) {
        cameraRotation += 45f * (int)facing + (45f / 2f);
        if(cameraRotation > 360)
            cameraRotation -= 360;
        if(cameraRotation < 0)
            cameraRotation += 360;

        var index = Mathf.FloorToInt(cameraRotation / 45f);

        return Mathf.Clamp(index, 0, 7); ;
    }

    public static int GetMotionIdForSprite(EntityType type, SpriteMotion motion) {
        if (motion == SpriteMotion.Idle) {
            return 0;
        }

        if(type == EntityType.NPC) {
            switch(motion) {
                case SpriteMotion.Walk: return 1 * 8;
                case SpriteMotion.Hit: return 2 * 8;
                case SpriteMotion.Attack1: return 3 * 8;
            }
        }

        //if(type == EntityType.Monster2) {
        //    if(motion == SpriteMotion.Attack2)
        //        return 5 * 8;
        //}

        if(type == EntityType.MOB || type == EntityType.PET) {
            switch(motion) {
                case SpriteMotion.Walk: return 1 * 8;
                case SpriteMotion.Attack1: return 2 * 8;
                case SpriteMotion.Attack2: return 2 * 8;
                case SpriteMotion.Attack3: return 2 * 8;
                case SpriteMotion.Hit: return 3 * 8;
                case SpriteMotion.Dead: return 4 * 8;
            }
        }

        if(type == EntityType.PET) {
            switch(motion) {
                case SpriteMotion.Special: return 5 * 8;
                case SpriteMotion.Performance1: return 6 * 8;
                case SpriteMotion.Performance2: return 7 * 8;
                case SpriteMotion.Performance3: return 8 * 8;
            }
        }

        if(type == EntityType.PC) {
            switch(motion) {
                case SpriteMotion.Walk: return 1 * 8;
                case SpriteMotion.Sit: return 2 * 8;
                case SpriteMotion.PickUp: return 3 * 8;
                case SpriteMotion.Standby: return 4 * 8;
                case SpriteMotion.Attack1: return 11 * 8;
                case SpriteMotion.Hit: return 6 * 8;
                case SpriteMotion.Freeze1: return 7 * 8;
                case SpriteMotion.Dead: return 8 * 8;
                case SpriteMotion.Freeze2: return 9 * 8;
                case SpriteMotion.Attack2: return 10 * 8;
                case SpriteMotion.Attack3: return 11 * 8;
                case SpriteMotion.Casting: return 12 * 8;
            }
        }


        return -1;
    }
}
