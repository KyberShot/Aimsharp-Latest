using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Globalization;
using AimsharpWow.API; //needed to access Aimsharp API

namespace AimsharpWow.Modules
{
    public class VengeanceShadowlands : Rotation
    {  string addonName;
       bool DebugMode;
       int Counter = 0;

        //Spells
        List<string> VengeanceSpells = new List<string>{
            "Demon Spikes","Fiery Brand","Immolation Aura","Fracture","Spirit Bomb","Soul Cleave","Sigil of Flame","Throw Glaive","Metamorphosis",
            "Fel Devastation","Shear", "Infernal Strike","Bulk Extraction","Felblade","Soul Barrier","Sigil of Misery","Arcane Torrent",
            "Sigil of Silence","Sigil of Chains","Consume Magic"
        };

        List<string> VengeanceBuffs = new List<string>{
            "Metamorphosis","Demon Spikes","Soul Fragments","Fel Bombardment","Immolation Aura","Blessing of Protection","Magic"
        };

        List<string> VengeanceDebuffs = new List<string>{
            "Spirit Bomb","Imprison","Sinful Brand","Fiery Brand","Sigil of Flame"
        };

        List<string> BloodlustEffects = new List<string>
        {
            "Bloodlust","Heroism","Time Warp","Primal Rage","Drums of Rage"
        };

        List<string> CovenantAbilities = new List<string>
        {
            "Sinful Brand","The Hunt","Elysian Decree"
        };


        public override void LoadSettings()
        {
            Settings.Add(new Setting("General Settings"));
            Settings.Add(new Setting("Debug Mode: ", false));
            Settings.Add(new Setting("Latency: ", 0, 1000, 40));
            Settings.Add(new Setting("Quick Delay: ", 50, 1000, 100));
            Settings.Add(new Setting("Slow Delay: ", 50, 1000, 250));
            Settings.Add(new Setting("First 5 Letter of your Addon:", "xxxxx"));
            Settings.Add(new Setting("Use Top Trinket:", false));
            Settings.Add(new Setting("Use Bottom Trinket:", false));
            Settings.Add(new Setting("Use DPS Potion:", false));
            Settings.Add(new Setting("Potion name:", "Potion of Phantom Fire"));
            Settings.Add(new Setting("Use Arcane Torrent", false));
            Settings.Add(new Setting("Auto Consume Magic?", false));
            Settings.Add(new Setting("Sigils are @player by default"));
            Settings.Add(new Setting("Use Elysian Decree @cursor instead?", false));
            Settings.Add(new Setting("Use Sigil of Flame @cursor instead?", false));
            Settings.Add(new Setting("Use Sigil of Misery @cursor instead?", false));
            Settings.Add(new Setting("Use Sigil of Silence @cursor instead?", false));
            Settings.Add(new Setting("Use Sigil of Chains @cursor instead?", false));
            Settings.Add(new Setting("Auto Felblade?", false));
            Settings.Add(new Setting("Spell Queues"));
            Settings.Add(new Setting("/xxxxx UseMisery"));
            Settings.Add(new Setting("/xxxxx UseSilence"));
            Settings.Add(new Setting("/xxxxx UseChains"));
            Settings.Add(new Setting("/xxxxx UseElysian"));
            Settings.Add(new Setting("/xxxxx UseFiery"));
            Settings.Add(new Setting("/xxxxx UseFelDev"));
            Settings.Add(new Setting(""));

        }

