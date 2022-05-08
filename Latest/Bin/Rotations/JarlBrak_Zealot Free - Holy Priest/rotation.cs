using System.Linq;
using System.Diagnostics;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class Priest : Rotation
    {
        #region Static Variables
        private static int[] Talents = new int[8];
        private static int SpellQueueWindow = new int();
        private static int Latency = new int();
        private static int PlayerHealth = new int();
        private static int TargetHealth = new int();
        private static bool Moving = new bool();
        private static bool Mounted = new bool();
        private static bool Channeling = new bool();
        private static int CastTimeRemaining = new int();
        private static bool Casting = new bool();
        private static bool InParty = new bool();
        private static bool InCombat = new bool();
        private static bool HasBuffFae = new bool();
        private static bool HasBuffBoon = new bool();
        private static int CovenantID = new int();
        private static Color Covenant = Color.FromArgb(255, 179, 0);
        private static Color Damage = Color.FromArgb(255, 103, 0);
        private static Color Healing = Color.FromArgb(0, 204, 255);
        private static Color Cooldown = Color.FromArgb(0, 255, 179);
        private static string Language;
        private static List<string> AntiHealingDebuffs;
        private static List<string> BuffsList;
        private static List<string> DebuffsList;
        private static List<string> SpellsList;
        private static List<string> ItemsList;
        private static List<string> MacroCommands;
        private static List<string> CovenantAbilities;
        #region Toggles
        private static bool AutoStartMode = new bool();
        private static bool DebugMode = new bool();
        private static bool RampToggle = new bool();
        private static bool UseCooldowns = new bool();
        private static bool MovementBoost = new bool();
        #endregion
        #endregion
        #region Translations
        #region Buffs Spells
        private static string FlashConcentration_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Blitzkonzentration";
                case "Español":
                    return "Concentración relámpago";
                case "Français":
                    return "Concentration éclair";
                case "Italiano":
                    return "Concentrazione Rapida";
                case "Português Brasileiro":
                    return "Concentração Célere";
                case "Русский":
                    return "Быстрая концентрация";
                case "한국어":
                    return "집중된 섬광";
                case "简体中文":
                    return "快速专注";
                default:
                    return "Flash Concentration";
            }
        }
        private static string SurgeofLight_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Woge des Lichts";
                case "Español":
                    return "Oleada de Luz";
                case "Français":
                    return "Vague de Lumière";
                case "Italiano":
                    return "Eruzione di Luce";
                case "Português Brasileiro":
                    return "Torrente de Luz";
                case "Русский":
                    return "Пробуждение Света";
                case "한국어":
                    return "빛의 쇄도";
                case "简体中文":
                    return "圣光涌动";
                default:
                    return "Surge of Light";
            }
        }
        private static string ResonantWords_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Resonierende Worte";
                case "Español":
                    return "Palabras resonantes";
                case "Français":
                    return "Mots résonnants";
                case "Italiano":
                    return "Parole Risonanti";
                case "Português Brasileiro":
                    return "Palavras Ressonantes";
                case "Русский":
                    return "Резонирующие слова";
                case "한국어":
                    return "공명의 권능";
                case "简体中文":
                    return "共鸣圣言";
                default:
                    return "Resonant Words";
            }
        }
        private static string SpiritofRedemption_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Geist der Erlösung";
                case "Español":
                    return "Espíritu redentor";
                case "Français":
                    return "Esprit de rédemption";
                case "Italiano":
                    return "Spirito di Redenzione";
                case "Português Brasileiro":
                    return "Espírito da Redenção";
                case "Русский":
                    return "Дух воздаяния";
                case "한국어":
                    return "구원의 영혼";
                case "简体中文":
                    return "救赎之魂";
                default:
                    return "Spirit of Redemption";
            }
        }
        #endregion
        #region Debuffs Spells
        private static string GluttonousMiasma_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gefräßiges Miasma";
                case "Español":
                    return "Miasma glotón";
                case "Français":
                    return "Miasme glouton";
                case "Italiano":
                    return "Miasma Insaziabile";
                case "Português Brasileiro":
                    return "Miasma Glutônico";
                case "Русский":
                    return "Ненасытные миазмы";
                case "한국어":
                    return "걸신들린 독기";
                case "简体中文":
                    return "暴食瘴气";
                default:
                    return "Gluttonous Miasma";
            }
        }
        private static string CloakofFlames_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Flammenumhang";
                case "Español":
                    return "Capa de llamas";
                case "Français":
                    return "Cape des flammes";
                case "Italiano":
                    return "Mantello delle Fiamme";
                case "Português Brasileiro":
                    return "Manto das Chamas";
                case "Русский":
                    return "Плащ пламени";
                case "한국어":
                    return "화염 망토";
                case "简体中文":
                    return "烈焰披风";
                default:
                    return "Cloak of Flames";
            }
        }
        private static string WrathfulFaerie_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zornige Fee";
                case "Español":
                    return "Hada colérica";
                case "Français":
                    return "Fée courroucée";
                case "Italiano":
                    return "Silfide Infuriato";
                case "Português Brasileiro":
                    return "Fada Irascível";
                case "Русский":
                    return "Гневный пикси";
                case "한국어":
                    return "격노의 페어리";
                case "简体中文":
                    return "盛怒法夜";
                default:
                    return "Wrathful Faerie";
            }
        }
        private static string WeakenedSoul_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Geschwächte Seele";
                case "Español":
                    return "Alma debilitada";
                case "Français":
                    return "Ame affaiblie";
                case "Italiano":
                    return "Anima Indebolita";
                case "Português Brasileiro":
                    return "Alma Enfraquecida";
                case "Русский":
                    return "Ослабленная душа";
                case "한국어":
                    return "약화된 영혼";
                case "简体中文":
                    return "虚弱灵魂";
                default:
                    return "Weakened Soul";
            }
        }
        #endregion
        #region Spells
        private static string AngelicFeather_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Engelsfeder";
                case "Español":
                    return "Pluma angélica";
                case "Français":
                    return "Plume angélique";
                case "Italiano":
                    return "Piuma Angelica";
                case "Português Brasileiro":
                    return "Pena Angelical";
                case "Русский":
                    return "Божественное перышко";
                case "한국어":
                    return "천사의 깃털";
                case "简体中文":
                    return "天堂之羽";
                default:
                    return "Angelic Feather";
            }
        }
        private static string Apotheosis_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Apotheose";
                case "Español":
                    return "Apoteosis";
                case "Français":
                    return "Apothéose";
                case "Italiano":
                    return "Apoteosi";
                case "Português Brasileiro":
                    return "Apoteose";
                case "Русский":
                    return "Прославление";
                case "한국어":
                    return "절정";
                case "简体中文":
                    return "神圣化身";
                default:
                    return "Apotheosis";
            }
        }
        private static string BindingHeal_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Verbindende Heilung";
                case "Español":
                    return "Sanación conjunta";
                case "Français":
                    return "Soins de lien";
                case "Italiano":
                    return "Cura Combinata";
                case "Português Brasileiro":
                    return "Cura Vinculada";
                case "Русский":
                    return "Связующее исцеление";
                case "한국어":
                    return "결속의 치유";
                case "简体中文":
                    return "联结治疗";
                default:
                    return "Binding Heal";
            }
        }
        private static string CircleofHealing_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Kreis der Heilung";
                case "Español":
                    return "Círculo de sanación";
                case "Français":
                    return "Cercle de soins";
                case "Italiano":
                    return "Circolo di Guarigione";
                case "Português Brasileiro":
                    return "Círculo de Cura";
                case "Русский":
                    return "Круг исцеления";
                case "한국어":
                    return "치유의 마법진";
                case "简体中文":
                    return "治疗之环";
                default:
                    return "Circle of Healing";
            }
        }
        private static string DesperatePrayer_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Verzweifeltes Gebet";
                case "Español":
                    return "Rezo desesperado";
                case "Français":
                    return "Prière du désespoir";
                case "Italiano":
                    return "Preghiera Disperata";
                case "Português Brasileiro":
                    return "Prece Desesperada";
                case "Русский":
                    return "Молитва отчаяния";
                case "한국어":
                    return "구원의 기도";
                case "简体中文":
                    return "绝望祷言";
                default:
                    return "Desperate Prayer";
            }
        }
        private static string DivineHymn_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gotteshymne";
                case "Español":
                    return "Himno divino";
                case "Français":
                    return "Hymne divin";
                case "Italiano":
                    return "Inno Divino";
                case "Português Brasileiro":
                    return "Hino Divino";
                case "Русский":
                    return "Божественный гимн";
                case "한국어":
                    return "천상의 찬가";
                case "简体中文":
                    return "神圣赞美诗";
                default:
                    return "Divine Hymn";
            }
        }
        private static string DivineStar_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Göttlicher Stern";
                case "Español":
                    return "Estrella divina";
                case "Français":
                    return "Etoile divine";
                case "Italiano":
                    return "Stella Divina";
                case "Português Brasileiro":
                    return "Estrela Divina";
                case "Русский":
                    return "Божественная звезда";
                case "한국어":
                    return "천상의 별";
                case "简体中文":
                    return "神圣之星";
                default:
                    return "Divine Star";
            }
        }
        private static string DispelMagic_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Magiebannung";
                case "Español":
                    return "Disipar magia";
                case "Français":
                    return "Dissipation de la magie";
                case "Italiano":
                    return "Dissoluzione Magica";
                case "Português Brasileiro":
                    return "Dissipar Magia";
                case "Русский":
                    return "Рассеивание заклинаний";
                case "한국어":
                    return "마법 무효화";
                case "简体中文":
                    return "驱散魔法";
                default:
                    return "Dispel Magic";
            }
        }
        private static string Fade_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Verblassen";
                case "Español":
                    return "Desvanecerse";
                case "Français":
                    return "Disparition";
                case "Italiano":
                    return "Trasparenza";
                case "Português Brasileiro":
                    return "Desvanecer";
                case "Русский":
                    return "Уход в тень";
                case "한국어":
                    return "소실";
                case "简体中文":
                    return "渐隐术";
                default:
                    return "Fade";
            }
        }
        private static string FlashHeal_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Blitzheilung";
                case "Español":
                    return "Sanación relámpago";
                case "Français":
                    return "Soins rapides";
                case "Italiano":
                    return "Cura Rapida";
                case "Português Brasileiro":
                    return "Cura Célere";
                case "Русский":
                    return "Быстрое исцеление";
                case "한국어":
                    return "순간 치유";
                case "简体中文":
                    return "快速治疗";
                default:
                    return "Flash Heal";
            }
        }
        private static string GuardianSpirit_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schutzgeist";
                case "Español":
                    return "Espíritu guardián";
                case "Français":
                    return "Esprit gardien";
                case "Italiano":
                    return "Spirito Custode";
                case "Português Brasileiro":
                    return "Espírito Guardião";
                case "Русский":
                    return "Оберегающий дух";
                case "한국어":
                    return "수호 영혼";
                case "简体中文":
                    return "守护之魂";
                default:
                    return "Guardian Spirit";
            }
        }
        private static string Halo_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Strahlenkranz";
                case "Español":
                    return "Halo";
                case "Français":
                    return "Halo";
                case "Italiano":
                    return "Aureola";
                case "Português Brasileiro":
                    return "Halo";
                case "Русский":
                    return "Сияние";
                case "한국어":
                    return "후광";
                case "简体中文":
                    return "光晕";
                default:
                    return "Halo";
            }
        }
        private static string Heal_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Heilung";
                case "Español":
                    return "Sanar";
                case "Français":
                    return "Soins";
                case "Italiano":
                    return "Cura";
                case "Português Brasileiro":
                    return "Cura";
                case "Русский":
                    return "Исцеление";
                case "한국어":
                    return "치유";
                case "简体中文":
                    return "治疗术";
                default:
                    return "Heal";
            }
        }
        private static string HolyFire_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Heiliges Feuer";
                case "Español":
                    return "Fuego Sagrado";
                case "Français":
                    return "Flammes sacrées";
                case "Italiano":
                    return "Fuoco Sacro";
                case "Português Brasileiro":
                    return "Fogo Sagrado";
                case "Русский":
                    return "Священный огонь";
                case "한국어":
                    return "신성한 불꽃";
                case "简体中文":
                    return "神圣之火";
                default:
                    return "Holy Fire";
            }
        }
        private static string HolyNova_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Heilige Nova";
                case "Español":
                    return "Nova Sagrada";
                case "Français":
                    return "Nova sacrée";
                case "Italiano":
                    return "Esplosione Sacra";
                case "Português Brasileiro":
                    return "Nova Sagrada";
                case "Русский":
                    return "Кольцо Света";
                case "한국어":
                    return "신성한 폭발";
                case "简体中文":
                    return "神圣新星";
                default:
                    return "Holy Nova";
            }
        }
        private static string HolyWordChastise_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segenswort: Züchtigung";
                case "Español":
                    return "Palabra sagrada: condena";
                case "Français":
                    return "Mot sacré : Châtier";
                case "Italiano":
                    return "Parola Sacra: Castigo";
                case "Português Brasileiro":
                    return "Palavra Sagrada: Castigar";
                case "Русский":
                    return "Слово Света: Наказание";
                case "한국어":
                    return "빛의 권능: 응징";
                case "简体中文":
                    return "圣言术：罚";
                default:
                    return "Holy Word: Chastise";
            }
        }
        private static string HolyWordSalvation_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segenswort: Erlösung";
                case "Español":
                    return "Palabra sagrada: salvación";
                case "Français":
                    return "Mot sacré : Salut";
                case "Italiano":
                    return "Parola Sacra: Salvezza";
                case "Português Brasileiro":
                    return "Palavra Sagrada: Salvação";
                case "Русский":
                    return "Слово Света: Спасение";
                case "한국어":
                    return "빛의 권능: 구원";
                case "简体中文":
                    return "圣言术：赎";
                default:
                    return "Holy Word: Salvation";
            }
        }
        private static string HolyWordSanctify_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segenswort: Heiligung";
                case "Español":
                    return "Palabra sagrada: santificar";
                case "Français":
                    return "Mot sacré : Sanctification";
                case "Italiano":
                    return "Parola Sacra: Santificazione";
                case "Português Brasileiro":
                    return "Palavra Sagrada: Santificar";
                case "Русский":
                    return "Слово Света: Освящение";
                case "한국어":
                    return "빛의 권능: 신성화";
                case "简体中文":
                    return "圣言术：灵";
                default:
                    return "Holy Word: Sanctify";
            }
        }
        private static string HolyWordSerenity_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segenswort: Epiphanie";
                case "Español":
                    return "Palabra sagrada: serenidad";
                case "Français":
                    return "Mot sacré : Sérénité";
                case "Italiano":
                    return "Parola Sacra: Serenità";
                case "Português Brasileiro":
                    return "Palavra Sagrada: Serenidade";
                case "Русский":
                    return "Слово Света: Безмятежность";
                case "한국어":
                    return "빛의 권능: 평온";
                case "简体中文":
                    return "圣言术：静";
                default:
                    return "Holy Word: Serenity";
            }
        }
        private static string LeapofFaith_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Glaubenssprung";
                case "Español":
                    return "Salto de fe";
                case "Français":
                    return "Saut de foi";
                case "Italiano":
                    return "Balzo della Fede";
                case "Português Brasileiro":
                    return "Salto da Fé";
                case "Русский":
                    return "Духовное рвение";
                case "한국어":
                    return "신의의 도약";
                case "简体中文":
                    return "信仰飞跃";
                default:
                    return "Leap of Faith";
            }
        }
        private static string MindBlast_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gedankenschlag";
                case "Español":
                    return "Explosión mental";
                case "Français":
                    return "Attaque mentale";
                case "Italiano":
                    return "Detonazione Mentale";
                case "Português Brasileiro":
                    return "Impacto Mental";
                case "Русский":
                    return "Взрыв разума";
                case "한국어":
                    return "정신 분열";
                case "简体中文":
                    return "心灵震爆";
                default:
                    return "Mind Blast";
            }
        }
        private static string PowerInfusion_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Seele der Macht";
                case "Español":
                    return "Infusión de poder";
                case "Français":
                    return "Infusion de puissance";
                case "Italiano":
                    return "Infusione di Potere";
                case "Português Brasileiro":
                    return "Infusão de Poder";
                case "Русский":
                    return "Придание сил";
                case "한국어":
                    return "마력 주입";
                case "简体中文":
                    return "能量灌注";
                default:
                    return "Power Infusion";
            }
        }
        private static string PowerWordFortitude_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Machtwort: Seelenstärke";
                case "Español":
                    return "Palabra de poder: entereza";
                case "Français":
                    return "Mot de pouvoir : Robustesse";
                case "Italiano":
                    return "Parola del Potere: Fermezza";
                case "Português Brasileiro":
                    return "Palavra de Poder: Fortitude";
                case "Русский":
                    return "Слово силы: Стойкость";
                case "한국어":
                    return "신의 권능: 인내";
                case "简体中文":
                    return "真言术：韧";
                default:
                    return "Power Word: Fortitude";
            }
        }
        private static string PowerWordShield_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Machtwort: Schild";
                case "Español":
                    return "Palabra de poder: escudo";
                case "Français":
                    return "Mot de pouvoir : Bouclier";
                case "Italiano":
                    return "Parola del Potere: Scudo";
                case "Português Brasileiro":
                    return "Palavra de Poder: Escudo";
                case "Русский":
                    return "Слово силы: Щит";
                case "한국어":
                    return "신의 권능: 보호막";
                case "简体中文":
                    return "真言术：盾";
                default:
                    return "Power Word: Shield";
            }
        }
        private static string PrayerofHealing_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gebet der Heilung";
                case "Español":
                    return "Rezo de sanación";
                case "Français":
                    return "Prière de soins";
                case "Italiano":
                    return "Preghiera di Cura";
                case "Português Brasileiro":
                    return "Prece de Cura";
                case "Русский":
                    return "Молитва исцеления";
                case "한국어":
                    return "치유의 기원";
                case "简体中文":
                    return "治疗祷言";
                default:
                    return "Prayer of Healing";
            }
        }
        private static string PrayerofMending_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gebet der Besserung";
                case "Español":
                    return "Rezo de alivio";
                case "Français":
                    return "Prière de guérison";
                case "Italiano":
                    return "Preghiera di Guarigione";
                case "Português Brasileiro":
                    return "Prece da Recomposição";
                case "Русский":
                    return "Молитва восстановления";
                case "한국어":
                    return "회복의 기원";
                case "简体中文":
                    return "愈合祷言";
                default:
                    return "Prayer of Mending";
            }
        }
        private static string Purify_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Läutern";
                case "Español":
                    return "Purificar";
                case "Français":
                    return "Purifier";
                case "Italiano":
                    return "Depurazione";
                case "Português Brasileiro":
                    return "Purificar";
                case "Русский":
                    return "Очищение";
                case "한국어":
                    return "정화";
                case "简体中文":
                    return "纯净术";
                default:
                    return "Purify";
            }
        }
        private static string Renew_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Erneuerung";
                case "Español":
                    return "Renovar";
                case "Français":
                    return "Rénovation";
                case "Italiano":
                    return "Rinnovamento";
                case "Português Brasileiro":
                    return "Renovar";
                case "Русский":
                    return "Обновление";
                case "한국어":
                    return "소생";
                case "简体中文":
                    return "恢复";
                default:
                    return "Renew";
            }
        }
        private static string ShadowWordDeath_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schattenwort: Tod";
                case "Español":
                    return "Palabra de las Sombras: muerte";
                case "Français":
                    return "Mot de l’ombre : Mort";
                case "Italiano":
                    return "Parola d'Ombra: Morte";
                case "Português Brasileiro":
                    return "Palavra Sombria: Morte";
                case "Русский":
                    return "Слово Тьмы: Смерть";
                case "한국어":
                    return "어둠의 권능: 죽음";
                case "简体中文":
                    return "暗言术：灭";
                default:
                    return "Shadow Word: Death";
            }
        }
        private static string ShadowWordPain_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schattenwort: Schmerz";
                case "Español":
                    return "Palabra de las Sombras: dolor";
                case "Français":
                    return "Mot de l’ombre : Douleur";
                case "Italiano":
                    return "Parola d'Ombra: Dolore";
                case "Português Brasileiro":
                    return "Palavra Sombria: Dor";
                case "Русский":
                    return "Слово Тьмы: Боль";
                case "한국어":
                    return "어둠의 권능: 고통";
                case "简体中文":
                    return "暗言术：痛";
                default:
                    return "Shadow Word: Pain";
            }
        }
        private static string Smite_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Heilige Pein";
                case "Español":
                    return "Punición";
                case "Français":
                    return "Châtiment";
                case "Italiano":
                    return "Punizione";
                case "Português Brasileiro":
                    return "Punição";
                case "Русский":
                    return "Кара";
                case "한국어":
                    return "성스러운 일격";
                case "简体中文":
                    return "惩击";
                default:
                    return "Smite";
            }
        }
        private static string SymbolofHope_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Symbol der Hoffnung";
                case "Español":
                    return "Símbolo de esperanza";
                case "Français":
                    return "Symbole d’espoir";
                case "Italiano":
                    return "Simbolo di Speranza";
                case "Português Brasileiro":
                    return "Símbolo de Esperança";
                case "Русский":
                    return "Символ надежды";
                case "한국어":
                    return "희망의 상징";
                case "简体中文":
                    return "希望象征";
                default:
                    return "Symbol of Hope";
            }
        }
        #endregion
        #region Covenant Spells
        private static string FaeGuardians_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Faewächter";
                case "Español":
                    return "Sílfides guardianas";
                case "Français":
                    return "Gardiens faë";
                case "Italiano":
                    return "Guardiani Silfi";
                case "Português Brasileiro":
                    return "Guardiões Feérios";
                case "Русский":
                    return "Волшебные стражи";
                case "한국어":
                    return "페이 수호자";
                case "简体中文":
                    return "法夜守护者";
                default:
                    return "Fae Guardians";
            }
        }
        private static string BoonoftheAscended_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segen der Aufgestiegenen";
                case "Español":
                    return "Bendición de los Ascendidos";
                case "Français":
                    return "Faveur des transcendés";
                case "Italiano":
                    return "Dono degli Ascesi";
                case "Português Brasileiro":
                    return "Dom dos Ascendidos";
                case "Русский":
                    return "Благословение перерожденных";
                case "한국어":
                    return "승천자의 은혜";
                case "简体中文":
                    return "晋升者之赐";
                default:
                    return "Boon of the Ascended";
            }
        }
        private static string Mindgames_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gedankenspiele";
                case "Español":
                    return "Juegos mentales";
                case "Français":
                    return "Jeux d’esprit";
                case "Italiano":
                    return "Giochi Mentali";
                case "Português Brasileiro":
                    return "Jogos Mentais";
                case "Русский":
                    return "Игры разума";
                case "한국어":
                    return "정신 조작";
                case "简体中文":
                    return "控心术";
                default:
                    return "Mindgames";
            }
        }
        private static string AscendedBlast_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Woge des Aufstiegs";
                case "Español":
                    return "Explosión ascendida";
                case "Français":
                    return "Déflagration d’ascension";
                case "Italiano":
                    return "Detonazione Ascesa";
                case "Português Brasileiro":
                    return "Impacto Ascendido";
                case "Русский":
                    return "Взрыв перерождения";
                case "한국어":
                    return "승천의 작렬";
                case "简体中文":
                    return "晋升冲击";
                default:
                    return "Ascended Blast";
            }
        }
        private static string AscendedNova_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Nova des Aufstiegs";
                case "Español":
                    return "Nova ascendida";
                case "Français":
                    return "Nova transcendée";
                case "Italiano":
                    return "Nova Ascesa";
                case "Português Brasileiro":
                    return "Nova Ascendida";
                case "Русский":
                    return "Кольцо перерождения";
                case "한국어":
                    return "승천의 회오리";
                case "简体中文":
                    return "晋升新星";
                default:
                    return "Ascended Nova";
            }
        }
        private static string UnholyNova_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Unheilige Nova";
                case "Español":
                    return "Nova profana";
                case "Français":
                    return "Nova impie";
                case "Italiano":
                    return "Nova Empia";
                case "Português Brasileiro":
                    return "Nova Profana";
                case "Русский":
                    return "Нечестивое кольцо";
                case "한국어":
                    return "부정한 폭발";
                case "简体中文":
                    return "邪恶新星";
                default:
                    return "Unholy Nova";
            }
        }
        #endregion
        #region Item Spells
        private static string Healthstone_SpellName()
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
        private static string PotionofSpectralIntellect_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Trank der Spektralintelligenz";
                case "Español":
                    return "Poci&oacute;n de intelecto espectral";
                case "Français":
                    return "Potion d&rsquo;Intelligence spectrale";
                case "Italiano":
                    return "Pozione dell'Intelletto Spettrale";
                case "Português Brasileiro":
                    return "Po&ccedil;&atilde;o do Intelecto Espectral";
                case "Русский":
                    return "Зелье призрачного интеллекта";
                case "한국어":
                    return "유령 지능의 물약";
                case "简体中文":
                    return "幽魂智力药水";
                default:
                    return "Potion of Spectral Intellect";
            }
        }
        private static string SpiritualManaPotion_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Spiritueller Manatrank";
                case "Español":
                    return "Poci&oacute;n de man&aacute; espiritual";
                case "Français":
                    return "Potion de mana spirituel";
                case "Italiano":
                    return "Pozione di Mana Spirituale";
                case "Português Brasileiro":
                    return "Po&ccedil;&atilde;o de Mana Espiritual";
                case "Русский":
                    return "Духовное зелье маны";
                case "한국어":
                    return "영적인 마나 물약";
                case "简体中文":
                    return "灵魂法力药水";
                default:
                    return "Spiritual Mana Potion";
            }
        }
        #endregion
        #endregion
        #region General Methods
        public static void Logger(string lines)
        {
            if (DebugMode)
            {
                string path = Directory.GetCurrentDirectory() + "\\Rotations\\JarlBrak_Zealot Free - Holy Priest\\";
                VerifyDir(path);
                string fileName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_ZealotLogs.txt";
                try
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(path + fileName, true);
                    file.WriteLine(DateTime.Now.ToString() + ": " + lines);
                    file.Close();
                }
                catch (Exception) { }
            }
        }
        public static void VerifyDir(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                }
            catch{}
        }
        private void GetTalents()
        {
            for (int i = 1; i <= 7; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (Aimsharp.Talent(i, j))
                    {
                        Talents[i] = new int();
                        Talents[i] = j;
                    }
                }
            }
        }
        #endregion
        #region Covenant Methods
        private bool UnholyNova()
        {
            string spellName = UnholyNova_SpellName();
            if (Aimsharp.EnemiesInMelee() > 3 && Aimsharp.CanCast(spellName, "player", false, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Unholy Nova cast in melee", Covenant);
                return true;
            }

            if (Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0)
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Unholy Nova on target", Covenant);
                return true;
            }
            return false;
        }
        private bool AscendedBlast()
        {
            string spellName = AscendedBlast_SpellName();
            if (Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0 && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Ascended Blast on target", Covenant);
                return true;
            }
            return false;
        }

        private bool AscendedNova()
        {
            string spellName = AscendedNova_SpellName();
            if (Aimsharp.EnemiesInMelee() > 3 && Aimsharp.CanCast(spellName, "player", false, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Ascended Nova cast", Covenant);
                return true;
            }
            
            return false;
        }

        private bool Mindgames()
        {
            string spellName = Mindgames_SpellName();
            if (!Moving && Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0 && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Mindgames on enemy target", Covenant);
                return true;
            }
            return false;
        }

        private bool BoonoftheAscended()
        {
            string spellName = BoonoftheAscended_SpellName();
            if (!Moving && UseCooldowns && Aimsharp.CanCast(spellName, "player", false, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Boon of the Ascended cast", Covenant);
                return true;
            }
            return false;
        }        

        private bool FaeGuardians()
        {
            string spellName = FaeGuardians_SpellName();
            if (UseCooldowns && Aimsharp.CanCast(spellName, "player", false, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Covenant - Fae Guardians cast", Covenant);
                return true;
            }
            return false;
        }
        #endregion
        #region DPS Spell Methods
        private bool ShadowWordPain()
        {
            string spellName = ShadowWordPain_SpellName();
            if (Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0  && Aimsharp.CanCast(spellName, "target", true, true))
            {
                if (!Aimsharp.HasDebuff(spellName, "target")
                    || Aimsharp.DebuffRemaining(spellName, "target", true) < 1000)
                {
                    Aimsharp.Cast(spellName);
                    Aimsharp.PrintMessage("DPS - SW:P on target", Damage);
                    return true;
                }
            }
            return false;
        }
        private bool ShadowWordDeath()
        {
            string spellName = ShadowWordDeath_SpellName();
            if (Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0  && Aimsharp.TargetCurrentHP() < 3 && Aimsharp.CanCast(spellName, "target", true, false))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("DPS - Shadow Word: Death on Target", Damage);
                return true;
            }

            return false;
        }
        private bool HolyWordChastise()
        {
            string spellName = HolyWordChastise_SpellName();
            if (Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0  && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("DPS - Chastise on target", Damage);
                return true;
            }
            return false;
        }
        private bool HolyFire()
        {
            string spellName = HolyFire_SpellName();
            if (!Moving && Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0  && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("DPS - Holy Fire on target", Damage);
                return true;
            }
            return false;
        }
        private bool Smite()
        {
            string spellName = Smite_SpellName();
            if (!Moving && Aimsharp.TargetIsEnemy() && Aimsharp.Health("target") > 0  && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("DPS - Smite on target", Damage);
                return true;
            }
            return false;
        }
        private bool MindBlast()
        {
            string spellName = MindBlast_SpellName();
            if (!Moving && Aimsharp.TargetIsEnemy() && Aimsharp.TargetExactCurrentHP() > 1500  && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("DPS - " + spellName + " on target", Damage);
                return true;
            }
            return false;
        }
        #endregion
        #region Holy Spell Methods
        private bool HolyWordSerenity(int healthThreshold)
        {
            string spellName = HolyWordSerenity_SpellName();
            if (Aimsharp.Health("target") <= healthThreshold && Aimsharp.CanCast(spellName, "target", true, false))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Holy Word: Serenity on target", Healing);
                return true;
            }
            return false;
        }
        private bool FlashHeal(int healthThreshold)
        {
            string spellName = FlashHeal_SpellName();
            if (Aimsharp.Health("target") <= healthThreshold && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Flash Heal on target", Healing);
                return true;
            }
            return false;
        }
        private bool Heal(int healthThreshold)
        {
            string spellName = Heal_SpellName();
            if (Aimsharp.Health("target") <= healthThreshold && Aimsharp.CanCast(spellName, "target", true, true))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Heal on target", Healing);
                return true;
            }
            return false;
        }
        private bool Renew(int healthThreshold)
        {
            string spellName = Renew_SpellName();
            if (Aimsharp.Health("target") <= healthThreshold
                && Aimsharp.CanCast(spellName, "target", true, true)
                && !Aimsharp.HasBuff(spellName, "target"))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("Renew on target", Healing);
                return true;
            }
            return false;
        }
        private bool PrayerofMending(int healthThreshold)
        {
            string spellName = PrayerofMending_SpellName();
            if (Aimsharp.Health("target") <= healthThreshold && Aimsharp.CanCast(spellName, "target", false, true))
            {
                Aimsharp.Cast(spellName);   
                Aimsharp.PrintMessage("Prayer of Mending on target", Healing);
                return true;
            }
            return false;
        }
        private bool HolyWordSanctify(int healthThreshold)
        {
            string spellName = HolyWordSanctify_SpellName();
            if (InParty
                && Aimsharp.Health("target") <= healthThreshold
                && Aimsharp.AlliesNearTarget() >= 2
                && Aimsharp.CanCast(spellName, "player", false, true))
            {
                Aimsharp.Cast("SanctifyCursor");
                Aimsharp.PrintMessage("Sanctify on cursor", Healing);
                return true;
            }
            return false;
        }
        private bool GuardianSpiritCD(int healthThreshold)
        {
            string spellName = GuardianSpirit_SpellName();
            if (Aimsharp.Health("target") <= healthThreshold && Aimsharp.CanCast(spellName, "target", true, true) && !Aimsharp.HasBuff(spellName, "target"))
            {
                Aimsharp.Cast(spellName);
                Aimsharp.PrintMessage("CD - Guardian Spirit on target", Cooldown);
                return true;
            }
            return false;
        }
        private bool AngelicFeatherSelf()
        {
            string spellName = AngelicFeather_SpellName();
            if (Aimsharp.CanCast(spellName, "player", false, true) && !Aimsharp.HasBuff(spellName, "player"))
            {
                Aimsharp.Cast("AngelicFeatherSelf");
                Aimsharp.PrintMessage("Angelic Feather speed boost used", Color.White);
                return true;
            }
            return false;
        }
        private bool BodyandSoulSelf()
        {
            string spellName = PowerWordShield_SpellName();
            if (Aimsharp.CanCast(spellName, "player", false, true) && !Aimsharp.HasDebuff(WeakenedSoul_SpellName(), "player"))
            {
                Aimsharp.Cast("BodyandSoulSelf");
                Aimsharp.PrintMessage("Body and Soul (PW:S) speed boost used", Color.White);
                return true;
            }
            return false;
        }
        #endregion
        #region Holy Rotation Methods
        private bool SingleTargetModeRotation()
        {
            if (!Aimsharp.TargetIsEnemy() || TargetHealth == 0)
            {
                if (UseCooldowns)
                {
                    if (Aimsharp.CanUseTrinket(0) && !Moving)
                    {
                        Aimsharp.Cast("TopTrinket", true);
                        Aimsharp.PrintMessage("CD - Top Trinket used", Cooldown);
                        return true;
                    }
                    if (Aimsharp.CanUseTrinket(1) && !Moving)
                    {
                        Aimsharp.Cast("BottomTrinket", true);
                        Aimsharp.PrintMessage("CD - Bottom Trinket used", Cooldown);
                        return true;
                    }
                    if (GuardianSpiritCD(20)) return true;
                }
                if (HolyWordSanctify(85)) return true;
                if (Renew(100)) return true;
                if (PrayerofMending(100)) return true;
                if (HolyWordSerenity(30)) return true;
                if (Heal(85)) return true;
                if (FlashHeal(60)) return true;
            }
            if (Aimsharp.TargetIsEnemy())
            {
                if (UseCooldowns && CovenantID == 3) if (FaeGuardians()) return true;
                if (UseCooldowns && CovenantID == 1) if (BoonoftheAscended()) return true;
                if (HasBuffFae && CovenantID == 3) if (ShadowWordPain()) return true;
                if (HasBuffBoon && CovenantID == 1) if (AscendedBlast()) return true;
                if (HasBuffBoon && CovenantID == 1) if (AscendedNova()) return true;
                if (CovenantID == 4) if (UnholyNova()) return true;
                if (CovenantID == 2) if(Mindgames()) return true;
                if (ShadowWordDeath()) return true;
                if (HolyWordChastise()) return true;
                if (HolyFire()) return true;
                if (ShadowWordPain()) return true;
                if (MindBlast()) return true;
                if (Smite()) return true;
            }
            return false;
        }
        #endregion
        #region Aimsharp Methods
        public override void LoadSettings()
        {
            Settings.Add(new Setting("Zealot Free Edition - A Holy Priest rotation by JarlBrak"));
            Settings.Add(new Setting("Game Client Language", new List<string>(){"English", "Deutsch", "Español", "Français", "Italiano", "Português Brasileiro", "Русский", "한국어", "简体中文"}, "English"));
            Settings.Add(new Setting("Internet Lag Settings"));
            Settings.Add(new Setting("Spell Queue Window", 0, 400, 10));
            Settings.Add(new Setting("Latency", 0, 200, 60));
        }
        public override void Initialize()
        {
            Aimsharp.PrintMessage("-----------------------------------------------------------------------------------------------------------------", Color.White);
            Aimsharp.PrintMessage("Welcome to Zealot Free Edition 2.0.1 - A Priest rotation by JarlBrak", Color.White);
            Aimsharp.PrintMessage("-----------------------------------------------------------------------------------------------------------------", Color.White);
            Aimsharp.PrintMessage("Please refer to the Discord server for setup info as well", Color.White);
            Aimsharp.PrintMessage("as open issues/bugs!", Color.White);
            Aimsharp.PrintMessage("-----------------------------------------------------------------------------------------------------------------", Color.White);

            Language = GetDropDown("Game Client Language");
            SpellQueueWindow = GetSlider("Spell Queue Window");
            Latency = GetSlider("Latency");

            Aimsharp.Latency = Latency;

            Macros.Add("AngelicFeatherSelf", "/cast [@player] " + AngelicFeather_SpellName());
            Macros.Add("BodyandSoulSelf", "/cast [@player] " + PowerWordShield_SpellName());
            Macros.Add("SanctifyCursor", "/cast [@cursor] " + HolyWordSanctify_SpellName());

            #region Lists
            AntiHealingDebuffs = new List<string>
            {
                GluttonousMiasma_SpellName(),
                CloakofFlames_SpellName()
            };
            BuffsList = new List<string>
            {
                FlashConcentration_SpellName(),
                SurgeofLight_SpellName(),
                ResonantWords_SpellName(),
                PowerWordShield_SpellName(),
                FaeGuardians_SpellName(),
                BoonoftheAscended_SpellName(),
                SpiritofRedemption_SpellName(),
                PrayerofMending_SpellName(),
                Renew_SpellName(),
                Apotheosis_SpellName(),
                AngelicFeather_SpellName(),
                PowerWordFortitude_SpellName()
            };
            DebuffsList = new List<string>
            {
                ShadowWordPain_SpellName(),
                WrathfulFaerie_SpellName(),
                WeakenedSoul_SpellName(),
                GluttonousMiasma_SpellName()
            };
            SpellsList = new List<string>
            {
                AngelicFeather_SpellName(),
                Apotheosis_SpellName(),
                BindingHeal_SpellName(),
                CircleofHealing_SpellName(),
                DesperatePrayer_SpellName(),
                DivineHymn_SpellName(),
                DivineStar_SpellName(),
                DispelMagic_SpellName(),
                Fade_SpellName(),
                FlashHeal_SpellName(),
                GuardianSpirit_SpellName(),
                Halo_SpellName(),
                Heal_SpellName(),
                HolyFire_SpellName(),
                HolyNova_SpellName(),
                HolyWordChastise_SpellName(),
                HolyWordSalvation_SpellName(),
                HolyWordSanctify_SpellName(),
                HolyWordSerenity_SpellName(),
                LeapofFaith_SpellName(),
                PowerInfusion_SpellName(),
                PowerWordFortitude_SpellName(),
                PowerWordShield_SpellName(),
                PrayerofHealing_SpellName(),
                PrayerofMending_SpellName(),
                Purify_SpellName(),
                Renew_SpellName(),
                ShadowWordDeath_SpellName(),
                ShadowWordPain_SpellName(),
                Smite_SpellName(),
                SymbolofHope_SpellName()
            };
            ItemsList = new List<string>
            {
                Healthstone_SpellName(),
                PotionofSpectralIntellect_SpellName(),
                SpiritualManaPotion_SpellName()
            };
            MacroCommands = new List<string>
            {
                "DebugMode",
                "UseCDs",
                "FocusHeals",
                "AutoStart",
                "MovementBoost"
            };
            CovenantAbilities = new List<string>
            {
                FaeGuardians_SpellName(),
                BoonoftheAscended_SpellName(),
                Mindgames_SpellName(),
                AscendedBlast_SpellName(),
                AscendedNova_SpellName(),
                UnholyNova_SpellName()
            };
            #endregion

            SpellsList.ForEach(spell => Spellbook.Add(spell));
            CovenantAbilities.ForEach(spell => Spellbook.Add(spell));
            BuffsList.ForEach(buff => Buffs.Add(buff));
            DebuffsList.ForEach(debuff => Debuffs.Add(debuff));
            MacroCommands.ForEach(macroCommand => CustomCommands.Add(macroCommand));
        }
        public override bool CombatTick()
        {
            DebugMode = Aimsharp.IsCustomCodeOn("DebugMode");
            UseCooldowns = Aimsharp.IsCustomCodeOn("UseCDs");
            AutoStartMode = Aimsharp.IsCustomCodeOn("AutoStart");
            MovementBoost = Aimsharp.IsCustomCodeOn("MovementBoost");
            Moving = Aimsharp.PlayerIsMoving();
            PlayerHealth = Aimsharp.Health("player");
            TargetHealth = Aimsharp.Health("target");
            Mounted = Aimsharp.PlayerIsMounted();
            Channeling = Aimsharp.IsChanneling("player");
            CastTimeRemaining = Aimsharp.CastingRemaining("player") - SpellQueueWindow;
            Casting = CastTimeRemaining > SpellQueueWindow;
            HasBuffFae = Aimsharp.HasBuff(FaeGuardians_SpellName(), "player", true);
            HasBuffBoon = Aimsharp.HasBuff(BoonoftheAscended_SpellName(), "player", true);
            InCombat = true;

            GetTalents();
            if (Mounted || Channeling) return false;
            if (Moving && MovementBoost && Talents[2] == 3) if (AngelicFeatherSelf()) return true;
            if (Moving && MovementBoost && Talents[2] == 2) if (BodyandSoulSelf()) return true;
            if (SingleTargetModeRotation()) return true;
            return true;
        }
        public override bool OutOfCombatTick()
        {
            DebugMode = Aimsharp.IsCustomCodeOn("DebugMode");
            UseCooldowns = Aimsharp.IsCustomCodeOn("UseCDs");
            AutoStartMode = Aimsharp.IsCustomCodeOn("AutoStart");
            MovementBoost = Aimsharp.IsCustomCodeOn("MovementBoost");
            Moving = Aimsharp.PlayerIsMoving();
            Mounted = Aimsharp.PlayerIsMounted();
            Channeling = Aimsharp.IsChanneling("player");
            CastTimeRemaining = Aimsharp.CastingRemaining("player") - SpellQueueWindow;
            Casting = CastTimeRemaining > SpellQueueWindow;
            CovenantID = Aimsharp.CovenantID();
            
            GetTalents();
            if (Mounted || Channeling) return false;
            if (Moving && MovementBoost && Talents[2] == 3) if (AngelicFeatherSelf()) return true;
            if (Moving && MovementBoost && Talents[2] == 2) if (BodyandSoulSelf()) return true;
            if (AutoStartMode) if (SingleTargetModeRotation()) return true;

            InCombat = false;
            return true;
        }
        #endregion
    }
}