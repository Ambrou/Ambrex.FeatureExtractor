Feature: ExtractionDesScenarios
    In order to manipulate Requirement's scenarios as easily as moving shit around
    As a bourrin developer
    I want to find the context and all scenarios

@core
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


@core
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

@core
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