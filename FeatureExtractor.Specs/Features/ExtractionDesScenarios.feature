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
            | ReqID   | TEXTE                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
            | ESD_044 | "Contexte:Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK Scénario: Changement de table avec une table non définie Étant donné un matériel Et la configuration ne définissant pas la table 2 Lorsque j'appelle le mot clef changeTable 2 Alors j’ai la trace d’erreur numéro IDS_TCL_ERR_UNDEFINED_TABLE Et le script retourne KO" |
    When j'extrais les scénarios
    Then le besoin ESD_044 existe
        And Et il contient les scénario:
            | titre                                          | scénarios                                                                                                                                                                                                      |
            | Changement de table                            | Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK                                                                     |
            | Changement de table avec une table non définie | Étant donné un matériel Et la configuration ne définissant pas la table 2 Lorsque j'appelle le mot clef changeTable 2 Alors j’ai la trace d’erreur numéro IDS_TCL_ERR_UNDEFINED_TABLE Et le script retourne KO |
        And Et il contient le contexte "Étant donné un interpréteur de script"
