using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API; //needed to access Aimsharp API


namespace AimsharpWow.Modules
{

    public class TrinityFuryWarriorRotation : Rotation
    {

        // Globale Einstellungen
        #region Statische variablen

        private static string Version = "1.1.2 (Community Version)";

        #region Sprache
        private static string PotionofSpectralAgility_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trank der Spektralbeweglichkeit";
                case "Español":
                    return "Poción de agilidad espectral";
                case "Français":
                    return "Potion d’agilité spectrale";
                case "Italiano":
                    return "Pozione dell'Agilità Spettrale";
                case "Português Brasileiro":
                    return "Poção da Agilidade Espectral";
                case "Русский":
                    return "Зелье призрачной ловкости";
                case "한국어":
                    return "유령 민첩성의 물약";
                case "简体中文":
                    return "幽魂敏捷药水";
                default:
                    return "Potion of Spectral Agility";
            }
        }
        private static string PotionofDeathlyFixation_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "PotionofDeathlyFixation";
                case "Español":
                    return "Poción de fijación mortífera";
                case "Français":
                    return "Potion de fixation mortelle";
                case "Italiano":
                    return "Pozione della Fissazione Letale";
                case "Português Brasileiro":
                    return "Poção de Fixação Mortal";
                case "Русский":
                    return "Зелье смертельной фиксации";
                case "한국어":
                    return "죽음을 부르는 집착의 물약";
                case "简体中文":
                    return "死亡偏执药水";
                default:
                    return "Potion of Deathly Fixation";
            }
        }
        private static string PotionofEmpoweredExorcisms_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trank des ermächtigten Exorzismus";
                case "Español":
                    return "Poción de exorcismos potenciados";
                case "Français":
                    return "Potion d’exorcismes renforcés";
                case "Italiano":
                    return "Pozione degli Esorcismi Potenziati";
                case "Português Brasileiro":
                    return "Poção dos Exorcismos Potencializados";
                case "Русский":
                    return "Зелье усиленного экзорцизма";
                case "한국어":
                    return "강화된 퇴마술의 물약";
                case "简体中文":
                    return "强化驱魔药水";
                default:
                    return "Potion of Empowered Exorcisms";
            }
        }
        private static string PotionofPhantomFire_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trank des Phantomfeuers";
                case "Español":
                    return "Poción de fuego fantasmal";
                case "Français":
                    return "Potion de feu fantomatique";
                case "Italiano":
                    return "Pozione del Fuoco Fantasma";
                case "Português Brasileiro":
                    return "Poção do Fogo Fantasma";
                case "Русский":
                    return "Зелье фантомного огня";
                case "한국어":
                    return "도깨비불의 물약";
                case "简体中文":
                    return "幻影火焰药水";
                default:
                    return "Potion of Phantom Fire";
            }
        }
        private static string PotionofUnbridledFury_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trank der ungezügelten Wut";
                case "Español":
                    return "Poción de furia desbocada";
                case "Français":
                    return "Potion de fureur débridée";
                case "Italiano":
                    return "Pozione della Furia Sfrenata";
                case "Português Brasileiro":
                    return "Potion de fureur débridée";
                case "Русский":
                    return "Зелье неукротимой ярости";
                case "한국어":
                    return "굴레를 벗어난 격노의 물약";
                case "简体中文":
                    return "无拘之怒药水";
                default:
                    return "Potion of Unbridled Fury";
            }
        }
        private static string SpectralFlaskofPower_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Spektralfl&auml;schchen der Macht";
                case "Español":
                    return "Frasco de poder espectral";
                case "Français":
                    return "Flacon spectral de puissance";
                case "Italiano":
                    return "Tonico del Potere Spettrale";
                case "Português Brasileiro":
                    return "Frasco de Poder Espectral";
                case "Русский":
                    return "Призрачный настой силы";
                case "한국어":
                    return "권능의 유령 영약";
                case "简体中文":
                    return "幽魂强能合剂";
                default:
                    return "Spectral Flask of Power";
            }
        }
        private static string SpiritualHealingPotion_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Spiritueller Heiltrank";
                case "Español":
                    return "Poción de sanación espiritual";
                case "Français":
                    return "Potion de soins spirituels";
                case "Italiano":
                    return "Pozione di Cura Spirituale";
                case "Português Brasileiro":
                    return "Poción de sanación espiritual";
                case "Русский":
                    return "Духовное зелье исцеления";
                case "한국어":
                    return "영적인 치유 물약";
                case "简体中文":
                    return "灵魂治疗药水";
                default:
                    return "Spiritual Healing Potion";
            }
        }
        private static string PotionofSpectralStrength_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trank der Spektralstärke";
                case "Español":
                    return "Poción de fuerza espectral";
                case "Français":
                    return "Potion de Force spectrale";
                case "Italiano":
                    return "Pozione della Forza Spettrale";
                case "Português Brasileiro":
                    return "Poção da Força Espectral";
                case "Русский":
                    return "Зелье призрачной силы";
                case "한국어":
                    return "유령 힘의 물약";
                case "简体中文":
                    return "幽魂力量药水";
                default:
                    return "Potion of Spectral Strength";
            }
        }
        private static string Healthstone_ItemName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gesundheitsstein";
                case "Español":
                    return "Piedra de salud";
                case "Français":
                    return "Pierre de soins";
                case "Italiano":
                    return "Pietra della Salute";
                case "Português Brasileiro":
                    return "Pedra de Vida";
                case "Русский":
                    return "Камень здоровья";
                case "한국어":
                    return "생명석";
                case "简体中文":
                    return "治疗石";
                default:
                    return "Healthstone";
            }
        }

        private static string WilloftheBerserker_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Wille des Berserkers";
                case "Español":
                    return "Voluntad del rabioso";
                case "Français":
                    return "Volonté du berserker";
                case "Italiano":
                    return "Volontà del Berserker";
                case "Português Brasileiro":
                    return "Determinação do Berserker";
                case "Русский":
                    return "Воля берсерка";
                case "한국어":
                    return "광전사의 의지";
                case "简体中文":
                    return "狂暴意志";
                default:
                    return "Will of the Berserker";
            }
        }
        private static string Frenzy_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Raserei";
                case "Español":
                    return "Frenesí";
                case "Français":
                    return "Frénésie";
                case "Italiano":
                    return "Frenesia";
                case "Português Brasileiro":
                    return "Frenesi";
                case "Русский":
                    return "Бешенство";
                case "한국어":
                    return "광기";
                case "简体中文":
                    return "狂乱";
                default:
                    return "Frenzy";
            }
        }
        private static string firststrike_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Erstschlag";
                case "EspaÃ±ol":
                    return "Primer golpe";
                case "FranÃ§ais":
                    return "Frappe initiale";
                case "Italiano":
                    return "Primo Assalto";
                case "PortuguÃªs Brasileiro":
                    return "Primeiro Golpe";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Первый удар";
                case "í•œêµ­ì–´":
                    return "선제 공격";
                case "ç®€ä½“ä¸­æ–‡":
                    return "争先打击";
                default:
                    return "First Strike";
            }
        }
        private static string LightsJudgment_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Urteil des Lichts";
                case "Español":
                    return "Sentencia de la Luz";
                case "Français":
                    return "Jugement de la Lumière";
                case "Italiano":
                    return "Giudizio della Luce";
                case "Português Brasileiro":
                    return "Julgamento da Luz";
                case "Русский":
                    return "Правосудие Света";
                case "한국어":
                    return "빛의 심판";
                case "简体中文":
                    return "圣光裁决者";
                default:
                    return "Light's Judgment";
            }
        }
        private static string HeroicThrow_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Heldenhafter Wurf";
                case "Español":
                    return "Lanzamiento heroico";
                case "Français":
                    return "Lancer héroïque";
                case "Italiano":
                    return "Lancio Eroico";
                case "Português Brasileiro":
                    return "Arremesso Heroico";
                case "Русский":
                    return "Героический бросок";
                case "한국어":
                    return "영웅의 투척";
                case "简体中文":
                    return "英勇投掷";
                default:
                    return "Heroic Throw";
            }
        }
        private static string ShieldSlam_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schildschlag";
                case "Español":
                    return "Embate con escudo";
                case "Français":
                    return "Heurt de bouclier";
                case "Italiano":
                    return "Colpo di Scudo";
                case "Português Brasileiro":
                    return "Escudada";
                case "Русский":
                    return "Мощный удар щитом";
                case "한국어":
                    return "방패 밀쳐내기";
                case "简体中文":
                    return "盾牌猛击";
                default:
                    return "Shield Slam";
            }
        }
        private static string Slam_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zerschmettern";
                case "Español":
                    return "Embate";
                case "Français":
                    return "Heurtoir";
                case "Italiano":
                    return "Contusione";
                case "Português Brasileiro":
                    return "Batida";
                case "Русский":
                    return "Мощный удар";
                case "한국어":
                    return "격돌";
                case "简体中文":
                    return "猛击";
                default:
                    return "Slam";
            }
        }
        private static string Rally_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zusammenruf";
                case "EspaÃ±ol":
                    return "Convocar";
                case "FranÃ§ais":
                    return "Ralliement";
                case "Italiano":
                    return "Adunata";
                case "PortuguÃªs Brasileiro":
                    return "Reagrupamento";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Поддержка в бою";
                case "í•œêµ­ì–´":
                    return "집결";
                case "ç®€ä½“ä¸­æ–‡":
                    return "集结";
                default:
                    return "Rally";
            }
        }
        private static string Intervene_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Einschreiten";
                case "Español":
                    return "Intervenir";
                case "Français":
                    return "Intervention";
                case "Italiano":
                    return "Intervento";
                case "Português Brasileiro":
                    return "Comprar Briga";
                case "Русский":
                    return "Вмешательство";
                case "한국어":
                    return "가로막기";
                case "简体中文":
                    return "援护";
                default:
                    return "Intervene";
            }
        }
        private static string Berserking_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Berserker";
                case "EspaÃ±ol":
                    return "Rabiar";
                case "FranÃ§ais":
                    return "Berserker";
                case "Italiano":
                    return "Berserker";
                case "PortuguÃªs Brasileiro":
                    return "Berserk";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Берсерк";
                case "í•œêµ­ì–´":
                    return "광폭화";
                case "ç®€ä½“ä¸­æ–‡":
                    return "狂暴";
                default:
                    return "Berserking";
            }
        }
        private static string BerserkerRage_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Berserkerwut";
                case "Español":
                    return "Ira rabiosa";
                case "Français":
                    return "Rage de berserker";
                case "Italiano":
                    return "Furia del Berserker";
                case "Português Brasileiro":
                    return "Raiva Incontrolada";
                case "Русский":
                    return "Ярость берсерка";
                case "한국어":
                    return "광전사의 격노";
                case "简体中文":
                    return "狂暴之怒";
                default:
                    return "Berserker Rage";
            }
        }
        private static string Taunt_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Spott";
                case "Español":
                    return "Provocar";
                case "Français":
                    return "Provocation";
                case "Italiano":
                    return "Provocazione";
                case "Português Brasileiro":
                    return "Provocar";
                case "Русский":
                    return "Провокация";
                case "한국어":
                    return "도발";
                case "简体中文":
                    return "嘲讽";
                default:
                    return "Taunt";
            }
        }
        private static string ChallengingShout_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Herausforderungsruf";
                case "Español":
                    return "Grito desafiante";
                case "Français":
                    return "Cri de défi";
                case "Italiano":
                    return "Urlo di Sfida";
                case "Português Brasileiro":
                    return "Brado Desafiador";
                case "Русский":
                    return "Вызывающий крик";
                case "한국어":
                    return "도전의 외침";
                case "简体中文":
                    return "挑战怒吼";
                default:
                    return "Challenging Shout";
            }
        }
        private static string CrushingBlow_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schmetterschlag";
                case "Español":
                    return "Golpe aplastante";
                case "Français":
                    return "Coup écrasant";
                case "Italiano":
                    return "Colpo Devastante";
                case "Português Brasileiro":
                    return "Golpe Triturante";
                case "Русский":
                    return "Сокрушающий удар";
                case "한국어":
                    return "분쇄의 타격";
                case "简体中文":
                    return "碎甲猛击";
                default:
                    return "Crushing Blow";
            }
        }
        private static string Bloodbath_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Blutbad";
                case "Español":
                    return "Baño de sangre";
                case "Français":
                    return "Bain de sang";
                case "Italiano":
                    return "Bagno di Sangue";
                case "Português Brasileiro":
                    return "Banho de Sangue";
                case "Русский":
                    return "Кровавая баня";
                case "한국어":
                    return "피범벅";
                case "简体中文":
                    return "浴血奋战";
                default:
                    return "Bloodbath";
            }
        }
        private static string MercilessBonegrinder_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gnadenloser Knochenmahler";
                case "EspaÃ±ol":
                    return "Crujehuesos despiadado";
                case "FranÃ§ais":
                    return "Broyeur d’os impitoyable";
                case "Italiano":
                    return "Tritaossa Spietato";
                case "PortuguÃªs Brasileiro":
                    return "Esmaga-osso Inclemente";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Безжалостный костедробитель";
                case "í•œêµ­ì–´":
                    return "무자비한 해골분쇄자";
                case "ç®€ä½“ä¸­æ–‡":
                    return "无情碾骨";
                default:
                    return "Merciless Bonegrinder";
            }
        }
        private static string VictoryRush_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Siegesrausch";
                case "EspaÃ±ol":
                    return "Ataque de la victoria";
                case "FranÃ§ais":
                    return "Ivresse de la victoire";
                case "Italiano":
                    return "Frenesia di Vittoria";
                case "PortuguÃªs Brasileiro":
                    return "Ímpeto da Vitória";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Победный раж";
                case "í•œêµ­ì–´":
                    return "연전연승";
                case "ç®€ä½“ä¸­æ–‡":
                    return "乘胜追击";
                default:
                    return "Victory Rush";
            }
        }
        private static string MeatCleaver_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Metzger";
                case "EspaÃ±ol":
                    return "Cuchilla de carne";
                case "FranÃ§ais":
                    return "Fendoir à viande";
                case "Italiano":
                    return "Tritacarne";
                case "PortuguÃªs Brasileiro":
                    return "Cutelo de Carne";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Рассечение плоти";
                case "í•œêµ­ì–´":
                    return "고기칼";
                case "ç®€ä½“ä¸­æ–‡":
                    return "血肉顺劈";
                default:
                    return "Meat Cleaver";
            }
        }

        private static string Recklessness_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Tollkühnheit";
                case "Español":
                    return "Temeridad";
                case "Français":
                    return "Témérité";
                case "Italiano":
                    return "Avventatezza";
                case "Português Brasileiro":
                    return "Temeridade";
                case "Русский":
                    return "Безрассудство";
                case "한국어":
                    return "무모한 희생";
                case "简体中文":
                    return "鲁莽";
                default:
                    return "Recklessness";
            }
        }
        private static string TitansGrip_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Titanengriff";
                case "Español":
                    return "Empuñadura de titán";
                case "Français":
                    return "Poigne du titan";
                case "Italiano":
                    return "Presa dei Titani";
                case "Português Brasileiro":
                    return "Punhos de Titã";
                case "Русский":
                    return "Хватка титана";
                case "한국어":
                    return "티탄의 손아귀";
                case "简体中文":
                    return "泰坦之握";
                default:
                    return "Titan's Grip";
            }
        }
        private static string Bloodthirst_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Blutdurst";
                case "Español":
                    return "Sed de sangre";
                case "Français":
                    return "Sanguinaire";
                case "Italiano":
                    return "Sete di Sangue";
                case "Português Brasileiro":
                    return "Sede de Sangue";
                case "Русский":
                    return "Кровожадность";
                case "한국어":
                    return "피의 갈증";
                case "简体中文":
                    return "嗜血";
                default:
                    return "Bloodthirst";
            }
        }
        private static string Rampage_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Toben";
                case "Español":
                    return "Desenfreno";
                case "Français":
                    return "Saccager";
                case "Italiano":
                    return "Scatto d'Ira";
                case "Português Brasileiro":
                    return "Alvoroço";
                case "Русский":
                    return "Буйство";
                case "한국어":
                    return "광란";
                case "简体中文":
                    return "暴怒";
                default:
                    return "Rampage";
            }
        }
        private static string Enrage_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Wutanfall";
                case "Español":
                    return "Enfurecer";
                case "Français":
                    return "Enrager";
                case "Italiano":
                    return "Furia";
                case "Português Brasileiro":
                    return "Enfurecer";
                case "Русский":
                    return "Исступление";
                case "한국어":
                    return "격노";
                case "简体中文":
                    return "激怒";
                default:
                    return "Enrage";
            }
        }
        private static string Execute_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Hinrichten";
                case "Español":
                    return "Ejecutar";
                case "Français":
                    return "Exécution";
                case "Italiano":
                    return "Esecuzione";
                case "Português Brasileiro":
                    return "Executar";
                case "Русский":
                    return "Казнь";
                case "한국어":
                    return "마무리 일격";
                case "简体中文":
                    return "斩杀";
                default:
                    return "Execute";
            }
        }
        private static string SuddenDeath_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Plötzlicher Tod";
                case "Español":
                    return "Muerte súbita";
                case "Français":
                    return "Mort subite";
                case "Italiano":
                    return "Morte Improvvisa";
                case "Português Brasileiro":
                    return "Morte Súbita";
                case "Русский":
                    return "Внезапная смерть";
                case "한국어":
                    return "급살";
                case "简体中文":
                    return "猝死";
                default:
                    return "Sudden Death";
            }
        }
        private static string RagingBlow_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Wütender Schlag";
                case "Español":
                    return "Arremetida enfurecida";
                case "Français":
                    return "Coup déchaîné";
                case "Italiano":
                    return "Colpo Furente";
                case "Português Brasileiro":
                    return "Golpe Furioso";
                case "Русский":
                    return "Яростный выпад";
                case "한국어":
                    return "분노의 강타";
                case "简体中文":
                    return "怒击";
                default:
                    return "Raging Blow";
            }
        }
        private static string ShatteringThrow_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zerschmetternder Wurf";
                case "Español":
                    return "Lanzamiento destrozador";
                case "Français":
                    return "Lancer fracassant";
                case "Italiano":
                    return "Lancio Frantumante";
                case "Português Brasileiro":
                    return "Arremesso Estilhaçante";
                case "Русский":
                    return "Сокрушительный бросок";
                case "한국어":
                    return "분쇄의 투척";
                case "简体中文":
                    return "碎裂投掷";
                default:
                    return "Shattering Throw";
            }
        }
        private static string Whirlwind_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Wirbelwind";
                case "Español":
                    return "Torbellino";
                case "Français":
                    return "Tourbillon";
                case "Italiano":
                    return "Turbine";
                case "Português Brasileiro":
                    return "Redemoinho";
                case "Русский":
                    return "Вихрь";
                case "한국어":
                    return "소용돌이";
                case "简体中文":
                    return "旋风斩";
                default:
                    return "Whirlwind";
            }
        }
        private static string RallyingCry_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Anspornender Schrei";
                case "Español":
                    return "Berrido de convocación";
                case "Français":
                    return "Cri de ralliement";
                case "Italiano":
                    return "Chiamata a Raccolta";
                case "Português Brasileiro":
                    return "Brado de Convocação";
                case "Русский":
                    return "Ободряющий клич";
                case "한국어":
                    return "재집결의 함성";
                case "简体中文":
                    return "集结呐喊";
                default:
                    return "Rallying Cry";
            }
        }
        private static string IntimidatingShout_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Drohruf";
                case "Español":
                    return "Grito intimidador";
                case "Français":
                    return "Cri d’intimidation";
                case "Italiano":
                    return "Urlo Intimidatorio";
                case "Português Brasileiro":
                    return "Brado Intimidador";
                case "Русский":
                    return "Устрашающий крик";
                case "한국어":
                    return "위협의 외침";
                case "简体中文":
                    return "破胆怒吼";
                default:
                    return "Intimidating Shout";
            }
        }
        private static string EnragedRegeneration_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Wütende Regeneration";
                case "Español":
                    return "Regeneración enfurecida";
                case "Français":
                    return "Régénération enragée";
                case "Italiano":
                    return "Rigenerazione Furente";
                case "Português Brasileiro":
                    return "Regeneração Enfurecida";
                case "Русский":
                    return "Безудержное восстановление";
                case "한국어":
                    return "격노의 재생력";
                case "简体中文":
                    return "狂怒回复";
                default:
                    return "Enraged Regeneration";
            }
        }
        private static string PiercingHowl_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Durchdringendes Heulen";
                case "Español":
                    return "Aullido perforador";
                case "Français":
                    return "Hurlement perçant";
                case "Italiano":
                    return "Urlo Penetrante";
                case "Português Brasileiro":
                    return "Uivo Perfurante";
                case "Русский":
                    return "Пронзительный вой";
                case "한국어":
                    return "날카로운 고함";
                case "简体中文":
                    return "刺耳怒吼";
                default:
                    return "Piercing Howl";
            }
        }
        private static string FuryWarrior_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Furorkrieger";
                case "Español":
                    return "Guerrero Furia";
                case "Français":
                    return "Guerrier Fureur";
                case "Italiano":
                    return "Guerriero (Furia)";
                case "Português Brasileiro":
                    return "Guerreiro de Fúria";
                case "Русский":
                    return "Воин - Неистовство";
                case "한국어":
                    return "분노 전사";
                case "简体中文":
                    return "狂怒战士";
                default:
                    return "Fury Warrior";
            }
        }
        private static string BattleShout_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schlachtruf";
                case "Español":
                    return "Grito de batalla";
                case "Français":
                    return "Cri de guerre";
                case "Italiano":
                    return "Urlo di Battaglia";
                case "Português Brasileiro":
                    return "Brado de Batalha";
                case "Русский":
                    return "Боевой крик";
                case "한국어":
                    return "전투의 외침";
                case "简体中文":
                    return "战斗怒吼";
                default:
                    return "Battle Shout";
            }
        }
        private static string Charge_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Sturmangriff";
                case "Español":
                    return "Cargar";
                case "Français":
                    return "Charge";
                case "Italiano":
                    return "Carica";
                case "Português Brasileiro":
                    return "Investida";
                case "Русский":
                    return "Рывок";
                case "한국어":
                    return "돌진";
                case "简体中文":
                    return "冲锋";
                default:
                    return "Charge";
            }
        }
        private static string Bladestorm_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Klingensturm";
                case "Español":
                    return "Filotormenta";
                case "Français":
                    return "Tempête de lames";
                case "Italiano":
                    return "Tempesta di Lame";
                case "Português Brasileiro":
                    return "Tornado de Aço";
                case "Русский":
                    return "Вихрь клинков";
                case "한국어":
                    return "칼날폭풍";
                case "简体中文":
                    return "剑刃风暴";
                default:
                    return "Bladestorm";
            }
        }
        private static string Hamstring_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Kniesehne";
                case "Español":
                    return "Seccionar";
                case "Français":
                    return "Brise-genou";
                case "Italiano":
                    return "Azzoppamento";
                case "Português Brasileiro":
                    return "Cortar Tendão";
                case "Русский":
                    return "Подрезать сухожилия";
                case "한국어":
                    return "무력화";
                case "简体中文":
                    return "断筋";
                default:
                    return "Hamstring";
            }
        }
        private static string StormBolt_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Sturmblitz";
                case "EspaÃ±ol":
                    return "Descarga tormentosa";
                case "FranÃ§ais":
                    return "Éclair de tempête";
                case "Italiano":
                    return "Dardo della Tempesta";
                case "PortuguÃªs Brasileiro":
                    return "Seta Tempestuosa";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Удар громовержца";
                case "í•œêµ­ì–´":
                    return "폭풍망치";
                case "ç®€ä½“ä¸­æ–‡":
                    return "风暴之锤";
                default:
                    return "Storm Bolt";
            }
        }
        private static string AncientAftershock_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Nachbeben der Ahnen";
                case "Español":
                    return "Réplica ancestral";
                case "Français":
                    return "Réplique des anciens";
                case "Italiano":
                    return "Scossa d'Assestamento Antica";
                case "Português Brasileiro":
                    return "Tremor Secundário Ancestral";
                case "Русский":
                    return "Повторный толчок Древних";
                case "한국어":
                    return "고대의 여진";
                case "简体中文":
                    return "上古余震";
                default:
                    return "Ancient Aftershock";
            }
        }
        private static string IgnorePain_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zähne zusammenbeißen";
                case "Español":
                    return "Ignorar dolor";
                case "Français":
                    return "Dur au mal";
                case "Italiano":
                    return "Insensibilità";
                case "Português Brasileiro":
                    return "Ignorar Dor";
                case "Русский":
                    return "Стойкость к боли";
                case "한국어":
                    return "고통 감내";
                case "简体中文":
                    return "无视苦痛";
                default:
                    return "Ignore Pain";
            }
        }
        private static string Pummel_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zuschlagen";
                case "Español":
                    return "Zurrar";
                case "Français":
                    return "Volée de coups";
                case "Italiano":
                    return "Pugno Diversivo";
                case "Português Brasileiro":
                    return "Murro";
                case "Русский":
                    return "Зуботычина";
                case "한국어":
                    return "들이치기";
                case "简体中文":
                    return "拳击";
                default:
                    return "Pummel";
            }
        }
        private static string BloodFury_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Kochendes Blut";
                case "Español":
                    return "Furia sangrienta";
                case "Français":
                    return "Fureur sanguinaire";
                case "Italiano":
                    return "Furia Sanguinaria";
                case "Português Brasileiro":
                    return "Fúria Sangrenta";
                case "Русский":
                    return "Кровавое неистовство";
                case "한국어":
                    return "피의 격노";
                case "简体中文":
                    return "血性狂怒";
                default:
                    return "Blood Fury";
            }
        }
        private static string Condemn_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Verurteilen";
                case "Español":
                    return "Condenar";
                case "Français":
                    return "Blâme";
                case "Italiano":
                    return "Condanna";
                case "Português Brasileiro":
                    return "Condenar";
                case "Русский":
                    return "Порицание";
                case "한국어":
                    return "규탄";
                case "简体中文":
                    return "判罪";
                default:
                    return "Condemn";
            }
        }
        private static string SpearofBastion_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Speer der Bastion";
                case "Español":
                    return "Lanza de Bastión";
                case "Français":
                    return "Lance du Bastion";
                case "Italiano":
                    return "Lancia del Bastione";
                case "Português Brasileiro":
                    return "Lança do Bastião";
                case "Русский":
                    return "Копье Бастиона";
                case "한국어":
                    return "보루의 창";
                case "简体中文":
                    return "晋升堡垒之矛";
                default:
                    return "Spear of Bastion";
            }
        }
        private static string ConquerorsBanner_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Banner des Eroberers";
                case "Español":
                    return "Estandarte de conquistador";
                case "Français":
                    return "Bannière du conquérant";
                case "Italiano":
                    return "Stendardo del Conquistatore";
                case "Português Brasileiro":
                    return "Estandarte do Conquistador";
                case "Русский":
                    return "Знамя завоевателя";
                case "한국어":
                    return "정복자의 깃발";
                case "简体中文":
                    return "征服者战旗";
                default:
                    return "Conqueror's Banner";
            }
        }
        private static string Siegebreaker_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Belagerungsbrecher";
                case "Español":
                    return "Rompedor de asedio";
                case "Français":
                    return "Briseur de siège";
                case "Italiano":
                    return "Spezzassedio";
                case "Português Brasileiro":
                    return "Quebra-cerco";
                case "Русский":
                    return "Прорыв блокады";
                case "한국어":
                    return "공성파괴자";
                case "简体中文":
                    return "破城者";
                default:
                    return "Siegebreaker";
            }
        }
        private static string Onslaught_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Ansturm";
                case "Español":
                    return "Irrupción";
                case "Français":
                    return "Assaut";
                case "Italiano":
                    return "Massacro";
                case "Português Brasileiro":
                    return "Ofensiva";
                case "Русский":
                    return "Натиск";
                case "한국어":
                    return "맹공";
                case "简体中文":
                    return "强攻";
                default:
                    return "Onslaught";
            }
        }
        private static string DragonRoar_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Drachengebrüll";
                case "Español":
                    return "Rugido de dragón";
                case "Français":
                    return "Rugissement de dragon";
                case "Italiano":
                    return "Ruggito del Drago";
                case "Português Brasileiro":
                    return "Rugido do Dragão";
                case "Русский":
                    return "Рев дракона";
                case "한국어":
                    return "용의 포효";
                case "简体中文":
                    return "巨龙怒吼";
                default:
                    return "Dragon Roar";
            }
        }
        private static string SpellReflection_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zauberreflexion";
                case "EspaÃ±ol":
                    return "Reflejo de hechizos";
                case "FranÃ§ais":
                    return "Renvoi de sort";
                case "Italiano":
                    return "Rifletti Incantesimo";
                case "PortuguÃªs Brasileiro":
                    return "Reflexão de Feitiço";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Отражение заклинаний";
                case "í•œêµ­ì–´":
                    return "주문 반사";
                case "ç®€ä½“ä¸­æ–‡":
                    return "法术反射";
                default:
                    return "Spell Reflection";
            }
        }
        private static string ImpendingVictory_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Bevorstehender Sieg";
                case "Español":
                    return "Victoria inminente";
                case "Français":
                    return "Victoire imminente";
                case "Italiano":
                    return "Vittoria Imminente";
                case "Português Brasileiro":
                    return "Vitória Iminente";
                case "Русский":
                    return "Верная победа";
                case "한국어":
                    return "예견된 승리";
                case "简体中文":
                    return "胜利在望";
                default:
                    return "Impending Victory";
            }
        }
        private static string AncestralCall_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Ruf der Ahnen";
                case "EspaÃ±ol":
                    return "Llamada ancestral";
                case "FranÃ§ais":
                    return "Appel ancestral";
                case "Italiano":
                    return "Richiamo Ancestrale";
                case "PortuguÃªs Brasileiro":
                    return "Chamado Ancestral";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Призыв предков";
                case "í•œêµ­ì–´":
                    return "고대의 부름";
                case "ç®€ä½“ä¸­æ–‡":
                    return "先祖召唤";
                default:
                    return "Ancestral Call";
            }
        }
        private static string Fireblood_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Feuerblut";
                case "EspaÃ±ol":
                    return "Sangrardiente";
                case "FranÃ§ais":
                    return "Sang de feu";
                case "Italiano":
                    return "Sangue Infuocato";
                case "PortuguÃªs Brasileiro":
                    return "Sangue de Fogo";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Огненная кровь";
                case "í•œêµ­ì–´":
                    return "불꽃피";
                case "ç®€ä½“ä¸­æ–‡":
                    return "烈焰之血";
                default:
                    return "Fireblood";
            }
        }
        private static string BagofTricks_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trickkiste";
                case "EspaÃ±ol":
                    return "Bolsa de trucos";
                case "FranÃ§ais":
                    return "Sac à malice";
                case "Italiano":
                    return "Borsa di Trucchi";
                case "PortuguÃªs Brasileiro":
                    return "Bolsa de Truques";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Набор хитростей";
                case "í•œêµ­ì–´":
                    return "비장의 묘수";
                case "ç®€ä½“ä¸­æ–‡":
                    return "袋里乾坤";
                default:
                    return "Bag of Tricks";
            }
        }
        private static string GiftoftheNaaru_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gabe der Naaru";
                case "EspaÃ±ol":
                    return "Ofrenda de los naaru";
                case "FranÃ§ais":
                    return "Don des Naaru";
                case "Italiano":
                    return "Dono dei Naaru";
                case "PortuguÃªs Brasileiro":
                    return "Dádiva dos Naarus";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Дар наару";
                case "í•œêµ­ì–´":
                    return "나루의 선물";
                case "ç®€ä½“ä¸­æ–‡":
                    return "纳鲁的赐福";
                default:
                    return "Gift of the Naaru";
            }
        }
        private static string Stoneform_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Steingestalt";
                case "EspaÃ±ol":
                    return "Forma de piedra";
                case "FranÃ§ais":
                    return "Forme de pierre";
                case "Italiano":
                    return "Forma di Pietra";
                case "PortuguÃªs Brasileiro":
                    return "Forma de Pedra";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Каменная форма";
                case "í•œêµ­ì–´":
                    return "석화";
                case "ç®€ä½“ä¸­æ–‡":
                    return "石像形态";
                default:
                    return "Stoneform";
            }
        }
        private static string EscapeArtist_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Entfesselungskünstler";
                case "EspaÃ±ol":
                    return "Artista del escape";
                case "FranÃ§ais":
                    return "Maître de l’évasion";
                case "Italiano":
                    return "Artista della Fuga";
                case "PortuguÃªs Brasileiro":
                    return "Artista da Fuga";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Мастер побега";
                case "í•œêµ­ì–´":
                    return "탈출의 명수";
                case "ç®€ä½“ä¸­æ–‡":
                    return "逃命专家";
                default:
                    return "Escape Artist";
            }
        }
        private static string WilltoSurvive_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Überlebenswille";
                case "EspaÃ±ol":
                    return "Lucha por la supervivencia";
                case "FranÃ§ais":
                    return "Volonté de survie";
                case "Italiano":
                    return "Volontà di Sopravvivenza";
                case "PortuguÃªs Brasileiro":
                    return "Desejo de Sobreviver";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Воля к жизни";
                case "í•œêµ­ì–´":
                    return "삶의 의지";
                case "ç®€ä½“ä¸­æ–‡":
                    return "生存意志";
                default:
                    return "Will to Survive";
            }
        }
        private static string RocketBarrage_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Raketenbeschuss";
                case "EspaÃ±ol":
                    return "Tromba de cohetes";
                case "FranÃ§ais":
                    return "Barrage de fusées";
                case "Italiano":
                    return "Raffica di Razzi";
                case "PortuguÃªs Brasileiro":
                    return "Barragem de Foguetes";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Ракетный обстрел";
                case "í•œêµ­ì–´":
                    return "로켓 연발탄";
                case "ç®€ä½“ä¸­æ–‡":
                    return "火箭弹幕";
                default:
                    return "Rocket Barrage";
            }
        }
        private static string WarStomp_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Kriegsdonner";
                case "EspaÃ±ol":
                    return "Pisotón de guerra";
                case "FranÃ§ais":
                    return "Choc martial";
                case "Italiano":
                    return "Zoccolo di Guerra";
                case "PortuguÃªs Brasileiro":
                    return "Pisada de Guerra";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Громовая поступь";
                case "í•œêµ­ì–´":
                    return "전투 발구르기";
                case "ç®€ä½“ä¸­æ–‡":
                    return "战争践踏";
                default:
                    return "War Stomp";
            }
        }
        private static string Shadowmeld_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schattenmimik";
                case "EspaÃ±ol":
                    return "Fusión de las sombras";
                case "FranÃ§ais":
                    return "Camouflage dans l'ombre";
                case "Italiano":
                    return "Fondersi nelle Ombre";
                case "PortuguÃªs Brasileiro":
                    return "Fusão Sombria";
                case "Ð ÑƒÑÑÐºÐ¸Ð¹":
                    return "Слиться с тенью";
                case "í•œêµ­ì–´":
                    return "그림자 숨기";
                case "ç®€ä½“ä¸­æ–‡":
                    return "影遁";
                default:
                    return "Shadowmeld";
            }
        }
        #endregion
        #region Farben
        private static Color Covenant = Color.FromArgb(255, 179, 0);
        private static Color Damage = Color.FromArgb(255, 103, 0);
        private static Color Healing = Color.FromArgb(0, 204, 255);
        private static Color Cooldown = Color.FromArgb(0, 255, 179);
        #endregion
        #region Einstellungen

        #region Main Settings
        private static bool DebugMode;
        private static string Language = "English";
        private static string FiveLetters;
        
        #endregion
        #region Internet Lag
        public static int Latency = new int();
        public static int QuickDelay = new int();
        public static int SlowDelay = new int();
        #endregion

        #region General settings
        private static bool AutoTarget;
        private static int HealthstoneHP;
        private static int HealthPotionHP;
        private static string PotionType;
        private static string PotionTypeName;
        public static bool TopTrinket;
        public static bool BotTrinket;
        #endregion
        #region Defensive
        private static int RallyingCryHP;
        private static int IgnorePainHP;
        private static int EnragedRegenerationHP;
        private static bool AutoPummel;
        private static int AutoPummelTimer;
        private static int VictoryRushHP;
        #endregion
        #region General DPS
        #endregion
        #region Savecooldowns
        private static bool NoAoE;
        private static bool SavePotion;
        private static bool SaveCooldowns;
        private static bool SavePummel;
        private static bool SaveBloodFury;
        private static bool SaveCondemn;
        private static bool SaveRallyingCry;
        private static bool SaveRecklessness;
        private static bool SaveEnragedRegeneration;
        private static bool SaveStormBolt;
        private static bool SaveBladestorm;
        private static bool SaveDragonRoar;
        private static bool SaveSiegebreaker;
        #endregion
        #endregion
        #region Schalter
        private static bool T_SaveCooldowns;
        private static bool T_Potion;
        private static bool T_NoAoE;
        private static bool T_SavePummel;
        private static bool T_SaveCovenant;
        private static bool T_SaveRacial;
        private static bool T_SaveRallyingCry;
        private static bool T_SaveRecklessness;
        private static bool T_SaveEnragedRegeneration;
        private static bool T_SaveStormBolt;
        private static bool T_SaveBladestorm;
        private static bool T_SaveDragonRoar;
        private static bool T_SaveSiegebreaker;

        #endregion
        #region AimSharp Variablen
        private static float Haste;
        private static int GCD;
        private static int GCDMAX;
        private static bool LOS;
        private static int CombatTime;
        private static bool IsMoving;
        private static bool Fighting;
        private static bool InMelee;

        private static int PlayerHealth;
        private static bool PlayerIsDead;
        private static bool IsChanneling;
        private static int PlayerCastingID;
        private static string LastCast;
        private static bool InCombat;
        private static int CastRemaining;
        private static int PlayerLevel;
        private static int Rage;
        private static int RageMax;
        private static int RageDefecit;

        private static bool CovenantKyrian;
        private static bool CovenantNecro;
        private static bool CovenantFae;
        private static bool CovenantVenthyr;
        private static bool CovenantNone;

        private static int TargetHealth;
        private static int TargetMaxHP;
        private static int TargetCurrentHp;
        private static int HealthInK;
        private static bool TargetIsEnemy;
        private static int TargetID;
        private static int RangeToTarget;
        private static int TargetTimeToDie;
        private static int EnemiesNearTarget;
        private static int EnemiesInMelee;
        private static bool IsChannelingTarget;
        private static bool IsInterruptableTarget;
        private static int CastingRemainingTarget;
        private static int CastingElapsedTarget;
        private static bool IsBoss;
        private static bool HasLust;
        private static bool WeAreinParty;
        #endregion
        #region Buff and Debuff Variables
        private static int BuffWhirlwindRemains;
        private static bool BuffWhirlwindUp;
        private static int BuffRecklessnessRemains;
        private static bool BuffRecklessnessUp;
        private static int BuffEnrageRemains;
        private static bool BuffEnrageUp;
        private static int BuffWilloftheBerserkerRemains;
        private static bool BuffWilloftheBerserkerUp;
        private static int BuffFrenzyRemains;
        private static bool BuffFrenzyUp;
        private static int BuffMeatCleaverRemains;
        private static bool BuffMeatCleaverUp;
        private static int BuffFirstStrikeRemains;
        private static bool BuffFirstStrikeUp;
        private static int BuffMercilessBonegrinderRemains;
        private static bool BuffMercilessBonegrinderUp;
        private static int DebuffSiegebreakerRemains;
        private static bool DebuffSiegebreakerUp;
        #endregion
        #region Talent Variables
        private static bool ConduitViciousContempt;
        private static bool ConduitFirstStrike;
        private static bool TalentRecklessAbandon;
        private static bool TalentAngerManagement;
        private static bool TalentMassacre;
        private static bool TalentCruelty;
        #endregion
        #region Cooldowns
        //SaveCoolDowns
        private static int CDRecklessnessRemains;
        private static bool CDRecklessnessUp;
        private static int CDCrushingBlowCharges;
        private static int CDCrushingBlowFullRecharge;
        private static float CDCrushingBlowFractional;
        private static int CDRagingBlowCharges;
        private static int CDRagingBlowFullRecharge;
        private static float CDRagingBlowFractional;
        private static int CDSpearofBastionRemains;
        private static bool CDSpearofBastionUp;
        private static int CDCondemnRemains;
        private static bool CDCondemnUp;
        private static int CDPummel;
        #endregion
        #region Legendary effects
        private static int LegendaryID;
        private static bool LegendaryMemoryoftheBerserkersWill;
        private static bool LegendarySignetofTormentedKings;
        private static bool LegendarySinfulSurge;
        private static bool LegendaryElysianMight;
        #endregion
        #region Fury Warrior
        private static bool execute_phase;
        private static bool unique_legendaries;
        #endregion
        #region CanCast
        private static bool CanCastCharge;
        private static bool CanCastHeroicThrow;
        private static bool CanCastHamstring;
        private static bool CanCastBattleShout;
        private static bool CanCastRampage;
        private static bool CanCastRecklessness;
        private static bool CanCastRagingBlow;
        private static bool CanCastLightsJudgment;
        private static bool CanCastCrushingBlow;
        private static bool CanCastSiegebreaker;
        private static bool CanCastCondemn;
        private static bool CanCastExecute;
        private static bool CanCastBladestorm;
        private static bool CanCastBloodthirst;
        private static bool CanCastBloodbath;
        private static bool CanCastWhirlwind;
        private static bool CanCastDragonRoar;
        private static bool CanCastOnslaught;
        private static bool CanCastVictoryrush;
        private static bool CanCastAncientAftershock;
        private static bool CanCastSpearofBastion;
        private static bool CanCastConquerorsBanner;
        private static bool CanCastPummel;
        private static bool CanCastAncestralCall;
        private static bool CanCastBagofTricks;
        private static bool CanCastFireblood;
        private static bool CanCastVictoryRush;
        private static bool CanCastSlam;
        private static bool CanCastShieldSlam;
        private static bool CanCastRallyingCry;
        private static bool CanCastEnragedRegeneration;
        private static bool CanCastStormBolt;
        private static bool CanCastBloodFury;
        private static bool CanCastSpellReflection;
        private static bool CanCastBerserking;
        private static bool CanCastGiftoftheNaaru;
        private static bool CanCastStoneform;
        private static bool CanCastEscapeArtist;
        private static bool CanCastWilltoSurvive;
        private static bool CanCastRocketBarrage;
        private static bool CanCastWarStomp;
        private static bool CanCastShadowmeld;
        private static bool CanCastShatteringThrow;
        private static bool CanCastImpendingVictory;
        private static bool CanCastIgnorePain;
        #endregion

        #endregion

        #region Allgemeine Methoden

        #endregion

        #region Spells

        #region Utillity
        private bool spellCharge()
        {
            string spellName = Charge_SpellName();
            if (Aimsharp.CanCast(spellName) && (RangeToTarget < 26 && RangeToTarget > 7))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellIntervene()
        {
            string spellName = Intervene_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBattleShout()
        {
            string spellName = BattleShout_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBerserking()
        {
            string spellName = Berserking_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBerserkerRage()
        {
            string spellName = BerserkerRage_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellPummel()
        {
            string spellName = Pummel_SpellName();
            if (AutoPummel)
            {
                if (CanCastPummel && IsInterruptableTarget && CastingRemainingTarget < AutoPummelTimer)
                {
                    Aimsharp.Cast(spellName);

                    return true;
                }
            }
            else
            {
                if ((CDPummel > 5000 || PlayerIsDead) && T_SavePummel)
                {
                    Aimsharp.Cast("PummelOff");

                    return true;
                }

                if (T_SavePummel && CanCastPummel && IsInterruptableTarget)
                {
                    Aimsharp.Cast(spellName);

                    return true;
                }
            }
            return false;
        }
        private bool spellTaunt()
        {
            string spellName = Taunt_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellChallengingShout()
        {
            string spellName = ChallengingShout_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellHamstring()
        {
            string spellName = Hamstring_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellPiercingHowl()
        {
            string spellName = PiercingHowl_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellIntimidatingShout()
        {
            string spellName = IntimidatingShout_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellISpellReflection()
        {
            string spellName = SpellReflection_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellCancelBuff()
        {
            string spellName = "CancelBuff";

            if (EnemiesInMelee > 1 && GCD <= 0 && ConduitFirstStrike && BuffFirstStrikeUp && BuffEnrageRemains < GCDMAX)
            {
                Aimsharp.Cast("CancelBuff");
                Aimsharp.PrintMessage("Spell - " + spellName + "", Cooldown);
                return true;
            }
            return false;
        }
        private bool spellHealthstoneItem(int healthThreshold)
        {
            string spellName = Healthstone_ItemName();

            if (Aimsharp.CanUseItem(spellName, false) && PlayerHealth < healthThreshold)
            {
                Aimsharp.Cast("HStone");
                Aimsharp.PrintMessage("Item - " + spellName + " on self", Healing);
                return true;
            }
            return false;
        }
        private bool spellHealthPotionItem(int healthThreshold)
        {
            string spellName = SpiritualHealingPotion_ItemName();

            if (Aimsharp.CanUseItem(spellName, false) && PlayerHealth < healthThreshold)
            {
                Aimsharp.Cast("HStone");
                Aimsharp.PrintMessage("Item - " + spellName + " on self", Healing);
                return true;
            }
            return false;
        }
        #endregion
        #region Damage
        private bool spellBloodthirst()
        {
            string spellName = Bloodthirst_SpellName();
            if (CanCastBloodthirst)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellExecute()
        {
            string spellName = Execute_SpellName();
            if (CanCastExecute)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellStormBolt()
        {
            string spellName = StormBolt_SpellName();
            if (CanCastStormBolt && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellRagingBlow()
        {
            string spellName = RagingBlow_SpellName();
            if (CanCastRagingBlow)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellWhirlwind()
        {
            string spellName = Whirlwind_SpellName();
            if (CanCastWhirlwind && RangeToTarget < 8)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellRampage()
        {
            string spellName = Rampage_SpellName();
            if (CanCastRampage && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellHeroicThrow()
        {
            string spellName = HeroicThrow_SpellName();
            if (Aimsharp.CanCast(spellName) && RangeToTarget >= 8 && RangeToTarget <= 30)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellShieldSlam()
        {
            string spellName = ShieldSlam_SpellName();
            if (CanCastShieldSlam)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellSlam()
        {
            string spellName = Slam_SpellName();
            if (CanCastSlam)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBladestorm()
        {
            string spellName = Bladestorm_SpellName();
            if (CanCastBladestorm && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellCrushingBlow()
        {
            string spellName = CrushingBlow_SpellName();
            if (CanCastCrushingBlow)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellSiegebreaker()
        {
            string spellName = Siegebreaker_SpellName();
            if (CanCastSiegebreaker)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellImpendingVictory()
        {
            string spellName = ImpendingVictory_SpellName();
            if (CanCastBloodbath)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBloodbath()
        {
            string spellName = Bloodbath_SpellName();
            if (CanCastBloodbath)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellVictoryRush()
        {
            string spellName = VictoryRush_SpellName();
            if (CanCastVictoryRush)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellVictoryRush(int healthThreshold)
        {
            string spellName = VictoryRush_SpellName();
            if (CanCastVictoryRush && PlayerHealth < healthThreshold)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        #endregion
        #region Cooldowns
        private bool spellAncientAftershock()
        {
            string spellName = AncientAftershock_SpellName();
            if (CanCastAncientAftershock && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellCondemn()
        {
            string spellName = Condemn_SpellName();
            if (CanCastCondemn && RangeToTarget < 8)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellSpearofBastion()
        {
            string spellName = SpearofBastion_SpellName();
            if (CanCastSpearofBastion && TargetTimeToDie > 10)
            {
                Aimsharp.Cast("SpearofBastionMouseOver");

                return true;
            }
            return false;
        }
        private bool spellConquerorsBanner()
        {
            string spellName = ConquerorsBanner_SpellName();
            if (CanCastConquerorsBanner && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellFireblood()
        {
            string spellName = Fireblood_SpellName();
            if (CanCastFireblood && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellAncestralCall()
        {
            string spellName = AncestralCall_SpellName();
            if (CanCastAncestralCall && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBagofTricks()
        {
            string spellName = BagofTricks_SpellName();
            if (CanCastBagofTricks && TargetTimeToDie > 5)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellLightsJudgment()
        {
            string spellName = LightsJudgment_SpellName();
            if (CanCastLightsJudgment)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellRecklessness()
        {
            string spellName = Recklessness_SpellName();
            if (CanCastRecklessness && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellEnragedRegeneration(int healthThreshold)
        {
            string spellName = EnragedRegeneration_SpellName();
            if (CanCastEnragedRegeneration && PlayerHealth < healthThreshold)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellIgnorePain(int healthThreshold)
        {
            string spellName = IgnorePain_SpellName();
            if (CanCastIgnorePain && PlayerHealth < healthThreshold)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellRallyingCry(int healthThreshold)
        {
            string spellName = RallyingCry_SpellName();
            if (CanCastRallyingCry && PlayerHealth < healthThreshold)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellDragonRoar()
        {
            string spellName = DragonRoar_SpellName();
            if (CanCastDragonRoar && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellOnslaught()
        {
            string spellName = Onslaught_SpellName();
            if (Aimsharp.CanCast(spellName, "target", false, true))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellBloodFury()
        {
            string spellName = BloodFury_SpellName();
            if (CanCastBloodFury && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool SpellReflection()
        {
            string spellName = SpellReflection_SpellName();
            if (CanCastSpellReflection && TargetTimeToDie > 6)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool SpellShatteringThrow()
        {
            string spellName = ShatteringThrow_SpellName();
            if (Aimsharp.CanCast(spellName))
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellGiftoftheNaaru()
        {
            string spellName = GiftoftheNaaru_SpellName();
            if (CanCastGiftoftheNaaru)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellStoneform()
        {
            string spellName = Stoneform_SpellName();
            if (CanCastStoneform && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellEscapeArtist()
        {
            string spellName = EscapeArtist_SpellName();
            if (CanCastEscapeArtist)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellWilltoSurvive()
        {
            string spellName = WilltoSurvive_SpellName();
            if (CanCastWilltoSurvive && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellRocketBarrage()
        {
            string spellName = RocketBarrage_SpellName();
            if (CanCastRocketBarrage)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellWarStomp()
        {
            string spellName = WarStomp_SpellName();
            if (CanCastWarStomp && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        private bool spellShadowmeld()
        {
            string spellName = Shadowmeld_SpellName();
            if (CanCastShadowmeld)
            {
                Aimsharp.Cast(spellName);

                return true;
            }
            return false;
        }
        //Potion
        private bool spellTopTrinket()
        {
            string spellName = "TopTrinket";
            if (!T_SaveCooldowns && TopTrinket && Aimsharp.CanUseTrinket(0) && InMelee && HealthInK > 0 && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast("TopTrinket", true);

                return true;
            }
            return false;
        }
        private bool spellBotTrinket()
        {
            string spellName = "BotTrinket";
            if (!T_SaveCooldowns && BotTrinket && Aimsharp.CanUseTrinket(1) && InMelee && HealthInK > 0 && RangeToTarget < 8 && TargetTimeToDie > 10)
            {
                Aimsharp.Cast("BotTrinket", true);

                return true;
            }
            return false;
        }
        private bool spellUsePotion()
        {
            string spellName = PotionTypeName;
            if (Aimsharp.CanUseItem(spellName, false) && PotionType != "None" && T_Potion)
            {
                Aimsharp.Cast("Potion");

                return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region Rotation

        private bool UtillityRotation()
        {
            if (spellPummel()) return true;
            if (SpellReflection()) return true;
            if (spellImpendingVictory()) return true;

            return false;
        }

        private bool DefenseRotation()
        {
            if (spellHealthstoneItem(HealthstoneHP)) return true;
            if (spellHealthPotionItem(HealthPotionHP)) return true;
            if (spellRallyingCry(RallyingCryHP)) return true;
            if (spellIgnorePain(IgnorePainHP)) return true;
            if (spellEnragedRegeneration(EnragedRegenerationHP)) return true;
            if (spellVictoryRush(VictoryRushHP)) return true;

            return false;
        }

        private bool MainRotation()
        {
            //execute_phase,value=talent.massacre&target.health.pct<35|target.health.pct<20|target.health.pct>80&covenant.venthyr
            if (TalentMassacre && TargetHealth < 35 || TargetHealth < 20 || TargetHealth > 80 && CovenantVenthyr) if (spellExecute()) return true;
            // pummel,if= target.debuff.casting.react
            if (IsInterruptableTarget)
            if (spellPummel()) return true;
            if (IsInterruptableTarget)
            if (spellStormBolt()) return true;
            // rampage,if= cooldown.recklessness.remains < 3 & talent.reckless_abandon.enabled
            if (CDRecklessnessRemains < 3000 && TalentRecklessAbandon) if (spellRampage()) return true;
            // recklessness,if= runeforge.sinful_surge & gcd.remains = 0 & (variable.execute_phase | (target.time_to_pct_35 > 40 & talent.anger_management | target.time_to_pct_35 > 70 & !talent.anger_management)) & (spell_targets.whirlwind = 1 | buff.meat_cleaver.up)
            if (LegendarySinfulSurge && (EnemiesInMelee == 1 || BuffWhirlwindUp)) if (spellRecklessness()) return true;
            if (EnemiesInMelee == 1 || BuffWhirlwindUp) if (spellRecklessness()) return true;
            // recklessness,if= runeforge.elysian_might & gcd.remains = 0 & (cooldown.spear_of_bastion.remains < 5 | cooldown.spear_of_bastion.remains > 20) & ((buff.bloodlust.up | talent.anger_management.enabled | raid_event.adds.in> 10)| target.time_to_die > 100 | variable.execute_phase | target.time_to_die < 15 & raid_event.adds.in> 10)&(spell_targets.whirlwind = 1 | buff.meat_cleaver.up)
            if (LegendaryElysianMight && (CDSpearofBastionRemains < 5000 || CDSpearofBastionRemains > 20000) && (TalentAngerManagement || TargetTimeToDie > 100000 || execute_phase) && (EnemiesInMelee == 1 || BuffWhirlwindUp)) if (spellRecklessness()) return true;
            // recklessness,if= !variable.unique_legendaries & gcd.remains = 0 & ((buff.bloodlust.up | talent.anger_management.enabled | raid_event.adds.in> 10)| target.time_to_die > 100 | variable.execute_phase | target.time_to_die < 15 & raid_event.adds.in> 10)&(spell_targets.whirlwind = 1 | buff.meat_cleaver.up)
            if (unique_legendaries && (TalentAngerManagement || TargetTimeToDie > 100000 || execute_phase) && (EnemiesInMelee == 1 || BuffWhirlwindUp)) if (spellRecklessness()) return true;
            // recklessness,use_off_gcd = 1,if= runeforge.signet_of_tormented_kings.equipped & gcd.remains & prev_gcd.1.rampage & ((buff.bloodlust.up | talent.anger_management.enabled | raid_event.adds.in> 10)| target.time_to_die > 100 | variable.execute_phase | target.time_to_die < 15 & raid_event.adds.in> 10)&(spell_targets.whirlwind = 1 | buff.meat_cleaver.up)
            if (LegendarySignetofTormentedKings && LastCast == Rampage_SpellName() && (TalentAngerManagement || TargetTimeToDie > 100000 || execute_phase) && (EnemiesInMelee == 1 || BuffWhirlwindUp)) if (spellRecklessness()) return true;
            // whirlwind,if=spell_targets.whirlwind>1&!buff.meat_cleaver.up|raid_event.adds.in<gcd&!buff.meat_cleaver.up
            //if (EnemiesInMelee > 1 && !BuffMeatCleaverUp) if (spellWhirlwind()) return true;
            //action+=/Trinkets
            if (BuffRecklessnessUp) if (spellUsePotion()) return true;
            if (BuffRecklessnessUp) if (spellTopTrinket()) return true;
            if (BuffRecklessnessUp) if (spellBotTrinket()) return true;
            //actions+=/blood_fury
            if (spellBloodFury()) return true;
            // berserking,if= buff.recklessness.up
            if (BuffRecklessnessUp) if (spellBerserking()) return true;
            // lights_judgment,if= buff.recklessness.down & debuff.siegebreaker.down
            if (!BuffRecklessnessUp && !DebuffSiegebreakerUp) if (spellLightsJudgment()) return true;
            // fireblood
            if (spellFireblood()) return true;
            // ancestral_call
            if (spellAncestralCall()) return true;
            // bag_of_tricks,if= buff.recklessness.down & debuff.siegebreaker.down & buff.enrage.up
            if (!BuffRecklessnessUp && !DebuffSiegebreakerUp) if (spellBagofTricks()) return true;
            // actions+=/call_action_list,name=aoe
            if (AOERotation()) return true;
            // call_action_list,name=single_target
            if (SingleRotation()) return true;

            return false;
        }

        private bool SingleRotation()
        {

            //actions.single_target=raging_blow,if=runeforge.will_of_the_berserker.equipped&buff.will_of_the_berserker.remains<gcd
            if (LegendaryMemoryoftheBerserkersWill && BuffWilloftheBerserkerRemains < GCDMAX) if (spellRagingBlow()) return true;
            //actions.single_target+=/crushing_blow,if=runeforge.will_of_the_berserker.equipped&buff.will_of_the_berserker.remains<gcd
            if (LegendaryMemoryoftheBerserkersWill && BuffWilloftheBerserkerRemains < GCDMAX) if (spellCrushingBlow()) return true;
            //actions.single_target+=/cancel_buff,name=bladestorm,if=spell_targets.whirlwind=1&gcd.remains=0&(talent.massacre.enabled|covenant.venthyr.enabled)&variable.execute_phase&(rage>90|!cooldown.condemn.remains)
            if ((TalentMassacre || CovenantVenthyr) && execute_phase && (Rage > 90 || !CDCondemnUp)) if (spellCancelBuff()) return true;
            //actions.single_target+=/condemn,if=(buff.enrage.up|buff.recklessness.up&runeforge.sinful_surge)&variable.execute_phase
            if ((BuffEnrageUp || BuffRecklessnessUp && LegendarySinfulSurge) && execute_phase) if (spellCondemn()) return true;
            //actions.single_target+=/siegebreaker,if=spell_targets.whirlwind>1|raid_event.adds.in>15
            if (spellSiegebreaker()) return true;
            //actions.single_target+=/rampage,if=buff.recklessness.up|(buff.enrage.remains<gcd|rage>90)|buff.frenzy.remains<1.5
            if (BuffRecklessnessUp || (BuffEnrageRemains < GCDMAX || Rage > 80) || BuffFrenzyRemains < 1500) if (spellRampage()) return true;
            //actions.single_target+=/condemn
            if (spellCondemn()) return true;
            if (spellAncientAftershock()) return true;
            if (spellConquerorsBanner()) return true;
            if (spellSpearofBastion()) return true;
            //actions.single_target +=/ execute
            if (spellExecute()) return true;
            //actions.single_target+=/bladestorm,if=buff.enrage.up&(!buff.recklessness.remains|rage<50)&(spell_targets.whirlwind=1&raid_event.adds.in>45|spell_targets.whirlwind=2)
            if (BuffEnrageUp && (!BuffRecklessnessUp || Rage < 50) && (EnemiesInMelee == 1 || EnemiesInMelee == 2)) if (spellBladestorm()) return true;
            //actions.single_target+=/bloodthirst,if=buff.enrage.down|conduit.vicious_contempt.rank>5&target.health.pct<35
            if (!BuffEnrageUp || ConduitViciousContempt && TargetHealth < 35) if (spellBloodthirst()) return true;
            //actions.single_target+=/bloodbath,if=buff.enrage.down|conduit.vicious_contempt.rank>5&target.health.pct<35&!talent.cruelty.enabled
            if (!BuffEnrageUp || ConduitViciousContempt && TargetHealth < 35 && !TalentCruelty) if (spellBloodbath()) return true;
            //actions.single_target+=/dragon_roar,if=buff.enrage.up&(spell_targets.whirlwind>1|raid_event.adds.in>15)
            if (BuffEnrageUp) if (spellDragonRoar()) return true;
            //actions.single_target+=/onslaught
            if (spellOnslaught()) return true;
            //actions.single_target+=/whirlwind,if=buff.merciless_bonegrinder.up&spell_targets.whirlwind>3
            if (BuffMercilessBonegrinderUp && EnemiesInMelee > 3) if (spellWhirlwind()) return true;
            //actions.single_target+=/raging_blow,if=charges=2|buff.recklessness.up&variable.execute_phase&talent.massacre.enabled
            if (CDCrushingBlowFullRecharge < GCD || BuffRecklessnessUp && execute_phase && TalentMassacre) if (spellRagingBlow()) return true;
            //actions.single_target+=/crushing_blow,if=charges=2|buff.recklessness.up&variable.execute_phase&talent.massacre.enabled
            if (CDCrushingBlowFullRecharge < GCD || BuffRecklessnessUp && execute_phase && TalentMassacre) if (spellCrushingBlow()) return true;
            //if (CDCrushingBlowFullRecharge < GCD || BuffRecklessnessUp && execute_phase && TalentMassacre) if (spellCrushingBlow()) return true;
            // bloodthirst
            if (spellBloodthirst()) return true;
            // bloodbath
            if (spellBloodbath()) return true;
            // raging_blow
            if (spellRagingBlow()) return true;
            // crushing_blow
            if (spellCrushingBlow()) return true;
            // whirlwind
            if (spellWhirlwind()) return true;

            return false;
        }

        private bool AOERotation()
        {
            //actions.aoe=cancel_buff,name=bladestorm,if=spell_targets.whirlwind>1&gcd.remains=0&soulbind.first_strike&buff.first_strike.remains&buff.enrage.remains<gcd
            if (spellCancelBuff()) return true;
            //actions.aoe+=/bladestorm,if=buff.enrage.up&spell_targets.whirlwind>2
            if (BuffEnrageUp && EnemiesInMelee > 2) if (spellBladestorm()) return true;
            //actions.aoe+=/condemn,if=spell_targets.whirlwind>1&(buff.enrage.up|buff.recklessness.up&runeforge.sinful_surge)&variable.execute_phase
            if (EnemiesInMelee > 1 && (BuffEnrageUp || BuffRecklessnessUp && LegendarySinfulSurge) && execute_phase) if (spellCondemn()) return true;
            //actions.aoe+=/siegebreaker,if=spell_targets.whirlwind>1
            if (EnemiesInMelee > 1) if (spellSiegebreaker()) return true;
            //actions.aoe+=/rampage,if=spell_targets.whirlwind>1
            if (EnemiesInMelee > 1) if (spellRampage()) return true;
            //actions.aoe+=/bladestorm,if=buff.enrage.remains>gcd*2.5&spell_targets.whirlwind>1
            if (BuffEnrageRemains > GCDMAX * 2.5 && EnemiesInMelee > 1) if (spellBladestorm()) return true;

            return false;
        }

        //Interrupt Setup
        bool IsInterruptable = Aimsharp.IsInterruptable("target");
        int CastingRemaining = Aimsharp.CastingRemaining("target");
        int CastingElapsed = Aimsharp.CastingElapsed("target");
        bool IsChannelingTar = Aimsharp.IsChanneling("target");
        int KickValue = 300;
        int KickChannelsAfter = 196;

        #endregion

        #region AimSharp methoden

        public override void LoadSettings()
        {
            #region Settings Main
            Settings.Add(new Setting("Trinity - Fury Warrior"));
            Settings.Add(new Setting("DebugMode", false));
            Settings.Add(new Setting("First 5 Letters of the Addon:", "xxxxx"));
            #endregion
            #region Internet Lag
            Settings.Add(new Setting("Internet Settings"));
            Settings.Add(new Setting("Latency", 0, 200, 50));
            Settings.Add(new Setting("Quick Delay", 50, 200, 100));
            Settings.Add(new Setting("Slow Delay", 200, 500, 200));
            #endregion
            #region General Settings
            Settings.Add(new Setting("General settings"));
            Settings.Add(new Setting("Use auto Target", false));
            Settings.Add(new Setting("Auto Healthstone HP%", 0, 100, 70));
            Settings.Add(new Setting("Spiritual Healing Potion HP%", 0, 100, 65));
            List<string> Potions = new List<string>(new string[]
            {"None", "Potion of Deathly Fixation", "Potion of Empowered Exorcisms", "Potion of Phantom Fire", "Potion of Unbridled Fury", "Potion of Spectral Strength"});
            Settings.Add(new Setting("Potion Type", Potions, "None"));
            Settings.Add(new Setting("Use Top Trinket", false));
            Settings.Add(new Setting("Use Bot Trinket", false));
            #endregion
            #region Defensive
            Settings.Add(new Setting("Defensives"));

            Settings.Add(new Setting("Rallying Cry on self HP%", 0, 100, 40));
            Settings.Add(new Setting("Ignore Pain on self HP%", 0, 100, 80));
            Settings.Add(new Setting("Enraged Regeneration on self HP%", 0, 100, 45));
            Settings.Add(new Setting("Victory Rush on target HP%", 0, 100, 70));
            #endregion
            #region SaveCoolDowns 

            #endregion
            #region General Interrupt
            Settings.Add(new Setting("General Interrupt"));
            Settings.Add(new Setting("Use auto Pummel", true));
            Settings.Add(new Setting("Pummel at milliseconds remaining", 50, 1500, 500));
            #endregion
        }
        public override void Initialize()
        {
            #region Console
            //Aimsharp.DebugMode();
            Aimsharp.PrintMessage("#A Rotation By Trinity", Color.Yellow);
            Aimsharp.PrintMessage("Fury Warrior Version 1.1.2 (Community Version)", Color.Yellow);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("Suggested M+ Talents: X-X-X-X-X-X-X", Color.Yellow);
            Aimsharp.PrintMessage("Suggested Raid Talents: X-X-X-X-X-X-X", Color.Yellow);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("These macros can be used for manual control:", Color.White);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("/xxxxx Potion -- Toggles Auto use Potion on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SavePummel -- Toggles use Interrupt on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveRacial -- Toggles the use of Racials abilities on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveCovenant -- Toggles the use of Covenant abilities on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveRallyingCry -- Toggles use RallyingCry on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveRecklessness -- Toggles use Recklessness on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveEnragedRegeneration -- Toggles use EnragedRegeneration on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveStormBolt -- Toggles use StormBolt on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveBladestorm -- Toggles use Bladestorm on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveDragonRoar -- Toggles use DragonRoar on/off.", Color.White);
            Aimsharp.PrintMessage("/xxxxx SaveSiegebreaker -- Toggles use Siegebreaker on/off.", Color.White);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("Please note that the community version is limited", Color.Black);
            Aimsharp.PrintMessage("The Community Version Support only MouseOver", Color.Black);
            Aimsharp.PrintMessage("This version is played by the Community. Please share feedback in the Feedback Chat in the Discord.", Color.Orange);
            Aimsharp.PrintMessage("If you want to share logs, Please send them to Scythe or Toxay privately. Do not post logs to the Chat. Have fun with the Rotation.", Color.Orange);
            #endregion
            #region Einstellungen

            #region Settings Main
            DebugMode = GetCheckBox("DebugMode");
            FiveLetters = GetString("First 5 Letters of the Addon:");
            #endregion
            #region Internet Lag
            Latency = GetSlider("Latency");
            QuickDelay = GetSlider("Quick Delay");
            SlowDelay = GetSlider("Slow Delay");

            Aimsharp.Latency = Latency;
            Aimsharp.QuickDelay = QuickDelay;
            Aimsharp.SlowDelay = SlowDelay;
            #endregion
            #region General Settings
            AutoTarget = GetCheckBox("Use auto Target");
            HealthstoneHP = GetSlider("Auto Healthstone HP%");
            HealthPotionHP = GetSlider("Spiritual Healing Potion HP%");
            PotionType = GetDropDown("Potion Type");
            TopTrinket = GetCheckBox("Use Top Trinket");
            BotTrinket = GetCheckBox("Use Bot Trinket");
            // PotionTyp ermitteln
            if (PotionType == "Potion of Deathly Fixation") PotionTypeName = PotionofDeathlyFixation_ItemName();
            if (PotionType == "Potion of Empowered Exorcisms") PotionTypeName = PotionofEmpoweredExorcisms_ItemName();
            if (PotionType == "Potion of Phantom Fire") PotionTypeName = PotionofPhantomFire_ItemName();
            if (PotionType == "Potion of Unbridled Fury") PotionTypeName = PotionofUnbridledFury_ItemName();
            if (PotionType == "Potion of Spectral Strength") PotionTypeName = PotionofSpectralStrength_ItemName();

            //Cooldowns


            #endregion
            #region Defensive
            RallyingCryHP = GetSlider("Rallying Cry on self HP%");
            IgnorePainHP = GetSlider("Ignore Pain on self HP%");
            EnragedRegenerationHP = GetSlider("Enraged Regeneration on self HP%");
            AutoPummel = GetCheckBox("Use auto Pummel");
            AutoPummelTimer = GetSlider("Pummel at milliseconds remaining");
            VictoryRushHP = GetSlider("Victory Rush on target HP%");
            #endregion
            #region General DPS

            #endregion
            #region SaveCoolDowns

            #endregion

            #endregion
            #region Listen

            #region Listen erstellen
            List<string> Racials = new List<string>
            {
                BloodFury_SpellName(), Berserking_SpellName(), Fireblood_SpellName(), AncestralCall_SpellName(), BagofTricks_SpellName(), GiftoftheNaaru_SpellName(), Stoneform_SpellName(), EscapeArtist_SpellName(),
                WilltoSurvive_SpellName(), RocketBarrage_SpellName(), WarStomp_SpellName(), Shadowmeld_SpellName()
            };

            List<string> CovenantAbilities = new List<string>
            {
                SpearofBastion_SpellName(), ConquerorsBanner_SpellName(), AncientAftershock_SpellName(), Condemn_SpellName()
            };

            List<string> SpellsList = new List<string>
            {
               Rampage_SpellName(), Recklessness_SpellName(), Whirlwind_SpellName(), Execute_SpellName(), Bladestorm_SpellName(), Bloodthirst_SpellName(), RagingBlow_SpellName(), Onslaught_SpellName(), DragonRoar_SpellName(),
                Siegebreaker_SpellName(), CrushingBlow_SpellName(), Bloodbath_SpellName(), RallyingCry_SpellName(), ShatteringThrow_SpellName(),
               IgnorePain_SpellName(), EnragedRegeneration_SpellName(), Slam_SpellName(), ShieldSlam_SpellName(), HeroicThrow_SpellName(), Charge_SpellName(), Intervene_SpellName(), BerserkerRage_SpellName(),
                Pummel_SpellName(), Taunt_SpellName(), ChallengingShout_SpellName(), Hamstring_SpellName(), ImpendingVictory_SpellName(),
               PiercingHowl_SpellName(), IntimidatingShout_SpellName(), VictoryRush_SpellName(), StormBolt_SpellName()
            };

            List<string> BuffsList = new List<string>
            {
                Whirlwind_SpellName(), Recklessness_SpellName(), Enrage_SpellName(), SuddenDeath_SpellName(), MercilessBonegrinder_SpellName(), MeatCleaver_SpellName(), SpellReflection_SpellName(),
                MeatCleaver_SpellName(), "First Strike", Whirlwind_SpellName(), BattleShout_SpellName()
            };

            List<string> DebuffsList = new List<string>
            {
               Siegebreaker_SpellName()
            };

            List<string> TotemsList = new List<string>
            {

            };

            List<string> MacroCommands = new List<string>
            {
                "SaveCooldowns", "NoAoE", "Potion", "SaveCovenant", "SaveRacial", "SavePummel", "SaveBloodFury", "SaveRallyingCry", "SaveRecklessness", "SaveEnragedRegeneration", "SaveStormBolt", "SaveBladestorm", "SaveDragonRoar", "SaveSiegebreaker"
            };
            #endregion

            #region Listen Laden
            foreach (string Spell in SpellsList)
            {
                Spellbook.Add(Spell);
            }

            foreach (string Spell in CovenantAbilities)
            {
                Spellbook.Add(Spell);
            }

            foreach (string Spell in Racials)
            {
                Spellbook.Add(Spell);
            }

            foreach (string Buff in BuffsList)
            {
                Buffs.Add(Buff);
            }

            foreach (string Debuff in DebuffsList)
            {
                Debuffs.Add(Debuff);
            }

            foreach (string Totem in TotemsList)
            {
                Totems.Add(Totem);
            }
            foreach (string MacroCommand in MacroCommands)
            {
                CustomCommands.Add(MacroCommand);
            }
            #endregion

            Items.Add(PotionTypeName);
            Items.Add(Healthstone_ItemName());
            //Buff
            Spellbook.Add(BattleShout_SpellName());
            #endregion
            #region Macros
            Macros.Add("HStone", "/use " + Healthstone_ItemName());
            Macros.Add("HPotion", "/use " + SpiritualHealingPotion_ItemName());
            Macros.Add("Potion", "/use " + PotionTypeName);
            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BotTrinket", "/use 14");
            Macros.Add("NextEnemy", "/targetenemy");

            Macros.Add("PummelOff", "/" + FiveLetters + " " + Pummel_SpellName());
            Macros.Add("CancelBuff", "/cancelaura " + BloodFury_SpellName());
            Macros.Add("SpearofBastionMouseOver", "#showtooltip " + SpearofBastion_SpellName() + "\\n/cast [@cursor] " + SpearofBastion_SpellName());
            #endregion
            #region CustomFunctions

            CustomFunctions.Add("GetLegendarySpellID", "local power = 0 for i=1,15,1 do local xcs = ItemLocation:CreateFromEquipmentSlot(i) if(C_Item.DoesItemExist(xcs)) then if(C_LegendaryCrafting.IsRuneforgeLegendary(xcs)) then local id = C_LegendaryCrafting.GetRuneforgeLegendaryComponentInfo(xcs)[\"powerID\"] power = C_LegendaryCrafting.GetRuneforgePowerInfo(id)[\"descriptionSpellID\"] end end end return power");

            #endregion
        }
        public override bool CombatTick()
        {
            #region Einstellungen

            #region Schalter
            T_Potion = Aimsharp.IsCustomCodeOn("Potion");
            T_SavePummel = Aimsharp.IsCustomCodeOn("SavePummel");
            T_SaveCovenant = Aimsharp.IsCustomCodeOn("SaveCovenant");
            T_SaveRacial = Aimsharp.IsCustomCodeOn("SaveRacial");
            T_SaveRallyingCry = Aimsharp.IsCustomCodeOn("SaveRallyingCry");
            T_SaveRecklessness = Aimsharp.IsCustomCodeOn("SaveRecklessness");
            T_SaveEnragedRegeneration = Aimsharp.IsCustomCodeOn("SaveEnragedRegeneration");
            T_SaveStormBolt = Aimsharp.IsCustomCodeOn("SaveStormBolt");
            T_SaveBladestorm = Aimsharp.IsCustomCodeOn("SaveBladestorm");
            T_SaveDragonRoar = Aimsharp.IsCustomCodeOn("SaveDragonRoar");
            T_SaveSiegebreaker = Aimsharp.IsCustomCodeOn("SaveSiegebreaker");

            #endregion
            #region General Variables

            Haste = Aimsharp.Haste() / 100f;
            Latency = Aimsharp.Latency;
            GCD = Aimsharp.GCD() + Latency;
            GCDMAX = (int)((1500f / (Haste + 1f)) + GCD);
            LOS = Aimsharp.LineOfSighted();
            CombatTime = Aimsharp.CombatTime();
            IsMoving = Aimsharp.PlayerIsMoving();
            //Fighting                  = Aimsharp.TargetIsEnemy() && (Aimsharp.InCombat("target") && !PlayerIsDead);
            Fighting = !PlayerIsDead;
            InMelee = Aimsharp.Range("target") <= 5 && Aimsharp.TargetIsEnemy();

            PlayerHealth = Aimsharp.Health("player");
            PlayerIsDead = Aimsharp.PlayerIsDead();
            IsChanneling = Aimsharp.IsChanneling("player");
            PlayerCastingID = Aimsharp.CastingID("player");
            LastCast = Aimsharp.LastCast();
            InCombat = Aimsharp.InCombat("player");
            CastRemaining = Aimsharp.CastingRemaining("player");
            PlayerLevel = Aimsharp.GetPlayerLevel();
            Rage = Aimsharp.Power("player");
            RageMax = Aimsharp.PlayerMaxPower();
            RageDefecit = RageMax - Rage;

            CovenantKyrian = Aimsharp.CovenantID() == 1;
            CovenantNecro = Aimsharp.CovenantID() == 4;
            CovenantFae = Aimsharp.CovenantID() == 3;
            CovenantVenthyr = Aimsharp.CovenantID() == 2;
            CovenantNone = Aimsharp.CovenantID() == 0;

            TargetHealth = Aimsharp.Health("target");
            TargetMaxHP = Aimsharp.TargetMaxHP();
            TargetCurrentHp = Aimsharp.TargetCurrentHP();
            HealthInK = Aimsharp.TargetExactCurrentHP();
            TargetIsEnemy = Aimsharp.TargetIsEnemy();
            TargetID = Aimsharp.UnitID("target");
            RangeToTarget = Aimsharp.Range("target");
            var TargetDamageTakenPerSecond = (TargetMaxHP - TargetCurrentHp) / (Math.Floor((double)CombatTime / 1000));
            TargetTimeToDie = (int)Math.Ceiling(TargetCurrentHp / TargetDamageTakenPerSecond);
            EnemiesNearTarget = Aimsharp.EnemiesNearTarget();
            EnemiesInMelee = Aimsharp.EnemiesInMelee();
            IsChannelingTarget = Aimsharp.IsChanneling("target");
            IsInterruptableTarget = Aimsharp.IsInterruptable("target");
            CastingRemainingTarget = Aimsharp.CastingRemaining("target");
            CastingElapsedTarget = Aimsharp.CastingElapsed("target");
            IsBoss = Aimsharp.TargetIsBoss();

            WeAreinParty = Aimsharp.InParty() && Aimsharp.GroupSize() > 1;

            #endregion
            #region Buff and Debuff Variables

            BuffWhirlwindRemains = Aimsharp.BuffRemaining(Whirlwind_SpellName()) - GCD;
            BuffWhirlwindUp = BuffWhirlwindRemains > 0;
            BuffRecklessnessRemains = Aimsharp.BuffRemaining(Recklessness_SpellName()) - GCD;
            BuffRecklessnessUp = BuffRecklessnessRemains > 0;
            BuffEnrageRemains = Aimsharp.BuffRemaining(Enrage_SpellName()) - GCD;
            BuffEnrageUp = BuffEnrageRemains > 0;
            BuffWilloftheBerserkerRemains = Aimsharp.BuffRemaining(WilloftheBerserker_SpellName()) - GCD;
            BuffWilloftheBerserkerUp = BuffWilloftheBerserkerRemains > 0;
            BuffFrenzyRemains = Aimsharp.BuffRemaining(Frenzy_SpellName()) - GCD;
            BuffFrenzyUp = BuffFrenzyRemains > 0;
            BuffMeatCleaverRemains = Aimsharp.BuffRemaining(MeatCleaver_SpellName()) - GCD;
            BuffMeatCleaverUp = BuffMeatCleaverRemains > 0;
            BuffFirstStrikeRemains = Aimsharp.BuffRemaining("First Strike") - GCD;
            BuffFirstStrikeUp = BuffFirstStrikeRemains > 0;
            BuffMercilessBonegrinderRemains = Aimsharp.BuffRemaining(MercilessBonegrinder_SpellName()) - GCD;
            BuffMercilessBonegrinderUp = BuffMercilessBonegrinderRemains > 0;

            DebuffSiegebreakerRemains = Aimsharp.DebuffRemaining(Siegebreaker_SpellName()) - GCD;
            DebuffSiegebreakerUp = DebuffSiegebreakerRemains > 0;


            #endregion
            #region Talent Variables

            var ConduitList = new List<int> { };
            var PvPTalentList = new List<int> { };
            PvPTalentList = Aimsharp.PvpTalentIDs();
            ConduitList = Aimsharp.GetActiveConduits();
            ConduitViciousContempt = ConduitList.Contains(337302);
            ConduitFirstStrike = ConduitList.Contains(325069);
            TalentRecklessAbandon = Aimsharp.Talent(7, 2);
            TalentAngerManagement = Aimsharp.Talent(7, 1);
            TalentMassacre = Aimsharp.Talent(3, 1);
            TalentCruelty = Aimsharp.Talent(5, 3);

            #endregion
            #region Cooldowns

            CDRecklessnessRemains = Aimsharp.SpellCooldown(Recklessness_SpellName());
            CDRecklessnessUp = CDRecklessnessRemains <= 0;
            CDCrushingBlowCharges = Aimsharp.SpellCharges(CrushingBlow_SpellName());
            CDCrushingBlowFullRecharge = (int)(Aimsharp.RechargeTime(CrushingBlow_SpellName()) + 8000f * (Aimsharp.MaxCharges(CrushingBlow_SpellName()) - CDCrushingBlowCharges - 1) / (1f + Haste));
            CDCrushingBlowFractional = CDCrushingBlowCharges + (1 - (Aimsharp.RechargeTime(CrushingBlow_SpellName()) - GCD) / (8000f / (1f + Haste)));
            CDCrushingBlowFractional = CDCrushingBlowFractional > Aimsharp.MaxCharges(CrushingBlow_SpellName()) ? Aimsharp.MaxCharges(CrushingBlow_SpellName()) : CDCrushingBlowFractional;
            CDRagingBlowCharges = Aimsharp.SpellCharges(RagingBlow_SpellName());
            CDRagingBlowFullRecharge = (int)(Aimsharp.RechargeTime(RagingBlow_SpellName()) + 8000f * (Aimsharp.MaxCharges(RagingBlow_SpellName()) - CDRagingBlowCharges - 1) / (1f + Haste));
            CDRagingBlowFractional = CDRagingBlowCharges + (1 - (Aimsharp.RechargeTime(RagingBlow_SpellName()) - GCD) / (8000f / (1f + Haste)));
            CDRagingBlowFractional = CDRagingBlowFractional > Aimsharp.MaxCharges(RagingBlow_SpellName()) ? Aimsharp.MaxCharges(RagingBlow_SpellName()) : CDRagingBlowFractional;
            CDSpearofBastionRemains = Aimsharp.SpellCooldown(SpearofBastion_SpellName());
            CDSpearofBastionUp = CDSpearofBastionRemains <= 0;
            CDCondemnRemains = Aimsharp.SpellCooldown(Condemn_SpellName());
            CDCondemnUp = CDCondemnRemains <= 0;
            CDPummel = Aimsharp.SpellCooldown(Pummel_SpellName());
            #endregion
            #region Legendary effects

            LegendaryID = Aimsharp.CustomFunction("GetLegendarySpellID");
            LegendaryMemoryoftheBerserkersWill = LegendaryID == 183389;
            LegendarySignetofTormentedKings = LegendaryID == 335266;
            LegendarySinfulSurge = LegendaryID == 354131;
            LegendaryElysianMight = LegendaryID == 357996;

            #endregion
            #region Fury Warrior
            // variable,name=execute_phase,value=talent.massacre&target.health.pct<35|target.health.pct<20|target.health.pct>80&covenant.venthyr
            execute_phase = TalentMassacre && TargetHealth < 3500 || TargetHealth < 2000 || TargetHealth > 8000 && CovenantVenthyr;

            //actions+=/variable,name=unique_legendaries,value=runeforge.signet_of_tormented_kings|runeforge.sinful_surge|runeforge.elysian_might
            unique_legendaries = LegendarySignetofTormentedKings || LegendarySinfulSurge || LegendaryElysianMight;

            #endregion
            #region CanCast
            //Spells
            CanCastCharge = Aimsharp.CanCast(Charge_SpellName(), "target") && Fighting;
            CanCastRampage = Aimsharp.CanCast(Rampage_SpellName(), "target") && Fighting;
            CanCastOnslaught = Aimsharp.CanCast(Onslaught_SpellName(), "target") && Fighting;
            CanCastBloodthirst = Aimsharp.CanCast(Bloodthirst_SpellName(), "target") && Fighting;
            CanCastRagingBlow = Aimsharp.CanCast(RagingBlow_SpellName(), "target") && Fighting;
            CanCastVictoryRush = Aimsharp.CanCast(VictoryRush_SpellName(), "target") && Fighting;
            CanCastSlam = Aimsharp.CanCast(Slam_SpellName(), "target") && Fighting;
            CanCastShatteringThrow = Aimsharp.CanCast(ShatteringThrow_SpellName(), "target") && Fighting;
            CanCastImpendingVictory = Aimsharp.CanCast(ImpendingVictory_SpellName(), "target") && Fighting;
            CanCastHamstring = Aimsharp.CanCast(Hamstring_SpellName(), "target") && Fighting;
            CanCastHeroicThrow = Aimsharp.CanCast(HeroicThrow_SpellName(), "target") && Fighting;
            CanCastBattleShout = Aimsharp.CanCast(BattleShout_SpellName(), "target") && Fighting;
            CanCastSpellReflection = Aimsharp.CanCast(SpellReflection_SpellName(), "player") && Fighting;
            CanCastCrushingBlow = Aimsharp.CanCast(CrushingBlow_SpellName(), "target") && Fighting;
            CanCastBloodbath = Aimsharp.CanCast(Bloodbath_SpellName(), "target") && Fighting;
            CanCastIgnorePain = Aimsharp.CanCast(IgnorePain_SpellName(), "player") && Fighting;
            //Covenant
            CanCastCondemn = Aimsharp.CanCast(Condemn_SpellName(), "target", true, true) && Fighting && CovenantVenthyr && Aimsharp.CanCast(Execute_SpellName(), "target", true, true);
            CanCastExecute = Aimsharp.CanCast(Execute_SpellName(), "target", true, true) && Fighting && !CovenantVenthyr;
            CanCastConquerorsBanner = Aimsharp.CanCast(ConquerorsBanner_SpellName(), "player") && Fighting && RangeToTarget < 6 && !T_SaveCovenant;
            CanCastSpearofBastion = Aimsharp.CanCast(SpearofBastion_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveCovenant;
            CanCastAncientAftershock = Aimsharp.CanCast(AncientAftershock_SpellName(), "player") && Fighting && RangeToTarget < 6 && !T_SaveCovenant;
            //Racials
            CanCastBloodFury = Aimsharp.CanCast(BloodFury_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastBerserking = Aimsharp.CanCast(Berserking_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastFireblood = Aimsharp.CanCast(Fireblood_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastAncestralCall = Aimsharp.CanCast(AncestralCall_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastBagofTricks = Aimsharp.CanCast(BagofTricks_SpellName()) && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastGiftoftheNaaru = Aimsharp.CanCast(GiftoftheNaaru_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastStoneform = Aimsharp.CanCast(Stoneform_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastEscapeArtist = Aimsharp.CanCast(EscapeArtist_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastWilltoSurvive = Aimsharp.CanCast(WilltoSurvive_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastRocketBarrage = Aimsharp.CanCast(RocketBarrage_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastWarStomp = Aimsharp.CanCast(WarStomp_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastShadowmeld = Aimsharp.CanCast(Shadowmeld_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            CanCastLightsJudgment = Aimsharp.CanCast(LightsJudgment_SpellName(), "player") && Fighting && RangeToTarget < 5 && !T_SaveRacial;
            //AOE
            CanCastWhirlwind = Aimsharp.CanCast(Whirlwind_SpellName(), "player") && !T_NoAoE && Fighting;
            //Macros
            CanCastPummel = Aimsharp.CanCast(Pummel_SpellName(), "target") && !T_SavePummel && Fighting;
            CanCastRallyingCry = Aimsharp.CanCast(RallyingCry_SpellName(), "player") && !T_SaveRallyingCry && Fighting;
            CanCastRecklessness = Aimsharp.CanCast(Recklessness_SpellName(), "player") && !T_SaveRecklessness && Fighting;
            CanCastEnragedRegeneration = Aimsharp.CanCast(EnragedRegeneration_SpellName(), "player") && !T_SaveEnragedRegeneration && Fighting;
            CanCastStormBolt = Aimsharp.CanCast(StormBolt_SpellName(), "target") && !T_SaveStormBolt && Fighting;
            CanCastBladestorm = Aimsharp.CanCast(Bladestorm_SpellName(), "player") && !T_SaveBladestorm && RangeToTarget <= 8 && Fighting;
            CanCastDragonRoar = Aimsharp.CanCast(DragonRoar_SpellName(), "player") && !T_SaveDragonRoar && Fighting;
            CanCastSiegebreaker = Aimsharp.CanCast(Siegebreaker_SpellName(), "target") && !T_SaveSiegebreaker && Fighting;
            #endregion

            #endregion

            #region Rotation

            if (Fighting)
            {
                // AutoTarget
                if (HealthInK == 0 && TargetIsEnemy && AutoTarget)
                {
                    Aimsharp.Cast("NextEnemy");
                    return true;
                }

                if (UtillityRotation()) return true;
                if (DefenseRotation()) return true;

                //never interrupt channels 
                if (IsChanneling) return false;

                if (MainRotation()) return true;

            }

            #endregion

            return false;
        }
        public override bool OutOfCombatTick()
        {
            #region Einstellungen

            #region Schalter
            T_SavePummel = Aimsharp.IsCustomCodeOn("SavePummel");
            T_SaveCovenant = Aimsharp.IsCustomCodeOn("SaveCovenant");
            T_SaveRacial = Aimsharp.IsCustomCodeOn("SaveRacial");
            T_SaveRallyingCry = Aimsharp.IsCustomCodeOn("SaveRallyingCry");
            T_SaveRecklessness = Aimsharp.IsCustomCodeOn("SaveRecklessness");
            T_SaveEnragedRegeneration = Aimsharp.IsCustomCodeOn("SaveEnragedRegeneration");
            T_SaveStormBolt = Aimsharp.IsCustomCodeOn("SaveStormBolt");
            T_SaveBladestorm = Aimsharp.IsCustomCodeOn("SaveBladestorm");
            T_SaveDragonRoar = Aimsharp.IsCustomCodeOn("SaveDragonRoar");
            T_SaveSiegebreaker = Aimsharp.IsCustomCodeOn("SaveSiegebreaker");
            #endregion
            #region General Variables

            Haste = Aimsharp.Haste() / 100f;
            Latency = Aimsharp.Latency;
            GCD = Aimsharp.GCD() + Latency;
            GCDMAX = (int)((1500f / (Haste + 1f)) + GCD);
            LOS = Aimsharp.LineOfSighted();
            CombatTime = Aimsharp.CombatTime();
            IsMoving = Aimsharp.PlayerIsMoving();
            //Fighting                  = Aimsharp.TargetIsEnemy() && (Aimsharp.InCombat("target") && !PlayerIsDead);
            Fighting = !PlayerIsDead;
            InMelee = Aimsharp.Range("target") <= 6 && Aimsharp.TargetIsEnemy();

            PlayerHealth = Aimsharp.Health("player");
            PlayerIsDead = Aimsharp.PlayerIsDead();
            IsChanneling = Aimsharp.IsChanneling("player");
            PlayerCastingID = Aimsharp.CastingID("player");
            InCombat = Aimsharp.InCombat("player");
            CastRemaining = Aimsharp.CastingRemaining("player");
            PlayerLevel = Aimsharp.GetPlayerLevel();
            Rage = Aimsharp.Power("player");
            RageMax = Aimsharp.PlayerMaxPower();
            RageDefecit = RageMax - Rage;

            CovenantKyrian = Aimsharp.CovenantID() == 1;
            CovenantNecro = Aimsharp.CovenantID() == 4;
            CovenantFae = Aimsharp.CovenantID() == 3;
            CovenantVenthyr = Aimsharp.CovenantID() == 2;
            CovenantNone = Aimsharp.CovenantID() == 0;

            TargetHealth = Aimsharp.Health("target");
            TargetCurrentHp = Aimsharp.TargetCurrentHP();
            HealthInK = Aimsharp.TargetExactCurrentHP();
            TargetID = Aimsharp.UnitID("target");
            RangeToTarget = Aimsharp.Range("target");
            TargetTimeToDie = 1000000; //need to implement time to die estimation
            EnemiesNearTarget = Aimsharp.EnemiesNearTarget();
            EnemiesInMelee = Aimsharp.EnemiesInMelee();
            IsChannelingTarget = Aimsharp.IsChanneling("target");
            IsInterruptableTarget = Aimsharp.IsInterruptable("target");
            CastingRemainingTarget = Aimsharp.CastingRemaining("target");
            CastingElapsedTarget = Aimsharp.CastingElapsed("target");
            IsBoss = Aimsharp.TargetIsBoss();

            WeAreinParty = Aimsharp.InParty() && Aimsharp.GroupSize() > 1;

            #endregion
            #region BuffBattleShout
            if (Aimsharp.CanCast(BattleShout_SpellName(), "player") && !Aimsharp.HasBuff(BattleShout_SpellName(), "player", false))
            {
                Aimsharp.Cast(BattleShout_SpellName());
                return true;
            }
            #endregion

            #endregion

            return false;
        }

        #endregion






    }
}