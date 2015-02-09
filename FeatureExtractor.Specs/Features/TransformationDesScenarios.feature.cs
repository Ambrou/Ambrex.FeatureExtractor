﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FeatureExtractor.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TransformationDesScenariosFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TransformationDesScenarios.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TransformationDesScenarios", "In order to use cucumber-cpp with ruby\nAs a french man\nI want to remove all silly" +
                    " caracteres like é or à", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "TransformationDesScenarios")))
            {
                FeatureExtractor.Specs.Features.TransformationDesScenariosFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("transformation d\'un scénario")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TransformationDesScenarios")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("transformation")]
        public virtual void TransformationDUnScenario()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("transformation d\'un scénario", new string[] {
                        "transformation"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table1.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’a" +
                            "ppelle le mot clef changeTable 7 Alors le script retourne à volonté OK"});
#line 8
 testRunner.Given("l\'exigence extraite suivante:", ((string)(null)), table1, "Given ");
#line 11
        testRunner.And("son contexte est \"Étant donné un interpréteur de script\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("je transforme le scénario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table2.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j\'appelle " +
                            "le mot clef changeTable 7\nAlors le script retourne a volonte OK"});
#line 13
 testRunner.Then("l\'exigence extraite devient:", ((string)(null)), table2, "Then ");
#line 16
        testRunner.And("son contexte devient \"Soit un interpreteur de script\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("transformation de deux scénarios")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TransformationDesScenarios")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("transformation")]
        public virtual void TransformationDeDeuxScenarios()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("transformation de deux scénarios", new string[] {
                        "transformation"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table3.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’a" +
                            "ppelle le mot clef changeTable 7 Alors le script retourne à volonté OK"});
            table3.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Étant donné un matériel Et où la configuration définissant la table 7 Lorsque j’a" +
                            "ppelle le mot clef changeTable 7 Alors le script retourne à volonté OK24"});
#line 21
 testRunner.Given("l\'exigence extraite suivante:", ((string)(null)), table3, "Given ");
#line 25
        testRunner.And("son contexte est \"Étant donné un interpréteur de script Et un agenda\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.When("je transforme le scénario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table4.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j\'appelle " +
                            "le mot clef changeTable 7\nAlors le script retourne a volonte OK"});
            table4.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j\'appelle " +
                            "le mot clef changeTable 7\nAlors le script retourne a volonte OK24"});
#line 27
 testRunner.Then("l\'exigence extraite devient:", ((string)(null)), table4, "Then ");
#line 31
        testRunner.And("son contexte devient \"Soit un interpreteur de script\\nEt un agenda\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("transformation d\'un scénario avec Etant donné")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TransformationDesScenarios")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("transformation")]
        public virtual void TransformationDUnScenarioAvecEtantDonne()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("transformation d\'un scénario avec Etant donné", new string[] {
                        "transformation"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table5.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Etant donné un matériel Et où la configuration définissant la table 7 Lorsque j’a" +
                            "ppelle le mot clef changeTable 7 Alors le script retourne à volonté OK"});
#line 35
 testRunner.Given("l\'exigence extraite suivante:", ((string)(null)), table5, "Given ");
#line 38
        testRunner.And("son contexte est \"Étant donné un interpréteur de script\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.When("je transforme le scénario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table6.AddRow(new string[] {
                        "Changement d’une tablée",
                        "Soit un materiel\nEt ou la configuration definissant la table 7\nLorsque j\'appelle " +
                            "le mot clef changeTable 7\nAlors le script retourne a volonte OK"});
#line 40
 testRunner.Then("l\'exigence extraite devient:", ((string)(null)), table6, "Then ");
#line 43
        testRunner.And("son contexte devient \"Soit un interpreteur de script\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("transformation d\'un plan de scénario simple sans indication de plan de scénario d" +
            "ans le texte")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TransformationDesScenarios")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("transformation")]
        public virtual void TransformationDUnPlanDeScenarioSimpleSansIndicationDePlanDeScenarioDansLeTexte()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("transformation d\'un plan de scénario simple sans indication de plan de scénario d" +
                    "ans le texte", new string[] {
                        "transformation"});
#line 48
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table7.AddRow(new string[] {
                        "Définition des statuts bloquants l’acquisition",
                        @"Etant donné un générateur type Et aucun statut bloquant pour l’acquisition Lorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres Alors les statuts st sont bloquants pour l’acquisition Et le script retourne TCL_OK Exemples: | type | paramètres | st | | Philips avec le protocole SDL | st1Value 32 | st1Value 32 |"});
#line 49
    testRunner.Given("l\'exigence extraite suivante:", ((string)(null)), table7, "Given ");
#line 52
     testRunner.And("son contexte est \"Soit un interpreteur TCL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
    testRunner.When("je transforme le scénario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table8.AddRow(new string[] {
                        "Définition des statuts bloquants l’acquisition",
                        @"Soit un generateur type
Et aucun statut bloquant pour l'acquisition
Lorsque j'appelle le mot clef setAcquiBlockingXGStatus parametres
Alors les statuts st sont bloquants pour l'acquisition
Et le script retourne TCL_OK
Exemples:
| type                          | parametres  | st          |
| Philips avec le protocole SDL | st1Value 32 | st1Value 32 |"});
#line 54
    testRunner.Then("l\'exigence extraite devient:", ((string)(null)), table8, "Then ");
#line 57
        testRunner.And("son contexte devient \"Soit un interpreteur TCL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("transformation d\'un scénario avec table")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TransformationDesScenarios")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("transformation")]
        public virtual void TransformationDUnScenarioAvecTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("transformation d\'un scénario avec table", new string[] {
                        "transformation"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table9.AddRow(new string[] {
                        "Affichage des modes disponibles",
                        @"Etant donné la fenetre de modification d’un PKA ouverte     Et la configuration detecteur définissant les modes : | mode |  | 1 |  | 7 |  | 4 |  | 3 | Alors les modes disponibles dans la liste deroulante sont dans l’ordre : | mode | | 1    | | 3    | | 4    | | 7    |"});
#line 61
    testRunner.Given("l\'exigence extraite suivante:", ((string)(null)), table9, "Given ");
#line 64
     testRunner.And("son contexte est \"Etant donné l\'IHM de TeTriS\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
    testRunner.When("je transforme le scénario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "titre",
                        "scénario"});
            table10.AddRow(new string[] {
                        "Affichage des modes disponibles",
                        @"Soit la fenetre de modification d'un PKA ouverte
Et la configuration detecteur definissant les modes :
| mode |
| 1    |
| 7    |
| 4    |
| 3    |
Alors les modes disponibles dans la liste deroulante sont dans l'ordre :
| mode |
| 1    |
| 3    |
| 4    |
| 7    |"});
#line 66
    testRunner.Then("l\'exigence extraite devient:", ((string)(null)), table10, "Then ");
#line 69
        testRunner.And("son contexte devient \"Soit l\'IHM de TeTriS\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
