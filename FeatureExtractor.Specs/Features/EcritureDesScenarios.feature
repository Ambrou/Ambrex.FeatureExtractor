Feature: EcritureDesScenarios
	In order to get all scenarios in files
	As a lazy developer
	I want to the scenarios written in a file

@ecriture
Scenario: Ecriture d'un scénario
	Given l'exigence transformée ESD_044 contenant les scénario:	       
            | titre                   | scénario                                                                                                                                              |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK   |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK24 |
	    And le contexte "Soit un interpreteur de script\nEt un agenda"
		And sa fonctionnalité est "Changement de table"
	When je génére les fichiers scénarios temporaires
	Then j'ai le fichier contient 044.feature contient les lignes:
	        | ligne                                                 |
	        | "# language: fr"                                      |
	        | "# encoding: Windows-1252"                            |
	        | "@ESD_044"                                            |
	        | "Fonctionnalité: Changement de table"                 |
	        | ""                                                    |
	        | "  Contexte:"                                         |
	        | "    Soit un interpreteur de script"                  |
	        | "      Et un agenda                                   |
	        | ""                                                    |
	        | "  @clean"                                            |
	        | "  Scénario: Changement d’une tablée"                 |
	        | "    Soit un materiel"                                |
	        | "      Et ou la configuration definissant la table 7" |
	        | "    Lorsque j'appelle le mot clef changeTable 7"     |
	        | "    Alors le script retourne a volonte OK"           |
	        | ""                                                    |
	        | "  @clean"                                            |
	        | "  Scénario: Changement d’une tablée"                 |
	        | "    Soit un materiel"                                |
	        | "      Et ou la configuration definissant la table 7" |
	        | "    Lorsque j'appelle le mot clef changeTable 7"     |
	        | "    Alors le script retourne a volonte OK24"         |


@ecriture
Scenario: Ecriture d'un plan de scénario
	Given l'exigence transformée ESD_044 contenant les scénario:	       
            | titre                                          | scénario                                                                                                                                                                                                                                                                                                                                    |
            | Définition des statuts bloquants l’acquisition | Soit un generateur type\nEt aucun statut bloquant pour l'acquisition\nLorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres\nAlors les statuts st sont bloquants pour l'acquisition\nEt le script retourne TCL_OK\nExemples:\n\| type \| parametres \| st \|\n\| Philips avec le protocole SDL \| st1Value 32 \| st1Value 32 \| |
	    And le contexte "Soit un interpreteur de script"
	When je génére les fichiers scénarios temporaires
	Then j'ai le fichier contient 044.feature contient les lignes:
	        | ligne                                                                       |
	        | "# language: fr"                                                            |
	        | "# encoding: Windows-1252"                                                  |
	        | "@ESD_044"                                                                  |
	        | "Fonctionnalité: "                                                          |
	        | ""                                                                          |
	        | "  Contexte:"                                                               |
	        | "    Soit un interpreteur de script"                                        |
	        | ""                                                                          |
	        | "  @clean"                                                                  |
	        | "  Plan du scénario: Définition des statuts bloquants l’acquisition         |
	        | "    Soit un generateur type"                                               |
	        | "      Et aucun statut bloquant pour l'acquisition"                         |
	        | "    Lorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres"     |
	        | "    Alors les statuts st sont bloquants pour l'acquisition"                |
	        | "      Et le script retourne TCL_OK"                                        |
	        | "  Exemples:"                                                               |
	        | "        \| type \| parametres \| st \|"                                    |
	        | "        \| Philips avec le protocole SDL \| st1Value 32 \| st1Value 32 \|" |

			
@ecriture
Scenario: Ecriture d'un scénario sans contexte
	Given l'exigence transformée ESD_144 contenant les scénario:	       
            | titre                   | scénario                                                                                                                                              |
            | Changement d’une tablée | Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j'appelle le mot clef changeTable 7\nAlors le script retourne a volonte OK   |
	    And le contexte ""
		And sa fonctionnalité est "Changement de table"
	When je génére les fichiers scénarios temporaires
	Then j'ai le fichier contient 144.feature contient les lignes:
	        | ligne                                                 |
	        | "# language: fr"                                      |
	        | "# encoding: Windows-1252"                            |
	        | "@ESD_144"                                            |
	        | "Fonctionnalité: Changement de table"                 |
	        | ""                                                    |
	        | "  @clean"                                            |
	        | "  Scénario: Changement d’une tablée"                 |
	        | "    Soit un materiel"                                |
	        | "      Et ou la configuration definissant la table 7" |
	        | "    Lorsque j'appelle le mot clef changeTable 7"     |
	        | "    Alors le script retourne a volonte OK"           |
