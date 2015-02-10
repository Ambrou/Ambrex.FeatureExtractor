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
Scenario: transformation de deux scénarios
	Given l'exigence extraite suivante:
            | titre                   | scénario                                                                                                                                                  |
            | Changement d’une tablée | Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’appelle le mot clef changeTable 7 Alors le script retourne à volonté OK   |
            | Changement d’une tablée | Étant donné un matériel Et où la configuration définissant la table 7 Quand j’appelle le mot clef changeTable 7 Alors le script retourne à volonté OK24 |
        And son contexte est "Étant donné un interpréteur de script Et un agenda"
	When je transforme le scénario
	Then l'exigence extraite devient:
            | titre                   | scénario                                                                                                                                              |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK   |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nQuand j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK24 |
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


		
@transformation
Scenario: transformation d'un plan de scénario simple sans indication de plan de scénario dans le texte
    Given l'exigence extraite suivante:
            | titre                                          | scénario                                                                                                                                                                                                                                                                                                                                    |
            | Définition des statuts bloquants l’acquisition | Etant donné un générateur type Et aucun statut bloquant pour l’acquisition Lorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres Alors les statuts st sont bloquants pour l’acquisition Et le script retourne TCL_OK Exemples: \| type \| paramètres \| st \| \| Philips avec le protocole SDL \| st1Value 32 \| st1Value 32 \| |
	    And son contexte est "Soit un interpreteur TCL"
    When je transforme le scénario
    Then l'exigence extraite devient:
            | titre                                          | scénario                                                                                                                                                                                                                                                                                                                                    |
            | Définition des statuts bloquants l’acquisition | Soit un generateur type\nEt aucun statut bloquant pour l'acquisition\nLorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres\nAlors les statuts st sont bloquants pour l'acquisition\nEt le script retourne TCL_OK\nExemples:\n\| type                          \| parametres  \| st          \|\n\| Philips avec le protocole SDL \| st1Value 32 \| st1Value 32 \| |
        And son contexte devient "Soit un interpreteur TCL"

@transformation
Scenario: transformation d'un scénario avec table
    Given l'exigence extraite suivante:
            | titre                           | scénario                                                                                                                                                                                                                                                                                         |
            | Affichage des modes disponibles | Etant donné la fenetre de modification d’un PKA ouverte     Et la configuration detecteur définissant les modes : \| mode \|  \| 1 \|  \| 7 \|  \| 4 \|  \| 3 \| Alors les modes disponibles dans la liste deroulante sont dans l’ordre : \| mode \| \| 1    \| \| 3    \| \| 4    \| \| 7    \| |
	    And son contexte est "Etant donné l'IHM de TeTriS"
    When je transforme le scénario
    Then l'exigence extraite devient:
            | titre                           | scénario                                                                                                                                                                                                                                                                          |
            | Affichage des modes disponibles | Soit la fenetre de modification d'un PKA ouverte\nEt la configuration detecteur definissant les modes :\n\| mode \|\n\| 1    \|\n\| 7    \|\n\| 4    \|\n\| 3    \|\nAlors les modes disponibles dans la liste deroulante sont dans l'ordre :\n\| mode \|\n\| 1    \|\n\| 3    \|\n\| 4    \|\n\| 7    \| |
        And son contexte devient "Soit l'IHM de TeTriS"

