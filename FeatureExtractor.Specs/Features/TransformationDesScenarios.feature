Feature: TransformationDesScenarios
	In order to use cucumber-cpp with ruby
	As a french man
	I want to remove all silly caracteres like é or à 

@transformation
Scenario: transformation d'un scénario
	Given l'exigence extraite suivante:
            | titre                   | scénario                                                                                                                                                |
            | Changement d’une tablée | Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’appelle le mot clef changeTable 7 Alors le script retourne à volonté OK |
        And son contexte est "Étant donné un interpréteur de script"
	When je transforme le scénario
	Then l'exigence extraite devient:
            | titre                   | scénario                                                                                                                                            |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK |
        And son contexte devient "Soit un interpreteur de script"

		
@transformation
Scenario: transformation de deux scénario
	Given l'exigence extraite suivante:
            | titre                   | scénario                                                                                                                                                  |
            | Changement d’une tablée | Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’appelle le mot clef changeTable 7 Alors le script retourne à volonté OK   |
            | Changement d’une tablée | Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’appelle le mot clef changeTable 7 Alors le script retourne à volonté OK24 |
        And son contexte est "Étant donné un interpréteur de script Et un agenda"
	When je transforme le scénario
	Then l'exigence extraite devient:
            | titre                   | scénario                                                                                                                                              |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK   |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK24 |
        And son contexte devient "Soit un interpreteur de script\nEt un agenda"

@transformation
Scenario: transformation d'un scénario avec Etant donné
	Given l'exigence extraite suivante:
            | titre                   | scénario                                                                                                                                                |
            | Changement d’une tablée | Etant donné un matériel Et où la configuration définissant la table 7 Lorsque j’appelle le mot clef changeTable 7 Alors le script retourne à volonté OK |
        And son contexte est "Étant donné un interpréteur de script"
	When je transforme le scénario
	Then l'exigence extraite devient:
            | titre                   | scénario                                                                                                                                            |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK |
        And son contexte devient "Soit un interpreteur de script"
