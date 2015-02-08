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
            Assert.AreEqual("Description La configuration matérielle de l’application permet de connaître le contexte dans lequel l’utilisateur veut utiliser l’application. Il doit être en mesure de paramétrer : Le type de détecteur, Le type de générateur, Le type de RTC, Le type de carte d'acquisition, La demande de reset du RTC, La demande de reset du détecteur ou pas au démarrage de TeTriS, La demande de rafraîchissement de l’interface avec les paramètres du détecteur, Le nom du port série pour le RTC, Le nom du port série pour le générateur de rayons X. Accès à la fonctionnalité depuis un profil Conditions Lancer TeTriS Résultats attendus Une fenêtre de sélection de profil s’affiche avec les profils présents dans le répertoire courant de l’application. Un bouton   permet de sélectionner un autre répertoire afin de sélectionner d’autres profils sur un autre répertoire. Une fois le répertoire choisi, la fenêtre se met à jour avec les nouveaux profils trouvés et efface les profils de l’ancien répertoire.  Accès à la fonctionnalité depuis le fichier TeTriS_Configuration.ini Conditions Chaque répertoire de profil doit contenir un fichier TeTriS_Configuration.ini. Résultats attendus Si ce fichier n'existe pas dans le répertoire de profil, l’application ne peut pas démarrer et une boite de dialogue s’ouvre. Elle prévient l’utilisateur que l’application ne peut démarrer sans ce fichier.        Si le fichier existe : Lors du lancement de l'application, un contrôle est fait sur les choix hardware du profil, afin de vérifier la concordance du matériel choisi et d’éviter que l’application ne démarre avec une configuration qui n’a pas de sens.   Spécifications exécutables  Scénario: Vérification du RTC Port pour un RTC NO     Etant donné le champ Active RTC defini a NO     Lorsque je verifie la configuration RTC     Alors TeTriS ne verifie pas le champ RTC Port  Scénario: Vérification du RTC Port pour un RTC soft ou hard     Etant donné le champ Active RTC defini a un type de RTC hard ou soft         Et le champ RTC Port <etat>     Lorsque je verifie la configuration RTC     Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG         Et TeTriS ne se lance pas Exemple:     | etat       |     | inexistant |     | vide       |    IDS_ERR_RTC_PORT_CONFIG  Erreur de configuration de TeTriS : RTC port non défini dans le fichier  TeTriS Configuration Error : there is no RTC port configuration in the file       Cette vérification du matériel se fait via la lecture du fichier de configuration «HardwareConfigurationTable_Default.ini ». En effet, ce dernier liste toutes les combinaisons de hardware autorisées possibles, il est analysé au lancement de l’application afin de continuer ou de bloquer le démarrage. Si les champs ne sont pas renseignés ou sont commentés, la valeur par défaut est « NO » (pas de matériel de connecté). Si la configuration matérielle n'existe pas, le lancement de l'application est arrêté et une boite de dialogue s'ouvre avec un message rappelant à l'utilisateur sa configuration hardware, et que celle-ci n’est pas correcte.",
                requirement["ESD-TXL-TeTriS-001"].Item2);

        }
    }
}
