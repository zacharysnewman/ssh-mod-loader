using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OldBrawlStarsModTools
{
    [System.Serializable]
    public class Projectile
    {
        public string Name;
        public string ParentProjectileForSkin;
        public int Speed;
        private string FileName;
        private string BlueSCW, RedSCW;
        private string BlueExportName, RedExportName, ShadowExportName;
        private string BlueGroundGlowExportName, RedGroundGlowExportName;
        private string PreExplosionBlueExportName, PreExplosionRedExportName;
        public int PreExplosionTimeMs;
        private string HitEffectEnv, HitEffectChar, MaxRangeReachedEffect, CancelEffect;
        public int Radius;
        public bool Indirect;
        public bool ConstantFlyTime;
        public int TriggerWithDelayMs;
        public int BouncePercent;
        public int Gravity;
        public int EarlyTicks;
        public int HideTime;
        public int Scale;
        public int RandomStartFrame;
        public string SpawnAreaEffectObject, SpawnAreaEffectObject2, SpawnCharacter, SpawnItem;
        public string TrailEffect;
        public bool ShotByHero, IsBeam, IsBouncing;
        public int DistanceAddFromBounce;
        private string Rendering;
        public bool PiercesCharacters, PiercesEnvironment, PiercesEnvironmentLikeButter;
        public int PushbackStrength;
        public bool VariablePushback;
        public bool DirectionAlignedPushback;
        public int ChainsToEnemies, ChainBullets, ChainSpread, ChainTravelDistance;
        public string ChainBullet;
        public int ExecuteChainSpecialCase;
        public int DamagePercentStart, DamagePercentEnd;
        public int DamagesConstantlyTickDelay;
        public int FreezeStrength, FreezeDurationMS, StunLengthMS;
        public int ScaleStart, ScaleEnd;
        public bool AttractsPet;
        public int LifeStealPercent;
        public bool PassesEnvironment;
        public int PoisonDamagePercent;
        public bool DamageOnlyWithOneProj;
        public int HealOwnPercent;
        public bool CanGrowStronger;
        public bool HideFaster;
        public bool GrapplesEnemy;
        public int KickBack;
        private bool UseColorMod;
        private int RedAdd, GreenAdd, BlueAdd;
        private int RedMul, GreenMul, BlueMul;
        private bool GroundBasis;
        public int MinDistanceForSpread;
        public bool IsFriendlyHomingMissile, IsBoomerang, CanHitAgainAfterBounce, IsHomingMissile, BlockUltiCharge;
        public int PoisonType, TravelType;
        public int SteerStrength, SteerIgnoreTicks, HomeDistance, SteerLifeTime;

        public Projectile(string csvRow)
        {
            var data = csvRow.Split(',');

            Name = Convert.ToString(data[0]);
            ParentProjectileForSkin = Convert.ToString(data[1]);
            Speed = Convert.ToInt(data[2]);
            FileName = Convert.ToString(data[3]);
            BlueSCW = Convert.ToString(data[4]);
            RedSCW = Convert.ToString(data[5]);
            BlueExportName = Convert.ToString(data[6]);
            RedExportName = Convert.ToString(data[7]);
            ShadowExportName = Convert.ToString(data[8]);
            BlueGroundGlowExportName = Convert.ToString(data[9]);
            RedGroundGlowExportName = Convert.ToString(data[10]);
            PreExplosionBlueExportName = Convert.ToString(data[11]);
            PreExplosionRedExportName = Convert.ToString(data[12]);
            PreExplosionTimeMs = Convert.ToInt(data[13]);
            HitEffectEnv = Convert.ToString(data[14]);
            HitEffectChar = Convert.ToString(data[15]);
            MaxRangeReachedEffect = Convert.ToString(data[16]);
            CancelEffect = Convert.ToString(data[17]);
            Radius = Convert.ToInt(data[18]);
            Indirect = Convert.ToBool(data[19]);
            ConstantFlyTime = Convert.ToBool(data[20]);
            TriggerWithDelayMs = Convert.ToInt(data[21]);
            BouncePercent = Convert.ToInt(data[22]);
            Gravity = Convert.ToInt(data[23]);
            EarlyTicks = Convert.ToInt(data[24]);
            HideTime = Convert.ToInt(data[25]);
            Scale = Convert.ToInt(data[26]);
            RandomStartFrame = Convert.ToInt(data[27]);
            SpawnAreaEffectObject = Convert.ToString(data[28]);
            SpawnAreaEffectObject2 = Convert.ToString(data[29]);
            SpawnCharacter = Convert.ToString(data[30]);
            SpawnItem = Convert.ToString(data[31]);
            TrailEffect = Convert.ToString(data[32]);
            ShotByHero = Convert.ToBool(data[33]);
            IsBeam = Convert.ToBool(data[34]);
            IsBouncing = Convert.ToBool(data[35]);
            DistanceAddFromBounce = Convert.ToInt(data[36]);
            Rendering = Convert.ToString(data[37]);
            PiercesCharacters = Convert.ToBool(data[38]);
            PiercesEnvironment = Convert.ToBool(data[39]);
            PiercesEnvironmentLikeButter = Convert.ToBool(data[40]);
            PushbackStrength = Convert.ToInt(data[41]);
            VariablePushback = Convert.ToBool(data[42]);
            DirectionAlignedPushback = Convert.ToBool(data[43]);
            ChainsToEnemies = Convert.ToInt(data[44]);
            ChainBullets = Convert.ToInt(data[45]);
            ChainSpread = Convert.ToInt(data[46]);
            ChainTravelDistance = Convert.ToInt(data[47]);
            ChainBullet = Convert.ToString(data[48]);
            ExecuteChainSpecialCase = Convert.ToInt(data[49]);
            DamagePercentStart = Convert.ToInt(data[50]);
            DamagePercentEnd = Convert.ToInt(data[51]);
            DamagesConstantlyTickDelay = Convert.ToInt(data[52]);
            FreezeStrength = Convert.ToInt(data[53]);
            FreezeDurationMS = Convert.ToInt(data[54]);
            StunLengthMS = Convert.ToInt(data[55]);
            ScaleStart = Convert.ToInt(data[56]);
            ScaleEnd = Convert.ToInt(data[57]);
            AttractsPet = Convert.ToBool(data[58]);
            LifeStealPercent = Convert.ToInt(data[59]);
            PassesEnvironment = Convert.ToBool(data[60]);
            PoisonDamagePercent = Convert.ToInt(data[61]);
            DamageOnlyWithOneProj = Convert.ToBool(data[62]);
            HealOwnPercent = Convert.ToInt(data[63]);
            CanGrowStronger = Convert.ToBool(data[64]);
            HideFaster = Convert.ToBool(data[65]);
            GrapplesEnemy = Convert.ToBool(data[66]);
            KickBack = Convert.ToInt(data[67]);
            UseColorMod = Convert.ToBool(data[68]);
            RedAdd = Convert.ToInt(data[69]);
            GreenAdd = Convert.ToInt(data[70]);
            BlueAdd = Convert.ToInt(data[71]);
            RedMul = Convert.ToInt(data[72]);
            GreenMul = Convert.ToInt(data[73]);
            BlueMul = Convert.ToInt(data[74]);
            GroundBasis = Convert.ToBool(data[75]);
            MinDistanceForSpread = Convert.ToInt(data[76]);
            IsFriendlyHomingMissile = Convert.ToBool(data[77]);
            IsBoomerang = Convert.ToBool(data[78]);
            CanHitAgainAfterBounce = Convert.ToBool(data[79]);
            IsHomingMissile = Convert.ToBool(data[80]);
            BlockUltiCharge = Convert.ToBool(data[81]);
            PoisonType = Convert.ToInt(data[82]);
            TravelType = Convert.ToInt(data[83]);
            SteerStrength = Convert.ToInt(data[84]);
            SteerIgnoreTicks = Convert.ToInt(data[85]);
            HomeDistance = Convert.ToInt(data[86]);
            SteerLifeTime = Convert.ToInt(data[87]);
        }

        public string ToCsvRow()
        {
            return
            Convert.ToCsvString(Name) + "," +
            Convert.ToCsvString(ParentProjectileForSkin) + "," +
            Convert.ToCsvString(Speed) + "," +
            Convert.ToCsvString(FileName) + "," +
            Convert.ToCsvString(BlueSCW) + "," +
            Convert.ToCsvString(RedSCW) + "," +
            Convert.ToCsvString(BlueExportName) + "," +
            Convert.ToCsvString(RedExportName) + "," +
            Convert.ToCsvString(ShadowExportName) + "," +
            Convert.ToCsvString(BlueGroundGlowExportName) + "," +
            Convert.ToCsvString(RedGroundGlowExportName) + "," +
            Convert.ToCsvString(PreExplosionBlueExportName) + "," +
            Convert.ToCsvString(PreExplosionRedExportName) + "," +
            Convert.ToCsvString(PreExplosionTimeMs) + "," +
            Convert.ToCsvString(HitEffectEnv) + "," +
            Convert.ToCsvString(HitEffectChar) + "," +
            Convert.ToCsvString(MaxRangeReachedEffect) + "," +
            Convert.ToCsvString(CancelEffect) + "," +
            Convert.ToCsvString(Radius) + "," +
            Convert.ToCsvString(Indirect) + "," +
            Convert.ToCsvString(ConstantFlyTime) + "," +
            Convert.ToCsvString(TriggerWithDelayMs) + "," +
            Convert.ToCsvString(BouncePercent) + "," +
            Convert.ToCsvString(Gravity) + "," +
            Convert.ToCsvString(EarlyTicks) + "," +
            Convert.ToCsvString(HideTime) + "," +
            Convert.ToCsvString(Scale) + "," +
            Convert.ToCsvString(RandomStartFrame) + "," +
            Convert.ToCsvString(SpawnAreaEffectObject) + "," +
            Convert.ToCsvString(SpawnAreaEffectObject2) + "," +
            Convert.ToCsvString(SpawnCharacter) + "," +
            Convert.ToCsvString(SpawnItem) + "," +
            Convert.ToCsvString(TrailEffect) + "," +
            Convert.ToCsvString(ShotByHero) + "," +
            Convert.ToCsvString(IsBeam) + "," +
            Convert.ToCsvString(IsBouncing) + "," +
            Convert.ToCsvString(DistanceAddFromBounce) + "," +
            Convert.ToCsvString(Rendering) + "," +
            Convert.ToCsvString(PiercesCharacters) + "," +
            Convert.ToCsvString(PiercesEnvironment) + "," +
            Convert.ToCsvString(PiercesEnvironmentLikeButter) + "," +
            Convert.ToCsvString(PushbackStrength) + "," +
            Convert.ToCsvString(VariablePushback) + "," +
            Convert.ToCsvString(DirectionAlignedPushback) + "," +
            Convert.ToCsvString(ChainsToEnemies) + "," +
            Convert.ToCsvString(ChainBullets) + "," +
            Convert.ToCsvString(ChainSpread) + "," +
            Convert.ToCsvString(ChainTravelDistance) + "," +
            Convert.ToCsvString(ChainBullet) + "," +
            Convert.ToCsvString(ExecuteChainSpecialCase) + "," +
            Convert.ToCsvString(DamagePercentStart) + "," +
            Convert.ToCsvString(DamagePercentEnd) + "," +
            Convert.ToCsvString(DamagesConstantlyTickDelay) + "," +
            Convert.ToCsvString(FreezeStrength) + "," +
            Convert.ToCsvString(FreezeDurationMS) + "," +
            Convert.ToCsvString(StunLengthMS) + "," +
            Convert.ToCsvString(ScaleStart) + "," +
            Convert.ToCsvString(ScaleEnd) + "," +
            Convert.ToCsvString(AttractsPet) + "," +
            Convert.ToCsvString(LifeStealPercent) + "," +
            Convert.ToCsvString(PassesEnvironment) + "," +
            Convert.ToCsvString(PoisonDamagePercent) + "," +
            Convert.ToCsvString(DamageOnlyWithOneProj) + "," +
            Convert.ToCsvString(HealOwnPercent) + "," +
            Convert.ToCsvString(CanGrowStronger) + "," +
            Convert.ToCsvString(HideFaster) + "," +
            Convert.ToCsvString(GrapplesEnemy) + "," +
            Convert.ToCsvString(KickBack) + "," +
            Convert.ToCsvString(UseColorMod) + "," +
            Convert.ToCsvString(RedAdd) + "," +
            Convert.ToCsvString(GreenAdd) + "," +
            Convert.ToCsvString(BlueAdd) + "," +
            Convert.ToCsvString(RedMul) + "," +
            Convert.ToCsvString(GreenMul) + "," +
            Convert.ToCsvString(BlueMul) + "," +
            Convert.ToCsvString(GroundBasis) + "," +
            Convert.ToCsvString(MinDistanceForSpread) + "," +
            Convert.ToCsvString(IsFriendlyHomingMissile) + "," +
            Convert.ToCsvString(IsBoomerang) + "," +
            Convert.ToCsvString(CanHitAgainAfterBounce) + "," +
            Convert.ToCsvString(IsHomingMissile) + "," +
            Convert.ToCsvString(BlockUltiCharge) + "," +
            Convert.ToCsvString(PoisonType) + "," +
            Convert.ToCsvString(TravelType) + "," +
            Convert.ToCsvString(SteerStrength) + "," +
            Convert.ToCsvString(SteerIgnoreTicks) + "," +
            Convert.ToCsvString(HomeDistance) + "," +
            Convert.ToCsvString(SteerLifeTime) + "\n";
        }
    }
}