        public override void Initialize()
        {
            DebugMode = GetCheckBox("Debug Mode: ");
            Aimsharp.DebugMode(DebugMode);
            Aimsharp.PrintMessage("Kyber Vengenace DH V3.3", Color.Blue);
            Aimsharp.PrintMessage("These macros can be used for manual control:", Color.Blue);
            Aimsharp.PrintMessage("/xxxxx SaveCovenant", Color.Blue);
            Aimsharp.PrintMessage("--Toggles the use of Covenant abilities on/off.", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("/xxxxx AOE", Color.Blue);
            Aimsharp.PrintMessage("--Toggles AOE mode on/off.", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("/xxxxx SaveMeta", Color.Blue);
            Aimsharp.PrintMessage("--Toggles the use of Metamorphosis on/off.", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("/xxxxx AutoInfernal", Color.Blue);
            Aimsharp.PrintMessage("--Toggles the use of Infernal Strike on/off.", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("/xxxxx SaveFiery", Color.Blue);
            Aimsharp.PrintMessage("--Toggles the use of Fiery Brand on/off.", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("/xxxxx SaveFelDev", Color.Blue);
            Aimsharp.PrintMessage("--Toggles the use of Fel Devastation on/off.", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("--Replace xxxxx with first 5 letters of your addon, lowercase.", Color.Blue);

            Aimsharp.Latency    = GetSlider("Latency: ");
            Aimsharp.QuickDelay = GetSlider("Quick Delay: ");
            Aimsharp.SlowDelay  = GetSlider("Slow Delay: ");
            DebugMode           = GetCheckBox("Debug Mode: ");
            

            //Main Skills
            foreach (string Spell in VengeanceSpells){
                if (DebugMode) {
                    Aimsharp.PrintMessage("Adding " + Spell + " to the Spellbook");
                }

                Spellbook.Add(Spell);
            }

            //Covenant
            foreach (string Spell in CovenantAbilities){
            if (DebugMode) {
                    Aimsharp.PrintMessage("Adding " + Spell + " to the Spellbook");
                }

                Spellbook.Add(Spell);
            }

            //Buffs
            foreach (string Buff in VengeanceBuffs){
                if (DebugMode) {
                    Aimsharp.PrintMessage("Adding " + Buff + " to the Bufflist");
                }

                Buffs.Add(Buff);
            }

            //Debuffs
            foreach (string Debuff in VengeanceDebuffs){
                if (DebugMode) {
                    Aimsharp.PrintMessage("Adding " + Debuff + " to the Debufflist");
                }

                Debuffs.Add(Debuff);
            }


            foreach (string Buff in BloodlustEffects){
                if (DebugMode) {
                    Aimsharp.PrintMessage("Adding " + Buff + " to the Bufflist");
                }

                Buffs.Add(Buff);
            }
            

            addonName = GetString("First 5 Letter of your Addon:");

            Items.Add(GetString("Potion name:"));

            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BottomTrinket", "/use 14");
            Macros.Add("DPS Pot", "/use " + GetString("Potion name:"));

            Macros.Add("sigil self", "/cast [@player] Sigil of Flame");
            Macros.Add("Elysian self", "/cast [@player] Elysian Decree");
            Macros.Add("sigilC", "/cast [@cursor] Sigil of Flame");
            Macros.Add("ElysianC", "/cast [@cursor] Elysian Decree");
            Macros.Add("infernal self","/cast [@player] Infernal Strike");
            Macros.Add("Phial of Serenity Self", "/use Phial of Serenity");
            Macros.Add("ElysianDisable", "/" + addonName + " UseElysian");
            Macros.Add("FieryDisable", "/" + addonName + " UseFiery");
            Macros.Add("FelDevDisable", "/" + addonName + " UseFelDev");
            Macros.Add("SigilMDisable", "/" + addonName + " UseMisery");
            Macros.Add("SigilSDisable", "/" + addonName + " UseSilence");
            Macros.Add("SigilCDisable", "/" + addonName + " UseChains");
            Macros.Add("SigilMC", "/cast [@cursor] Sigil of Misery");
            Macros.Add("SigilMSelf", "/cast [@player] Sigil of Misery");
            Macros.Add("SigilSC", "/cast [@cursor] Sigil of Silence");
            Macros.Add("SigilSSelf", "/cast [@player] Sigil of Silence");
            Macros.Add("SigilCC", "/cast [@cursor] Sigil of Chains");
            Macros.Add("SigilCSelf", "/cast [@player] Sigil of Chains");
            Macros.Add("BoP Killer", "/cancelaura Blessing of Protection");


            CustomCommands.Add("AOE");
            CustomCommands.Add("SaveCovenant");
            CustomCommands.Add("SaveFiery");
            CustomCommands.Add("SaveFelDev");
            CustomCommands.Add("UseFiery");
            CustomCommands.Add("UseMisery");
            CustomCommands.Add("UseSilence");
            CustomCommands.Add("UseChains");
            CustomCommands.Add("UseElysian");
            CustomCommands.Add("UseFelDev");
            CustomCommands.Add("SaveMeta");
            CustomCommands.Add("AutoInfernal");
            CustomCommands.Add("SaveDS");
            
            CustomFunctions.Add("MagicBuffCheck", "local y=0 \r\nfor i=1,25 do \r\n    local name,_,_,type=UnitBuff(\"target\",i); \r\n    if type ~= nil and type == \"Magic\" then\r\n        y = y + 1; \r\n    end \r\n end return y");
            CustomFunctions.Add("ThreatStatus", "if (UnitDetailedThreatSituation(\"player\", \"target\"))\nthen\nreturn 1;\nend\nreturn 0;");
            CustomFunctions.Add("GetLegendarySpellID", "local power = 0 for i=1,15,1 do local xcs = ItemLocation:CreateFromEquipmentSlot(i) if(C_Item.DoesItemExist(xcs)) then if(C_LegendaryCrafting.IsRuneforgeLegendary(xcs)) then local id = C_LegendaryCrafting.GetRuneforgeLegendaryComponentInfo(xcs)[\"powerID\"] power = C_LegendaryCrafting.GetRuneforgePowerInfo(id)[\"descriptionSpellID\"] end end end return power");       
        }

        public override bool CombatTick()
        {
            int GCD = Aimsharp.GCD();
            float Haste = Aimsharp.Haste() / 100f;
            int GCDMAX = (int)(1500f / (Haste + 1f));
            int Latency = Aimsharp.Latency;
            string LastCast = Aimsharp.LastCast();
            bool Moving = Aimsharp.PlayerIsMoving();
            bool Fighting = Aimsharp.Range("target") <= 8 && Aimsharp.TargetIsEnemy();
            bool Pulling = Aimsharp.Range("target") <= 30 && Aimsharp.TargetIsEnemy();//used for pulling mobs with throw glaive and NightFae Covenant
            bool SigilDrop = Aimsharp.Range("target") <= 4 && Aimsharp.TargetIsEnemy();//only used for sigils and kyrian covenant
            bool CursorSigilsRange = Aimsharp.Range("target") <= 30 && Aimsharp.TargetIsEnemy();
            bool TargetIsEnemy = Aimsharp.TargetIsEnemy();
            bool IsChanneling = Aimsharp.IsChanneling("player");
            int EnemiesInMelee = Aimsharp.EnemiesInMelee();
            int RangeToTarget = Aimsharp.Range("target");
            int selfhealth = Aimsharp.Health("player");
            bool TargetIsBoss = Aimsharp.TargetIsBoss();
            string PotionName = GetString("Potion name:");
            

            //custom settings
            bool UsePotion = GetCheckBox("Use DPS Potion:");
            bool UseTopTrinket = GetCheckBox("Use Top Trinket:");
            bool UseBottomTrinket = GetCheckBox("Use Bottom Trinket:");
            bool UseTorrent = GetCheckBox("Use Arcane Torrent");
            bool AutoConsume = GetCheckBox("Auto Consume Magic?");
            bool CursorElysian = GetCheckBox("Use Elysian Decree @cursor instead?");
            bool CursorFlame = GetCheckBox("Use Sigil of Flame @cursor instead?");
            bool CursorChains = GetCheckBox("Use Sigil of Chains @cursor instead?");
            bool CursorMisery = GetCheckBox("Use Sigil of Misery @cursor instead?");
            bool CursorSilence = GetCheckBox("Use Sigil of Silence @cursor instead?");
            bool AutoFelblade = GetCheckBox("Auto Felblade?");
            bool UseElysian = Aimsharp.IsCustomCodeOn("UseElysian");
            bool UseFiery = Aimsharp.IsCustomCodeOn("UseFiery");
            bool UseFelDev = Aimsharp.IsCustomCodeOn("UseFelDev");
            bool UseMisery = Aimsharp.IsCustomCodeOn("UseMisery");
            bool UseSilence = Aimsharp.IsCustomCodeOn("UseSilence");
            bool UseChains = Aimsharp.IsCustomCodeOn("UseChains");
            bool SaveFiery = Aimsharp.IsCustomCodeOn("SaveFiery");
            bool SaveDS = Aimsharp.IsCustomCodeOn("SaveDS");
            bool SaveFelDev = Aimsharp.IsCustomCodeOn("SaveFelDev");
            bool SaveMeta = Aimsharp.IsCustomCodeOn("SaveMeta");
            bool AutoInfernal = Aimsharp.IsCustomCodeOn("AutoInfernal");
            bool BrandBuild = (Aimsharp.Talent(1, 2) && Aimsharp.Talent(2, 3) && Aimsharp.Talent(3, 2));
            bool AOE = Aimsharp.IsCustomCodeOn("AOE");
            bool SaveCovenant = Aimsharp.IsCustomCodeOn("SaveCovenant");

            int ThreatStatus = Aimsharp.CustomFunction("ThreatStatus");
            bool Istanking = ThreatStatus == 1;
            bool LowAggro = ThreatStatus == 0;

            //Target time to die
            int TargetHealth = Aimsharp.Health("target");
            int TargetMaxHP = Aimsharp.TargetMaxHP();
            int TargetCurrentHP = Aimsharp.TargetCurrentHP();
            int Time = Aimsharp.CombatTime();
            var TargetDamageTakenPerSecond = (TargetMaxHP - TargetCurrentHP) / (Math.Floor((double)Time / 1000));
            int TargetTimeToDie = (int)Math.Ceiling(TargetCurrentHP / TargetDamageTakenPerSecond);

            //Covenants
            int CovenantID = Aimsharp.CovenantID();
            bool Kyrian = CovenantID == 1;
            bool Venthyr = CovenantID == 2;
            bool NightFae = CovenantID == 3;
            bool Necrolord = CovenantID == 4;
            bool NoCovenant = CovenantID == 0;

            //legendary effects 
            int LegendaryID = Aimsharp.CustomFunction("GetLegendarySpellID");
            bool LegendaryFelBombardment = LegendaryID == 337775;
            bool LegendaryRazelikhsDefilement = LegendaryID == 337544;

            //Conduits & Soulbinds
            List<int> ActiveConduits = new List<int>();

            //Conduits
            bool ConduitBroodingPool = ActiveConduits.Contains(340063);

            //Soulbinds
            bool SoulbindAscendantPhial = ActiveConduits.Contains(329776);
            

            bool BloodlustUp = false;
            foreach (string BloodlustEffect in BloodlustEffects)
            {
                if (Aimsharp.HasBuff(BloodlustEffect))
                {
                    BloodlustUp = true;
                    break;
                }
            }

            //player power
            int Fury = Aimsharp.Power("player");
            int FuryDefecit = Aimsharp.PlayerMaxPower() - Fury;

            //Talents
            bool TalentFracture = Aimsharp.Talent(4, 3);
            bool SpiritBombEnabled = Aimsharp.Talent(3, 3);
            bool TalentBulkExtraction = Aimsharp.Talent(7, 3);
            bool TalentFelblade = Aimsharp.Talent(1, 3);
            bool TalentSoulBarrier = Aimsharp.Talent(6, 3);
            bool TalentAgonizingFlames = Aimsharp.Talent(1, 2);
            bool TalentBurningAlive = Aimsharp.Talent(2, 3);
            bool TalentCharredFlesh = Aimsharp.Talent(3, 2);
            bool TalentAbyssalStrike = Aimsharp.Talent(1, 1);
            bool TalentFallout = Aimsharp.Talent(2, 2);
            bool TalentDemonic = Aimsharp.Talent(6, 2);

            //CD's 
            int FelDevastationCDRemaining = Aimsharp.SpellCooldown("Fel Devastation") - GCD;
            bool FelDevastationCDReady = FelDevastationCDRemaining <= 10;
            int FelbladeCDRemaining = Aimsharp.SpellCooldown("Felblade") - GCD;
            bool FelbladeCDReady = FelbladeCDRemaining <= 10;
            int FractureCharges = Aimsharp.SpellCharges("Fracture");
            int ImmolationAuraCDRemaining = Aimsharp.SpellCooldown("Immolation Aura") - GCD;
            bool ImmolationAuraCDReady = ImmolationAuraCDRemaining <= 10;
            int FieryBrandCDRemaining = Aimsharp.SpellCooldown("Fiery Brand") - GCD;
            bool FieryBrandCDReady = FieryBrandCDRemaining <= 10;
            int SigilCDRemaining = Aimsharp.SpellCooldown("Sigil of Flame") - GCD;
            bool SigilCDReady = SigilCDRemaining <= 10;
            int MetaCDRemaining = Aimsharp.SpellCooldown("Metamorphosis") - GCD;
            bool MetaCDReady = MetaCDRemaining <= 10;
            int InfernalCharges = Aimsharp.SpellCharges("Infernal Strike");
            int InfernalRechargeTime = Aimsharp.RechargeTime("Infernal Strike");
            int DemonSpikeCharges = Aimsharp.SpellCharges("Demon Spikes");
            int DpsPotionCdRemaining = Aimsharp.ItemCooldown(GetString("Potion name:"));
            bool DpsPotionCdReady = DpsPotionCdRemaining <= 10;
            int BulkExtractionCDRemaining = Aimsharp.SpellCooldown("Bulk Extraction") - GCD;
            bool BulkExtractionCDReady = BulkExtractionCDRemaining <= 10;
            int TheHuntCDRemaining = Aimsharp.SpellCooldown("The Hunt") - GCD;
            bool TheHuntCDReady = TheHuntCDRemaining <= 10;
            int ElysianDecreeCDRemaining = Aimsharp.SpellCooldown("Elysian Decree") - GCD;
            bool ElysianDecreeCDReady = ElysianDecreeCDRemaining <= 10;
            int SinfulBrandCDRemaining = Aimsharp.SpellCooldown("Sinful Brand") - GCD;
            bool SinfulBrandCDReady = SinfulBrandCDRemaining <= 10;
            int TopTrinketCdRemaining = Aimsharp.TrinketCooldown(13);
            bool TopTrinketCdReady = TopTrinketCdRemaining <= 10;
            int BottomTrinketCdRemaining = Aimsharp.TrinketCooldown(14);
            bool BottomTrinketCdReady = BottomTrinketCdRemaining <= 10;
            int SigilofChainsCDRemaining = Aimsharp.SpellCooldown("Sigil of Chains") - GCD;
            bool SigilofChainsCDReady = SigilofChainsCDRemaining <= 10;
            int SigilofMiseryCDRemaining = Aimsharp.SpellCooldown("Sigil of Misery") - GCD;
            bool SigilofMiseryCDReady = SigilofMiseryCDRemaining <= 10;
            int SigilofSilenceCDRemaining = Aimsharp.SpellCooldown("Sigil of Silence") - GCD;
            bool SigilofSilenceCDReady = SigilofSilenceCDRemaining <= 10;
         
            //Buffs
            bool SinfulDebuffUp = Aimsharp.HasDebuff("Sinful Brand");
            bool BuffSoulFragmentUp = Aimsharp.HasBuff("Soul Fragments");
            int SoulFragStacks = Aimsharp.BuffStacks("Soul Fragments");
            int MetaRemains = Aimsharp.BuffRemaining("Metamorphosis");
            bool MetaUp = MetaRemains > 0;
            bool BuffImmolationAuraUp = Aimsharp.HasBuff("Immolation Aura");
            int FelBombardmentStacks = Aimsharp.BuffStacks("Fel Bombardment");
            bool DemonSpikesUp = Aimsharp.HasBuff("Demon Spikes");
            bool MagicBuff = Aimsharp.HasBuff("", "target", false, "Magic");

            //Debuffs
            bool DebuffFieryBrandUp = Aimsharp.HasDebuff("Fiery Brand");
            int DebuffSigilofFlameRemains = Aimsharp.DebuffRemaining("Sigil of Flame");

            //Spirit Bomb
            int DebuffSpiritBombRemains = Aimsharp.BuffRemaining("Spirit Bomb") - GCD;
            bool DebuffSpiritBombUp = DebuffSpiritBombRemains > 0;

            if (DebugMode && Counter >= 200){
            Aimsharp.PrintMessage("PlayerSpec " + Aimsharp.GetSpec("player").ToString());
            Aimsharp.PrintMessage("PlayerRace " + Aimsharp.GetPlayerRace().ToString());
            Aimsharp.PrintMessage("CovenantID " + Aimsharp.CovenantID().ToString());
            Aimsharp.PrintMessage("LegendaryID " + Aimsharp.CustomFunction("GetLegendarySpellID").ToString());
            Aimsharp.PrintMessage("ThreatStatus " + Aimsharp.CustomFunction("ThreatStatus").ToString());
            Aimsharp.PrintMessage("IsTanking " + Istanking);
            Aimsharp.PrintMessage("Haste  " + Aimsharp.Haste());
            Aimsharp.PrintMessage("Crit  " + Aimsharp.Crit());
            Aimsharp.PrintMessage("Soul Fragments " + Aimsharp.BuffStacks("Soul Fragments"));
            Aimsharp.PrintMessage("SpiritBomb Enabled " + Aimsharp.Talent(3, 3));
            Aimsharp.PrintMessage("Fracture Enabled " + Aimsharp.Talent(4, 3));
            Aimsharp.PrintMessage("AgonizingFlames Enabled " + Aimsharp.Talent(1, 2));
            Aimsharp.PrintMessage("BurningAlive Enabled " + Aimsharp.Talent(2, 3));
            Aimsharp.PrintMessage("CharredFlesh Enabled " + Aimsharp.Talent(3, 2));
            Aimsharp.PrintMessage("Brand Build Enabled " + (Aimsharp.Talent(1, 2) && Aimsharp.Talent(2, 3) && Aimsharp.Talent(3, 2)));
            Aimsharp.PrintMessage("My Health Percent " + Aimsharp.Health("player"));
            Aimsharp.PrintMessage("Fury " + Aimsharp.Power("player"));
            Aimsharp.PrintMessage("TargetTimeToDie " + TargetTimeToDie);
            Aimsharp.PrintMessage("EnemiesInMelee " + Aimsharp.EnemiesInMelee());
            Aimsharp.PrintMessage("TargetIsBoss " + Aimsharp.TargetIsBoss());
            Aimsharp.PrintMessage("Targets UnitID " + Aimsharp.UnitID("target"));
            Aimsharp.PrintMessage("Focus UnitID " + Aimsharp.UnitID("focus"));
            Aimsharp.PrintMessage("boss1  UnitID " + Aimsharp.UnitID("boss1"));
            Aimsharp.PrintMessage("boss2  UnitID " + Aimsharp.UnitID("boss2"));
            Aimsharp.PrintMessage("boss3  UnitID " + Aimsharp.UnitID("boss3"));
            Aimsharp.PrintMessage("boss4  UnitID " + Aimsharp.UnitID("boss4"));
            Aimsharp.PrintMessage(Aimsharp.CustomFunction("MagicBuffCheck").ToString());
            Counter = 0;
            }else{
            Counter++;
            }


            if (!AOE)
            {
                EnemiesInMelee = EnemiesInMelee > 0 ? 1 : 0;
            }

            if (IsChanneling)
                return false;

            if (Aimsharp.HasDebuff("Imprison"))
                return false;

            if(AutoConsume && Aimsharp.CanCast("Consume Magic", "target") && Aimsharp.CustomFunction("MagicBuffCheck") != 0){
                Aimsharp.Cast("Consume Magic");
                return true;
            }

            if(Aimsharp.HasBuff("Blessing of Protection", "player", false)){
                Aimsharp.Cast("BoP Killer");
                Aimsharp.PrintMessage("Removed BoP");
                return true;
            }

            if(UseElysian && (LastCast == "Elysian Decree" || ElysianDecreeCDRemaining > 30000)){
                Aimsharp.Cast("ElysianDisable");
                return true;
            }

            if(UseFiery && (LastCast == "Fiery Brand" || FieryBrandCDRemaining > 15000)){
                Aimsharp.Cast("FieryDisable");
                return true;
            }

            if(UseFelDev && (LastCast == "Fel Devastation" || FelDevastationCDRemaining > 15000)){
                Aimsharp.Cast("FelDevDisable");
                return true;
            }

            if(UseChains && (LastCast == "Sigil of Chains" || SigilofChainsCDRemaining > 15000)){
                Aimsharp.Cast("SigilCDisable");
                return true;
            }

            if(UseSilence && (LastCast == "Sigil of Silence" || SigilofSilenceCDRemaining > 15000)){
                Aimsharp.Cast("SigilSDisable");
                return true;
            }

            if(UseMisery && (LastCast == "Sigil of Misery" || SigilofMiseryCDRemaining > 15000)){
                Aimsharp.Cast("SigilMDisable");
                return true;
            }

            if (!CursorChains && UseChains){
            if (Aimsharp.CanCast("Sigil of Chains", "player") && SigilDrop && SigilofChainsCDReady) {
                Aimsharp.Cast("SigilCSelf");
                return true; 
                }
            } 
            
            if (CursorChains && UseChains){
            if (Aimsharp.CanCast("Sigil of Chains", "player") && CursorSigilsRange && SigilofChainsCDReady) {
                Aimsharp.Cast("SigilCC");
                return true; 
                }
            } 

            if (!CursorMisery && UseMisery){
            if (Aimsharp.CanCast("Sigil of Misery", "player") && SigilDrop && SigilofMiseryCDReady) {
                Aimsharp.Cast("SigilMSelf");
                return true; 
                }
            } 
            
            if (CursorMisery && UseMisery){
            if (Aimsharp.CanCast("Sigil of Misery", "player") && CursorSigilsRange && SigilofMiseryCDReady) {
                Aimsharp.Cast("SigilMC");
                return true; 
                }
            } 

            if (!CursorSilence && UseSilence){
            if (Aimsharp.CanCast("Sigil of Silence", "player") && SigilDrop && SigilofSilenceCDReady) {
                Aimsharp.Cast("SigilSSelf");
                return true; 
                }
            } 
            
            if (CursorSilence && UseSilence){
            if (Aimsharp.CanCast("Sigil of Silence", "player") && CursorSigilsRange && SigilofSilenceCDReady) {
                Aimsharp.Cast("SigilSC");
                return true; 
                }
            }

            if (UseTorrent && Aimsharp.CanCast("Arcane Torrent") && Fighting && Fury <= 50){
                Aimsharp.Cast("Arcane Torrent");
                return true;
            }


            if (Aimsharp.CanCast("Throw Glaive") && Fighting){
            if (LegendaryFelBombardment && FelBombardmentStacks == 5 && (BuffImmolationAuraUp || !MetaUp)){
                Aimsharp.Cast("Throw Glaive");
                return true;}
            }

            if (BrandBuild)
            {

            if (Aimsharp.CanCast("Fiery Brand") && Fighting && FieryBrandCDReady && (!SaveFiery || UseFiery)){
                Aimsharp.Cast("Fiery Brand");
                return true;
            }
                
            if (Aimsharp.CanCast("Immolation Aura", "player") && Fighting && ImmolationAuraCDReady && DebuffFieryBrandUp && !BuffImmolationAuraUp){
                Aimsharp.Cast("Immolation Aura");
                return true;
                }
            }

            if (Aimsharp.CanCast("Demon Spikes") && Fighting && !DebuffFieryBrandUp && !(FieryBrandCDRemaining < 5000) && !SaveDS){
            if (!DemonSpikesUp){
                Aimsharp.Cast("Demon Spikes");
                return true;}
            }

            if (Aimsharp.CanCast("Soul Barrier", "player") && Fighting && TalentSoulBarrier){
            if (EnemiesInMelee > 3 && !DemonSpikesUp || selfhealth <= 60){
                Aimsharp.Cast("Soul Barrier");
                return true;}
            }

            if (!SaveMeta){
            if (Aimsharp.CanCast("Metamorphosis") && Fighting){
            if (!Venthyr && selfhealth <= 30 || Venthyr && !SinfulDebuffUp){
                Aimsharp.Cast("Metamorphosis");
                return true;}
                }
            }
                
            if (Aimsharp.CanCast("Fiery Brand") && Fighting && FieryBrandCDReady && (!SaveFiery || UseFiery)){
                Aimsharp.Cast("Fiery Brand");
                return true;
            }

            if (UsePotion && Aimsharp.CanUseItem(PotionName, false) && DpsPotionCdReady){
                Aimsharp.Cast("DPS Pot", true);
                return true;
            }

            if (Aimsharp.CanUseTrinket(0) && UseTopTrinket && Fighting && TopTrinketCdReady){
                Aimsharp.Cast("TopTrinket", true);
                return true;
            }
                
            if (Aimsharp.CanUseTrinket(1) && UseBottomTrinket && Fighting && BottomTrinketCdReady){
                Aimsharp.Cast("BottomTrinket", true);
                return true;
            }

            if (UseElysian || !SaveCovenant){
            if (!CursorElysian){
            if (Kyrian && Aimsharp.CanCast("Elysian Decree", "player") && SigilDrop && ElysianDecreeCDReady){
                Aimsharp.Cast("Elysian self");
                return true;}
            }
            if (CursorElysian){
                if (Kyrian && Aimsharp.CanCast("Elysian Decree", "player") && CursorSigilsRange && ElysianDecreeCDReady){
                Aimsharp.Cast("ElysianC");
                return true;}
                }
            }
            
            if (Venthyr && Aimsharp.CanCast("Sinful Brand") && Fighting && !SinfulDebuffUp && SinfulBrandCDReady && !SaveCovenant){
                Aimsharp.Cast("Sinful Brand");
                return true;
            }
            
            if (NightFae && Aimsharp.CanCast("The Hunt") && Pulling && !Moving && TheHuntCDReady && !SaveCovenant){
                Aimsharp.Cast("The Hunt");
                return true;
            }

            if (Aimsharp.CanCast("Infernal Strike", "player") && Fighting && AutoInfernal){
            if (InfernalRechargeTime < 1000 && (!TalentAbyssalStrike || DebuffSigilofFlameRemains < 3)){
                Aimsharp.Cast("infernal self");
                return true;}
            }
            
            if (Aimsharp.CanCast("Bulk Extraction", "player") && Fighting && TalentBulkExtraction && BulkExtractionCDReady) {
                Aimsharp.Cast("Bulk Extraction");
                return true;
            }  
            
            if (Aimsharp.CanCast("Spirit Bomb", "player") && Fighting && SpiritBombEnabled) {
            if (((MetaUp && TalentFracture && SoulFragStacks >=3) || SoulFragStacks >=4)) {
                Aimsharp.Cast("Spirit Bomb");
                return true; 
                }
            }  
            
            if (Aimsharp.CanCast("Fel Devastation", "player") && Fighting && FelDevastationCDReady && (!SaveFelDev || UseFelDev)) {
                Aimsharp.Cast("Fel Devastation");
                return true;
            } 
            
            if (Aimsharp.CanCast("Soul Cleave") && Fighting) {
            if (((SpiritBombEnabled && SoulFragStacks == 0) || !SpiritBombEnabled) && ((TalentFracture && Fury >= 55) || (!TalentFracture && Fury >= 70) || FelDevastationCDRemaining > TargetTimeToDie || (MetaUp && ((TalentFracture && Fury >= 35) || (!TalentFracture && Fury >= 50))))) {
                Aimsharp.Cast("Soul Cleave");
                return true; }
            } 
            
            if (Aimsharp.CanCast("Immolation Aura", "player") && Fighting && ImmolationAuraCDReady && !BuffImmolationAuraUp) {
            if (((BrandBuild && FieryBrandCDRemaining > 10000) || !BrandBuild && Fury <= 90)) {
                Aimsharp.Cast("Immolation Aura");
                return true; }
            }  
            
            if (AutoFelblade && Aimsharp.CanCast("Felblade") && TalentFelblade && FelbladeCDReady) {
            if (Fury <= 60) {
                Aimsharp.Cast("Felblade");
                return true; }
            } 
            
            if (Aimsharp.CanCast("Fracture", "player") && Fighting && TalentFracture) {
            if (Fury < 30 || ((SpiritBombEnabled && SoulFragStacks <= 3) || (!SpiritBombEnabled && ((MetaUp && Fury <= 55) || (!MetaUp && Fury <= 70))))) {
                Aimsharp.Cast("Fracture");
                return true; }
            } 
            
            if (!CursorFlame){
            if (Aimsharp.CanCast("Sigil of Flame", "player") && SigilDrop && SigilCDReady) {
            if (!(Kyrian && LegendaryRazelikhsDefilement)) {
                Aimsharp.Cast("sigil self");
                return true; }
                }
            } 
            
            if (CursorFlame){
            if (Aimsharp.CanCast("Sigil of Flame", "player") && CursorSigilsRange && SigilCDReady) {
            if (!(Kyrian && LegendaryRazelikhsDefilement)) {
                Aimsharp.Cast("sigilC");
                return true; }
                }
            } 
            
            if (Aimsharp.CanCast("Shear") && !TalentFracture && Fighting) {
                Aimsharp.Cast("Shear");
                return true;
            } 

            if (Aimsharp.CanCast("Throw Glaive") && Fighting){
                Aimsharp.Cast("Throw Glaive");
                return true;
            }

            return false;
        }

        public override bool OutOfCombatTick()
        {

            return false;
        }
    }
}