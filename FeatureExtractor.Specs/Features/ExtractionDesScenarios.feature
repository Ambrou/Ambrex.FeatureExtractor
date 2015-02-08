Feature: ExtractionDesScenarios
    In order to manipulate Requirement's scenarios as easily as moving shit around
    As a bourrin developer
    I want to find the context and all scenarios

@extraction
Scenario: Extraction de scénario simple
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                      |   
            | ESD_044 |   Contexte: Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK |
    When j'extrais les scénarios
    Then le besoin ESD_044 existe
        And Et il contient le scénario:
            | titre                | scénario                                                                                                                                   |
            |  Changement de table | Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK |
        And Et il contient le contexte "Étant donné un interpréteur de script"


@extraction
Scenario: Extraction de plusieurs scénarios simples
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
            | ESD_044 | Contexte: Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK Scénario: Changement de table avec une table non définie Étant donné un matériel Et la configuration ne définissant pas la table 2 Lorsque j'appelle le mot clef changeTable 2 Alors j’ai la trace d’erreur numéro IDS_TCL_ERR_UNDEFINED_TABLE Et le script retourne KO |
    When j'extrais les scénarios
    Then le besoin ESD_044 existe
        And Et il contient les scénarios:
            | titre                                          | scénarios                                                                                                                                                                                                      |
            | Changement de table                            | Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK                                                                     |
            | Changement de table avec une table non définie | Étant donné un matériel Et la configuration ne définissant pas la table 2 Lorsque j'appelle le mot clef changeTable 2 Alors j’ai la trace d’erreur numéro IDS_TCL_ERR_UNDEFINED_TABLE Et le script retourne KO |
        And Et il contient le contexte "Étant donné un interpréteur de script"

@extraction
Scenario: Extraction de scénarios complexes
    Given les exigences suivantes:
        | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
        | ESD_044 | Cette fonctionnalité permet de changer la valeur courante de gain. Accès à la fonctionnalité depuis un script Syntaxe changeGain valeur Spécifications exécutables Contexte: Étant donné un interpréteur de script Scénario: Changement de gain Etant donné un matériel Et la configuration définit le gain 7 Lorsque j'appelle le mot clef changeGain 7 Alors le script retourne OK Scénario: Changement de gain avec un gain non défini Etant donné un matériel Et la configuration définit pas le gain 2 Lorsque j'appelle le mot clef changeGain 2 Alors j’ai la trace d’erreur numero IDS_TCL_ERR_UNDEFINED_GAIN Et le script retourne KO Résultats attendus Met à jour le gain du mode courant. Met à jour la combo box gain de l’IHM. Le mot clef ne retourne rien à l’interpréteur. Si un problème survient alors un message d’erreur est affiché dans la fenêtre de sortie des messages standards. |
	When j'extrais les scénarios
	Then le besoin ESD_044 existe
        And Et il contient les scénarios:
            | titre                                      | scénarios                                                                                                                                                                                            |
            | Changement de gain                         | Etant donné un matériel Et la configuration définit le gain 7 Lorsque j'appelle le mot clef changeGain 7 Alors le script retourne OK                                                                 |
            | Changement de gain avec un gain non défini | Etant donné un matériel Et la configuration définit pas le gain 2 Lorsque j'appelle le mot clef changeGain 2 Alors j’ai la trace d’erreur numero IDS_TCL_ERR_UNDEFINED_GAIN Et le script retourne KO |
        And Et il contient le contexte "Étant donné un interpréteur de script"


@extraction
Scenario: Extraction d'un plan de scénario simple sans indication de plande scénario dans le texte
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |   
            | ESD_046 |   Contexte:     Soit un interpreteur TCL  Scénario: Définition des statuts bloquant l’acquisition     Etant donné un générateur type     Et aucun statut bloquant pour l’acquisition     Lorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres     Alors les statuts st sont bloquants pour l’acquisition     Et le script retourne TCL_OK Exemples:     \|  type                      \| paramètres  \| st          \|     \| Philips avec le protocole SDL  \| st1Value 32 \| st1Value 32 \| |
    When j'extrais les scénarios
    Then le besoin ESD_046 existe
        And Et il contient le scénario:
            | titre                                          | scénario                                                                                                                                                                                                                                                                                                                                                                                                                                               |
            |  Définition des statuts bloquant l’acquisition | Etant donné un générateur type Et aucun statut bloquant pour l’acquisition Lorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres Alors les statuts st sont bloquants pour l’acquisition Et le script retourne TCL_OK Exemples: \| type \| paramètres \| st \| \| Philips avec le protocole SDL \| st1Value 32 \| st1Value 32 \| |
        And Et il contient le contexte "Soit un interpreteur TCL"
	
