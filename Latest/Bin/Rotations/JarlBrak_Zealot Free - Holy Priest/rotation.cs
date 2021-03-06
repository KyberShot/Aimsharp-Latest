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
                case "Espa??ol":
                    return "Concentraci??n rel??mpago";
                case "Fran??ais":
                    return "Concentration ??clair";
                case "Italiano":
                    return "Concentrazione Rapida";
                case "Portugu??s Brasileiro":
                    return "Concentra????o C??lere";
                case "??????????????":
                    return "?????????????? ????????????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Oleada de Luz";
                case "Fran??ais":
                    return "Vague de Lumi??re";
                case "Italiano":
                    return "Eruzione di Luce";
                case "Portugu??s Brasileiro":
                    return "Torrente de Luz";
                case "??????????????":
                    return "?????????????????????? ??????????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Palabras resonantes";
                case "Fran??ais":
                    return "Mots r??sonnants";
                case "Italiano":
                    return "Parole Risonanti";
                case "Portugu??s Brasileiro":
                    return "Palavras Ressonantes";
                case "??????????????":
                    return "???????????????????????? ??????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
                default:
                    return "Resonant Words";
            }
        }
        private static string SpiritofRedemption_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Geist der Erl??sung";
                case "Espa??ol":
                    return "Esp??ritu redentor";
                case "Fran??ais":
                    return "Esprit de r??demption";
                case "Italiano":
                    return "Spirito di Redenzione";
                case "Portugu??s Brasileiro":
                    return "Esp??rito da Reden????o";
                case "??????????????":
                    return "?????? ??????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                    return "Gefr????iges Miasma";
                case "Espa??ol":
                    return "Miasma glot??n";
                case "Fran??ais":
                    return "Miasme glouton";
                case "Italiano":
                    return "Miasma Insaziabile";
                case "Portugu??s Brasileiro":
                    return "Miasma Glut??nico";
                case "??????????????":
                    return "???????????????????? ????????????";
                case "?????????":
                    return "???????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Capa de llamas";
                case "Fran??ais":
                    return "Cape des flammes";
                case "Italiano":
                    return "Mantello delle Fiamme";
                case "Portugu??s Brasileiro":
                    return "Manto das Chamas";
                case "??????????????":
                    return "???????? ??????????????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Hada col??rica";
                case "Fran??ais":
                    return "F??e courrouc??e";
                case "Italiano":
                    return "Silfide Infuriato";
                case "Portugu??s Brasileiro":
                    return "Fada Irasc??vel";
                case "??????????????":
                    return "?????????????? ??????????";
                case "?????????":
                    return "????????? ?????????";
                case "????????????":
                    return "????????????";
                default:
                    return "Wrathful Faerie";
            }
        }
        private static string WeakenedSoul_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Geschw??chte Seele";
                case "Espa??ol":
                    return "Alma debilitada";
                case "Fran??ais":
                    return "Ame affaiblie";
                case "Italiano":
                    return "Anima Indebolita";
                case "Portugu??s Brasileiro":
                    return "Alma Enfraquecida";
                case "??????????????":
                    return "?????????????????????? ????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Pluma ang??lica";
                case "Fran??ais":
                    return "Plume ang??lique";
                case "Italiano":
                    return "Piuma Angelica";
                case "Portugu??s Brasileiro":
                    return "Pena Angelical";
                case "??????????????":
                    return "???????????????????????? ??????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Apoteosis";
                case "Fran??ais":
                    return "Apoth??ose";
                case "Italiano":
                    return "Apoteosi";
                case "Portugu??s Brasileiro":
                    return "Apoteose";
                case "??????????????":
                    return "????????????????????????";
                case "?????????":
                    return "??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Sanaci??n conjunta";
                case "Fran??ais":
                    return "Soins de lien";
                case "Italiano":
                    return "Cura Combinata";
                case "Portugu??s Brasileiro":
                    return "Cura Vinculada";
                case "??????????????":
                    return "?????????????????? ??????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "C??rculo de sanaci??n";
                case "Fran??ais":
                    return "Cercle de soins";
                case "Italiano":
                    return "Circolo di Guarigione";
                case "Portugu??s Brasileiro":
                    return "C??rculo de Cura";
                case "??????????????":
                    return "???????? ??????????????????";
                case "?????????":
                    return "????????? ?????????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Rezo desesperado";
                case "Fran??ais":
                    return "Pri??re du d??sespoir";
                case "Italiano":
                    return "Preghiera Disperata";
                case "Portugu??s Brasileiro":
                    return "Prece Desesperada";
                case "??????????????":
                    return "?????????????? ????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Himno divino";
                case "Fran??ais":
                    return "Hymne divin";
                case "Italiano":
                    return "Inno Divino";
                case "Portugu??s Brasileiro":
                    return "Hino Divino";
                case "??????????????":
                    return "???????????????????????? ????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "???????????????";
                default:
                    return "Divine Hymn";
            }
        }
        private static string DivineStar_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "G??ttlicher Stern";
                case "Espa??ol":
                    return "Estrella divina";
                case "Fran??ais":
                    return "Etoile divine";
                case "Italiano":
                    return "Stella Divina";
                case "Portugu??s Brasileiro":
                    return "Estrela Divina";
                case "??????????????":
                    return "???????????????????????? ????????????";
                case "?????????":
                    return "????????? ???";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Disipar magia";
                case "Fran??ais":
                    return "Dissipation de la magie";
                case "Italiano":
                    return "Dissoluzione Magica";
                case "Portugu??s Brasileiro":
                    return "Dissipar Magia";
                case "??????????????":
                    return "?????????????????????? ????????????????????";
                case "?????????":
                    return "?????? ?????????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Desvanecerse";
                case "Fran??ais":
                    return "Disparition";
                case "Italiano":
                    return "Trasparenza";
                case "Portugu??s Brasileiro":
                    return "Desvanecer";
                case "??????????????":
                    return "???????? ?? ????????";
                case "?????????":
                    return "??????";
                case "????????????":
                    return "?????????";
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
                case "Espa??ol":
                    return "Sanaci??n rel??mpago";
                case "Fran??ais":
                    return "Soins rapides";
                case "Italiano":
                    return "Cura Rapida";
                case "Portugu??s Brasileiro":
                    return "Cura C??lere";
                case "??????????????":
                    return "?????????????? ??????????????????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Esp??ritu guardi??n";
                case "Fran??ais":
                    return "Esprit gardien";
                case "Italiano":
                    return "Spirito Custode";
                case "Portugu??s Brasileiro":
                    return "Esp??rito Guardi??o";
                case "??????????????":
                    return "?????????????????????? ??????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Halo";
                case "Fran??ais":
                    return "Halo";
                case "Italiano":
                    return "Aureola";
                case "Portugu??s Brasileiro":
                    return "Halo";
                case "??????????????":
                    return "????????????";
                case "?????????":
                    return "??????";
                case "????????????":
                    return "??????";
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
                case "Espa??ol":
                    return "Sanar";
                case "Fran??ais":
                    return "Soins";
                case "Italiano":
                    return "Cura";
                case "Portugu??s Brasileiro":
                    return "Cura";
                case "??????????????":
                    return "??????????????????";
                case "?????????":
                    return "??????";
                case "????????????":
                    return "?????????";
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
                case "Espa??ol":
                    return "Fuego Sagrado";
                case "Fran??ais":
                    return "Flammes sacr??es";
                case "Italiano":
                    return "Fuoco Sacro";
                case "Portugu??s Brasileiro":
                    return "Fogo Sagrado";
                case "??????????????":
                    return "?????????????????? ??????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Nova Sagrada";
                case "Fran??ais":
                    return "Nova sacr??e";
                case "Italiano":
                    return "Esplosione Sacra";
                case "Portugu??s Brasileiro":
                    return "Nova Sagrada";
                case "??????????????":
                    return "???????????? ??????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
                default:
                    return "Holy Nova";
            }
        }
        private static string HolyWordChastise_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segenswort: Z??chtigung";
                case "Espa??ol":
                    return "Palabra sagrada: condena";
                case "Fran??ais":
                    return "Mot sacr????: Ch??tier";
                case "Italiano":
                    return "Parola Sacra: Castigo";
                case "Portugu??s Brasileiro":
                    return "Palavra Sagrada: Castigar";
                case "??????????????":
                    return "?????????? ??????????: ??????????????????";
                case "?????????":
                    return "?????? ??????: ??????";
                case "????????????":
                    return "???????????????";
                default:
                    return "Holy Word: Chastise";
            }
        }
        private static string HolyWordSalvation_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Segenswort: Erl??sung";
                case "Espa??ol":
                    return "Palabra sagrada: salvaci??n";
                case "Fran??ais":
                    return "Mot sacr????: Salut";
                case "Italiano":
                    return "Parola Sacra: Salvezza";
                case "Portugu??s Brasileiro":
                    return "Palavra Sagrada: Salva????o";
                case "??????????????":
                    return "?????????? ??????????: ????????????????";
                case "?????????":
                    return "?????? ??????: ??????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Palabra sagrada: santificar";
                case "Fran??ais":
                    return "Mot sacr????: Sanctification";
                case "Italiano":
                    return "Parola Sacra: Santificazione";
                case "Portugu??s Brasileiro":
                    return "Palavra Sagrada: Santificar";
                case "??????????????":
                    return "?????????? ??????????: ??????????????????";
                case "?????????":
                    return "?????? ??????: ?????????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Palabra sagrada: serenidad";
                case "Fran??ais":
                    return "Mot sacr????: S??r??nit??";
                case "Italiano":
                    return "Parola Sacra: Serenit??";
                case "Portugu??s Brasileiro":
                    return "Palavra Sagrada: Serenidade";
                case "??????????????":
                    return "?????????? ??????????: ??????????????????????????";
                case "?????????":
                    return "?????? ??????: ??????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Salto de fe";
                case "Fran??ais":
                    return "Saut de foi";
                case "Italiano":
                    return "Balzo della Fede";
                case "Portugu??s Brasileiro":
                    return "Salto da F??";
                case "??????????????":
                    return "???????????????? ????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Explosi??n mental";
                case "Fran??ais":
                    return "Attaque mentale";
                case "Italiano":
                    return "Detonazione Mentale";
                case "Portugu??s Brasileiro":
                    return "Impacto Mental";
                case "??????????????":
                    return "?????????? ????????????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Infusi??n de poder";
                case "Fran??ais":
                    return "Infusion de puissance";
                case "Italiano":
                    return "Infusione di Potere";
                case "Portugu??s Brasileiro":
                    return "Infus??o de Poder";
                case "??????????????":
                    return "???????????????? ??????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "????????????";
                default:
                    return "Power Infusion";
            }
        }
        private static string PowerWordFortitude_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Machtwort: Seelenst??rke";
                case "Espa??ol":
                    return "Palabra de poder: entereza";
                case "Fran??ais":
                    return "Mot de pouvoir??: Robustesse";
                case "Italiano":
                    return "Parola del Potere: Fermezza";
                case "Portugu??s Brasileiro":
                    return "Palavra de Poder: Fortitude";
                case "??????????????":
                    return "?????????? ????????: ??????????????????";
                case "?????????":
                    return "?????? ??????: ??????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Palabra de poder: escudo";
                case "Fran??ais":
                    return "Mot de pouvoir??: Bouclier";
                case "Italiano":
                    return "Parola del Potere: Scudo";
                case "Portugu??s Brasileiro":
                    return "Palavra de Poder: Escudo";
                case "??????????????":
                    return "?????????? ????????: ??????";
                case "?????????":
                    return "?????? ??????: ?????????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Rezo de sanaci??n";
                case "Fran??ais":
                    return "Pri??re de soins";
                case "Italiano":
                    return "Preghiera di Cura";
                case "Portugu??s Brasileiro":
                    return "Prece de Cura";
                case "??????????????":
                    return "?????????????? ??????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Rezo de alivio";
                case "Fran??ais":
                    return "Pri??re de gu??rison";
                case "Italiano":
                    return "Preghiera di Guarigione";
                case "Portugu??s Brasileiro":
                    return "Prece da Recomposi????o";
                case "??????????????":
                    return "?????????????? ????????????????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
                default:
                    return "Prayer of Mending";
            }
        }
        private static string Purify_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "L??utern";
                case "Espa??ol":
                    return "Purificar";
                case "Fran??ais":
                    return "Purifier";
                case "Italiano":
                    return "Depurazione";
                case "Portugu??s Brasileiro":
                    return "Purificar";
                case "??????????????":
                    return "????????????????";
                case "?????????":
                    return "??????";
                case "????????????":
                    return "?????????";
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
                case "Espa??ol":
                    return "Renovar";
                case "Fran??ais":
                    return "R??novation";
                case "Italiano":
                    return "Rinnovamento";
                case "Portugu??s Brasileiro":
                    return "Renovar";
                case "??????????????":
                    return "????????????????????";
                case "?????????":
                    return "??????";
                case "????????????":
                    return "??????";
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
                case "Espa??ol":
                    return "Palabra de las Sombras: muerte";
                case "Fran??ais":
                    return "Mot de l???ombre??: Mort";
                case "Italiano":
                    return "Parola d'Ombra: Morte";
                case "Portugu??s Brasileiro":
                    return "Palavra Sombria: Morte";
                case "??????????????":
                    return "?????????? ????????: ????????????";
                case "?????????":
                    return "????????? ??????: ??????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Palabra de las Sombras: dolor";
                case "Fran??ais":
                    return "Mot de l???ombre??: Douleur";
                case "Italiano":
                    return "Parola d'Ombra: Dolore";
                case "Portugu??s Brasileiro":
                    return "Palavra Sombria: Dor";
                case "??????????????":
                    return "?????????? ????????: ????????";
                case "?????????":
                    return "????????? ??????: ??????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Punici??n";
                case "Fran??ais":
                    return "Ch??timent";
                case "Italiano":
                    return "Punizione";
                case "Portugu??s Brasileiro":
                    return "Puni????o";
                case "??????????????":
                    return "????????";
                case "?????????":
                    return "???????????? ??????";
                case "????????????":
                    return "??????";
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
                case "Espa??ol":
                    return "S??mbolo de esperanza";
                case "Fran??ais":
                    return "Symbole d???espoir";
                case "Italiano":
                    return "Simbolo di Speranza";
                case "Portugu??s Brasileiro":
                    return "S??mbolo de Esperan??a";
                case "??????????????":
                    return "???????????? ??????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                    return "Faew??chter";
                case "Espa??ol":
                    return "S??lfides guardianas";
                case "Fran??ais":
                    return "Gardiens fa??";
                case "Italiano":
                    return "Guardiani Silfi";
                case "Portugu??s Brasileiro":
                    return "Guardi??es Fe??rios";
                case "??????????????":
                    return "?????????????????? ????????????";
                case "?????????":
                    return "?????? ?????????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Bendici??n de los Ascendidos";
                case "Fran??ais":
                    return "Faveur des transcend??s";
                case "Italiano":
                    return "Dono degli Ascesi";
                case "Portugu??s Brasileiro":
                    return "Dom dos Ascendidos";
                case "??????????????":
                    return "?????????????????????????? ??????????????????????????";
                case "?????????":
                    return "???????????? ??????";
                case "????????????":
                    return "???????????????";
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
                case "Espa??ol":
                    return "Juegos mentales";
                case "Fran??ais":
                    return "Jeux d???esprit";
                case "Italiano":
                    return "Giochi Mentali";
                case "Portugu??s Brasileiro":
                    return "Jogos Mentais";
                case "??????????????":
                    return "???????? ????????????";
                case "?????????":
                    return "?????? ??????";
                case "????????????":
                    return "?????????";
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
                case "Espa??ol":
                    return "Explosi??n ascendida";
                case "Fran??ais":
                    return "D??flagration d???ascension";
                case "Italiano":
                    return "Detonazione Ascesa";
                case "Portugu??s Brasileiro":
                    return "Impacto Ascendido";
                case "??????????????":
                    return "?????????? ????????????????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Nova ascendida";
                case "Fran??ais":
                    return "Nova transcend??e";
                case "Italiano":
                    return "Nova Ascesa";
                case "Portugu??s Brasileiro":
                    return "Nova Ascendida";
                case "??????????????":
                    return "???????????? ????????????????????????";
                case "?????????":
                    return "????????? ?????????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Nova profana";
                case "Fran??ais":
                    return "Nova impie";
                case "Italiano":
                    return "Nova Empia";
                case "Portugu??s Brasileiro":
                    return "Nova Profana";
                case "??????????????":
                    return "???????????????????? ????????????";
                case "?????????":
                    return "????????? ??????";
                case "????????????":
                    return "????????????";
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
                case "Espa??ol":
                    return "Piedra de salud";
                case "Fran??ais":
                    return "Pierre de soins";
                case "Italiano":
                    return "Pietra della Salute";
                case "Portugu??s Brasileiro":
                    return "Pedra de Vida";
                case "??????????????":
                    return "???????????? ????????????????";
                case "?????????":
                    return "?????????";
                case "????????????":
                    return "?????????";
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
                case "Espa??ol":
                    return "Poci&oacute;n de intelecto espectral";
                case "Fran??ais":
                    return "Potion d&rsquo;Intelligence spectrale";
                case "Italiano":
                    return "Pozione dell'Intelletto Spettrale";
                case "Portugu??s Brasileiro":
                    return "Po&ccedil;&atilde;o do Intelecto Espectral";
                case "??????????????":
                    return "?????????? ?????????????????????? ????????????????????";
                case "?????????":
                    return "?????? ????????? ??????";
                case "????????????":
                    return "??????????????????";
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
                case "Espa??ol":
                    return "Poci&oacute;n de man&aacute; espiritual";
                case "Fran??ais":
                    return "Potion de mana spirituel";
                case "Italiano":
                    return "Pozione di Mana Spirituale";
                case "Portugu??s Brasileiro":
                    return "Po&ccedil;&atilde;o de Mana Espiritual";
                case "??????????????":
                    return "???????????????? ?????????? ????????";
                case "?????????":
                    return "????????? ?????? ??????";
                case "????????????":
                    return "??????????????????";
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
            Settings.Add(new Setting("Game Client Language", new List<string>(){"English", "Deutsch", "Espa??ol", "Fran??ais", "Italiano", "Portugu??s Brasileiro", "??????????????", "?????????", "????????????"}, "English"));
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