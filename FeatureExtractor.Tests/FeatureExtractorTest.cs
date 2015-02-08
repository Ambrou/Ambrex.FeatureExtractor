using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FeatureExtractor.Tests
{
    [TestClass]
    public class FeatureExtractorTest
    {
        [TestMethod]
        public void TestExtractWithContextAndOneSimpleScenario()
        {
            // Arrange
            Extractor extractor = new Extractor();
            Dictionary<string, string> requirements = new Dictionary<string, string>();
            requirements.Add("ESD_044", "  Contexte: Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK");
            
            // Act
            Dictionary<string, Requirement> extractedRequirements = extractor.extract(requirements);

            // Assert
            Assert.AreEqual("Étant donné un interpréteur de script", extractedRequirements["ESD_044"].m_strContext);
            Assert.AreEqual(1, extractedRequirements["ESD_044"].m_Scenarios.Count);
            bool bFound = false;
            for (int i = 0; i < extractedRequirements["ESD_044"].m_Scenarios.Count; i++)
            {
                if (extractedRequirements["ESD_044"].m_Scenarios[i].m_strSteps == "Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK" &&
                    extractedRequirements["ESD_044"].m_Scenarios[i].m_strTitle == "Changement de table")
                {
                    bFound = true;
                }
            }
            Assert.AreEqual(true, bFound);

        }

        [TestMethod]
        public void TestExtractIssue1()
        {
            Extractor extractor = new Extractor();
            Dictionary<string, string> requirements = new Dictionary<string, string>();
            requirements.Add("ESD-TXL-TeTriS-001", "Description La configuration matérielle de l’application permet de connaître le contexte dans lequel l’utilisateur veut utiliser l’application. Il doit être en mesure de paramétrer : Le type de détecteur, Le type de générateur, Le type de RTC, Le type de carte d'acquisition, La demande de reset du RTC, La demande de reset du détecteur ou pas au démarrage de TeTriS, La demande de rafraîchissement de l’interface avec les paramètres du détecteur, Le nom du port série pour le RTC, Le nom du port série pour le générateur de rayons X. Accès à la fonctionnalité depuis un profil Conditions Lancer TeTriS Résultats attendus Une fenêtre de sélection de profil s’affiche avec les profils présents dans le répertoire courant de l’application. Un bouton   permet de sélectionner un autre répertoire afin de sélectionner d’autres profils sur un autre répertoire. Une fois le répertoire choisi, la fenêtre se met à jour avec les nouveaux profils trouvés et efface les profils de l’ancien répertoire.  Accès à la fonctionnalité depuis le fichier TeTriS_Configuration.ini Conditions Chaque répertoire de profil doit contenir un fichier TeTriS_Configuration.ini. Résultats attendus Si ce fichier n'existe pas dans le répertoire de profil, l’application ne peut pas démarrer et une boite de dialogue s’ouvre. Elle prévient l’utilisateur que l’application ne peut démarrer sans ce fichier.        Si le fichier existe : Lors du lancement de l'application, un contrôle est fait sur les choix hardware du profil, afin de vérifier la concordance du matériel choisi et d’éviter que l’application ne démarre avec une configuration qui n’a pas de sens.   Spécifications exécutables  Scénario: Vérification du RTC Port pour un RTC NO     Etant donné le champ Active RTC defini a NO     Lorsque je verifie la configuration RTC     Alors TeTriS ne verifie pas le champ RTC Port  Scénario: Vérification du RTC Port pour un RTC soft ou hard     Etant donné le champ Active RTC defini a un type de RTC hard ou soft         Et le champ RTC Port <etat>     Lorsque je verifie la configuration RTC     Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG         Et TeTriS ne se lance pas Exemple:     | etat       |     | inexistant |     | vide       |    IDS_ERR_RTC_PORT_CONFIG  Erreur de configuration de TeTriS : RTC port non défini dans le fichier  TeTriS Configuration Error : there is no RTC port configuration in the file       Cette vérification du matériel se fait via la lecture du fichier de configuration «HardwareConfigurationTable_Default.ini ». En effet, ce dernier liste toutes les combinaisons de hardware autorisées possibles, il est analysé au lancement de l’application afin de continuer ou de bloquer le démarrage. Si les champs ne sont pas renseignés ou sont commentés, la valeur par défaut est « NO » (pas de matériel de connecté). Si la configuration matérielle n'existe pas, le lancement de l'application est arrêté et une boite de dialogue s'ouvre avec un message rappelant à l'utilisateur sa configuration hardware, et que celle-ci n’est pas correcte.    ");

            // Act
            Dictionary<string, Requirement> extractedRequirements = extractor.extract(requirements);

            // Assert
            Assert.AreEqual("", extractedRequirements["ESD-TXL-TeTriS-001"].m_strContext);
            Assert.AreEqual(2, extractedRequirements["ESD-TXL-TeTriS-001"].m_Scenarios.Count);
            
            Assert.AreEqual("Etant donné le champ Active RTC defini a NO Lorsque je verifie la configuration RTC Alors TeTriS ne verifie pas le champ RTC Port", extractedRequirements["ESD-TXL-TeTriS-001"].m_Scenarios[0].m_strSteps);
            Assert.AreEqual("Vérification du RTC Port pour un RTC NO", extractedRequirements["ESD-TXL-TeTriS-001"].m_Scenarios[0].m_strTitle);

            Assert.AreEqual("Etant donné le champ Active RTC defini a un type de RTC hard ou soft Et le champ RTC Port <etat> Lorsque je verifie la configuration RTC Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG Et TeTriS ne se lance pas Exemple: | etat | | inexistant | | vide |", extractedRequirements["ESD-TXL-TeTriS-001"].m_Scenarios[1].m_strSteps);
            Assert.AreEqual("Vérification du RTC Port pour un RTC soft ou hard", extractedRequirements["ESD-TXL-TeTriS-001"].m_Scenarios[1].m_strTitle);
        }

        [TestMethod]
        public void TestExtractIssue2()
        {
            // Arrange
            Extractor extractor = new Extractor();
            Dictionary<string, string> requirements = new Dictionary<string, string>();
            requirements.Add("ESD_005", "Description Ce paragraphe décrit comment l’utilisateur est informé des événements qui ont lieu au cours de l’utilisation de l’application. Si TeTriS est lancé en mode « externalisation des messages », alors ces messages seront redirigés vers l’application de supervision située sur un poste accessible via le réseau (car le mécanisme de transfert de messages utilise le protocole réseau TCP/IP).   Les messages peuvent apparaître sous plusieurs formes : les messages dans la fenêtre de sortie standard,   On retrouve dans cette vue des messages provenant de tous les composants qui veulent envoyer à l’utilisateur des messages non bloquants : l’interface homme machine (IHM), l’interpréteur de script TCL, les messages remontés par le module de la carte d’acquisition, les messages remontés par le module du détecteur, les messages remontés par le module de gestion des périphériques DIO.  les messages dans la fenêtre de sortie hardware,   La partie haute de cette vue reçoit des messages d’alerte ou d’information provenant des composants RTC. Ces messages RTC sont asynchrones. La partie basse de cette vue reçoit des messages asynchrones du générateur de rayons X. Les buffers utilisés pour l’affichage des données pour ces trois fenêtres sont des buffers tournant de 10000000 octets. C'est-à-dire que si l’on atteint la limite alors lors de la prochaine écriture les premiers octets seront supprimés pour être remplacés par les nouveaux. Toutes les traces de tous les logs seront terminées par le caractére de retour chariot ‘\n’.   les boîtes de messages bloquantes d’information, d’avertissement et d’erreur, suivant la criticité du message,          Remarque : Dans le cas où TeTriS a été lancé en mode « Externalisation des messages », les messages bloquants d’information seront automatiquement validés par TETRIS afin d’être externalisés, afin de ne pas bloquer le traitement. Ceci n’a aucune incidence sur la suite des traitements.   les boîtes de dialogues bloquantes de décision, Elles sont utilisées pour solliciter un choix de la part de l’utilisateur. Ces fenêtres contiennent souvent trois boutons  OUI  NON  ANNULER . Le choix de l’utilisateur modifie la suite du traitement.    les boîtes de dialogue de saisie, Ce sont des fenêtres invitant l’utilisateur à saisir des données qui seront utilisées par TETRIS pour effectuer le traitement demandé.  Exemple : Fenêtre de sélection de fichier  les fichiers de données (fichiers de trace), une boîte de message avec les boutons « YES » / « NO », une boîte d’attente avec bouton « OK », une boîte d’attente avec bouton « OK » et une barre d’attente. Messages extérieurs TETRIS utilise plusieurs applications tierces, dont certaines peuvent afficher des messages bloquants. C’est notamment le cas de l’utilitaire IniTestDlg.exe, lancé depuis un script TCL, il permet d’afficher une boite de dialogues, sollicitant une action de l’utilisateur.  Tout exécutable peut potentiellement être lancé depuis un script TCL. Les messages provenant de ces applications externes sont mis dans la catégorie de messages extérieurs. Accès à la fonctionnalité depuis le fichier TeTriS_Configuration.ini Conditions Ce fichier permet notamment : Le paramétrage d’un fichier de traces (optionnel) : Fichier de trace de tous les messages de sortie de l'application ainsi que ceux provenant du détecteur. Fichier de trace des messages provenant du RTC Fichier de trace des messages provenant du Générateur X Fichier de trace des messages provenant du Serveur   Le paramétrage de l’affichage de l’heure au début de chaque message des fenêtres de sortie (optionnel). Les fichiers de trace doivent pouvoir être consultables durant l’exécution de TeTriS, c'est-à-dire que l’on doit pouvoir les ouvrir ou les copier. Résultats attendus Si les chemins vers les fichiers de trace sont valides, alors tout le contenu de la fenêtre qui lui est associée est recopié dans ce fichier, à l’emplacement donné par l’utilisateur. Il est alors possible de les ouvrir ou de les copier, pendant l’exécution de TeTriS. Si les chemins vers les fichiers de trace ne sont pas valides, alors aucun fichier n’est créé.  Si le paramètre Clock est demandé, alors l’heure d’affichage du message sera affichée avant chaque message. Accès à la fonctionnalité depuis un script TCL Conditions Syntaxe : showYesNoMsg message   showMsgWait  message    showMsgTime message  timeout Résumé : Ces mots clefs permettent d’afficher différents types de boîtes de message.  Spécifications exécutables  Contexte:     Etant donné un interpreteur TCL     Etant donné l’IHM de TeTriS  Scénario: Demande d’affichage d’une boite de dialogue avec time out     Lorsque un script execute la commande showMsgTime \"Ceci est un message avec time out\" 25     Alors une boite de dialogue modale avec le texte \"Ceci est un message avec time out\" est affichée     Et le script retourne TCL_OK après 25 s     Et la boîte modale est fermée   Scénario: Demande d’affichage d’une boite de dialogue avec time out non décimal     Lorsque un script execute la commande showMsgTime \"Ceci est un message avec time out\" 25X000      Alors il n’y a pas de boîte modale affichée     Et j’ai la trace d’erreur numero IDS_TCL_ERR_SHOW_MSG_TIME_WRONG_ARG.     Et le script retourne TCL_KO    Résultats attendus showYesNoMsg permet d’afficher une boîte de message avec le choix entre YES et NO.   showMsgWait permet d’afficher  une boîte de message bloquante avec un seul choix pour fermer la boîte (OK)   showMsgTime permet d’afficher une boîte de message avec un timeout qui tient lieu de compte à rebours.    A la fin du compte à rebours la boîte est fermée automatiquement.");

            // Act
            Dictionary<string, Requirement> extractedRequirements = extractor.extract(requirements);

            // Assert
            Assert.AreEqual(2, extractedRequirements["ESD_005"].m_Scenarios.Count);
            
            Assert.AreEqual("Etant donné un interpreteur TCL Etant donné l’IHM de TeTriS", extractedRequirements["ESD_005"].m_strContext);
            
            Assert.AreEqual("Lorsque un script execute la commande showMsgTime \"Ceci est un message avec time out\" 25 Alors une boite de dialogue modale avec le texte \"Ceci est un message avec time out\" est affichée Et le script retourne TCL_OK après 25 s Et la boîte modale est fermée", extractedRequirements["ESD_005"].m_Scenarios[0].m_strSteps);
            Assert.AreEqual("Demande d’affichage d’une boite de dialogue avec time out", extractedRequirements["ESD_005"].m_Scenarios[0].m_strTitle);
            
            Assert.AreEqual("Lorsque un script execute la commande showMsgTime \"Ceci est un message avec time out\" 25X000 Alors il n’y a pas de boîte modale affichée Et j’ai la trace d’erreur numero IDS_TCL_ERR_SHOW_MSG_TIME_WRONG_ARG. Et le script retourne TCL_KO", extractedRequirements["ESD_005"].m_Scenarios[1].m_strSteps);
            Assert.AreEqual("Demande d’affichage d’une boite de dialogue avec time out non décimal", extractedRequirements["ESD_005"].m_Scenarios[1].m_strTitle);
                

        }
    }
}