@extraction
Scenario: Extraction d'un plan de scénario complexe sans indication de plande scénario dans le texte
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
            | ESD_046 | Description La configuration maamétrer : ,    Spécifications exécutables   Scénario: Vérification du RTC Port pour un RTC soft ou hard     Etant donné le champ Active RTC defini a un type de RTC hard ou soft         Et le champ RTC Port <etat>     Lorsque je verifie la configuration RTC     Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG         Et TeTriS ne se lance pas Exemple:     \| etat       \|     \| inexistant \|     \| vide       \|    IDS_ERR_RTC_PORT_CONFIG  Erreur de configuration de TeTr |
    When j'extrais les scénarios
    Then le besoin ESD_046 existe
        And Et il contient le scénario:
            | titre                                             | scénario                                                                                                                                                                                                                                                                                                    |
            | Vérification du RTC Port pour un RTC soft ou hard | Etant donné le champ Active RTC defini a un type de RTC hard ou soft Et le champ RTC Port <etat> Lorsque je verifie la configuration RTC Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG Et TeTriS ne se lance pas Exemple: \| etat \| \| inexistant \| \| vide \| |
        And Et il contient le contexte ""
			
@extraction
Scenario: Extraction sans aucun scénario
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
            | ESD_263 | Cette fonctionnalité permet de définir si l’on doit se connecter avec le générateur au démarrage de TeTriS. Accès à la fonctionnalité depuis le fichier TeTriS_Configuration.ini Conditions  Dans le fichier de configuration du profil, dans la section Hardware Enabled l’entrée Connect XGenerator définit si l’on doit se connecter. Par défaut la valeur est à yes Résultats attendus Si le mot clef n’est pas défini alors par défaut on se connecte au démarrage. Si le mot clef est défini à yes alors on se connecte au démarrage. Si le mot clef est défini à no alors on ne se connecte pas au démarrage. Il faudra par la suite se connecter manuellement au générateur ou via un mot clef de pilotage du générateur. Si le mot clef est défini à une autre valeur, alors on se connecte au démarrage. |
    When j'extrais les scénarios
    Then le besoin ESD_263 n'existe pas
			
@extraction
Scenario: Extraction d'un scénario complexe dont la fin est un doublon de mot
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                   |
            | ESD_046 | Scénario: Sauvegarde impossible lors d’une acquisition autre que contrôlée par script     Etant donné que TeTriS n’a pas pu sauvegarder d’images pour cause de mémoire insuffisante     Lorsque l’acquisition est terminee     Alors j’ai la trace de warning numero IDS_WARN_ACQUI_NO_MEM  IDS_WARN_ACQUI_NO_MEM  WARNING : toutes les |
    When j'extrais les scénarios
    Then le besoin ESD_046 existe
        And Et il contient le scénario:
            | titre                                                                       | scénario                                                                                                                                                                                 |
            | Sauvegarde impossible lors d’une acquisition autre que contrôlée par script | Etant donné que TeTriS n’a pas pu sauvegarder d’images pour cause de mémoire insuffisante Lorsque l’acquisition est terminee Alors j’ai la trace de warning numero IDS_WARN_ACQUI_NO_MEM |
        And Et il contient le contexte ""
			
@extraction
Scenario: Extraction d'un scénario qui commence par Lorsque au lieu de Etant donne ou soit
    Given les exigences suivantes:
            | ReqID   | TEXTE                                                                                                                                                                                                                      |   
            | ESD_044 |   Contexte: Étant donné un interpréteur de script Scénario: Changement de table Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK |
    When j'extrais les scénarios
    Then le besoin ESD_044 existe
        And Et il contient le scénario:
            | titre               | scénario                                                                |
            | Changement de table | Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK |
        And Et il contient le contexte "Étant donné un interpréteur de script"

@extraction
Scenario: Extraction de scénario simple avec sa fonctionnalité
    Given l'exigences suivantes:
            | ReqID   | Fonctionnalité        | TEXTE                                                                                                                                                                                                                    |
            | ESD_044 | Mon role est de [p.4] | Contexte: Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK |
    When j'extrais les scénarios
    Then le besoin ESD_044 existe
        And Et il contient le scénario:
            | titre                | scénario                                                                                                                                   |
            |  Changement de table | Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK |
        And Et il contient le contexte "Étant donné un interpréteur de script"
		And sa fonctionnalité est "Mon role est de"
