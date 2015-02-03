Feature: ExtractionDesScenarios
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Extraction de scénario simple
	Given les exigences suivantes:
			| ReqID   | TEXTE                                                                                                                                                                                                                        |   
			| ESD_044 | "  Contexte: Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK" |
	When j'extrais les scénarios
	Then le besoin ESD_044 existe
		And Et il contient le scénario:
		    | titre                            | scénario                                                                                                                                     |
			|  "Scénario: Changement de table" | "Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK" |
		And Et il contient le contexte "Soit un interpreteur de script"