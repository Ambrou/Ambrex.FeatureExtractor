using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FeatureExtractor.Tests
{
    [TestClass]
    public class FeatureReaderTest
    {
        [TestMethod]
        public void FeatureReaderTestIssue1()
        {
            // Arrange
            FeatureReader reader = new FeatureReader();

            // Act
            Dictionary<string, Tuple<string, string>> requirement = reader.readRequirements("..\\..\\Ressources\\Issue01.agex");

            // Assert
            //Assert.AreEqual("ESD-TXL-TeTriS-001", requirement.Keys[0]);
            Assert.AreEqual("Description La configuration matÃ©rielle de lâapplication permet de connaÃ®tre le contexte dans lequel lâutilisateur veut utiliser lâapplication. Il doit Ãªtre en mesure de paramÃ©trerÂ : Le type de dÃ©tecteur, Le type de gÃ©nÃ©rateur, Le type de RTC, Le type de carte d'acquisition, La demande de reset du RTC, La demande de reset du dÃ©tecteur ou pas au dÃ©marrage de TeTriS, La demande de rafraÃ®chissement de lâinterface avec les paramÃštres du dÃ©tecteur, Le nom du port sÃ©rie pour le RTC, Le nom du port sÃ©rie pour le gÃ©nÃ©rateur de rayons X. AccÃšs Ã  la fonctionnalitÃ© depuis un profil Conditions Lancer TeTriS RÃ©sultats attendus Une fenÃªtre de sÃ©lection de profil sâaffiche avec les profils prÃ©sents dans le rÃ©pertoire courant de lâapplication. Un bouton   permet de sÃ©lectionner un autre rÃ©pertoire afin de sÃ©lectionner dâautres profils sur un autre rÃ©pertoire. Une fois le rÃ©pertoire choisi, la fenÃªtre se met Ã  jour avec les nouveaux profils trouvÃ©s et efface les profils de lâancien rÃ©pertoire.  AccÃšs Ã  la fonctionnalitÃ© depuis le fichier TeTriS_Configuration.ini Conditions Chaque rÃ©pertoire de profil doit contenir un fichier TeTriS_Configuration.ini. RÃ©sultats attendus Si ce fichier n'existe pas dans le rÃ©pertoire de profil, lâapplication ne peut pas dÃ©marrer et une boite de dialogue sâouvre. Elle prÃ©vient lâutilisateur que lâapplication ne peut dÃ©marrer sans ce fichier.        Si le fichier existeÂ : Lors du lancement de l'application, un contrÃŽle est fait sur les choix hardware du profil, afin de vÃ©rifier la concordance du matÃ©riel choisi et dâÃ©viter que lâapplication ne dÃ©marre avec une configuration qui nâa pas de sens.   SpÃ©cifications exÃ©cutables  ScÃ©nario: VÃ©rification du RTC Port pour un RTC NO     Etant donnÃ© le champ Active RTC defini a NO     Lorsque je verifie la configuration RTC     Alors TeTriS ne verifie pas le champ RTC Port  ScÃ©nario: VÃ©rification du RTC Port pour un RTC soft ou hard     Etant donnÃ© le champ Active RTC defini a un type de RTC hard ou soft         Et le champ RTC Port <etat>     Lorsque je verifie la configuration RTC     Alors jâai la boite de dialogue dâerreur IDS_ERR_RTC_PORT_CONFIG         Et TeTriS ne se lance pas Exemple:     | etat       |     | inexistant |     | vide       |    IDS_ERR_RTC_PORT_CONFIG  Erreur de configuration de TeTriSÂ : RTC port non dÃ©fini dans le fichier  TeTriS Configuration Error : there is no RTC port configuration in the file       Cette vÃ©rification du matÃ©riel se fait via la lecture du fichier de configuration Â«HardwareConfigurationTable_Default.iniÂ Â». En effet, ce dernier liste toutes les combinaisons de hardware autorisÃ©es possibles, il est analysÃ© au lancement de lâapplication afin de continuer ou de bloquer le dÃ©marrage. Si les champs ne sont pas renseignÃ©s ou sont commentÃ©s, la valeur par dÃ©faut est Â«Â NOÂ Â» (pas de matÃ©riel de connectÃ©). Si la configuration matÃ©rielle n'existe pas, le lancement de l'application est arrÃªtÃ© et une boite de dialogue s'ouvre avec un message rappelant Ã  l'utilisateur sa configuration hardware, et que celle-ci nâest pas correcte.",
                requirement["ESD-TXL-TeTriS-001"].Item2);

        }
    }
}
