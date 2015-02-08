Feature: LectureDesScenarios
	In order to extract scenarios from a requirement file
	As a BDD's developers
	I want to read in input file the several requirements

@lecture
Scenario: Lecture des exigences
	Given Le fichier ESD.agex contenant les lignes:
	    | ligne                                                                                                                                            |
	    | REQUIREMENTS EXTRACTION (RQ-FRT)                                                                                                                 |
	    | Document-Source: P:\Trixell_TMA\16 - Exigences\AGEX_VIT\docs\CDS-003896-00J Specifications Fonctionnelles VIT.docm                               |
	    | Document-Name: CDS-003896-00J Specifications Fonctionnelles VIT.docm [filtre=ESD]                                                                |
	    | Extracted-By: apetitgenet with agexWordMacros (Astek-RhA) 20090303 + apetitgenet/GNB-DT-005 with agexSplitReqs (Astek-RhA) 20090423 [filter=ESD] |
	    | Date-Time: 31/10/2014 - 14:59:03 + 2014/10/31-14:59                                                                                              |
	    | @=@=@REQUIREMENT@=@=@                                                                                                                            |
	    | ReqID= ESD_044                                                                                                                                   |
	    | TITRE= Utilisation de la bibliothèque IO_Image pour définir les zones de ROI [p.15]                                                              |
	    | VER= 00                                                                                                                                          |
	    | Exigence(s)-Amont= ESG-TXL-VIT-001 (P)                                                                                                           |
	    | Catégorie= Interopérabilité                                                                                                                      |
	    | Criticité= Préférable                                                                                                                            |
	    | Impact= Faible                                                                                                                                   |
	    | Stabilité= MoyenneImportante                                                                                                                     |
	    | Vérif.= Test                                                                                                                                     |
	    | TEXTE=   Gestion des informations dans la barre de statusstatuts [p.29]                                                                          |
	    | Commentaire(s)=                                                                                                                                  |
	    | Statut= A valider                                                                                                                                |
	    | Date-Statut= 09/05/2014                                                                                                                          |
	    | @=@=@REQUIREMENT@=@=@                                                                                                                            |
	    | ReqID= ESD_544                                                                                                                                   |
	    | TITRE= Utilisation de la bibliothèque IO_Image pour définir les zones de ROI [p.15]                                                              |
	    | VER= 00                                                                                                                                          |
	    | Exigence(s)-Amont= ESG-TXL-VIT-001 (P)                                                                                                           |
	    | Catégorie= Interopérabilité                                                                                                                      |
	    | Criticité= Préférable                                                                                                                            |
	    | Impact= Faible                                                                                                                                   |
	    | Stabilité= MoyenneImportante                                                                                                                     |
	    | Vérif.= Test                                                                                                                                     |
	    | TEXTE=   Gestion des informations dans la barre de status           statuts [p.29]                                                               |
	    | Commentaire(s)=                                                                                                                                  |
	    | Statut= A valider                                                                                                                                |
	    | Date-Statut= 09/05/2014                                                                                                                          |
	    | @=@=@REQUIREMENT@=@=@                                                                                                                            |
	When j'analyse ce fichier
	Then j'ai l'exigence ESD_044 avec comme texte "Gestion des informations dans la barre de statusstatuts [p.29]" et titre "Utilisation de la bibliothèque IO_Image pour définir les zones de ROI [p.15]"
	    And j'ai l'exigence ESD_544 avec comme texte "Gestion des informations dans la barre de status           statuts [p.29]" et titre "Utilisation de la bibliothèque IO_Image pour définir les zones de ROI [p.15]"
