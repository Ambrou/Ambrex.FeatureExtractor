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
	When je génére les fichiers scénarios temporaires
	Then j'ai le fichier contient 044.feature contient les lignes:
	        | ligne                                                 |
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

