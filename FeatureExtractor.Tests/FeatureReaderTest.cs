﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

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
            string path = Directory.GetCurrentDirectory();

            // Act
            Dictionary<string, Tuple<string, string>> requirement = reader.readRequirements("..\\..\\..\\FeatureExtractor.Tests\\Ressources\\Issue01.agex");

            // Assert
            //Assert.AreEqual("ESD-TXL-TeTriS-001", requirement.Keys[0]);
            Assert.AreEqual("Description La configuration matérielle de l’application permet de connaître le contexte dans lequel l’utilisateur veut utiliser l’application. Il doit être en mesure de paramétrer : Le type de détecteur, Le type de générateur, Le type de RTC, Le type de carte d'acquisition, La demande de reset du RTC, La demande de reset du détecteur ou pas au démarrage de TeTriS, La demande de rafraîchissement de l’interface avec les paramètres du détecteur, Le nom du port série pour le RTC, Le nom du port série pour le générateur de rayons X. Accès à la fonctionnalité depuis un profil Conditions Lancer TeTriS Résultats attendus Une fenêtre de sélection de profil s’affiche avec les profils présents dans le répertoire courant de l’application. Un bouton   permet de sélectionner un autre répertoire afin de sélectionner d’autres profils sur un autre répertoire. Une fois le répertoire choisi, la fenêtre se met à jour avec les nouveaux profils trouvés et efface les profils de l’ancien répertoire.  Accès à la fonctionnalité depuis le fichier TeTriS_Configuration.ini Conditions Chaque répertoire de profil doit contenir un fichier TeTriS_Configuration.ini. Résultats attendus Si ce fichier n'existe pas dans le répertoire de profil, l’application ne peut pas démarrer et une boite de dialogue s’ouvre. Elle prévient l’utilisateur que l’application ne peut démarrer sans ce fichier.        Si le fichier existe : Lors du lancement de l'application, un contrôle est fait sur les choix hardware du profil, afin de vérifier la concordance du matériel choisi et d’éviter que l’application ne démarre avec une configuration qui n’a pas de sens.   Spécifications exécutables  Scénario: Vérification du RTC Port pour un RTC NO     Etant donné le champ Active RTC defini a NO     Lorsque je verifie la configuration RTC     Alors TeTriS ne verifie pas le champ RTC Port  Scénario: Vérification du RTC Port pour un RTC soft ou hard     Etant donné le champ Active RTC defini a un type de RTC hard ou soft         Et le champ RTC Port <etat>     Lorsque je verifie la configuration RTC     Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG         Et TeTriS ne se lance pas Exemple:     | etat       |     | inexistant |     | vide       |    IDS_ERR_RTC_PORT_CONFIG  Erreur de configuration de TeTriS : RTC port non défini dans le fichier  TeTriS Configuration Error : there is no RTC port configuration in the file       Cette vérification du matériel se fait via la lecture du fichier de configuration «HardwareConfigurationTable_Default.ini ». En effet, ce dernier liste toutes les combinaisons de hardware autorisées possibles, il est analysé au lancement de l’application afin de continuer ou de bloquer le démarrage. Si les champs ne sont pas renseignés ou sont commentés, la valeur par défaut est « NO » (pas de matériel de connecté). Si la configuration matérielle n'existe pas, le lancement de l'application est arrêté et une boite de dialogue s'ouvre avec un message rappelant à l'utilisateur sa configuration hardware, et que celle-ci n’est pas correcte.",
                requirement["ESD-TXL-TeTriS-001"].Item2);

        }

        [TestMethod]
        public void FeatureReaderTestIssue4()
        {
            // Arrange
            FeatureReader reader = new FeatureReader();
            string path = Directory.GetCurrentDirectory();

            // Act
            Dictionary<string, Tuple<string, string>> requirement = reader.readRequirements("..\\..\\..\\FeatureExtractor.Tests\\Ressources\\Issue04.agex");

            string strTemp = "Description L’application TeTriS peut être lancée de plusieurs manières : Depuis le fichier exécutable directement (donc sans ligne de commande) En ligne de commande (de plusieurs façons).  Le fichier exécutable doit être contenu dans le répertoire de package de tests asterix. Lors du démarrage de TeTriS une fenêtre indique les différentes étapes d’initialisation : Vérification de la configuration de la carte réseau (facultatif) Connexion avec la carte d’acquisition Connexion avec le RTC Connexion avec le générateur Connexion avec le détecteur Lancement du script tcl defaultstartup.tcl Rafraichissement de l’interface homme machine  Spécifications exécutables  Scénario: Vérification de la configuration de la carte réseau      Etant donné les données Ethernet correctement définies dans la configuration TeTriS         Et la carte reseau \"Ethernet Board Name\" avec une adresse IP <statut> de celle definie par Ethernet Board IP          Et un utilisateur avec les droits <droits>     Lorsque TeTriS initialise le materiel     Alors l’adresse IP de la carte est <etat>         Et j’ai la boite d’initialisation hardware avec l’information Ethernet board setting : <resultat> Exemples : | statut     | droits             | etat         | resultat          | | differente | administrateur     | modifiee     | OK (modified)     | | differente | non administrateur | non modifiee | error             | | identique  | administrateur     | non modifiee | OK (not modified) | | identique  | non administrateur | non modifiee | OK (not modified) |  Scénario: Vérification de la configuration de la carte réseau avec configuration insuffisante     Etant donné les données Ethernet dans la configuration TeTriS <etat>     Lorsque TeTriS initialise le materiel     Alors j’ai la boite d’initialisation hardware avec l’information Ethernet board setting : <resultat> Exemples : | etat         | resultat  | | inexistantes | not done  | | vides        | not done  | | erronées     | error     |   Avant la connexion avec le générateur, si un module DIO est présent TeTriS teste si la porte du générateur est fermée. Si elle est ouverte affichage de la trace d’information dans la sortie générateur IDS_TXL_GENERATOR_DOOR_OPENED.  IDS_TXL_GENERATOR_DOOR_OPENED  ATTENTION : La porte du générateur est ouverte  XGenerator door is not closed MM :SS ». HH représente l’heure courante sur 24 heures, MM représente les minutes courantes, SS représente les secondes courantes. Exemple :      Si l’initialisation échoue un message modal récapitule l’état de l’initialisation sous forme de  « Acquisition board\\t  : statusRTC\\t\\t  : status X-ray generator\\t  : status Detector\\t\\t  : status »  Si la configuration du port du module DIO USB échoue le message IDS_DIO_CONFIGURE_PORT_FAILED est affiché et TeTriS sort avec le code d’erreur 1  IDS_DIO_CONFIGURE_PORT_FAILED  “Echec de configuration du port du module USB DIO”  \"Cannot configure port for USBDIO module.\"      Le statut est  « Disable » si le matériel correspondant est defini à NO dans le fichier de configuration.  Exemple   Accès à la fonctionnalité sans ligne de commande Conditions Il s’agit d’un double-clic sur l’application ou le lancement de l’application depuis une application externe sans ligne de commande. Résultats attendus Il conduit à l’exécution simple de l’application.  Le titre de l’application est correctement renseigné en fonction du profil demandé. Les positions des fenêtres sont celles mémorisées dans le fichier TeTriS_Registry.ini. Accès à la fonctionnalité avec une ligne de commande Conditions L’application peut-être exécutée depuis un raccourci, un fichier bat, une application extérieure. La ligne de commande est composée de plusieurs paramètres et options : Nom du profil Nom du script à exécuter (optionnel) Exécution « cachée » (optionnel : défaut = pas caché). Option d’externalisation des messages (voir paragraphe correspondant) Obtention de la version (-v)  Lors du lancement de TeTriS via une ligne de commande sans l’option extmsg, la boîte de dialogue apparaissant lors d’une erreur d’exécution de script TCL n’apparait pas. Les informations qu’elle contient seront affichées dans la fenêtre de sortie standard. Lors du lancement de TeTriS via une ligne de commande avec l’option -v, aucune autre commande ne doit être présente. Si un paramètre est erroné il est ignoré et aucune trace ne l’indique à l’opérateur. Par exemple si l’opérateur saisi –extmag 7400, TeTriS se lancera en mode mono poste. Résultats attendus Le titre de l’application est correctement renseigné en fonction du profil demandé. Les positions des fenêtres sont celles mémorisées dans le fichier TeTriS_Registry.ini.  Suivant le cas : Nom du profil seulement : TeTriS va être lancé avec le profil correspondant et va se mettre en attente d’une utilisation manuelle, Nom du script à exécuter : TeTriS va se lancer, exécuter le script et se fermer automatiquement sans demander une intervention de l’utilisateur, Exécution « cachée » : TeTriS sera exécuté en mode invisible. Obtention de la version : Le paramètre v affichera le numéro court de la version de Tetris, exemple pour la version 61542913AX, AX sera affiché. L’appel  à ce paramètre affichera la version de Tetris dans la console, puis  Tetris se fermera.  Si une erreur survient lors du lancement du à la ligne de commande, une boîte de dialogue modale en informe l’opérateur.  Message d’erreur Si le script n’existe pas : \"TeTriS error : the script script does not exist\" où script est le nom du script avec son chemin d’accès Si le profil n’existe pas : \"TeTriS error : the profil profil does not exist\"où profil est le nom du profil utilisé Si l’usage est incorrect : \"TETRIS usage : tetris.exe [-p profil_utilisateur [ [-i script] [-hide] [-extmsg serverport] ] ] [-v]\"";

            // Assert
            Assert.AreEqual(strTemp, requirement["ESD-TXL-TeTriS-008"].Item2);

        }
    }
}
