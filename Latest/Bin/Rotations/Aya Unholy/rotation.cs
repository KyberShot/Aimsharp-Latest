using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API; //needed to access Aimsharp API


namespace AimsharpWow.Modules
{

    public class ShadowlandsUnholy : Rotation
    {
        #region Translations
        private static string Language = "English";
        private static string Heroism_SpellName()
        {
            // spell=32182
            switch (Language)
            {
                case "English":
                    return "Heroism";
                case "Deutsch":
                    return "Heldentum";
                case "Español":
                    return "Heroísmo";
                case "Français":
                    return "Héroïsme";
                case "Italiano":
                    return "Eroismo";
                case "Português Brasileiro":
                    return "Heroísmo";
                case "Русский":
                    return "Героизм";
                case "한국어":
                    return "영웅심";
                case "简体中文":
                    return "英勇";
                default:
                    return "Heroism";
            }
        }
        private static string SpiritualHealingPotion_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Spiritueller Heiltrank";
                case "Español":
                    return "Poci&oacute;n de sanaci&oacute;n espiritual";
                case "Français":
                    return "Potion de soins spirituels";
                case "Italiano":
                    return "Pozione di Cura Spirituale";
                case "Português Brasileiro":
                    return "Po&ccedil;&atilde;o de Cura Espiritual";
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
        private static string BloodFury_SpellName()
        {
            // spell=33697
            switch (Language)
            {
                case "English":
                    return "Blood Fury";
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

        private static string Berserking_SpellName()
        {
            // spell=26297
            switch (Language)
            {
                case "English":
                    return "Berserking";
                case "Deutsch":
                    return "Berserker";
                case "Español":
                    return "Rabiar";
                case "Français":
                    return "Berserker";
                case "Italiano":
                    return "Berserker";
                case "Português Brasileiro":
                    return "Berserk";
                case "Русский":
                    return "Берсерк";
                case "한국어":
                    return "광폭화";
                case "简体中文":
                    return "狂暴";
                default:
                    return "Berserking";
            }
        }

        private static string Fireblood_SpellName()
        {
            // spell=265221
            switch (Language)
            {
                case "English":
                    return "Fireblood";
                case "Deutsch":
                    return "Feuerblut";
                case "Español":
                    return "Sangrardiente";
                case "Français":
                    return "Sang de feu";
                case "Italiano":
                    return "Sangue Infuocato";
                case "Português Brasileiro":
                    return "Sangue de Fogo";
                case "Русский":
                    return "Огненная кровь";
                case "한국어":
                    return "불꽃피";
                case "简体中文":
                    return "烈焰之血";
                default:
                    return "Fireblood";
            }
        }

        private static string AncestralCall_SpellName()
        {
            // spell=274738
            switch (Language)
            {
                case "English":
                    return "Ancestral Call";
                case "Deutsch":
                    return "Ruf der Ahnen";
                case "Español":
                    return "Llamada ancestral";
                case "Français":
                    return "Appel ancestral";
                case "Italiano":
                    return "Richiamo Ancestrale";
                case "Português Brasileiro":
                    return "Chamado Ancestral";
                case "Русский":
                    return "Призыв предков";
                case "한국어":
                    return "고대의 부름";
                case "简体中文":
                    return "先祖召唤";
                default:
                    return "Ancestral Call";
            }
        }

        private static string LightsJudgment_SpellName()
        {
            // spell=255647
            switch (Language)
            {
                case "English":
                    return "Light's Judgment";
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

        private static string ArcaneTorrent_SpellName()
        {
            // spell=28730
            switch (Language)
            {
                case "English":
                    return "Arcane Torrent";
                case "Deutsch":
                    return "Arkaner Strom";
                case "Español":
                    return "Torrente Arcano";
                case "Français":
                    return "Torrent arcanique";
                case "Italiano":
                    return "Torrente Arcano";
                case "Português Brasileiro":
                    return "Torrente Arcana";
                case "Русский":
                    return "Волшебный поток";
                case "한국어":
                    return "비전 격류";
                case "简体中文":
                    return "奥术洪流";
                default:
                    return "Arcane Torrent";
            }
        }

        private static string WarStomp_SpellName()
        {
            // spell=20549
            switch (Language)
            {
                case "English":
                    return "War Stomp";
                case "Deutsch":
                    return "Kriegsdonner";
                case "Español":
                    return "Pisotón de guerra";
                case "Français":
                    return "Choc martial";
                case "Italiano":
                    return "Zoccolo di Guerra";
                case "Português Brasileiro":
                    return "Pisada de Guerra";
                case "Русский":
                    return "Громовая поступь";
                case "한국어":
                    return "전투 발구르기";
                case "简体中文":
                    return "战争践踏";
                default:
                    return "War Stomp";
            }
        }
        private static string ArcanePulse_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Arkaner Puls";
                case "Español":
                    return "Pulso Arcano";
                case "Français":
                    return "Impulsion arcanique";
                case "Italiano":
                    return "Impulso Arcano";
                case "Português Brasileiro":
                    return "Pulso Arcano";
                case "Русский":
                    return "Чародейский импульс";
                case "한국어":
                    return "비전 파동";
                case "简体中文":
                    return "奥术脉冲";
                default:
                    return "Arcane Pulse";
            }
        }
        private static string BagofTricks_SpellName()
        {
            // spell=312411
            switch (Language)
            {
                case "English":
                    return "Bag of Tricks";
                case "Deutsch":
                    return "Trickkiste";
                case "Español":
                    return "Bolsa de trucos";
                case "Français":
                    return "Sac à malice";
                case "Italiano":
                    return "Borsa di Trucchi";
                case "Português Brasileiro":
                    return "Bolsa de Truques";
                case "Русский":
                    return "Набор хитростей";
                case "한국어":
                    return "비장의 묘수";
                case "简体中文":
                    return "袋里乾坤";
                default:
                    return "Bag of Tricks";
            }
        }
        private static string Bloodlust_SpellName()
        {
            // spell=2825
            switch (Language)
            {
                case "English":
                    return "Bloodlust";
                case "Deutsch":
                    return "Kampfrausch";
                case "Español":
                    return "Ansia de sangre";
                case "Français":
                    return "Furie sanguinaire";
                case "Italiano":
                    return "Brama di Sangue";
                case "Português Brasileiro":
                    return "Sede de Sangue";
                case "Русский":
                    return "Жажда крови";
                case "한국어":
                    return "피의 욕망";
                case "简体中文":
                    return "嗜血";
                default:
                    return "Bloodlust";
            }
        }

        private static string TimeWarp_SpellName()
        {
            // spell=80353
            switch (Language)
            {
                case "English":
                    return "Time Warp";
                case "Deutsch":
                    return "Zeitkrümmung";
                case "Español":
                    return "Distorsión temporal";
                case "Français":
                    return "Distorsion temporelle";
                case "Italiano":
                    return "Distorsione Temporale";
                case "Português Brasileiro":
                    return "Distorção Temporal";
                case "Русский":
                    return "Искажение времени";
                case "한국어":
                    return "시간 왜곡";
                case "简体中文":
                    return "时间扭曲";
                default:
                    return "Time Warp";
            }
        }

        private static string AncientHysteria_SpellName()
        {
            // spell=90355
            switch (Language)
            {
                case "English":
                    return "Ancient Hysteria";
                case "Deutsch":
                    return "Uralte Hysterie";
                case "Español":
                    return "Histeria ancestral";
                case "Français":
                    return "Hystérie ancienne";
                case "Italiano":
                    return "Isteria degli Antichi";
                case "Português Brasileiro":
                    return "Histeria Ancestral";
                case "Русский":
                    return "Древняя истерия";
                case "한국어":
                    return "고대의 격분";
                case "简体中文":
                    return "远古狂乱";
                default:
                    return "Ancient Hysteria";
            }
        }

        private static string Netherwinds_SpellName()
        {
            // spell=160452
            switch (Language)
            {
                case "English":
                    return "Netherwinds";
                case "Deutsch":
                    return "Netherwinde";
                case "Español":
                    return "Vientos abisales";
                case "Français":
                    return "Vents du Néant";
                case "Italiano":
                    return "Venti Fatui";
                case "Português Brasileiro":
                    return "Ventos Etéreos";
                case "Русский":
                    return "Ветер Пустоты";
                case "한국어":
                    return "황천바람";
                case "简体中文":
                    return "虚空之风";
                default:
                    return "Netherwinds";
            }
        }

        private static string DrumsofRage_SpellName()
        {
            // item=102351
            switch (Language)
            {
                case "English":
                    return "Drums of Rage";
                case "Deutsch":
                    return "Trommeln des Zorns";
                case "Español":
                    return "Tambores de ira";
                case "Français":
                    return "Tambours de rage";
                case "Italiano":
                    return "Tamburi della Rabbia";
                case "Português Brasileiro":
                    return "Tambores da Raiva";
                case "Русский":
                    return "Барабаны ярости";
                case "한국어":
                    return "분노의 북";
                case "简体中文":
                    return "暴怒之鼓";
                default:
                    return "Drums of Rage";
            }
        }
        private static string PhialofSerenity_SpellName()
        {
            // item=177278
            switch (Language)
            {
                case "English":
                    return "Phial of Serenity";
                case "Deutsch":
                    return "Phiole des Gleichmuts";
                case "Español":
                    return "Ampolla de serenidad";
                case "Français":
                    return "Flasque de sérénité";
                case "Italiano":
                    return "Fiala della Serenità";
                case "Português Brasileiro":
                    return "Frasco de Serenidade";
                case "Русский":
                    return "Флакон безмятежности";
                case "한국어":
                    return "평온의 약병";
                case "简体中文":
                    return "静谧之瓶";
                default:
                    return "Phial of Serenity";
            }
        }
        private static string Outbreak_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Ausbruch";
                case "Español":
                    return "Brote";
                case "Français":
                    return "Poussée de fièvre";
                case "Italiano":
                    return "Contagio";
                case "Português Brasileiro":
                    return "Eclosão";
                case "Русский":
                    return "Вспышка болезни";
                case "한국어":
                    return "돌발 열병";
                case "简体中文":
                    return "爆发";
                default:
                    return "Outbreak";
            }
        }
        private static string Epidemic_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Epidemie";
                case "Español":
                    return "Epidemia";
                case "Français":
                    return "Epidémie";
                case "Italiano":
                    return "Epidemia";
                case "Português Brasileiro":
                    return "Epidemia";
                case "Русский":
                    return "Эпидемия";
                case "한국어":
                    return "전염병";
                case "简体中文":
                    return "传染";
                default:
                    return "Epidemic";
            }
        }
        private static string ScourgeStrike_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Geißelstoß";
                case "Español":
                    return "Golpe de la Plaga";
                case "Français":
                    return "Frappe du Fléau";
                case "Italiano":
                    return "Assalto del Flagello";
                case "Português Brasileiro":
                    return "Golpe do Flagelo";
                case "Русский":
                    return "Удар Плети";
                case "한국어":
                    return "스컬지의 일격";
                case "简体中文":
                    return "天灾打击";
                default:
                    return "Scourge Strike";
            }
        }
        private static string SacrificalPact_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Opferpakt";
                case "Español":
                    return "Sacrificio pactado";
                case "Français":
                    return "Pacte sacrificiel";
                case "Italiano":
                    return "Patto Sacrificale";
                case "Português Brasileiro":
                    return "Pacto Sacrificial";
                case "Русский":
                    return "Жертвенный договор";
                case "한국어":
                    return "희생의 서약";
                case "简体中文":
                    return "牺牲契约";
                default:
                    return "Sacrificial Pact";
            }
        }
        private static string ClawingShadows_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Reißende Schatten";
                case "Español":
                    return "Sombras desgarradoras";
                case "Français":
                    return "Griffes des ombres";
                case "Italiano":
                    return "Ombre Attanaglianti";
                case "Português Brasileiro":
                    return "Garras das Sombras";
                case "Русский":
                    return "Стискивающие тени";
                case "한국어":
                    return "할퀴는 어둠";
                case "简体中文":
                    return "暗影之爪";
                default:
                    return "Clawing Shadows";
            }
        }
        private static string DeathandDecay_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Tod und Verfall";
                case "Español":
                    return "Muerte y descomposición";
                case "Français":
                    return "Mort et décomposition";
                case "Italiano":
                    return "Morte e Distruzione";
                case "Português Brasileiro":
                    return "Morte e Decomposição";
                case "Русский":
                    return "Смерть и разложение";
                case "한국어":
                    return "죽음과 부패";
                case "简体中文":
                    return "枯萎凋零";
                default:
                    return "Death and Decay";
            }
        }
        private static string DeathsDue_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Recht des Todes";
                case "Español":
                    return "Cuota de la muerte";
                case "Français":
                    return "Dû de la mort";
                case "Italiano":
                    return "Dovere della Morte";
                case "Português Brasileiro":
                    return "Tributo da Morte";
                case "Русский":
                    return "Дань смерти";
                case "한국어":
                    return "죽음의 대가";
                case "简体中文":
                    return "消亡之债";
                default:
                    return "Death's Due";
            }
        }
        private static string Defile_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Entweihen";
                case "Español":
                    return "Profanar";
                case "Français":
                    return "Profanation";
                case "Italiano":
                    return "Profanazione";
                case "Português Brasileiro":
                    return "Profanar";
                case "Русский":
                    return "Осквернение";
                case "한국어":
                    return "파멸";
                case "简体中文":
                    return "亵渎";
                default:
                    return "Defile";
            }
        }
        private static string FesteringStrike_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schwärender Stoß";
                case "Español":
                    return "Golpe purulento";
                case "Français":
                    return "Frappe purulente";
                case "Italiano":
                    return "Assalto Putrescente";
                case "Português Brasileiro":
                    return "Ataque Supurante";
                case "Русский":
                    return "Удар разложения";
                case "한국어":
                    return "고름 일격";
                case "简体中文":
                    return "脓疮打击";
                default:
                    return "Festering Strike";
            }
        }
        private static string ArmyoftheDead_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Armee der Toten";
                case "Español":
                    return "Ejército de muertos";
                case "Français":
                    return "Armée des morts";
                case "Italiano":
                    return "Armata dei Morti";
                case "Português Brasileiro":
                    return "Exército dos Mortos";
                case "Русский":
                    return "Войско мертвых";
                case "한국어":
                    return "사자의 군대";
                case "简体中文":
                    return "亡者大军";
                default:
                    return "Army of the Dead";
            }
        }
        private static string UnholyBlight_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Unheilige Verseuchung";
                case "Español":
                    return "Añublo profano";
                case "Français":
                    return "Chancre impie";
                case "Italiano":
                    return "Sciame Empio";
                case "Português Brasileiro":
                    return "Devastação Profana";
                case "Русский":
                    return "Нечестивая порча";
                case "한국어":
                    return "부정의 파멸충";
                case "简体中文":
                    return "邪恶虫群";
                default:
                    return "Unholy Blight";
            }
        }
        private static string DarkTransformation_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Dunkle Transformation";
                case "Español":
                    return "Transformación oscura";
                case "Français":
                    return "Sombre transformation";
                case "Italiano":
                    return "Trasformazione Oscura";
                case "Português Brasileiro":
                    return "Transformação Negra";
                case "Русский":
                    return "Темное превращение";
                case "한국어":
                    return "어둠의 변신";
                case "简体中文":
                    return "黑暗突变";
                default:
                    return "Dark Transformation";
            }
        }
        private static string Apocalypse_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Apokalypse";
                case "Español":
                    return "Apocalipsis";
                case "Français":
                    return "Apocalypse";
                case "Italiano":
                    return "Apocalisse";
                case "Português Brasileiro":
                    return "Apocalipse";
                case "Русский":
                    return "Апокалипсис";
                case "한국어":
                    return "대재앙";
                case "简体中文":
                    return "天启";
                default:
                    return "Apocalypse";
            }
        }
        private static string SummonGargoyle_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gargoyle beschwören";
                case "Español":
                    return "Invocar gárgola";
                case "Français":
                    return "Invocation d'une gargouille";
                case "Italiano":
                    return "Evocazione: Gargoyle";
                case "Português Brasileiro":
                    return "Evocar Gárgula";
                case "Русский":
                    return "Призыв горгульи";
                case "한국어":
                    return "가고일 부르기";
                case "简体中文":
                    return "召唤石像鬼";
                default:
                    return "Summon Gargoyle";
            }
        }
        private static string UnholyAssault_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Unheiliger Angriff";
                case "Español":
                    return "Asalto profano";
                case "Français":
                    return "Assaut impie";
                case "Italiano":
                    return "Assalto Empio";
                case "Português Brasileiro":
                    return "Ataque Profano";
                case "Русский":
                    return "Нечестивый натиск";
                case "한국어":
                    return "부정의 습격";
                case "简体中文":
                    return "邪恶突袭";
                default:
                    return "Unholy Assault";
            }
        }
        private static string SoulReaper_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Seelenernter";
                case "Español":
                    return "Segador de almas";
                case "Français":
                    return "Faucheur d’âme";
                case "Italiano":
                    return "Mietitura dell'Anima";
                case "Português Brasileiro":
                    return "Ceifador de Almas";
                case "Русский":
                    return "Жнец душ";
                case "한국어":
                    return "영혼 수확자";
                case "简体中文":
                    return "灵魂收割";
                default:
                    return "Soul Reaper";
            }
        }
        private static string RaiseDead_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Totenerweckung";
                case "Español":
                    return "Levantar muerto";
                case "Français":
                    return "Réanimation morbide";
                case "Italiano":
                    return "Rianima Cadavere";
                case "Português Brasileiro":
                    return "Reviver Morto";
                case "Русский":
                    return "Воскрешение мертвых";
                case "한국어":
                    return "시체 되살리기";
                case "简体中文":
                    return "亡者复生";
                default:
                    return "Raise Dead";
            }
        }
        private static string SwarmingMist_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schwärmender Nebel";
                case "Español":
                    return "Niebla enjambradora";
                case "Français":
                    return "Brume écrasante";
                case "Italiano":
                    return "Nebbia Sciamante";
                case "Português Brasileiro":
                    return "Bruma Enxameante";
                case "Русский":
                    return "Клубящийся туман";
                case "한국어":
                    return "모여드는 안개";
                case "简体中文":
                    return "云集之雾";
                default:
                    return "Swarming Mist";
            }
        }
        private static string AbominationLimb_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Monströse Gliedmaße";
                case "Español":
                    return "Extremidad abominable";
                case "Français":
                    return "Membre abominable";
                case "Italiano":
                    return "Arto di Abominio";
                case "Português Brasileiro":
                    return "Membro da Abominação";
                case "Русский":
                    return "Рука поганища";
                case "한국어":
                    return "흉물 사지";
                case "简体中文":
                    return "憎恶附肢";
                default:
                    return "Abomination Limb";
            }
        }
        private static string ShackletheUnworthy_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Fesseln der Unwürdigen";
                case "Español":
                    return "Encadenar a los indignos";
                case "Français":
                    return "Entrave d’indignité";
                case "Italiano":
                    return "Incatenamento Immeritevoli";
                case "Português Brasileiro":
                    return "Agrilhoar os Indignos";
                case "Русский":
                    return "Узы недостойных";
                case "한국어":
                    return "부덕한 자의 굴레";
                case "简体中文":
                    return "失格者之梏";
                default:
                    return "Shackle the Unworthy";
            }
        }
        private static string DeathCoil_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Todesmantel";
                case "Español":
                    return "Espiral de la muerte";
                case "Français":
                    return "Voile mortel";
                case "Italiano":
                    return "Spira Mortale";
                case "Português Brasileiro":
                    return "Espiral da Morte";
                case "Русский":
                    return "Лик смерти";
                case "한국어":
                    return "죽음의 고리";
                case "简体中文":
                    return "凋零缠绕";
                default:
                    return "Death Coil";
            }
        }
        private static string IceboundFortitude_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Eisige Gegenwehr";
                case "Español":
                    return "Entereza ligada al hielo";
                case "Français":
                    return "Robustesse glaciale";
                case "Italiano":
                    return "Fermezza Glaciale";
                case "Português Brasileiro":
                    return "Fortitude Congélida";
                case "Русский":
                    return "Незыблемость льда";
                case "한국어":
                    return "얼음같은 인내력";
                case "简体中文":
                    return "冰封之韧";
                default:
                    return "Icebound Fortitude";
            }
        }
        private static string Lichborne_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Lichritter";
                case "Español":
                    return "Exánime nato";
                case "Français":
                    return "Changeliche";
                case "Italiano":
                    return "Essenza del Lich";
                case "Português Brasileiro":
                    return "Forma Decadente";
                case "Русский":
                    return "Перерождение";
                case "한국어":
                    return "리치의 혼";
                case "简体中文":
                    return "巫妖之躯";
                default:
                    return "Lichborne";
            }
        }
        private static string DeathPact_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Todespakt";
                case "Español":
                    return "Pacto de la Muerte";
                case "Français":
                    return "Pacte mortel";
                case "Italiano":
                    return "Patto con la Morte";
                case "Português Brasileiro":
                    return "Pacto da Morte";
                case "Русский":
                    return "Смертельный союз";
                case "한국어":
                    return "죽음의 서약";
                case "简体中文":
                    return "天灾契约";
                default:
                    return "Death Pact";
            }
        }
        private static string DeathStrike_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Todesstoß";
                case "Español":
                    return "Golpe letal";
                case "Français":
                    return "Frappe de mort";
                case "Italiano":
                    return "Assalto della Morte";
                case "Português Brasileiro":
                    return "Golpe da Morte";
                case "Русский":
                    return "Удар смерти";
                case "한국어":
                    return "죽음의 일격";
                case "简体中文":
                    return "灵界打击";
                default:
                    return "Death Strike";
            }
        }
        private static string AntiMagicShell_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Antimagische Hülle";
                case "Español":
                    return "Caparazón antimagia";
                case "Français":
                    return "Carapace anti-magie";
                case "Italiano":
                    return "Scudo Antimagia";
                case "Português Brasileiro":
                    return "Carapaça Antimagia";
                case "Русский":
                    return "Антимагический панцирь";
                case "한국어":
                    return "대마법 보호막";
                case "简体中文":
                    return "反魔法护罩";
                default:
                    return "Anti-Magic Shell";
            }
        }
        private static string UnholyStrength_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Unheilige Stärke";
                case "Español":
                    return "Fuerza impía";
                case "Français":
                    return "Force impie";
                case "Italiano":
                    return "Forza Empia";
                case "Português Brasileiro":
                    return "Força Profana";
                case "Русский":
                    return "Нечестивая сила";
                case "한국어":
                    return "부정의 힘";
                case "简体中文":
                    return "不洁之力";
                default:
                    return "Unholy Strength";
            }
        }
        private static string RunicCorruption_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Runenverderbnis";
                case "Español":
                    return "Corrupción rúnica";
                case "Français":
                    return "Corruption runique";
                case "Italiano":
                    return "Corruzione Runica";
                case "Português Brasileiro":
                    return "Corrupção Rúnica";
                case "Русский":
                    return "Руническая порча";
                case "한국어":
                    return "룬 부패";
                case "简体中文":
                    return "符文腐蚀";
                default:
                    return "Runic Corruption";
            }
        }
        private static string SuddenDoom_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Hereinbrechende Verdammnis";
                case "Español":
                    return "Fatalidad súbita";
                case "Français":
                    return "Malédiction soudaine";
                case "Italiano":
                    return "Condanna Improvvisa";
                case "Português Brasileiro":
                    return "Ruína Súbita";
                case "Русский":
                    return "Неумолимый рок";
                case "한국어":
                    return "불시의 파멸";
                case "简体中文":
                    return "末日突降";
                default:
                    return "Sudden Doom";
            }
        }
        private static string FesteringWound_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schwärende Wunde";
                case "Español":
                    return "Herida degenerativa";
                case "Français":
                    return "Blessure purulente";
                case "Italiano":
                    return "Ferita Putrescente";
                case "Português Brasileiro":
                    return "Ferida Purulenta";
                case "Русский":
                    return "Гнойная язва";
                case "한국어":
                    return "고름 상처";
                case "简体中文":
                    return "溃烂之伤";
                default:
                    return "Festering Wound";
            }
        }
        private static string VirulentPlague_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Virulente Seuche";
                case "Español":
                    return "Peste virulenta";
                case "Français":
                    return "Peste virulente";
                case "Italiano":
                    return "Piaga Virulenta";
                case "Português Brasileiro":
                    return "Peste Virulenta";
                case "Русский":
                    return "Смертоносная чума";
                case "한국어":
                    return "악성 역병";
                case "简体中文":
                    return "恶性瘟疫";
                default:
                    return "Virulent Plague";
            }
        }
        private static string FrostFever_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Frostfieber";
                case "Español":
                    return "Fiebre de Escarcha";
                case "Français":
                    return "Fièvre de givre";
                case "Italiano":
                    return "Febbre del Gelo";
                case "Português Brasileiro":
                    return "Febre do Gelo";
                case "Русский":
                    return "Озноб";
                case "한국어":
                    return "서리 열병";
                case "简体中文":
                    return "冰霜疫病";
                default:
                    return "Frost Fever";
            }
        }
        private static string BloodPlague_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Blutseuche";
                case "Español":
                    return "Peste de sangre";
                case "Français":
                    return "Peste de sang";
                case "Italiano":
                    return "Morbo del Sangue";
                case "Português Brasileiro":
                    return "Peste Sanguínea";
                case "Русский":
                    return "Кровавая чума";
                case "한국어":
                    return "피의 역병";
                case "简体中文":
                    return "血之疫病";
                default:
                    return "Blood Plague";
            }
        }
        private static string EbonGargoyle_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schwarzer Gargoyle";
                case "Español":
                    return "Gárgola de ébano";
                case "Français":
                    return "Gargouille d'ébène";
                case "Italiano":
                    return "Gargoyle d'Ebano";
                case "Português Brasileiro":
                    return "Gárgula de Ébano";
                case "Русский":
                    return "Вороная горгулья";
                case "한국어":
                    return "칠흑의 가고일";
                case "简体中文":
                    return "黑锋石像鬼";
                default:
                    return "Ebon Gargoyle";
            }
        }
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
        private static string Claw_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Klaue";
                case "Español":
                    return "Zarpa";
                case "Français":
                    return "Griffe";
                case "Italiano":
                    return "Sfregio";
                case "Português Brasileiro":
                    return "Garra";
                case "Русский":
                    return "Цапнуть";
                case "한국어":
                    return "할퀴기";
                case "简体中文":
                    return "爪击";
                default:
                    return "Claw";
            }
        }
        private static string RaiseAlly_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Verbündeten erwecken";
                case "Español":
                    return "Levantar a aliado";
                case "Français":
                    return "Réanimation d'un allié";
                case "Italiano":
                    return "Rianima Alleato";
                case "Português Brasileiro":
                    return "Reviver Aliado";
                case "Русский":
                    return "Воскрешение союзника";
                case "한국어":
                    return "아군 되살리기";
                case "简体中文":
                    return "复活盟友";
                default:
                    return "Raise Ally";
            }
        }
        private static string Fleshcraft_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Fleischformung";
                case "Español":
                    return "Modelar carne";
                case "EspañolLA":
                    return "Modelar carne";
                case "Français":
                    return "Chair recomposée";
                case "Italiano":
                    return "Forgiatura della Carne";
                case "Português Brasileiro":
                    return "Moldacarne";
                case "Русский":
                    return "Скульптор плоти";
                case "한국어":
                    return "살덩이창조";
                case "简体中文":
                    return "血肉铸造";
                default:
                    return "Fleshcraft";
            }
        }
        private static string DeathGrip_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Todesgriff";
                case "Español":
                    return "Atracción letal";
                case "EspañolLA":
                    return "Atracción letal";
                case "Français":
                    return "Poigne de la mort";
                case "Italiano":
                    return "Presa Mortale";
                case "Português Brasileiro":
                    return "Garra da Morte";
                case "Русский":
                    return "Хватка смерти";
                case "한국어":
                    return "죽음의 손아귀";
                case "简体中文":
                    return "死亡之握";
                default:
                    return "Death Grip";
            }
        }
        private static string AntiMagicZone_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Antimagisches Feld";
                case "Español":
                    return "Zona antimagia";
                case "EspañolLA":
                    return "Zona antimagia";
                case "Français":
                    return "Zone anti-magie";
                case "Italiano":
                    return "Area Antimagia";
                case "Português Brasileiro":
                    return "Zona Antimagia";
                case "Русский":
                    return "Зона антимагии";
                case "한국어":
                    return "대마법 지대";
                case "简体中文":
                    return "反魔法领域";
                default:
                    return "Anti-Magic Zone";
            }
        }
        private static string Asphyxiate_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Ersticken";
                case "Español":
                    return "Asfixiar";
                case "Français":
                    return "Asphyxier";
                case "Italiano":
                    return "Asfissia";
                case "Português Brasileiro":
                    return "Asfixiar";
                case "Русский":
                    return "Асфиксия";
                case "한국어":
                    return "어둠의 질식";
                case "简体中文":
                    return "窒息";
                default:
                    return "Asphyxiate";
            }
        }
        #endregion

        int enemyID = -1;
        int ApocTimer = -15000;
        int ArmyTimer = -30000;
        int CurrentTime = -1;
        int CurrentTime2 = -1;


        public override void LoadSettings()
        {
            Settings.Add(new Setting("Game Client Language", new List<string>()
            {
                "English",
                "Deutsch",
                "Español",
                "Français",
                "Italiano",
                "Português Brasileiro",
                "Русский",
                "한국어",
                "简体中文"
            }, "English"));
            Settings.Add(new Setting("General Settings"));

            Settings.Add(new Setting("Potion name:", "Potion of Spectral Strength"));

            Settings.Add(new Setting("Use In-Game Addon for other settings"));

            // Settings.Add(new Setting("Glaive Tempest desired targets:", 1, 5, 1));
        }

        public override void Initialize()
        {
            Language = GetDropDown("Game Client Language");

            //Aimsharp.DebugMode();
            Aimsharp.PrintMessage("Aya Unholy DK", Color.Purple);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("---------------------------------", Color.Blue);
            Aimsharp.PrintMessage("For list of commands Join Discord", Color.Blue);
            Aimsharp.PrintMessage("---------------------------------", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("https://discord.gg/Sw5sAFDB3r", Color.Purple);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("---------------------------------", Color.Blue);
            Aimsharp.PrintMessage("For list of commands Join Discord", Color.Blue);
            Aimsharp.PrintMessage("---------------------------------", Color.Blue);
            Aimsharp.PrintMessage(" ");
            Aimsharp.PrintMessage("--Replace xxxxx with first 5 letters of your addon, lowercase.", Color.Blue);

            List<string> Racials = new List<string>
            {

            };

            List<string> CovenantAbilities = new List<string>
            {

            };

            List<string> BloodlustEffects = new List<string>
            {
                Bloodlust_SpellName(),Heroism_SpellName(),TimeWarp_SpellName(),DrumsofRage_SpellName()
            };

            List<string> GeneralBuffs = new List<string>
            {

            };

            List<string> GeneralDebuffs = new List<string>
            {

            };

            List<string> SpellsList = new List<string>
            {
               BloodFury_SpellName(),Berserking_SpellName(),Fireblood_SpellName(),AncestralCall_SpellName(),BagofTricks_SpellName(),ArcaneTorrent_SpellName(),LightsJudgment_SpellName(),ArcanePulse_SpellName(),Outbreak_SpellName(),Epidemic_SpellName(),ScourgeStrike_SpellName(),SacrificalPact_SpellName(),ClawingShadows_SpellName(),DeathandDecay_SpellName(),DeathsDue_SpellName(),Defile_SpellName(),FesteringStrike_SpellName(),ArmyoftheDead_SpellName(),UnholyBlight_SpellName(),DarkTransformation_SpellName(),Apocalypse_SpellName(),SummonGargoyle_SpellName(),UnholyAssault_SpellName(),SoulReaper_SpellName(),RaiseDead_SpellName(),SwarmingMist_SpellName(),AbominationLimb_SpellName(),ShackletheUnworthy_SpellName(),DeathCoil_SpellName(), IceboundFortitude_SpellName(), Lichborne_SpellName(), "Shadowstrike" ,DeathPact_SpellName(), DeathStrike_SpellName(), AntiMagicShell_SpellName(), RaiseAlly_SpellName(), DeathGrip_SpellName(), AntiMagicZone_SpellName(), Asphyxiate_SpellName()
            };

            List<string> BuffsList = new List<string>
            {
                UnholyAssault_SpellName(),UnholyStrength_SpellName(),SwarmingMist_SpellName(),DarkTransformation_SpellName(),RunicCorruption_SpellName(),SuddenDoom_SpellName(),DeathandDecay_SpellName(),Defile_SpellName(),DeathsDue_SpellName(), IceboundFortitude_SpellName(), Lichborne_SpellName(),
            };

            List<string> DebuffsList = new List<string>
            {
               FesteringWound_SpellName(),VirulentPlague_SpellName(),FrostFever_SpellName(),BloodPlague_SpellName(),UnholyBlight_SpellName(),
            };

            List<string> TotemsList = new List<string>
            {
                EbonGargoyle_SpellName()
            };

            List<string> MacroCommands = new List<string>
            {
                "SingleTarget","SaveCooldowns","StopAutoSwap","HoldAbomLimb","HoldAOTD", "AOTD","HoldSacPact"
            };

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

            foreach (string Buff in GeneralBuffs)
            {
                Buffs.Add(Buff);
            }

            foreach (string Buff in BuffsList)
            {
                Buffs.Add(Buff);
            }

            foreach (string Buff in BloodlustEffects)
            {
                Buffs.Add(Buff);
            }

            foreach (string Debuff in DebuffsList)
            {
                Debuffs.Add(Debuff);
            }

            foreach (string Debuff in GeneralDebuffs)
            {
                Debuffs.Add(Debuff);
            }

            foreach (string Totem in TotemsList)
            {
                Totems.Add(Totem);
            }

            Items.Add(GetString("Potion name:"));

            Macros.Add("DPS Pot", "/use " + GetString("Potion name:"));

            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BottomTrinket", "/use 14");
            Macros.Add("FesteringStrikeM", "/cast [@mouseover] " + FesteringStrike_SpellName());
            Macros.Add("ApocM", "/cast [@mouseover] " + Apocalypse_SpellName());
            Macros.Add("UnholyAssaultM", "/cast [@mouseover] " + UnholyAssault_SpellName());
            Macros.Add("ClawingShadowsM", "/cast [@mouseover] " + ClawingShadows_SpellName());
            Macros.Add("ScourgeStrikeM", "/cast [@mouseover] " + ScourgeStrike_SpellName());
            Macros.Add("SoulReaperM", "/cast [@mouseover] " + SoulReaper_SpellName());
            Macros.Add("AntiMagicZoneM", "/cast [@player] " + AntiMagicZone_SpellName());
            Macros.Add("DeathGripMO", "/cast [@mouseover] " + DeathGrip_SpellName());
            Macros.Add("AsphyxiateMO", "/cast [@mouseover] " + Asphyxiate_SpellName());

            Macros.Add("DeathandDecayA", "/cast [spec:3, combat, talent:6/3, @player][spec:3, nocombat, talent:6/3] " + Defile_SpellName() + "; [combat, @player][nocombat] " + DeathandDecay_SpellName());

            Macros.Add("DeathsDueA", "/cast [@cursor] " + DeathsDue_SpellName());
            Macros.Add("DefileA", "/cast [spec:3, combat, talent:6/3, @player][spec:3, nocombat, talent:6/3] " + Defile_SpellName() + "; [combat, @player][nocombat] " + DeathandDecay_SpellName());
            Macros.Add("TabTarget", "/targetenemy");
            Macros.Add("DeathCoilM", "/cast " + DeathCoil_SpellName() + ";/cast[@pettarget] " + Claw_SpellName());
            Macros.Add("EpidemicM", "/cast " + Epidemic_SpellName() + ";/cast[@pettarget] " + Claw_SpellName());
            Macros.Add("HealthstoneM", "/use " + Healthstone_SpellName());
            Macros.Add("HealPotM", "/use " + SpiritualHealingPotion_SpellName());
            Macros.Add("RaiseAllyM", "/cast [@mouseover, exists][]" + RaiseAlly_SpellName());


            foreach (string MacroCommand in MacroCommands)
            {
                CustomCommands.Add(MacroCommand);
            }

            CustomFunctions.Add("FWoundCount", "local FlameShockCount = 0\n" +
                "for i=1,20 do\n" +
                  "local unit = \"nameplate\" .. i\n" +
                  "if UnitExists(unit) then\n" +
                     "if UnitCanAttack(\"player\", unit) then\n" +
                         "for j = 1, 40 do\nlocal name,_,_,_,_,_,source = UnitDebuff(unit, j)\n" +
                             "if name == \"Festering Wound\" and source == \"player\" then\n" +
                             "FlameShockCount = FlameShockCount + 1\n" +
                               "end\n" +
                "end\n" +
                "end\n" +
                "end\n" +
                "end\n" +
                "return FlameShockCount");


            CustomFunctions.Add("TargetinMelee", "local inMelee = 0\nif (IsItemInRange(37727, \"target\")) then\ninMelee = 1 end\nreturn inMelee");
            CustomFunctions.Add("TimeToDie", "local HL = HeroLib\nlocal Unit = HL.Unit\nlocal Target = Unit.Target\n return Target:TimeToDie()");
            CustomFunctions.Add("TimeToDie35", "local HL = HeroLib\nlocal Unit = HL.Unit\nlocal Target = Unit.Target\n return Target:TimeToX(35)");
            CustomFunctions.Add("TimeToDie20", "local HL = HeroLib\nlocal Unit = HL.Unit\nlocal Target = Unit.Target\n return Target:TimeToX(20)");
            CustomFunctions.Add("BotOn", "local HR = HeroRotation\nlocal HL = HeroLib\nlocal Unit = HL.Unit\nlocal Target = Unit.Target\nlocal on = 0\nlocal Everyone = HR.Commons.Everyone\nif HeroRotationCharDB.Toggles[3] and Everyone.TargetIsValid() then\non = 1\nend\nreturn on");
            //CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    local weaponLink = GetInventoryItemLink(\"player\",16)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if weaponLink ~= nil then\r\n                local weaponid = GetItemInfoInstant(weaponLink)\r\n                if weaponid ~= nil then\r\n    \t\t\t    if weaponid == id then\r\n\t    \t\t\t    return 3\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

            CustomFunctions.Add("ReturnSpell", "local Spellid = 0\nlocal loading, finished = IsAddOnLoaded(\"HeroRotation_DeathKnight\") \r\n" +
                "if loading == true and finished == true then \r\n" +
                    "local HR = HeroRotation\nlocal HL = HeroLib\nlocal Unit = HL.Unit\nlocal Target = Unit.Target\nSpellid= ReturnSpell()" +
                "end\n" +
                "return Spellid");
            CustomFunctions.Add("ReturnSpellMO", "local Spellid = 0\nlocal loading, finished = IsAddOnLoaded(\"HeroRotation_DeathKnight\") \r\n" +
                "if loading == true and finished == true then \r\n" +
                    "local HR = HeroRotation\nlocal HL = HeroLib\nlocal Unit = HL.Unit\nlocal Target = Unit.Target\nSpellid = ReturnSpellMO()" +
                "end\n" +
                "return Spellid");

            //CustomFunctions.Add("RuneforgeFallenCrusader", "if select(1,GetWeaponEnchantInfo()) then if select(4,GetWeaponEnchantInfo()) == 3368 then return 1 end end if select(5,GetWeaponEnchantInfo()) then if select(8,GetWeaponEnchantInfo()) == 3368 then return 1 end end return 0");
            //CustomFunctions.Add("RuneforgeRazorice", "if select(1,GetWeaponEnchantInfo()) then if select(4,GetWeaponEnchantInfo()) == 3370 then return 1 end end if select(5,GetWeaponEnchantInfo()) then if select(8,GetWeaponEnchantInfo()) == 3370 then return 1 end end return 0");
            //CustomFunctions.Add("Revolving Blades Rank", "local isSelected\nlocal count = 0\nfor _, itemLocation in AzeriteUtil.EnumerateEquipedAzeriteEmpoweredItems() do\nisSelected = C_AzeriteEmpoweredItem.IsPowerSelected(itemLocation, 126)\nif isSelected then count = count + 1 end\nend\nreturn count");
            //CustomFunctions.Add("Chaotic Transformation Rank", "local isSelected\nlocal count = 0\nfor _, itemLocation in AzeriteUtil.EnumerateEquipedAzeriteEmpoweredItems() do\nisSelected = C_AzeriteEmpoweredItem.IsPowerSelected(itemLocation, 220)\nif isSelected then count = count + 1 end\nend\nreturn count");
        }


        // optional override for the CombatTick which executes while in combat
        public override bool CombatTick()
        {

            #region Simc Conditionals

            // Aimsharp Settings
            int shouldcast = Aimsharp.CustomFunction("ReturnSpell");
            bool BotOn = Aimsharp.CustomFunction("BotOn") == 1;
            int shouldcastMO = Aimsharp.CustomFunction("ReturnSpellMO"); 
            int CovenantID = Aimsharp.CovenantID();
            bool CovenantKyrian = CovenantID == 1;
            bool CovenantVenthyr = CovenantID == 2;
            bool CovenantNightFae = CovenantID == 3;
            bool CovenantNecrolord = CovenantID == 4;

            //talents
            bool TalentDefile = Aimsharp.Talent(6, 3);
            bool TalentClawingShadows = Aimsharp.Talent(1, 3);
            #endregion

            int next = 0;
            int nextmo = 0;
            if (next != shouldcast || nextmo != shouldcastMO)
            {
                Aimsharp.PrintMessage("" + shouldcast + "," + shouldcastMO);
                next = shouldcast;
                nextmo = shouldcastMO;
            }


            if (!BotOn)
            {
                return false;
            }

            if (shouldcastMO == 151)
            {
                return ApocM();
                return true;
            }
            if (shouldcastMO == 171)
            {
                return UnholyAssaultM();
                return true;
            }
            if (shouldcastMO == 61)
            {
                return FesteringStrikeM();
                return true;
            }
            if (shouldcastMO == 111)
            {
                return SoulReaperM();
                return true;
            }
            if (shouldcastMO == 999)
            {
                return TabTarget();
                return true;
            }
            if (shouldcastMO == 71)
            {
                if (TalentClawingShadows)
                {
                    return ClawingShadowsM();
                    return true;
                }
                if (!TalentClawingShadows)
                {
                    return ScourgeStrikeM();
                    return true;
                }
            }
            if (shouldcastMO == 72)
            {
                return DeathGripMO();
                return true;
            }
            if (shouldcastMO == 73)
            {
                return CastRaiseAlly();
                return true;
            }
            if (shouldcastMO == 471)
            {
                Aimsharp.Cast("AsphyxiateMO");
                return false;
            }
            if (shouldcast == 1)
            {
                return RaiseDead();
                return true;
            }

            if (shouldcast == 2)
            {
                if (CovenantNightFae)
                {
                    return DeathsDue();
                    return true;
                }
                if (!CovenantNightFae && TalentDefile)
                {
                    return Defile();
                    return true;
                }
                if (!CovenantNightFae && !TalentDefile)
                {
                    return DeathandDecay();
                    return true;
                }
            }
            if (shouldcast == 3)
            {
                return Fleshcraft();
                return true;
            }
            if (shouldcast == 400)
            {
                return ArmyoftheDead();
                return true;
            }
            if (shouldcast == 5)
            {
                return ClawingShadows();
                return true;
            }
            if (shouldcast == 6)
            {
                return FesteringStrike();
                return true;
            }
            if (shouldcast == 7)
            {
                if (TalentClawingShadows)
                {
                    return ClawingShadows();
                    return true;
                }
                if (!TalentClawingShadows)
                {
                    return ScourgeStrike();
                    return true;
                }
            }
            if (shouldcast == 8)
            {
                return Outbreak();
                return true;
            }
            if (shouldcast == 9)
            {
                return DPSPot();
                return true;
            }
            if (shouldcast == 10)
            {
                return DeathCoil();
                return true;
            }
            if (shouldcast == 11)
            {
                return SoulReaper();
                return true;
            }
            if (shouldcast == 12)
            {
                return Epidemic();
                return true;
            }
            if (shouldcast == 13)
            {
                return UnholyBlight();
                return true;
            }
            if (shouldcast == 14)
            {
                return DarkTransformation();
                return true;
            }
            if (shouldcast == 15)
            {
                return Apocalypse();
                return true;
            }
            if (shouldcast == 16)
            {
                return SummonGargoyle();
                return true;
            }
            if (shouldcast == 17)
            {
                return UnholyAssault();
                return true;
            }
            if (shouldcast == 18)
            {
                return SacrificalPact();
                return true;
            }
            if (shouldcast == 19)
            {
                return SwarmingMist();
                return true;
            }
            if (shouldcast == 20)
            {
                return AbominationLimb();
                return true;
            }
            if (shouldcast == 21)
            {
                return ShackletheUnworthy();
                return true;
            }
            if (shouldcast == 22)
            {
                return ArcaneTorrent();
                return true;
            }
            if (shouldcast == 23)
            {
                return BloodFury();
                return true;
            }
            if (shouldcast == 24)
            {
                return Berserking();
                return true;
            }
            if (shouldcast == 25)
            {
                return LightsJudgment();
                return true;
            }
            if (shouldcast == 26)
            {
                return AncestralCall();
                return true;
            }
            if (shouldcast == 27)
            {
                return ArcanePulse();
                return true;
            }
            if (shouldcast == 28)
            {
                return Fireblood();
                return true;
            }
            if (shouldcast == 29)
            {
                return BagofTricks();
                return true;
            }
            if (shouldcast == 30)
            {
                return TopTrinket();
                return true;
            }
            if (shouldcast == 31)
            {
                return BotTrinket();
                return true;
            }
            if (shouldcast == 35)
            {
                return DeathStrike();
                return true;
            }
            if (shouldcast == 37)
            {
                return TabTarget();
                return true;
            }
            if (shouldcast == 38)
            {
                return AntiMagicZone();
                return true;
            }
            if (shouldcast == 39)
            {
                return DeathGrip();
                return true;
            }
            if (shouldcast == 40)
            {
                return Healthstone();
                return true;
            }
            if (shouldcast == 41)
            {
                return HealPot();
                return true;
            }
            if (shouldcast == 42)
            {
                return DeathStrike();
                return true;
            }
            if (shouldcast == 43)
            {
                return IceboundFortitude();
                return true;
            }
            if (shouldcast == 44)
            {
                return Lichborne();
                return true;
            }
            if (shouldcast == 45)
            {
                return AntiMagicShell();
                return true;
            }
            if (shouldcast == 46)
            {
                return DeathPact();
                return true;
            }
            if (shouldcast == 47)
            {
                Aimsharp.Cast(Asphyxiate_SpellName());
                return false;
            }
            if (shouldcast == 36)
            {
                return true;
            }
            return false;
        }


        public override bool OutOfCombatTick()
        {
            #region Simc Conditionals

            // Aimsharp Settings
            int shouldcast = Aimsharp.CustomFunction("ReturnSpell");
            int shouldcastMO = Aimsharp.CustomFunction("ReturnSpellMO");
            int CovenantID = Aimsharp.CovenantID();
            bool CovenantKyrian = CovenantID == 1;
            bool CovenantVenthyr = CovenantID == 2;
            bool CovenantNightFae = CovenantID == 3;
            bool CovenantNecrolord = CovenantID == 4;

            //talents
            bool TalentDefile = Aimsharp.Talent(6, 3);
            bool TalentClawingShadows = Aimsharp.Talent(1, 3);
            #endregion

            if (shouldcastMO == 151)
            {
                return ApocM();
                return true;
            }
            if (shouldcastMO == 171)
            {
                return UnholyAssaultM();
                return true;
            }
            if (shouldcastMO == 61)
            {
                return FesteringStrikeM();
                return true;
            }
            if (shouldcastMO == 111)
            {
                return SoulReaperM();
                return true;
            }
            if (shouldcastMO == 999)
            {
                return TabTarget();
                return true;
            }
            if (shouldcastMO == 71)
            {
                if (TalentClawingShadows)
                {
                    return ClawingShadowsM();
                    return true;
                }
                if (!TalentClawingShadows)
                {
                    return ScourgeStrikeM();
                    return true;
                }
            }
            if (shouldcastMO == 72)
            {
                return DeathGripMO();
                return true;
            }
            if (shouldcastMO == 73)
            {
                return CastRaiseAlly();
                return true;
            }
            if (shouldcastMO == 471)
            {
                Aimsharp.Cast("AsphyxiateMO");
                return false;
            }
            if (shouldcast == 1)
            {
                return RaiseDead();
                return true;
            }

            if (shouldcast == 2)
            {
                if (CovenantNightFae)
                {
                    return DeathsDue();
                    return true;
                }
                if (!CovenantNightFae && TalentDefile)
                {
                    return Defile();
                    return true;
                }
                if (!CovenantNightFae && !TalentDefile)
                {
                    return DeathandDecay();
                    return true;
                }
            }
            if (shouldcast == 3)
            {
                return Fleshcraft();
                return true;
            }
            if (shouldcast == 400)
            {
                return ArmyoftheDead();
                return true;
            }
            if (shouldcast == 5)
            {
                return ClawingShadows();
                return true;
            }
            if (shouldcast == 6)
            {
                return FesteringStrike();
                return true;
            }
            if (shouldcast == 7)
            {
                if (TalentClawingShadows)
                {
                    return ClawingShadows();
                    return true;
                }
                if (!TalentClawingShadows)
                {
                    return ScourgeStrike();
                    return true;
                }
            }
            if (shouldcast == 8)
            {
                return Outbreak();
                return true;
            }
            if (shouldcast == 9)
            {
                return DPSPot();
                return true;
            }
            if (shouldcast == 10)
            {
                return DeathCoil();
                return true;
            }
            if (shouldcast == 11)
            {
                return SoulReaper();
                return true;
            }
            if (shouldcast == 12)
            {
                return Epidemic();
                return true;
            }
            if (shouldcast == 13)
            {
                return UnholyBlight();
                return true;
            }
            if (shouldcast == 14)
            {
                return DarkTransformation();
                return true;
            }
            if (shouldcast == 15)
            {
                return Apocalypse();
                return true;
            }
            if (shouldcast == 16)
            {
                return SummonGargoyle();
                return true;
            }
            if (shouldcast == 17)
            {
                return UnholyAssault();
                return true;
            }
            if (shouldcast == 18)
            {
                return SacrificalPact();
                return true;
            }
            if (shouldcast == 19)
            {
                return SwarmingMist();
                return true;
            }
            if (shouldcast == 20)
            {
                return AbominationLimb();
                return true;
            }
            if (shouldcast == 21)
            {
                return ShackletheUnworthy();
                return true;
            }
            if (shouldcast == 22)
            {
                return ArcaneTorrent();
                return true;
            }
            if (shouldcast == 23)
            {
                return BloodFury();
                return true;
            }
            if (shouldcast == 24)
            {
                return Berserking();
                return true;
            }
            if (shouldcast == 25)
            {
                return LightsJudgment();
                return true;
            }
            if (shouldcast == 26)
            {
                return AncestralCall();
                return true;
            }
            if (shouldcast == 27)
            {
                return ArcanePulse();
                return true;
            }
            if (shouldcast == 28)
            {
                return Fireblood();
                return true;
            }
            if (shouldcast == 29)
            {
                return BagofTricks();
                return true;
            }
            if (shouldcast == 30)
            {
                return TopTrinket();
                return true;
            }
            if (shouldcast == 31)
            {
                return BotTrinket();
                return true;
            }
            if (shouldcast == 35)
            {
                return DeathStrike();
                return true;
            }
            if (shouldcast == 37)
            {
                return TabTarget();
                return true;
            }
            if (shouldcast == 38)
            {
                return AntiMagicZone();
                return true;
            }
            if (shouldcast == 39)
            {
                return DeathGrip();
                return true;
            }
            if (shouldcast == 40)
            {
                return Healthstone();
                return true;
            }
            if (shouldcast == 41)
            {
                return HealPot();
                return true;
            }
            if (shouldcast == 42)
            {
                return DeathStrike();
                return true;
            }
            if (shouldcast == 43)
            {
                return IceboundFortitude();
                return true;
            }
            if (shouldcast == 44)
            {
                return Lichborne();
                return true;
            }
            if (shouldcast == 45)
            {
                return AntiMagicShell();
                return true;
            }
            if (shouldcast == 46)
            {
                return DeathPact();
                return true;
            }
            if (shouldcast == 47)
            {
                Aimsharp.Cast(Asphyxiate_SpellName());
                return false;
            }
            if (shouldcast == 36)
            {
                return true;
            }
            return false;
        }

        bool ArcaneTorrent() { Aimsharp.Cast(ArcaneTorrent_SpellName()); return true; }
        bool Berserking() { Aimsharp.Cast(Berserking_SpellName()); return true; }
        bool AncestralCall() { Aimsharp.Cast(AncestralCall_SpellName()); return true; }
        bool Fireblood() { Aimsharp.Cast(Fireblood_SpellName()); return true; }
        bool BagofTricks() { Aimsharp.Cast(BagofTricks_SpellName()); return true; }
        bool SacrificalPact() { Aimsharp.Cast(SacrificalPact_SpellName()); return true; }
        bool BloodFury() { Aimsharp.Cast(BloodFury_SpellName()); return true; }
        bool LightsJudgment() { Aimsharp.Cast(LightsJudgment_SpellName()); return true; }
        bool ArcanePulse() { Aimsharp.Cast(ArcanePulse_SpellName()); return true; }
        bool Outbreak() { Aimsharp.Cast(Outbreak_SpellName()); return true; }
        bool IceboundFortitude() { Aimsharp.Cast(IceboundFortitude_SpellName()); return true; }
        bool Healthstone() { Aimsharp.Cast("HealthstoneM"); return true; }
        bool HealPot() { Aimsharp.Cast("HealpotM"); return true; }
        bool Lichborne() { Aimsharp.Cast(Lichborne_SpellName()); return true; }
        bool AntiMagicShell() { Aimsharp.Cast(AntiMagicShell_SpellName()); return true; }
        bool DeathPact() { Aimsharp.Cast(DeathPact_SpellName()); return true; }
        bool Epidemic() { Aimsharp.Cast("EpidemicM"); return true; }
        bool ScourgeStrike() { Aimsharp.Cast(ScourgeStrike_SpellName()); return true; }
        bool ClawingShadows() { Aimsharp.Cast(ClawingShadows_SpellName()); return true; }
        bool DeathandDecay() { Aimsharp.Cast("DeathandDecayA"); return true; }
        bool DeathsDue() { Aimsharp.Cast("DeathsDueA"); return true; }
        bool Defile() { Aimsharp.Cast("DefileA"); return true; }
        bool FesteringStrike() { Aimsharp.Cast(FesteringStrike_SpellName()); return true; }
        bool FesteringStrikeM() { Aimsharp.Cast("FesteringStrikeM"); return true; }
        bool ArmyoftheDead() { Aimsharp.Cast(ArmyoftheDead_SpellName()); return true; }
        bool UnholyBlight() { Aimsharp.Cast(UnholyBlight_SpellName()); return true; }
        bool DarkTransformation() { Aimsharp.Cast(DarkTransformation_SpellName()); return true; }
        bool Apocalypse() { Aimsharp.Cast(Apocalypse_SpellName()); return true; }
        bool SummonGargoyle() { Aimsharp.Cast(SummonGargoyle_SpellName()); return true; }
        bool UnholyAssault() { Aimsharp.Cast(UnholyAssault_SpellName()); return true; }
        bool SoulReaper() { Aimsharp.Cast(SoulReaper_SpellName()); return true; }
        bool RaiseDead() { Aimsharp.Cast(RaiseDead_SpellName()); return true; }
        bool Fleshcraft() { Aimsharp.Cast(Fleshcraft_SpellName()); return true; }
        bool SwarmingMist() { Aimsharp.Cast(SwarmingMist_SpellName()); return true; }
        bool AbominationLimb() { Aimsharp.Cast(AbominationLimb_SpellName()); return true; }
        bool ShackletheUnworthy() { Aimsharp.Cast(ShackletheUnworthy_SpellName()); return true; }
        bool DeathCoil() { Aimsharp.Cast("DeathCoilM"); return true; }
        bool TabTarget() { Aimsharp.Cast("TabTarget"); return true; }
        bool DeathStrike() { Aimsharp.Cast(DeathStrike_SpellName()); return true; }
        bool CastRaiseAlly() { Aimsharp.Cast("RaiseAllyM"); return true; }
        bool DPSPot() { Aimsharp.Cast("DPS Pot"); return true; }
        bool TopTrinket() { Aimsharp.Cast("TopTrinket"); return true; }
        bool BotTrinket() { Aimsharp.Cast("BottomTrinket"); return true; }
        bool ApocM() { Aimsharp.Cast("ApocM"); return true; }
        bool UnholyAssaultM() { Aimsharp.Cast("UnholyAssaultM"); return true; }
        bool ClawingShadowsM() { Aimsharp.Cast("ClawingShadowsM"); return true; }
        bool ScourgeStrikeM() { Aimsharp.Cast("ScourgeStrikeM"); return true; }
        bool SoulReaperM() { Aimsharp.Cast("SoulReaperM"); return true; }
        bool AntiMagicZone() { Aimsharp.Cast("AntiMagicZoneM"); return true; }
        bool DeathGrip() { Aimsharp.Cast(DeathGrip_SpellName()); return true; }
        bool DeathGripMO() { Aimsharp.Cast("DeathGripMO"); return true; }
    }
}
