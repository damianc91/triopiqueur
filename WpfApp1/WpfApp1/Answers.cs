using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WpfApp1.answers;

namespace WpfApp1
{
    class Answers
    {
        public static bool FindAllTeamsOwned(string text)
        {
            List<string> teamNames = new List<string>();
            List<string> teamIds = new List<string>();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);
                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"teamid\"]/option");

                foreach (HtmlNode link in collection)
                {
                    teamNames.Add(link.InnerText.Trim());
                    foreach (var link2 in link.Attributes)
                    {
                        if (link2.Name == "value")
                        {
                            teamIds.Add(link2.Value);
                        }
                    }
                }


                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);

                XmlNode projectNode = documentXml.SelectSingleNode("//root/teams");
                XmlNode nodeTeam;
                XmlNode nodeTeamName;
                XmlNode nodeTeamId;

                for (int i = 0; i < teamIds.Count; i++)
                {
                    nodeTeam = documentXml.CreateNode(XmlNodeType.Element, "team", string.Empty);
                    nodeTeamName = documentXml.CreateNode(XmlNodeType.Element, "name", string.Empty);
                    nodeTeamName.InnerText = teamNames[i];
                    nodeTeamId = documentXml.CreateNode(XmlNodeType.Element, "id", string.Empty);
                    nodeTeamId.InnerText = teamIds[i];
                    projectNode.AppendChild(nodeTeam);
                    nodeTeam.AppendChild(nodeTeamName);
                    nodeTeam.AppendChild(nodeTeamId);
                }

                documentXml.Save(configPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("teams not found. Exception : " + ex.Message);
                return false;
            }
        }

        public static void WriteCurrentTeamInXml(string text)
        {
            try
            {
                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);

                XmlNode projectNode = documentXml.SelectSingleNode("//root/currentTeam/number");
                projectNode.InnerText = text;

                documentXml.Save(configPath);

            }
            catch (Exception ex)
            {
                Log.Error("money not found. Exception : " + ex.Message);
            }
        }

        public static void WriteMoneyInXml(string text)
        {
            string money = "ERR DIV NOT FOUND";

            try
            {

                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);
                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"h_finances\"]/div/small/span");

                foreach (HtmlNode link in collection)
                {
                    money = link.InnerText.Trim();
                }

                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);

                XmlNode projectNode = documentXml.SelectSingleNode("//root/currentTeam/money");
                projectNode.InnerText = money;

                documentXml.Save(configPath);

            }
            catch (Exception ex)
            {
                Log.Error("money not found. Exception : " + ex.Message);
            }
        }

        public static void WriteDivisionInXml(string text)
        {
            string division = "ERR DIV NOT FOUND";

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);
                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"h_classements\"]/div/b");

                foreach (HtmlNode link in collection)
                {
                    division = link.InnerText.Trim();
                }

                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);

                XmlNode projectNode = documentXml.SelectSingleNode("//root/currentTeam/division");
                projectNode.InnerText = division;

                documentXml.Save(configPath);

            }
            catch (Exception ex)
            {
                Log.Error("division not found. Exception : " + ex.Message);
            }
        }

        public static List<string> GetAllTeamsOwned()
        {
            List<string> teamIds = new List<string>();

            XmlDocument documentXml = new XmlDocument();
            string configPath = "config.xml";
            documentXml.Load(configPath);

            XmlNodeList projectNode = documentXml.SelectNodes("//root/teams/team/id");

            foreach (XmlNode item in projectNode)
            {
                teamIds.Add(item.InnerText);
            }

            return teamIds;
        }

        public static List<string> GetAllTeamOwnedNames()
        {
            List<string> teamIds = new List<string>();

            XmlDocument documentXml = new XmlDocument();
            string configPath = "config.xml";
            documentXml.Load(configPath);

            XmlNodeList projectNode = documentXml.SelectNodes("//root/teams/team/name");

            foreach (XmlNode item in projectNode)
            {
                teamIds.Add(item.InnerText);
            }

            return teamIds;
        }

        public static string GetCurrentChoicedTeam()
        {
            try
            {
                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);
                XmlNode nodeCurrentTeam = documentXml.SelectSingleNode("//root/currentTeam/number");
                //return int.Parse(nodeCurrentTeam.InnerText);
                return nodeCurrentTeam.InnerText;
            }
            catch (Exception ex)
            {
                Log.Error("config.xml is missing or corrupted. Read currentTeam failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
                //TO DO popup window error
                return "error";
            }
        }

        public static string GetCurrentDivision()
        {
            try
            {
                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);
                XmlNode nodeCurrentDivision = documentXml.SelectSingleNode("//root/currentTeam/division");
                return nodeCurrentDivision.InnerText;
            }
            catch (Exception ex)
            {
                Log.Error("config.xml is missing or corrupted. Read currentTeam failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
                //TO DO popup window error
                return "error";
            }
        }

        public static string GetCurrentMoney()
        {
            try
            {
                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);
                XmlNode nodeCurrentMoney = documentXml.SelectSingleNode("//root/currentTeam/money");
                return nodeCurrentMoney.InnerText;
            }
            catch (Exception ex)
            {
                Log.Error("config.xml is missing or corrupted. Read currentTeam failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
                //TO DO popup window error
                return "error";
            }
        }


        public static int FindBlocNoteContent(string text)
        {
            try
            {
                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);
                XmlNode nodeCurrentTeam = documentXml.SelectSingleNode("//textarea[@name=\"lebloc\"");
                return int.Parse(nodeCurrentTeam.InnerText);
            }
            catch (Exception ex)
            {
                Log.Error("config.xml is missing or corrupted. Read currentTeam failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
                //TO DO popup window error
                return -1;
            }
        }



     

        internal static VMMagazine FindVMMagazineContent(string text)
        {
            VMMagazine vmMagazine = new VMMagazine();
            Comment comment;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"division\"]/option");
                foreach (HtmlNode link in collection)
                {
                    vmMagazine.divisions.Add(link.InnerText);
                }

                collection = documenthtml.DocumentNode.SelectNodes("//tr/td/table/tr/td/small");
                foreach (HtmlNode link in collection)
                {
                    comment = new Comment();
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "b")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "a")
                                {
                                    foreach (var attri in link3.Attributes)
                                    {
                                        if (attri.Name == "href")
                                        {
                                            comment.idCourse = attri.Value.Split('=').Last();
                                            if(comment.nomCourse == null)
                                            {
                                                comment.nomCourse = link3.GetDirectInnerText();
                                            }
                                        }
                                    }
                                }
                            }
                            vmMagazine.comments.Add(comment);
                            comment = new Comment();
                        }

                        if (link2.Name == "a")
                        {
                            foreach (var attri2 in link2.Attributes)
                            {
                                if (attri2.Name == "href")
                                {
                                    if (attri2.Value.Contains("coureur"))
                                    {
                                        comment.idCoureur = attri2.Value.Split('=').Last();
                                        comment.nomCoureur = link2.GetDirectInnerText();
                                    }
                                    else if (attri2.Value.Contains("equipe"))
                                    {
                                        comment.idEquipe = attri2.Value.Split('=').Last();
                                    }
                                }
                            }
                            comment.nomEquipe = link2.GetDirectInnerText();
                        }
                    }
                    comment.commentaire = link.GetDirectInnerText();
                    vmMagazine.comments.Add(comment);
                    comment = new Comment();
                }

                return vmMagazine;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return vmMagazine;
        }

        internal static Recherche FindRecherche(string text)
        {
            Recherche recherche = new Recherche();


            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]/span");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "a")
                        {
                            foreach (var attribute in link2.Attributes)
                            {
                                if (attribute.Name == "href")
                                {
                                    if (attribute.Value.Contains("coureur"))
                                    {
                                        recherche.idCoureur.Add(attribute.Value.Split('=').Last());
                                        recherche.nomCoureur.Add(link2.InnerText);
                                    }
                                    else if (attribute.Value.Contains("equipe"))
                                    {
                                        recherche.idTeam.Add(attribute.Value.Split('=').Last());
                                        recherche.nomTeam.Add(link2.InnerText);
                                    }
                                }
                            }
                        }
                        else if (link2.Name == "img")
                        {
                            foreach (var attribute in link2.Attributes)
                            {
                                if (attribute.Name == "src")
                                {
                                    recherche.nomPays.Add(attribute.Value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("FindRecherche failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return recherche;
        }

        internal static List<Message> FindPageMessage(string text)
        {
            List<Message> messages = new List<Message>();
            Message message = new Message();


            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]/form/table");//
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "p")
                                        {
                                            message.comment=link3.InnerText;
                                        }

                                        else if (link3.Name == "a")
                                        {
                                            foreach (var attri in link3.Attributes)
                                            {
                                                if (attri.Name == "href")
                                                {
                                                    if (message.id == null)
                                                    {
                                                        message.id = attri.Value.Split('=').Last();
                                                    }
                                                    if (attri.Value.Contains("messagerie"))
                                                    {
                                                        if (message.managerName == null)
                                                        {
                                                            message.managerName = link3.InnerText;
                                                        }
                                                    }
                                                    else if (attri.Value.Contains("equipe"))
                                                    {
                                                        message.teamName = link3.InnerText;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (message.comment != null)
                            {
                                messages.Add(message);
                                message = new Message();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("FindPageMessageLegacy failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return messages;
        }

        internal static List<RechercheMessageConversation> FindPageMessageConversation(string text)
        {
            List<RechercheMessageConversation> rechercheList = new List<RechercheMessageConversation>();
            RechercheMessageConversation recherche = new RechercheMessageConversation();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]/div");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        foreach (var attri in link2.Attributes)
                        {
                            if (attri.Name == "style")
                            {
                                if (attri.Value.Contains("right"))
                                {
                                    recherche.right = true;
                                }
                                else
                                {
                                    recherche.right = false;
                                }
                            }
                        }
                        if (link2.Name == "div")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "small")
                                {
                                    recherche.date = link3.GetDirectInnerText();
                                }
                            }
                        }
                        recherche.message = link2.InnerText.Replace(recherche.date, "");
                        rechercheList.Add(recherche);
                        recherche = new RechercheMessageConversation();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("FindRecherche failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return rechercheList;
        }

        internal static Staff FindPageStaff(string text)
        {
            Staff staff = new Staff();
            Scout scout = new Scout();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"100%;max-width:450px;\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "tr")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (scout.jours == null && scout.id != null)
                                {
                                    scout.jours = link3.InnerText;
                                }
                                else
                                {
                                    scout.prix = link3.InnerText;
                                }

                                if (link3.Name == "td")
                                {
                                    foreach (HtmlNode link4 in link3.ChildNodes)
                                    {
                                        if (link4.Name == "a")
                                        {
                                            foreach (var attri in link4.Attributes)
                                            {
                                                if (attri.Name == "href")
                                                {
                                                    scout.id = attri.Value.Split('=').Last();
                                                    scout.nom = link4.GetDirectInnerText();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (scout.id != null)
                            {
                                staff.scouts.Add(scout);
                                scout = new Scout();
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"entraineur\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            staff.entraineur = link.InnerHtml;
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"dir_sportif\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            staff.dir_sportif = link.InnerHtml;
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"mecano\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            staff.mecano = link.InnerHtml;
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"medecin\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            staff.medecin = link.InnerHtml;
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"recruteur\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            staff.recruteur = link.InnerHtml;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("FindRecherche failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return staff;
        }

        internal static Materiel FindMateriel(string text)
        {
            Materiel materiel = new Materiel();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:500px;margin:0 auto;text-align:center;\"]/tr");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "td")
                        {
                            if (link2.InnerText.Contains("Niveau"))
                            {
                                if (materiel.cadre == null)
                                {
                                    materiel.cadre = link2.InnerText.Split(':').First().Replace("Niveau ",""); ;
                                }
                                else
                                {
                                    if (materiel.roues == null)
                                    {
                                        materiel.roues = link2.InnerText.Split(':').First().Replace("Niveau ", "");
                                    }
                                    else
                                    {
                                        if (materiel.casque == null)
                                        {
                                            materiel.casque = link2.InnerText.Split(':').First().Replace("Niveau ", "");
                                        }
                                        else
                                        {
                                            materiel.groupe = link2.InnerText.Split(':').First().Replace("Niveau ", "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return materiel;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return materiel;
        }

        internal static Entrainement FindEntrainement(string text)
        {
            Entrainement ent = new Entrainement();
            EntrainementCoureur entCour = new EntrainementCoureur();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"spe_entraineur\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            ent.spe1 = link.InnerHtml;
                        }
                    }
                }
                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"spe_entraineur2\"]/option");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attribute in link.Attributes)
                    {
                        if (attribute.Name == "selected")
                        {
                            ent.spe2 = link.InnerHtml;
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:500px;margin:0 auto;text-align:center;\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        foreach (var attri in link2.Attributes)
                        {
                            if (attri.Name == "class" && (attri.Value.Contains("pair") || attri.Value == "reserve"))
                            {
                                if (attri.Value == "reserve")
                                {
                                    entCour.reserve = true;
                                }

                                foreach (HtmlNode link3 in link2.ChildNodes)
                                {
                                    foreach (HtmlNode link4 in link3.ChildNodes)
                                    {
                                        if (link4.Name == "a")
                                        {
                                            foreach (var attrib in link4.Attributes)
                                            {
                                                if (attrib.Name == "href")
                                                {
                                                    entCour.id = attrib.Value.Split('=').Last();
                                                }
                                            }
                                            entCour.coureur = link4.InnerHtml;
                                        }
                                        else if (link4.Name == "small")
                                        {
                                            entCour.speCoureur = link4.InnerText;
                                        }
                                        else if (link4.Name == "select")
                                        {
                                            foreach (HtmlNode link5 in link4.ChildNodes)
                                            {
                                                foreach (var attribute in link5.Attributes)
                                                {
                                                    if (attribute.Name == "selected")
                                                    {
                                                        if (entCour.entrainement == null)
                                                        {
                                                            entCour.entrainement = link5.InnerHtml;
                                                        }
                                                        else
                                                        {
                                                            entCour.seuil = link5.InnerHtml;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (link4.InnerText.Contains("+"))
                                        {
                                            entCour.lastGainType = link4.InnerText.Split('+').First().Trim();
                                            entCour.lastGain = "+" + link4.InnerText.Split('+').Last().Trim();
                                        }
                                    }
                                }
                            }
                        }
                        if (entCour.coureur != null)
                        {
                            ent.entCoureur.Add(entCour);
                            entCour = new EntrainementCoureur();
                        }
                    }
                }
                return ent;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return ent;
        }

        internal static Stage FindStage(string text)
        {
            Stage stage = new Stage();
            StageCoureur stageCoureur = new StageCoureur();
            int cpt = 0;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//form[@action=\"?page=stage\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "a")
                        {
                            stageCoureur.nomCoureur = link2.InnerText;

                            foreach (var attri in link2.Attributes)
                            {
                                if (attri.Name == "href")
                                {
                                    stageCoureur.id = attri.Value.Split('=').Last();
                                }
                            }
                        }
                        else if (link2.Name == "select")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                foreach (var attri2 in link3.Attributes)
                                {
                                    if(attri2.Name == "value")
                                    {
                                        stageCoureur.possibilities.Add(link3.InnerText);
                                    }
                                }
                            }

                            if (stageCoureur.id != null)
                            {
                                stageCoureur.choice = link.GetDirectInnerText().Split(')')[cpt].Replace("(", "").Split(' ').Last();
                                cpt++;
                                stage.coureurs.Add(stageCoureur);
                                stageCoureur = new StageCoureur();
                            }
                        }


                    }

                    stageCoureur = new StageCoureur();
                }

                return stage;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return stage;
        }

        internal static Objectifs FindObjectifs(string text)
        {
            Objectifs objectifs = new Objectifs();
            string tempSelected = string.Empty;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//input[@name=\"objectif_eq\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attri in link.Attributes)
                    {
                        if (attri.Name == "value")
                        {
                            tempSelected = attri.Value;
                        }
                        else if (attri.Name == "checked")
                        {
                            objectifs.primaryChoice = tempSelected;
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//input[@name=\"objectif_sec\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (var attri in link.Attributes)
                    {
                        if (attri.Name == "value")
                        {
                            tempSelected = attri.Value;
                        }
                        else if (attri.Name == "checked")
                        {
                            objectifs.secondaryChoice = tempSelected;
                        }
                    }
                }

                return objectifs;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return objectifs;
        }

        internal static Forum1 FindForum1(string text)
        {
            Forum1 forum1 = new Forum1();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//td[@style=\"padding:7px;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                {
                        foreach (HtmlNode link2 in link.ChildNodes)
                        {
                            if (link2.Name == "a")
                            {
                                foreach (var attri in link2.Attributes)
                                {
                                    if (attri.Name == "href")
                                    {
                                        if (attri.Value.Contains("from"))
                                        {
                                            forum1.lien.Add(attri.Value);
                                            forum1.nom.Add(link2.InnerText);
                                        }
                                    }
                                }

                                foreach (HtmlNode link3 in link2.ChildNodes)
                                {
                                    if (link3.Name == "img")
                                    {
                                        foreach (var attri in link3.Attributes)
                                        {
                                            if (attri.Name == "src")
                                            {
                                                if (attri.Value == "icones/forum_unread2.gif")
                                                {
                                                    forum1.orange.Add(true);
                                                }
                                                else if(attri.Value.Contains("2"))
                                                {
                                                    forum1.orange.Add(false);
                                                }
                                            }
                                            else if(attri.Name != "title")
                                            {
                                                forum1.orange.Add(false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return forum1;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return forum1;
        }

        internal static Forum2 FindForum2(string text)
        {
            Forum2 forum2 = new Forum2();
            string maxPage = string.Empty;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"100%\"]");
                foreach (HtmlNode link00 in collection)
                {
                    foreach (HtmlNode link0 in link00.ChildNodes)
                    {
                        foreach (HtmlNode link in link0.ChildNodes)
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "b")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "a")
                                        {
                                            foreach (var attri2 in link3.Attributes)
                                            {
                                                if (attri2.Name == "href")
                                                {
                                                    if (attri2.Value.Contains("t=")) //&& (!(attri.Value.Contains("from"))))
                                                    {
                                                        forum2.lien.Add(attri2.Value);
                                                        forum2.nom.Add(link2.InnerText);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (link2.Name == "img")
                                {
                                    foreach (var attri in link2.Attributes)
                                    {
                                        if (attri.Name == "src")
                                        {
                                            if (attri.Value == "icones/forum_unread2.gif")
                                            {
                                                forum2.orange.Add(true);
                                            }
                                            else if (attri.Value.Contains("2"))
                                            {
                                                forum2.orange.Add(false);
                                            }
                                        }
                                    }
                                }
                                else if (link2.Name == "div")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "a")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "span")
                                                {
                                                    foreach (HtmlNode link5 in link4.ChildNodes)
                                                    {
                                                        if (link5.Name == "small")
                                                        {
                                                            maxPage = link5.InnerText;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    forum2.maxPage.Add(maxPage);
                                }
                            }
                        }
                    }
                }

                return forum2;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return forum2;
        }

        internal static Coureurs FindPageCoureurs(string text)
        {
            Coureurs coureurs = new Coureurs();
            Coureur coureur = new Coureur();
            string maxPage = string.Empty;
            string tempo = null;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//script");
                foreach (HtmlNode link in collection)
                {
                    if (link.InnerText.Contains("myChart"))
                    {
                        coureurs.canva = link.InnerText.Split('[')[3].Split(']')[0];
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]");
                try
                {
                    foreach (HtmlNode link in collection)
                    {
                        var s = link.InnerHtml.Replace("?page=club&id=", "£").Split('£').First().Replace("Manager :", "£").Split('£').Last();
                        if(!s.Replace("</b>", "£").Split('£').First().Replace("<b>", "£").Split('£').Last().Any(char.IsDigit))
                        {
                            coureurs.manager = s.Replace("</b>", "£").Split('£').First().Replace("<b>", "£").Split('£').Last();
                        }
                        coureurs.equipe = s.Replace("</b>", "£").Split('£')[1].Replace("<b>", "£").Split('£').Last();
                        coureurs.division = s.Replace("</b>", "£").Split('£')[2].Replace("<b>", "£").Split('£').Last();
                        coureurs.team = s.Replace("TEAM:", "£").Split('£').Last().Replace("----", "£").Split('£').First();
                        coureurs.mentor = s.Replace("\">", "£").Split('£').Last().Replace("</a>", "£").Split('£').First();
                        coureurs.langue = s.Replace("</b>", "£").Split('£')[3].Replace("<b>", "£").Split('£').Last();
                    }
                }
                catch (Exception)
                {

                }


                collection = documenthtml.DocumentNode.SelectNodes("//table");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "tr")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "td")
                                {
                                    foreach (var attri4 in link3.Attributes)
                                    {
                                        if (attri4.Name == "class" && attri4.Value.Contains(" smaller") && !link3.InnerHtml.Contains("span") && link3.ChildNodes.Count==0)
                                        {
                                            if (tempo == null)
                                            {
                                                tempo = link3.InnerText;
                                            }
                                            else
                                            {
                                                if (coureur.age == null)
                                                {
                                                    coureur.age = link3.InnerText;
                                                }
                                                else
                                                {
                                                    if (coureur.form == null)
                                                    {
                                                        coureur.form = link3.InnerText;
                                                    }
                                                    else
                                                    {
                                                        if (coureur.sante == null)
                                                        {
                                                            coureur.sante = link3.InnerText;
                                                        }
                                                        else
                                                        {
                                                            if (coureur.ucv == null)
                                                            {
                                                                coureur.ucv = link3.InnerText;
                                                            }
                                                            else
                                                            {
                                                                if (coureur.salaire == null)
                                                                {
                                                                    coureur.salaire = link3.InnerText;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (attri4.Name == "class" && link3.InnerText!=string.Empty)
                                            {
                                                if (coureur.nom == null)
                                                {
                                                    coureur.nom = link3.InnerText;
                                                }
                                                else
                                                {
                                                    if (coureur.age == null)
                                                    {
                                                        coureur.age = link3.InnerText;
                                                    }
                                                    else
                                                    {
                                                        if (coureur.ucv == null && !link3.InnerText.Contains(".") && link3.InnerText.Length < 4)
                                                        {
                                                            coureur.ucv = link3.InnerText;
                                                        }
                                                        else
                                                        {
                                                            if (coureur.salaire == null && !link3.InnerText.Contains("."))
                                                            {
                                                                coureur.salaire = link3.InnerText;
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                }
                                                foreach (var item in link3.ChildNodes)
                                                {
                                                    foreach (var attri in item.Attributes)
                                                    {
                                                        if (attri.Name == "src")
                                                        {
                                                            coureur.pays = attri.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    foreach (HtmlNode link4 in link3.ChildNodes)
                                    {
                                        if (link4.Name == "span")
                                        {
                                            foreach (var attri in link4.Attributes)
                                            {
                                                if (attri.Name == "class" && attri.Value == "big")
                                                {
                                                    if (coureur.form == null && link4.InnerText.Any(char.IsDigit))
                                                    {
                                                        coureur.form = link4.InnerText;
                                                    }
                                                    else if (coureur.sante == null && link4.InnerText.Any(char.IsDigit))
                                                    {
                                                        coureur.sante = link4.InnerText;
                                                    }


                                                    foreach (HtmlNode link5 in link4.ChildNodes)
                                                    {
                                                        if (link5.Name == "a")
                                                        {
                                                            coureur.nom = link5.InnerText;

                                                            foreach (var attri3 in link5.Attributes)
                                                            {
                                                                if (attri3.Name == "href")
                                                                {
                                                                    coureur.id = attri3.Value.Split('=').Last();
                                                                }
                                                            }

                                                            foreach (HtmlNode link6 in link5.ChildNodes)
                                                            {
                                                                if (link6.Name == "img")
                                                                {
                                                                    foreach (var attri2 in link6.Attributes)
                                                                    {
                                                                        if (attri2.Name == "src")
                                                                        {
                                                                            coureur.pays = attri2.Value;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (attri.Name == "class" && attri.Value.Contains("big"))
                                                {
                                                    if (coureur.pla == null)
                                                    {
                                                        coureur.pla = link4.InnerText;
                                                    }
                                                    else
                                                    {
                                                        if (coureur.mon == null)
                                                        {
                                                            coureur.mon = link4.InnerText;
                                                        }
                                                        else
                                                        {
                                                            if (coureur.des == null)
                                                            {
                                                                coureur.des = link4.InnerText;
                                                            }
                                                            else
                                                            {
                                                                if (coureur.val == null)
                                                                {
                                                                    coureur.val = link4.InnerText;
                                                                }
                                                                else
                                                                {
                                                                    if (coureur.pav == null)
                                                                    {
                                                                        coureur.pav = link4.InnerText;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (coureur.agi == null)
                                                                        {
                                                                            coureur.agi = link4.InnerText;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (coureur.clm == null)
                                                                            {
                                                                                coureur.clm = link4.InnerText;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (coureur.spr == null)
                                                                                {
                                                                                    coureur.spr = link4.InnerText;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (coureur.end == null)
                                                                                    {
                                                                                        coureur.end = link4.InnerText;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (coureur.res == null)
                                                                                        {
                                                                                            coureur.res = link4.InnerText;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (coureur.form == null)
                                                                                            {
                                                                                                coureur.form = link3.InnerText;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (coureur.sante == null)
                                                                                                {
                                                                                                    coureur.sante = link3.InnerText;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (attri.Name == "class")
                                                {
                                                    foreach (var item in link4.ChildNodes)
                                                    {
                                                        if (item.Name == "img")
                                                        {
                                                            foreach (var attri5 in item.Attributes)
                                                            {
                                                                if (attri5.Name == "src" && attri5.Value.EndsWith(".png"))
                                                                {
                                                                    coureur.champNat = attri5.Value;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (link4.Name == "img")
                                        {
                                            foreach (var attri7 in link4.Attributes)
                                            {
                                                if (attri7.Name == "src" && (attri7.Value.EndsWith(".gif")) && (!(attri7.Value.Contains("info"))))
                                                {
                                                    coureur.pays = attri7.Value;
                                                }
                                                if (attri7.Name == "src" && (attri7.Value.Contains("/m") && !attri7.Value.Contains("supercoupe") && !attri7.Value.Contains("selection")))
                                                {
                                                    coureur.champNat = attri7.Value;
                                                }
                                                if (attri7.Name == "src" && (attri7.Value.EndsWith(".png")) && !attri7.Value.Contains("info"))
                                                {
                                                    coureur.aVendre = attri7.Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (link2.InnerHtml.Contains("reserve"))
                            {
                                coureur.reserve = true;
                            }
                            if (coureur.pays != null && coureur.ucv!=null && coureur.age.Any(char.IsDigit))
                            {
                                coureurs.coureur.Add(coureur);
                            }
                            coureur = new Coureur();
                            tempo = null;
                        }
                    }
                }

                return coureurs;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return coureurs;
        }

        internal static CoureursSuivi FindPageVipCoureursSuivis(string text)
        {
            CoureursSuivi coureurs = new CoureursSuivi();
            CoureurSuivi coureur = new CoureurSuivi();
            string tempo2 = string.Empty;
            string tempo4 = string.Empty;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//tr[@class=\"\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (coureur.nom == null)
                        {
                            coureur.nom = link2.InnerText;
                        }
                        else
                        {
                            if (tempo2 == string.Empty)
                            {
                                tempo2 = "2";
                            }
                            else
                            {
                                if (coureur.age == null)
                                {
                                    coureur.age = link2.InnerText;
                                }
                                else
                                {
                                    if (coureur.nomEquipe == null)
                                    {
                                        coureur.nomEquipe = link2.InnerText;
                                    }
                                    else
                                    {
                                        coureur.aVendre = link2.InnerText == "Non" ? false : true;
                                    }
                                }
                            }
                        }

                        foreach (HtmlNode link3 in link2.ChildNodes)
                        {
                            if(link3.Name == "a")
                            {
                                foreach (var item in link3.Attributes)
                                {
                                    if (item.Name=="href")
                                    {
                                        if (item.Value.Contains("coureur"))
                                        {
                                            coureur.id = item.Value.Split('=').Last();
                                        }
                                        else
                                        {
                                            coureur.idTeam = item.Value.Split('=').Last();
                                        }
                                    }
                                }
                            }else if(link3.Name == "img")
                            {
                                foreach (var item in link3.Attributes)
                                {
                                    if (item.Name == "src")
                                    {
                                        coureur.pays = item.Value;
                                    }
                                }
                            }
                        }
                    }

                    coureurs.coureur.Add(coureur);
                    coureur = new CoureurSuivi();
                    tempo2 = string.Empty;
                    tempo4 = string.Empty;
                }


                return coureurs;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return coureurs;
        }

        internal static EquipesSuivi FindPageVipEquipesSuivies(string text)
        {
            EquipesSuivi equipes = new EquipesSuivi();
            EquipeSuivi equipe = new EquipeSuivi();
            string tempo2 = string.Empty;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//tr");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (equipe.nomEquipe==null)
                        {
                            equipe.nomEquipe = link2.InnerText;
                        }
                        else
                        {
                            if (tempo2 == string.Empty)
                            {
                                tempo2 = "2";
                            }
                            else
                            {
                                if (equipe.division==null)
                                {
                                    equipe.division = link2.InnerText;
                                }
                                else
                                {

                                    equipe.place = link2.InnerText;
                                }
                            }
                        }

                        foreach (HtmlNode link3 in link2.ChildNodes)
                        {
                            if (link3.Name == "a")
                            {
                                foreach (var item in link3.Attributes)
                                {
                                    if (item.Name == "href")
                                    {
                                        equipe.idTeam = item.Value.Split('=').Last();
                                    }
                                }
                            }
                        }
                    }
                    if (equipe.idTeam != null && equipe.place != null)
                    {
                        equipes.coureur.Add(equipe);
                    }
                    equipe = new EquipeSuivi();
                    tempo2 = string.Empty;
                }


                return equipes;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return equipes;
        }

        internal static VipSuivi FindPageVipSuivi(string text)
        {
            VipSuivi suivis = new VipSuivi();
            VipSuiviCoureur suivisCoureurs = new VipSuiviCoureur();
            VipSuiviCoureurLine line = new VipSuiviCoureurLine();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "table")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "tr")
                                {
                                    foreach (HtmlNode link4 in link3.ChildNodes)
                                    {
                                        if (link4.Name == "td")
                                        {
                                            if (link3.ChildNodes.Count == 1)
                                            {
                                                suivisCoureurs.nom = link3.InnerText;
                                            }
                                            else
                                            {
                                                if (line.c1 == null)
                                                {
                                                        line.c1 = link4.InnerHtml;
                                                }else
                                                {
                                                    if (line.c2 == null)
                                                    {
                                                        line.c2 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                    }
                                                    else
                                                    {
                                                        if (line.c3 == null)
                                                        {
                                                            line.c3 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                        }
                                                        else
                                                        {
                                                            if (line.c4 == null)
                                                            {
                                                                line.c4 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                            }
                                                            else
                                                            {
                                                                if (line.c5 == null)
                                                                {
                                                                    line.c5 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                }
                                                                else
                                                                {
                                                                    if (line.c6 == null)
                                                                    {
                                                                        line.c6 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (line.c7 == null)
                                                                        {
                                                                            line.c7 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (line.c8 == null)
                                                                            {
                                                                                line.c8 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (line.c9 == null)
                                                                                {
                                                                                    line.c9 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (line.c10 == null)
                                                                                    {
                                                                                        line.c10 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (line.c11 == null)
                                                                                        {
                                                                                            line.c11 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (line.c12 == null)
                                                                                            {
                                                                                                line.c12 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (line.c13 == null)
                                                                                                {
                                                                                                    line.c13 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    line.c14 = (link4.InnerHtml.Contains("negatif") ? "-" : "") + link4.InnerHtml;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                //tr
                                if (line.c1!=null)
                                {
                                    suivisCoureurs.line.Add(line);
                                }
                                line = new VipSuiviCoureurLine();
                            }
                        }
                        //table
                        if (suivisCoureurs.nom != null)
                        {
                            suivis.coureur.Add(suivisCoureurs);
                        }
                        suivisCoureurs = new VipSuiviCoureur();
                    }
                }


                return suivis;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return suivis;
        }

        internal static Club FindPageClub(string text)
        {
            Club club = new Club();
            Transaction transactionVente = new Transaction();
            Transaction transactionAchat = new Transaction();
            Historique historique = new Historique();
            string tempo1 = string.Empty;
            string tempo2 = string.Empty;
            bool end = false;
            bool vente = true;


            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"float:left;text-align:left; width:300px;\"]");
                foreach (HtmlNode link in collection)
                {
                    var s = link.InnerHtml.Replace("<img src=\"icones", "£").Split('£').First();

                    club.nomEquipe = s.Replace("</a>", "£").Split('£').First().Split('>').Last();
                    club.division = s.Replace("\">", "£").Split('£').Last().Split('<').First();
                    club.team = s.Replace("TEAM:", "£").Split('£').Last().Split('<').First();
                    club.victoires = s.Replace("<b>", "£").Split('£').Last().Split('<').First();
                    club.fans = s.Replace("Fans :", "£").Split('£').Last().Split('<').First();
                    club.lienMaillot = link.InnerHtml.Replace("value=\"https", "£https").Split('£').Last().Split('"').First(); ;
                }

                collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"float:left;width:100%;text-align:center; padding:5px;clear:both;\"]");
                foreach (HtmlNode link in collection)
                {
                    club.description = link.InnerHtml;///.Replace("</p>", "£").Split('£').First().Replace("<p>","£").Split('£').Last();
                }

                collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"100%\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        foreach (HtmlNode link3 in link2.ChildNodes)
                        {
                            if (tempo1 == string.Empty)
                            {
                                tempo1 = "1";
                            }
                            else
                            {
                                if (club.objectif1 == null)
                                {
                                    club.objectif1 = link3.InnerText;
                                }
                                else
                                {
                                    if (tempo2 == string.Empty)
                                    {
                                        tempo2 = "2";
                                    }
                                    else
                                    {
                                        if (club.objectif2 == null)
                                        {
                                            club.objectif2 = link3.InnerText;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"100%;\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "tr" && ! end)
                        {
                            if(link2.InnerHtml.Contains("Ancien manager"))
                            {
                                end = true;
                            }

                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "td" && link3.Attributes.Count == 0 && link3.InnerText.Any(char.IsDigit))
                                {
                                    if (historique.saison == null)
                                    {
                                        historique.saison = link3.InnerText;
                                    }
                                    else
                                    {
                                        if (historique.division == null)
                                        {
                                            historique.division = link3.InnerText;
                                        }
                                        else
                                        {
                                            historique.place = link3.InnerText;
                                        }
                                    }
                                }
                            }
                            if (historique.place!=null)
                            {
                                club.historique.Add(historique);
                                historique = new Historique();
                            }
                        }
                    }
                }


                collection = documenthtml.DocumentNode.SelectNodes("//td[@valign=\"top\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.Name == "small")
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "a")
                                {
                                    foreach (var attri in link3.Attributes)
                                    {
                                        if (attri.Name == "href")
                                        {
                                            if (attri.Value.Contains("coureur"))
                                            {
                                                if (vente)
                                                {
                                                    transactionVente.nomCoureur = link3.InnerText;
                                                    transactionVente.idCoureur = attri.Value.Split('=').Last();
                                                }
                                                else
                                                {
                                                    transactionAchat.nomCoureur = link3.InnerText;
                                                    transactionAchat.idCoureur = attri.Value.Split('=').Last();
                                                }
                                            }
                                            else if(attri.Value.Contains("equipe") && link3.InnerText.Any(char.IsDigit))
                                            {
                                                if (vente)
                                                {
                                                    transactionVente.prix = link3.InnerText;
                                                    transactionVente.idEquipe = attri.Value.Split('=').Last();
                                                }
                                                else
                                                {
                                                    transactionAchat.prix = link3.InnerText;
                                                    transactionAchat.idEquipe = attri.Value.Split('=').Last();
                                                }
                                            }
                                        }else if (attri.Name == "title")
                                        {
                                            if (vente)
                                            {
                                                transactionVente.nomEquipe = attri.Value;
                                            }
                                            else
                                            {
                                                transactionAchat.nomEquipe = attri.Value;
                                            }
                                        }
                                    }
                                }else if (link3.Name == "b" && link3.InnerText.Contains("Achats :"))
                                {
                                    vente = false;
                                }

                                if (transactionVente.prix!=null)
                                {
                                    club.transactionVente.Add(transactionVente);
                                    transactionVente = new Transaction();
                                }
                                else if(transactionAchat.prix != null)
                                {
                                    club.transactionAchat.Add(transactionAchat);
                                    transactionAchat = new Transaction();
                                }
                            }
                        }
                    }
                }


                return club;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return club;
        }

        internal static VipStats FindPageVipStatsSpe(string text)
        {
            VipStats stats = new VipStats();
            VipStatsCoureurs coureur = new VipStatsCoureurs();
            VipStatsEquipes equipe = new VipStatsEquipes();


            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:300px;height:250px;margin:5px 5px;float:left;\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        if (link2.InnerText.Contains("Montagne"))
                        {
                            stats.nbMontagne= link2.InnerText;
                        }else if (link2.InnerText.Contains("Plat"))
                        {
                            stats.nbPlat = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("Vallon"))
                        {
                            stats.nbVallon = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("Pav"))
                        {
                            stats.nbPave = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("Agilit"))
                        {
                            stats.nbAgilite = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("Descente"))
                        {
                            stats.nbDescente = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("CLM"))
                        {
                            stats.nbClm = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("Endurance"))
                        {
                            stats.nbEndurance = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("sistance"))
                        {
                            stats.nbResistance = link2.InnerText;
                        }
                        else if (link2.InnerText.Contains("Sprint"))
                        {
                            stats.nbSprint = link2.InnerText;
                        }

                        foreach (HtmlNode link3 in link2.ChildNodes)
                        {
                            foreach (HtmlNode link4 in link3.ChildNodes)
                            {
                                if (link4.Name == "a")
                                {
                                    equipe.nomEquipe = link4.InnerText;
                                    equipe.masseSalariale = link3.InnerText.Replace(link4.InnerText + " ", "");
                                    foreach (var attri in link4.Attributes)
                                    {
                                        if (attri.Name == "href")
                                        {
                                            equipe.idEquipe = attri.Value.Split('=').Last();
                                        }
                                    }
                                }
                                if (equipe.idEquipe != null)
                                {
                                    stats.equipes.Add(equipe);
                                }
                                equipe = new VipStatsEquipes();
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:300px;margin:5px 5px;float:left;\"]");
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {
                        foreach (HtmlNode link3 in link2.ChildNodes)
                        {
                            foreach (HtmlNode link4 in link3.ChildNodes)
                            {
                                foreach (var item in link4.Attributes)
                                {
                                    if (link4.Name == "a")
                                    {
                                        if (item.Name == "href" && item.Value.Contains("coureur"))
                                        {
                                            coureur.nomCoureur = link4.InnerText;
                                            coureur.idCoureur = item.Value.Split('=').Last();
                                        }
                                        else if (item.Name == "href" && item.Value.Contains("equipe"))
                                        {
                                            coureur.nomEquipe = link4.InnerText;
                                            coureur.age = link3.InnerText.Split(' ').Last().Replace("ans","");
                                            coureur.salaire = link3.InnerText.Replace(coureur.nomEquipe + ")", "£").Split('£').Last().Replace(coureur.age, "").Trim();
                                            coureur.idEquipe = item.Value.Split('=').Last();
                                        }
                                    }
                                    else if (link4.Name == "img")
                                    {
                                        if (item.Name == "src")
                                        {
                                            coureur.pays = item.Value;
                                        }
                                    }
                                }
                            }
                            if (coureur.pays != null)
                            {
                                if (coureur.idCoureur != null && coureur.idEquipe != null && stats.coureurs.Count<10)
                                {
                                    stats.coureurs.Add(coureur);
                                }
                            }

                            coureur = new VipStatsCoureurs();
                        }
                    }
                }


                return stats;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return stats;
        }

        internal static VipMedailles FindPageVipMedailles(string text)
        {
            VipMedailles stats = new VipMedailles();
            MedailleCoureur coureur = new MedailleCoureur();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"400px\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        foreach (HtmlNode link2 in link.ChildNodes)
                        {
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {
                                if (link3.Name == "b")
                                {
                                    foreach (HtmlNode link4 in link3.ChildNodes)
                                    {
                                        if (stats.type ==null)
                                        {
                                            stats.type = link4.InnerText;
                                        }
                                    }
                                }
                                else if (link3.Name == "a")
                                {
                                    foreach (var item in link3.Attributes)
                                    {
                                        if (item.Name == "href")
                                        {
                                            if (item.Value.Contains("equipe"))
                                            {
                                                coureur.idEquipe = item.Value.Split('=').Last();
                                                coureur.nomEquipe = link3.InnerText;
                                            }
                                            else if (item.Value.Contains("coureur"))
                                            {
                                                coureur.idCoureur = item.Value.Split('=').Last();
                                                coureur.nomCoureur = link3.InnerText;
                                            }
                                        }
                                    }
                                }
                                else if (link3.Name == "img")
                                {
                                    foreach (var item in link3.Attributes)
                                    {
                                        if (item.Name == "src")
                                        {
                                            coureur.pays = item.Value;
                                        }
                                    }
                                }
                            }
                            if (coureur.nomCoureur != null)
                            {
                                stats.coureurs.Add(coureur);
                            }
                            coureur = new MedailleCoureur();
                        }
                    }
                }


                return stats;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return stats;
        }

        internal static CoureurIndividual FindPageCoureur(string text)
        {
            CoureurIndividual coureur = new CoureurIndividual();
            Medaille medaille = new Medaille();
            ParcoursPro parcours = new ParcoursPro();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"padding-top:10px;border:0px;color:white;font-size:1.2em;text-shadow: black 0.1em 0.1em 0.3em, black -0.1em -0.1em 0.3em;font-weight:bold;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "img")
                        {
                            foreach (var item in link.Attributes)
                            {
                                if (item.Name == "src")
                                {
                                    coureur.age = link0.InnerText.Substring(3,2);
                                    coureur.pays = item.Value;
                                }
                            }
                        }
                        else if (link.Name == "a")
                        {
                            foreach (var item in link.Attributes)
                            {
                                if (item.Name=="href")
                                {
                                    if (item.Value.Contains("equipe"))
                                    {
                                        coureur.nomEquipe = link.InnerText;
                                        coureur.idEquipe = item.Value.Split('=').Last();
                                    }
                                    else if(item.Value.Contains("division"))
                                    {
                                        coureur.division = item.Value.Split('=').Last();
                                    }
                                }
                            }
                        }
                    }
                }

                try
                {
                    collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"clear:both;width:85%;margin:0 auto;padding:2px;display:block; color:white;font-size:1.4em;font-weight:bold;text-transform:uppercase;text-shadow: black 0.05em 0.05em 0.1em;\"]");
                    foreach (HtmlNode link0 in collection)
                    {
                        foreach (HtmlNode link in link0.ChildNodes)
                        {
                            if (link.Name == "div")
                            {
                                string[] e = (link.InnerText + "£££").Replace("\n", "").Replace("\t", "").Split(' ');
                                if (coureur.pla == null)
                                {
                                    coureur.pla = e[1].Substring(0, e[1].Length - 3);
                                    coureur.des = e[2].Substring(0, e[1].Length - 3);
                                    coureur.pav = e[3].Substring(0, e[1].Length - 3);
                                    coureur.clm = e[4].Substring(0, e[1].Length - 3);
                                    coureur.end = e[5].Substring(0, e[1].Length - 3);
                                }
                                else
                                {
                                    coureur.mon = e[1].Substring(0, e[1].Length - 3);
                                    coureur.val = e[2].Substring(0, e[1].Length - 3);
                                    coureur.agi = e[3].Substring(0, e[1].Length - 3);
                                    coureur.spr = e[4].Substring(0, e[1].Length - 3);
                                    coureur.res = e[5].Substring(0, e[1].Length - 3);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }

                
                collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;text-align:center;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {//tr
                        foreach (HtmlNode link2 in link.ChildNodes)
                        {//td
                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {//big
                                foreach (HtmlNode link4 in link3.ChildNodes)
                                {//b
                                    if (link4.Name == "b")
                                    {
                                        coureur.nom = link.InnerText;
                                    }
                                }
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"display:inline-block;vertical-align:top;min-width:200px;margin:10px 5px;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    if (coureur.salaire == null)
                    {
                        coureur.salaire = link0.InnerText.Replace("Salaire : ", "£").Split('£').Last().Split('€').First();
                    }
                    foreach (HtmlNode link in link0.ChildNodes)
                    {//tr
                        if (link.Name=="a")
                        {
                            foreach (var item in link.Attributes)
                            {
                                if (item.Name == "href" && item.Value.Contains("suivi"))
                                {
                                    coureur.surveille = item.Value.Split('=').Last() == "non" ? true : false;
                                }

                                if(coureur.salaire == null)
                                {
                                    coureur.salaire = link0.InnerText.Replace("Salaire: ", "£").Split('£').Last().Split('€').First();
                                }

                                coureur.valeur = link0.InnerText.Replace("Valeur: ", "£").Split('£').Last().Split('€').First();
                                if (coureur.valeur.Contains(":"))
                                {
                                    coureur.valeur = null;
                                }

                                try
                                {
                                    coureur.prix = link0.InnerText.Replace("Prix de départ: ", "£").Split('£').Last().Split('€').First();
                                    coureur.jours = link0.InnerText.Replace("Jours Restants:", "£").Split('£').Last().Replace("Nombre d", "£").Split('£').First();
                                    coureur.nbEnchere = link0.InnerText.Replace("Nombre d'enchère(s) sur le coureur :", "£").Split('£').Last().Replace("Annuler la vent", "£").Split('£').First();
                                    if (coureur.jours.Length>1)
                                    {
                                        coureur.prix = null;
                                        coureur.jours = null;
                                        coureur.nbEnchere = null;
                                    }
                                }
                                catch (Exception) { }
                            }
                        }else if (link.Name == "form")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                foreach (var attri2 in link2.Attributes)
                                {
                                    if (attri2.Name == "href" && attri2.Value.Contains("suivi"))
                                    {
                                        coureur.surveille = attri2.Value.Split('=').Last() == "non" ? true : false;
                                    }
                                }
                            }
                        }
                    }
                }

                try
                {
                    collection = documenthtml.DocumentNode.SelectNodes("//textarea[@name=\"description\"]");
                    foreach (HtmlNode link0 in collection)
                    {
                        coureur.description = link0.InnerText;
                    }
                }
                catch (Exception)
                {

                }

                collection = documenthtml.DocumentNode.SelectNodes("//div[@align=\"center\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {//tr
                        if (link.Name == "img")
                        {
                            foreach (var item in link.Attributes)
                            {
                                if (item.Name == "src")
                                {
                                    coureur.champNat = item.Value;
                                }
                            }
                        }
                        else if (link.Name == "b" && coureur.nbCourses==null)
                        {
                            coureur.nbCourses = link.InnerText;
                        }
                    }
                }
               
                collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"100%\"]");
                foreach (HtmlNode link0 in collection)
                {
                    if (link0.Attributes.Count==4)
                    {
                        foreach (HtmlNode link in link0.ChildNodes)
                        {//tr
                            if (link.Name == "tr")
                            {
                                foreach (HtmlNode link2 in link.ChildNodes)
                                {//tr
                                    if (link2.Name == "td")
                                    {
                                        if (link2.InnerText.Contains(" en herbe"))
                                        {
                                            coureur.spe = link2.InnerText.Replace("Spécialité", "£").Split('£').Last().Replace(" en herbe", "£").Split('£').First();
                                        }


                                        foreach (HtmlNode link3 in link2.ChildNodes)
                                        {//tr
                                            if (link3.Name == "a")
                                            {
                                                foreach (HtmlNode link4 in link3.ChildNodes)
                                                {//tr
                                                    if (link4.Name == "img")
                                                    {
                                                        foreach (var item in link4.Attributes)/////table/tr[4]/td
                                                        {
                                                            if (item.Name == "src" && ! item.Value.Contains("Tour"))
                                                            {
                                                                medaille.lien = item.Value;
                                                                coureur.medailles.Add(medaille);
                                                                medaille = new Medaille();
                                                            }else if (item.Name == "title" && coureur.spe==null)
                                                            {
                                                                coureur.spe = item.Value.Split(' ').First();
                                                            }
                                                        }
                                                    }
                                                }

                                                if (link3.Attributes.Count ==2) 
                                                {                                                
                                                    foreach (var attri in link3.Attributes)
                                                    {
                                                        if (attri.Name == "href" && attri.Value.Contains("equipe"))
                                                        {
                                                            parcours.idEquipe = attri.Value.Split('=').Last();
                                                            parcours.nomEquipe = link3.InnerText;

                                                        }
                                                        else if (attri.Name == "title")
                                                        {
                                                            parcours.prix = attri.Value;
                                                            parcours.saison = link2.InnerHtml.Replace("<br>","£").Split('£')[coureur.parcours.Count].Split(')').First().Split('(').Last();
                                                            if (parcours.saison.Length!=3)
                                                            {
                                                                parcours.saison = "";
                                                            }
                                                        }
                                                    }
                                                }
                                            }else if (link3.Name == "small")
                                            {
                                                coureur.ucv = link.InnerHtml.Replace("<small>Points UCV</small>:", "£").Split('£').Last().Replace("<br>","£").Split('£').First();
                                            }
                                            if (parcours.prix != null)
                                            {
                                                coureur.parcours.Add(parcours);
                                                parcours = new ParcoursPro();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"display:inline-block;min-width:300px;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link1 in link0.ChildNodes)
                    {
                        foreach (var attri in link1.Attributes)
                        {
                            if (attri.Name=="style" && coureur.couleurCarte == null)
                            {
                                coureur.couleurCarte = attri.Value.Split(')').First().Split('(').Last();
                            }
                        }
                    }
                }

                return coureur;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return coureur;
        }

        internal static List<ClassementsEquipe> FindPageClassementsEquipe(string text)
        {
            List<ClassementsEquipe> classement = new List<ClassementsEquipe>();
            ClassementsEquipe equipe = new ClassementsEquipe();
            string tempo1 = string.Empty;
            string tempo2 = string.Empty;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"text-align:center;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {//tr
                        foreach (HtmlNode link2 in link.ChildNodes)
                        {//td
                            if (tempo1 == string.Empty)
                            {
                                tempo1 = link2.InnerText;
                            }
                            else
                            {
                                if (tempo2 == string.Empty)
                                {
                                    tempo2 = link2.InnerText;
                                }
                                else
                                {
                                    if (equipe.points == null && link2.InnerText.Trim().All(char.IsDigit) && link2.InnerText!=string.Empty)
                                    {
                                        equipe.points = link2.InnerText.Trim();
                                    }
                                    else
                                    {
                                        if (equipe.victoires == null && link2.InnerText.Trim().All(char.IsDigit) && link2.InnerText != string.Empty)
                                        {
                                            equipe.victoires = link2.InnerText;
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }

                            foreach (HtmlNode link3 in link2.ChildNodes)
                            {//
                                if (link3.Name == "a")
                                {
                                    foreach (var item in link3.Attributes)
                                    {
                                        if (item.Name == "href" && item.Value.Contains("equipe"))
                                        {
                                            equipe.idEquipe = item.Value.Split('=').Last();
                                            equipe.nomEquipe = link3.InnerText;
                                        }
                                    }
                                }
                                else if (link3.Name == "img")
                                {
                                    foreach (var item in link3.Attributes)
                                    {
                                        if (item.Name == "src" && !(item.Value.Any(char.IsDigit) && equipe.pays!=null))
                                        {
                                            equipe.pays = item.Value;
                                        }
                                    }
                                }
                            }
                        }
                        if (equipe.pays != null && equipe.victoires!=null)
                        {
                            classement.Add(equipe);
                        }
                        equipe = new ClassementsEquipe();
                        tempo1 = string.Empty;
                        tempo2 = string.Empty;
                    }
                }


                return classement;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return classement;
        }

        internal static List<Calendrier> FindPageCalendrier(string text)
        {
            Calendrier calendrier = new Calendrier();
            List<Calendrier> calendriers = new List<Calendrier>();
            string tempoIdTour=string.Empty;
            string tempoNomTour = string.Empty;
            DateTime dt = DateTime.Now;

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]");//*[@id="leftmain"]/p/a[5]
                foreach (HtmlNode link in collection)
                {
                    foreach (HtmlNode link2 in link.ChildNodes)
                    {//p
                        foreach (HtmlNode link3 in link2.ChildNodes)
                        {//b 
                            if (link3.Name == "b")
                            {
                                calendrier.idTour = string.Empty;
                                calendrier.nomTour = string.Empty;
                                calendrier.registered = string.Empty;

                                if (calendrier.nom == null)
                                {
                                    if (link3.InnerText.Contains("Bis"))
                                    {
                                        calendrier.typeCourse = "bis";
                                    }
                                    calendrier.nom = link3.InnerText.Split('(').First().Split('°').Last().Replace(link3.InnerText.Split('(').First().Split('°').Last().Split(' ').First(), "").Trim();
                                    calendrier.distance = link3.InnerText.Split(')').First().Split('(').Last().Replace("km","");
                                    try
                                    {
                                        calendrier.date = DateTime.Parse(link3.InnerText.Trim().Split(')').Last().Trim());
                                    }
                                    catch (Exception) { }
                                }

                                foreach (HtmlNode link4 in link3.ChildNodes)
                                {
                                    if (link4.Name == "img")
                                    {
                                        foreach (var item in link4.Attributes)
                                        {
                                            if (item.Name == "src" && !item.Value.Contains("courses") && !item.Value.Contains("valide"))
                                            {
                                                calendrier.typeCourse = item.Value;
                                            }
                                            else if (item.Name == "src" && item.Value.Contains("courses") && calendrier.image == null)
                                            {
                                                calendrier.image = item.Value;
                                            }
                                            else if (item.Name == "src" && item.Value.Contains("valide.png") && calendrier.registered != "true")
                                            {
                                                calendrier.registered = "true";
                                            }
                                        }
                                    }
                                    else if (link4.Name == "a")
                                    {
                                        foreach (var item in link4.Attributes)
                                        {
                                            if (item.Name == "href")
                                            {
                                                if (calendrier.idTour==null && (calendrier.idTour.Contains("tour")))
                                                {
                                                    calendrier.idTour = item.Value.Split('=').Last();
                                                }else if (calendrier.idCourse == null && item.Value.Split('=').Last().Any(char.IsDigit) && (item.Value.Contains("etape") || item.Value.Contains("eng_course")))
                                                {
                                                    calendrier.idCourse = item.Value.Split('=').Last();
                                                }

                                                if (link4.InnerText.Contains(")"))
                                                {
                                                    if (link3.InnerText.Contains("Bis"))
                                                    {
                                                        calendrier.typeCourse = "bis";
                                                    }
                                                    calendrier.nom = link4.InnerText.Split('(').First().Split('°').Last().Replace(link4.InnerText.Split('(').First().Split('°').Last().Split(' ').First(), "").Trim();
                                                    calendrier.distance = link4.InnerText.Split(')').First().Split('(').Last().Replace("km", "");
                                                    try
                                                    {
                                                        calendrier.date = DateTime.Parse(link4.InnerText.Trim().Split(')').Last().Trim());
                                                    }
                                                    catch (Exception) { }
                                                }
                                                else
                                                {
                                                    //calendrier.nom = link4.InnerText;
                                                }


                                                foreach (HtmlNode link5 in link4.ChildNodes)
                                                {
                                                    if (link5.Name == "img")
                                                    {
                                                        foreach (var item2 in link5.Attributes)
                                                        {
                                                            if (item2.Name == "src" && item2.Value == "icones/valide.png")
                                                            {
                                                                calendrier.registered = "true";
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        foreach (var link5 in link4.ChildNodes)
                                        {
                                            if (link5.Name=="img")
                                            {
                                                foreach (var item in link5.Attributes)
                                                {
                                                    if (item.Value.Contains("info.png"))
                                                    {
                                                        foreach (var item2 in link4.Attributes)
                                                        {
                                                            if (item2.Name=="href" && item2.Value.Split('=').Last().Any(char.IsDigit))
                                                            {
                                                                calendrier.idCourse = item2.Value.Split('=').Last();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (link3.Name == "a")
                            {
                                if (link3.InnerText.Length>10 && !link3.InnerText.Contains("Liste des"))
                                {
                                    calendrier.nom = link3.InnerText.Substring(0, link3.InnerText.Length - 11);
                                    try
                                    {
                                        calendrier.date = DateTime.Parse(link3.InnerText.Substring(0, link3.InnerText.Length - 1).Split(' ').Last().Trim());
                                    }
                                    catch (Exception) { }
                                }

                                foreach (var item in link3.Attributes)
                                {
                                    if (item.Name=="href" && item.Value.Contains("tour"))
                                    {
                                        calendrier.idTour = item.Value.Split('=').Last();
                                        calendrier.nomTour = link3.InnerText;
                                    }
                                    else if (item.Name == "href" && item.Value.Replace("id=", "£").Split('£').Last().Split('&').First().Any(char.IsDigit) && (item.Value.Contains("eng_course") || item.Value.Contains("tactique")))
                                    {
                                        calendrier.idCourse = item.Value.Replace("id=","£").Split('£').Last().Split('&').First();
                                    }
                                }
                            }else if (link3.Name == "img")
                            {
                                foreach (var attri in link3.Attributes)
                                {
                                    if (attri.Name == "src" && attri.Value.Contains("courses") && calendrier.image==null)
                                    {
                                        calendrier.image = attri.Value;
                                    }
                                    else if (attri.Name == "src" && attri.Value == "icones/valide.png")
                                    {
                                        calendrier.registered = "true";
                                    }
                                }
                            }

                            if (calendrier.nom != null && calendrier.date != null && calendrier.idCourse!=null)//&& calendrier.image != null
                            {
                                calendriers.Add(calendrier);
                                if (calendrier.idTour!=null)
                                {
                                    var id = calendrier.idTour;
                                    var nom = calendrier.nomTour;
                                    var registered = calendrier.registered;
                                    calendrier = new Calendrier();
                                    calendrier.idTour = id;
                                    calendrier.nomTour = nom;
                                    calendrier.registered = registered;
                                }
                                else
                                {
                                    calendrier = new Calendrier();
                                }
                            }
                            if (calendrier.idTour == null)
                            {
                                calendrier = new Calendrier();
                            }
                        }
                    }
                }

                return calendriers;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return calendriers;
        }

        internal static List<Transfert> FindPageTranferts(string text)
        {
            List<Transfert> transferts = new List<Transfert>();
            Transfert transfert = new Transfert();
           

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"text-align:center;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if(link.Name=="tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    if (link2.InnerText.Any(char.IsDigit) && transfert.age == null)
                                    {
                                        transfert.age = link2.InnerText;
                                    }

                                    if (transfert.res != null && link2.InnerText.Any(char.IsDigit))
                                    {
                                        if (transfert.prix == null)
                                        {
                                            transfert.prix = link2.InnerText.Substring(0, link2.InnerText.Length - 1);
                                        }
                                        else
                                        {
                                            if (transfert.salaire == null)
                                            {
                                                transfert.salaire = link2.InnerText;
                                            }
                                            else
                                            {
                                                if (transfert.jours == null)
                                                {
                                                    transfert.jours = link2.InnerText;
                                                }
                                                else
                                                {

                                                }
                                            }
                                        }
                                    }


                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "small")
                                        {
                                            if (link2.InnerText.Any(char.IsDigit))
                                            {
                                                if (transfert.pla == null)
                                                {
                                                    transfert.pla = link2.InnerText;
                                                }
                                                else
                                                {
                                                    if (transfert.mon == null)
                                                    {
                                                        transfert.mon = link2.InnerText;
                                                    }
                                                    else
                                                    {
                                                        if (transfert.des == null)
                                                        {
                                                            transfert.des = link2.InnerText;
                                                        }
                                                        else
                                                        {
                                                            if (transfert.val == null)
                                                            {
                                                                transfert.val = link2.InnerText;
                                                            }
                                                            else
                                                            {
                                                                if (transfert.pav == null)
                                                                {
                                                                    transfert.pav = link2.InnerText;
                                                                }
                                                                else
                                                                {
                                                                    if (transfert.agi == null)
                                                                    {
                                                                        transfert.agi = link2.InnerText;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (transfert.clm == null)
                                                                        {
                                                                            transfert.clm = link2.InnerText;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (transfert.spr == null)
                                                                            {
                                                                                transfert.spr = link2.InnerText;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (transfert.end == null)
                                                                                {
                                                                                    transfert.end = link2.InnerText;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (transfert.res == null)
                                                                                    {
                                                                                        transfert.res = link2.InnerText;
                                                                                    }
                                                                                    else
                                                                                    {

                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "a")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Name=="href")
                                                        {
                                                            transfert.nom = link4.InnerText;
                                                            transfert.id = item.Value.Split('=').Last();
                                                        }
                                                    }

                                                    foreach (HtmlNode link5 in link4.ChildNodes)
                                                    {
                                                        if (link5.Name == "img")
                                                        {
                                                            foreach (var item2 in link5.Attributes)
                                                            {
                                                                if (item2.Name == "src")
                                                                {
                                                                    transfert.pays = item2.Value.Split('=').Last();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (transfert.jours!=null)
                            {
                                transferts.Add(transfert);
                            }
                            transfert = new Transfert();
                        }
                    }
                }


                return transferts;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return transferts;
        }

        internal static List<TransfertDaily> FindPageTranfertsDaily(string text)
        {
            List<TransfertDaily> transferts = new List<TransfertDaily>();
            TransfertDaily transfert = new TransfertDaily();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:600px;margin:0 auto;text-align:center;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    if (transfert.nomCoureur != null && transfert.age == null)
                                    {
                                        transfert.age = link2.InnerText;
                                    }

                                    if (transfert.idEquipeAcheteur != null && transfert.prix == null)
                                    {
                                        transfert.prix = link2.InnerText;
                                    }

                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "a")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "href")
                                                {
                                                    if (item.Value.Contains("coureur"))
                                                    {
                                                        transfert.idCoureur = item.Value.Split('=').Last();
                                                        transfert.nomCoureur = link3.InnerText;
                                                    }else if (item.Value.Contains("equipe"))
                                                    {
                                                        if (transfert.nomEquipeVendeur == null)
                                                        {
                                                            transfert.nomEquipeVendeur = link3.InnerText;
                                                            transfert.idEquipeVendeur = item.Value.Split('=').Last();
                                                        }
                                                        else
                                                        {
                                                            transfert.nomEquipeAcheteur = link3.InnerText;
                                                            transfert.idEquipeAcheteur = item.Value.Split('=').Last();
                                                        }
                                                    }
                                                }
                                            }
                                        }else if (link3.Name == "img")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "src")
                                                {
                                                    transfert.pays = item.Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (transfert.prix != null)
                            {
                                transferts.Add(transfert);
                            }
                            transfert = new TransfertDaily();
                        }
                    }
                }

                return transferts;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return transferts;
        }


        internal static List<TransfertJuniors> FindPageTranfertsJuniors(string text)
        {
            List<TransfertJuniors> transferts = new List<TransfertJuniors>();
            TransfertJuniors transfert = new TransfertJuniors();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);
                                                                                       
                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:580px;margin:0 auto;text-align:center;\"]");//580
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    if (link2.InnerHtml.Length > 0)
                                    {
                                        transfert.prix = link2.InnerHtml.Substring(0, link2.InnerHtml.Length - 1);
                                    }

                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "a")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "href")
                                                {
                                                    if (item.Value.Contains("coureur"))
                                                    {
                                                        transfert.idCoureur = item.Value.Split('=').Last();
                                                        transfert.nomCoureur = link3.InnerText.Trim();
                                                    }
                                                    else if (item.Value.Contains("equipe"))
                                                    {
                                                        transfert.nomEquipe = link3.InnerText;
                                                        transfert.idEquipe = item.Value.Split('=').Last();
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "img")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "src")
                                                {
                                                    transfert.pays = item.Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (transfert.nomCoureur != null && transfert.nomCoureur != string.Empty)
                            {
                                transferts.Add(transfert);
                            }
                            transfert = new TransfertJuniors();
                        }
                    }
                }

                return transferts;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return transferts;
        }

        internal static Resultats FindPageResultats(string text)
        {
            Resultats resultat = new Resultats();
            ResultatsCoureur resultatsCoureurs = new ResultatsCoureur();
            ResultatsEquipe resultatsEquipes = new ResultatsEquipe();
            ResultatsCoursesDispos resultatsCoursesDispos = new ResultatsCoursesDispos();
            

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:600px;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "img")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "src")
                                                {
                                                    if (item.Value.Contains("courses"))
                                                    {
                                                        resultat.image = item.Value; //*[@id="leftmain"]/div[1]/table/tbody/tr/td[2]/img
                                                    }
                                                    else
                                                    {
                                                        if (resultat.meteo == null)
                                                        {
                                                            resultat.meteo = item.Value;
                                                        }
                                                        else if (resultat.ventDirection == null)
                                                        {
                                                            resultat.ventDirection = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "b")
                                        {
                                            if (resultat.vent == null)
                                            {
                                                resultat.vent = link3.InnerText;
                                            }
                                        }
                                        else if (link3.Name == "a")
                                        {
                                            if (resultat.nom == null)
                                            {
                                                resultat.nom = link3.InnerText;
                                            }

                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "href")
                                                {
                                                    if (item.Value.Contains("sultats") && resultat.id == null)
                                                    {
                                                        resultat.id = item.Value.Split('=').Last();
                                                    }
                                                }
                                            }

                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "img")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Name == "src" && resultat.pays == null)
                                                        {
                                                            resultat.pays = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "small")
                                        {
                                            resultat.km = link3.InnerText.Replace("(","").Replace(")","");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                try
                {
                    collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"background-color:white;margin:0 auto;\"]");
                    foreach (HtmlNode link0 in collection)
                    {
                        foreach (HtmlNode link in link0.ChildNodes)
                        {
                            if (link.Name == "tr")
                            {
                                foreach (HtmlNode link2 in link.ChildNodes)
                                {
                                    if (link2.Name == "td")
                                    {
                                        foreach (HtmlNode link3 in link2.ChildNodes)
                                        {
                                            if (link3.Name == "a")
                                            {
                                                foreach (var item2 in link3.Attributes)
                                                {
                                                    if (item2.Name == "href" && item2.Value.Contains("coureur"))
                                                    {
                                                        resultatsCoureurs.idCoureur = item2.Value.Split('=').Last();
                                                        resultatsCoureurs.nomCoureur = link3.InnerText;
                                                    }
                                                }

                                                foreach (HtmlNode link4 in link3.ChildNodes)
                                                {
                                                    if (link4.Name == "img")
                                                    {
                                                        foreach (var item in link4.Attributes)
                                                        {
                                                            if (item.Name == "src")
                                                            {
                                                                resultatsCoureurs.pays = item.Value;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if (link3.Name == "span")
                                            {
                                                foreach (HtmlNode link4 in link3.ChildNodes)
                                                {
                                                    if (link4.Name == "a")
                                                    {
                                                        foreach (var item in link4.Attributes)
                                                        {
                                                            if (item.Name == "href")
                                                            {
                                                                resultatsCoureurs.idEquipe = item.Value.Split('=').Last();
                                                                resultatsCoureurs.nomEquipe = link4.InnerText;
                                                            }
                                                        }
                                                    }
                                                }

                                                foreach (var item in link3.Attributes)
                                                {
                                                    if (item.Name == "class" && item.Value == "big")
                                                    {
                                                        if (resultatsCoureurs.points == null)
                                                        {
                                                            resultatsCoureurs.points = link3.InnerText;
                                                        }
                                                        else
                                                        {
                                                            if (resultatsCoureurs.prix == null)
                                                            {
                                                                resultatsCoureurs.prix = link3.InnerText;
                                                            }
                                                            else
                                                            {
                                                                if (resultatsCoureurs.prix == null)
                                                                {
                                                                    resultatsCoureurs.points = link3.InnerText;
                                                                }
                                                                else
                                                                {

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if (link3.Name == "img")
                                            {
                                                foreach (var item in link3.Attributes)
                                                {
                                                    if (item.Name == "src")
                                                    {
                                                        if (item.Value.Contains("pmu"))
                                                        {
                                                            resultatsCoureurs.sprint = item.Value;
                                                        }
                                                        else if (item.Value.Contains("relayer"))
                                                        {
                                                            resultatsCoureurs.rouler = item.Value;
                                                        }
                                                        else if (item.Value.Contains("attaque"))
                                                        {
                                                            resultatsCoureurs.attaque = item.Value;
                                                        }
                                                        else if (item.Value.Contains("chute"))
                                                        {
                                                            resultatsCoureurs.chute = item.Value;
                                                        }
                                                        else if (item.Value.Contains("crevaison"))
                                                        {
                                                            resultatsCoureurs.crevaison = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (link3.Name == "small")
                                            {
                                                if (resultatsCoureurs.temps == null)
                                                {
                                                    resultatsCoureurs.temps = link3.InnerText;
                                                }
                                                if (link3.InnerText.Contains("U22"))
                                                {
                                                    resultatsCoureurs.junior = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (resultatsCoureurs.prix != null)
                                {
                                    resultat.resultatsCoureurs.Add(resultatsCoureurs);
                                }
                                resultatsCoureurs = new ResultatsCoureur();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }


                collection = documenthtml.DocumentNode.SelectNodes("//div[@id=\"leftmain\"]");
                foreach (HtmlNode link00 in collection)
                {//div
                    foreach (HtmlNode link0 in link00.ChildNodes)
                    {//div
                        foreach (HtmlNode link in link0.ChildNodes)
                        {//table
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {//tr
                                foreach (HtmlNode link3 in link2.ChildNodes)
                                {//td
                                    foreach (HtmlNode link4 in link3.ChildNodes)
                                    {//a
                                        if (link4.Name=="a")
                                        {
                                            foreach (var item in link4.Attributes)
                                            {
                                                if (item.Name == "href" && item.Value.Contains("equipe"))
                                                {
                                                    resultatsEquipes.idEquipe = item.Value.Split('=').Last();
                                                    resultatsEquipes.nomEquipe = link4.InnerText;
                                                    resultatsEquipes.points = link3.InnerText.Split('€').Last().Replace("pts","£").Split('£')[resultat.resultatsEquipes.Count].Replace(" : ", "£").Split('£').Last();
                                                }
                                            }
                                        }

                                        if (resultatsEquipes.nomEquipe != null)
                                        {
                                            resultat.resultatsEquipes.Add(resultatsEquipes);
                                        }
                                        resultatsEquipes = new ResultatsEquipe();
                                    }
                                }
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//select[@name=\"id\"]");
                foreach (HtmlNode link00 in collection)
                {//div
                    foreach (HtmlNode link in link00.ChildNodes)
                    {//div
                        if (link.Name=="option")
                        {
                            foreach (var item in link.Attributes)
                            {
                                if (item.Name == "value")
                                {
                                    resultatsCoursesDispos.id = item.Value;
                                    resultatsCoursesDispos.nom = link.InnerText;
                                }
                            }
                            resultat.resultatsCoursesDispos.Add(resultatsCoursesDispos);
                            resultatsCoursesDispos = new ResultatsCoursesDispos();
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//div[@style=\"float:left;width:100%;text-align:center;\"]");
                foreach (HtmlNode link00 in collection)
                {//div
                    resultat.date = DateTime.Parse(link00.InnerHtml.Replace("<br>", "£").Split('£').First().Replace(") - ", "£").Split('£').Last());
                }

                return resultat;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return resultat;
        }

        internal static Tactique FindPageTactique(string text)
        {
            Tactique tactique = new Tactique();
            Recuperation recuperation = new Recuperation();
            TactiqueIndividuelle tactiqueIndividuelle = new TactiqueIndividuelle();
            Sprinteur sprinteur = new Sprinteur();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:600px;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "img")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "src")
                                                {
                                                    if (item.Value.Contains("courses"))
                                                    {
                                                        tactique.image = item.Value; //*[@id="leftmain"]/div[1]/table/tbody/tr/td[2]/img
                                                    }
                                                    else
                                                    {
                                                        if (tactique.meteo == null)
                                                        {
                                                            tactique.meteo = item.Value;
                                                        }
                                                        else if (tactique.ventDirection == null)
                                                        {
                                                            tactique.ventDirection = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "b")
                                        {
                                            if (tactique.vent == null)
                                            {
                                                tactique.vent = link3.InnerText;
                                            }
                                        }
                                        else if (link3.Name == "a")
                                        {
                                            if (tactique.nom == null)
                                            {
                                                tactique.nom = link3.InnerText;
                                            }

                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "href")
                                                {
                                                    if (item.Value.Contains("sultats") && tactique.id == null)
                                                    {
                                                        tactique.id = item.Value.Split('=').Last();
                                                    }
                                                }
                                            }

                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "img")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Name == "src" && tactique.pays == null)
                                                        {
                                                            tactique.pays = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "small")
                                        {
                                            tactique.km = link3.InnerText.Replace("(", "").Replace(")", "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                try
                {
                    collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:300px;margin:0 auto;\"]");
                    foreach (HtmlNode link0 in collection)
                    {
                        foreach (HtmlNode link in link0.ChildNodes)
                        {
                            if (link.Name == "tr")
                            {
                                foreach (HtmlNode link2 in link.ChildNodes)
                                {
                                    if (link2.Name == "td")
                                    {
                                        if (recuperation.nomCoureur == null && link2.InnerText != string.Empty)
                                        {
                                            recuperation.nomCoureur = link2.InnerText;
                                        }
                                        else
                                        {
                                            if (recuperation.prenomCoureur == null && link2.InnerText != string.Empty)
                                            {
                                                recuperation.prenomCoureur = link2.InnerText;
                                            }
                                            else
                                            {
                                                if (recuperation.place == null && link2.InnerText != string.Empty && link2.InnerText.Any(char.IsDigit))
                                                {
                                                    recuperation.place = link2.InnerText;
                                                }
                                                else
                                                {
                                                    if (recuperation.temps == null && link2.InnerText != string.Empty && link2.InnerText.Any(char.IsDigit))
                                                    {
                                                        recuperation.temps = link2.InnerText;
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }

                                        foreach (HtmlNode link3 in link2.ChildNodes)
                                        {
                                            if (link3.Name == "table")
                                            {
                                                foreach (HtmlNode link4 in link3.ChildNodes)
                                                {
                                                    if (link4.Name == "tr")
                                                    {
                                                        foreach (HtmlNode link5 in link4.ChildNodes)
                                                        {
                                                            if (link5.Name == "td")
                                                            {
                                                                foreach (HtmlNode link6 in link5.ChildNodes)
                                                                {
                                                                    if (link6.Name == "img")
                                                                    {
                                                                        foreach (var item in link6.Attributes)
                                                                        {
                                                                            if (item.Name == "width")
                                                                            {
                                                                                recuperation.recup = item.Value.Replace("px", "");
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (recuperation.temps != null)
                                {
                                    tactique.recuperation.Add(recuperation);
                                }
                                recuperation = new Recuperation();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }


                collection = documenthtml.DocumentNode.SelectNodes("//form[@style=\"text-align:center;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "div")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "div")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "span")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "b")
                                                {
                                                    tactiqueIndividuelle.nomCoureur = link4.InnerText;
                                                }
                                            }
                                        }else if (link3.Name == "select")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "option")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Value=="selected")
                                                        {
                                                            tactiqueIndividuelle.role = link4.InnerText;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }else if (link2.Name == "table")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "tr")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name.Contains("td") && link4.InnerText.Any(char.IsDigit))
                                                {
                                                    if (tactiqueIndividuelle.pla == null)
                                                    {
                                                        tactiqueIndividuelle.pla = link4.InnerText;
                                                    }
                                                    else
                                                    {
                                                        if (tactiqueIndividuelle.mon == null)
                                                        {
                                                            tactiqueIndividuelle.mon = link4.InnerText;
                                                        }
                                                        else
                                                        {
                                                            if (tactiqueIndividuelle.des == null)
                                                            {
                                                                tactiqueIndividuelle.des = link4.InnerText;
                                                            }
                                                            else
                                                            {
                                                                if (tactiqueIndividuelle.val == null)
                                                                {
                                                                    tactiqueIndividuelle.val = link4.InnerText;
                                                                }
                                                                else
                                                                {
                                                                    if (tactiqueIndividuelle.pav == null)
                                                                    {
                                                                        tactiqueIndividuelle.pav = link4.InnerText;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (tactiqueIndividuelle.agi == null)
                                                                        {
                                                                            tactiqueIndividuelle.agi = link4.InnerText;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (tactiqueIndividuelle.clm == null)
                                                                            {
                                                                                tactiqueIndividuelle.clm = link4.InnerText;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (tactiqueIndividuelle.spr == null)
                                                                                {
                                                                                    tactiqueIndividuelle.spr = link4.InnerText;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (tactiqueIndividuelle.end == null)
                                                                                    {
                                                                                        tactiqueIndividuelle.end = link4.InnerText;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (tactiqueIndividuelle.res == null)
                                                                                        {
                                                                                            tactiqueIndividuelle.res = link4.InnerText;
                                                                                        }
                                                                                        else
                                                                                        {

                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    foreach (HtmlNode link5 in link4.ChildNodes)
                                                    {
                                                        if (link5.Name == "select")
                                                        {
                                                            foreach (HtmlNode link6 in link5.ChildNodes)
                                                            {
                                                                if (link6.Name == "option")
                                                                {
                                                                    foreach (var item in link6.Attributes)
                                                                    {
                                                                        if (item.Value.Contains("selected"))
                                                                        {
                                                                            if (tactiqueIndividuelle.pourcentageT1 == null)
                                                                            {
                                                                                tactiqueIndividuelle.pourcentageT1 = link6.InnerText.Replace("%","");
                                                                            }
                                                                            else
                                                                            {
                                                                                if (tactiqueIndividuelle.consigneT1 == null)
                                                                                {
                                                                                    tactiqueIndividuelle.consigneT1 = link6.InnerText;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (tactiqueIndividuelle.pourcentageT2 == null)
                                                                                    {
                                                                                        tactiqueIndividuelle.pourcentageT2 = link6.InnerText.Replace("%", "");
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (tactiqueIndividuelle.consigneT2 == null)
                                                                                        {
                                                                                            tactiqueIndividuelle.consigneT2 = link6.InnerText;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (tactiqueIndividuelle.pourcentageT3 == null)
                                                                                            {
                                                                                                tactiqueIndividuelle.pourcentageT3 = link6.InnerText.Replace("%", "");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (tactiqueIndividuelle.consigneT3 == null)
                                                                                                {
                                                                                                    tactiqueIndividuelle.consigneT3 = link6.InnerText;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (tactiqueIndividuelle.pourcentageT4 == null)
                                                                                                    {
                                                                                                        tactiqueIndividuelle.pourcentageT4 = link6.InnerText.Replace("%", "");
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (tactiqueIndividuelle.consigneT4 == null)
                                                                                                        {
                                                                                                            tactiqueIndividuelle.consigneT4 = link6.InnerText;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (tactiqueIndividuelle.pourcentageT5 == null)
                                                                                                            {
                                                                                                                tactiqueIndividuelle.pourcentageT5 = link6.InnerText.Replace("%", "");
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (tactiqueIndividuelle.consigneT5 == null)
                                                                                                                {
                                                                                                                    tactiqueIndividuelle.consigneT5 = link6.InnerText;
                                                                                                                }
                                                                                                                else
                                                                                                                {

                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                if (link4.Name == "td")
                                                {
                                                    foreach (HtmlNode link5 in link4.ChildNodes)
                                                    {
                                                        if (link5.Name == "input")
                                                        {
                                                            foreach (var item in link5.Attributes)
                                                            {
                                                                if (item.Value == "checked")
                                                                {
                                                                    if (tactiqueIndividuelle.pourcentageT2 == null)
                                                                    {
                                                                        tactiqueIndividuelle.sprintT1 = true;////*[@id="leftmain"]/form[2]/div[1]/table[2]/tbody/tr[2]/td[5]/input
                                                                    }
                                                                    else
                                                                    {
                                                                        if (tactiqueIndividuelle.pourcentageT3 == null)
                                                                        {
                                                                            tactiqueIndividuelle.sprintT2 = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (tactiqueIndividuelle.pourcentageT4 == null)
                                                                            {
                                                                                tactiqueIndividuelle.sprintT3 = true;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (tactiqueIndividuelle.pourcentageT5 == null)
                                                                                {
                                                                                    tactiqueIndividuelle.sprintT4 = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (tactiqueIndividuelle.sprintT5 != true)
                                                                                    {
                                                                                        tactiqueIndividuelle.sprintT5 = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }                                   
                                    }
                                }
                            }


                            if (tactiqueIndividuelle.consigneT5 != null)
                            {
                                tactique.tactiqueIndividuelle.Add(tactiqueIndividuelle);
                            }
                            tactiqueIndividuelle = new TactiqueIndividuelle();
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//table[@align=\"center\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "small")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "a")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Name == "href" && item.Value.Contains("coureur"))
                                                        {
                                                            sprinteur.idCoureur = item.Value.Split('=').Last();
                                                            sprinteur.nomCoureur = link4.InnerText;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "select")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "option")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Value=="selected")
                                                        {
                                                            sprinteur.role = link4.InnerText;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (sprinteur.role != null && sprinteur.idCoureur != null)
                            {
                                tactique.sprinteur.Add(sprinteur);
                            }
                            sprinteur = new Sprinteur();
                        }
                    }
                }


                return tactique;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return tactique;
        }

        internal static Engagement FindPageEngagement(string text)
        {
            Engagement engagement = new Engagement();
            EngagementCoureur engagementCoureur = new EngagementCoureur();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                //*[@id="leftmain"]/table/tbody/tr/td[2]/img
                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:600px;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "img")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "src")
                                                {
                                                    if (item.Value.Contains("courses"))
                                                    {
                                                        engagement.image = item.Value; //*[@id="leftmain"]/div[1]/table/tbody/tr/td[2]/img
                                                    }
                                                    else
                                                    {
                                                        if (engagement.meteo == null)
                                                        {
                                                            engagement.meteo = item.Value;
                                                        }
                                                        else if (engagement.ventDirection == null)
                                                        {
                                                            engagement.ventDirection = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "b")
                                        {
                                            if (engagement.vent == null)
                                            {
                                                engagement.vent = link3.InnerText;
                                            }
                                        }
                                        else if (link3.Name == "a")
                                        {
                                            if (engagement.nom == null)
                                            {
                                                engagement.nom = link3.InnerText;
                                            }

                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "href")
                                                {
                                                    if (item.Value.Contains("sultats") && engagement.id == null)
                                                    {
                                                        engagement.id = item.Value.Split('=').Last();
                                                    }
                                                }
                                            }

                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "img")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Name == "src" && engagement.pays == null)
                                                        {
                                                            engagement.pays = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "small")
                                        {
                                            engagement.km = link3.InnerText.Replace("(", "").Replace(")", "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                collection = documenthtml.DocumentNode.SelectNodes("//table[@width=\"100%\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (var item0 in link.Attributes)
                            {
                                if (item0.Value.Contains("positif"))
                                {
                                    engagementCoureur.meteo = "positif";
                                }
                                else if (item0.Value.Contains("negatif"))
                                {
                                    engagementCoureur.meteo = "negatif";
                                }
                            }

                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "input")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "checked")
                                                {
                                                    engagementCoureur.registered = true;
                                                }
                                            }
                                        }else if (link3.Name == "select")
                                        {
                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "option")
                                                {
                                                    engagementCoureur.divisions.Add(link4.InnerText);

                                                    foreach (var item2 in link4.Attributes)
                                                    {
                                                        if (item2.Value=="selected")
                                                        {
                                                            engagementCoureur.choixDivision = link4.InnerText;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "small")
                                        {
                                            engagementCoureur.nbCoursesJuniorRestantes = link3.InnerText.Replace("(","").Replace(")", "");
                                        }
                                    }
                                    if (!link2.InnerText.Contains("(") && link2.InnerText!=string.Empty)
                                    {
                                        if (engagementCoureur.nomCoureur == null)
                                        {
                                            engagementCoureur.nomCoureur = link2.InnerText;
                                        }
                                        else if (engagementCoureur.pla == null)
                                        {
                                            engagementCoureur.pla = link2.InnerText;
                                        }
                                        else if (engagementCoureur.mon == null)
                                        {
                                            engagementCoureur.mon = link2.InnerText;
                                        }
                                        else if (engagementCoureur.des == null)
                                        {
                                            engagementCoureur.des = link2.InnerText;
                                        }
                                        else if (engagementCoureur.val == null)
                                        {
                                            engagementCoureur.val = link2.InnerText;
                                        }
                                        else if (engagementCoureur.pav == null)
                                        {
                                            engagementCoureur.pav = link2.InnerText;
                                        }
                                        else if (engagementCoureur.agi == null)
                                        {
                                            engagementCoureur.agi = link2.InnerText;
                                        }
                                        else if (engagementCoureur.clm == null)
                                        {
                                            engagementCoureur.clm = link2.InnerText;
                                        }
                                        else if (engagementCoureur.spr == null)
                                        {
                                            engagementCoureur.spr = link2.InnerText;
                                        }
                                        else if (engagementCoureur.end == null)
                                        {
                                            engagementCoureur.end = link2.InnerText;
                                        }
                                        else if (engagementCoureur.res == null)
                                        {
                                            engagementCoureur.res = link2.InnerText;
                                        }
                                        else if (engagementCoureur.forme == null)
                                        {
                                            engagementCoureur.forme = link2.InnerText;
                                        }
                                        else if (engagementCoureur.sante == null && link2.InnerText.All(char.IsDigit))
                                        {
                                            engagementCoureur.sante = link2.InnerText;
                                        }
                                    }
                                }
                            }
                            if (engagementCoureur.sante!=null && engagementCoureur.nomCoureur!=string.Empty)
                            {
                                engagement.engagementCoureur.Add(engagementCoureur);
                            }
                            engagementCoureur = new EngagementCoureur();
                        }
                    }
                }


                return engagement;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return engagement;
        }

        internal static Info FindPageInfo(string text)
        {
            Info info = new Info();

            try
            {
                HtmlDocument documenthtml = new HtmlDocument();
                documenthtml.LoadHtml(text);

                //*[@id="leftmain"]/table/tbody/tr/td[2]/img
                HtmlNodeCollection collection = documenthtml.DocumentNode.SelectNodes("//table[@style=\"width:100%;max-width:600px;margin:0 auto;\"]");
                foreach (HtmlNode link0 in collection)
                {
                    foreach (HtmlNode link in link0.ChildNodes)
                    {
                        if (link.Name == "tr")
                        {
                            foreach (HtmlNode link2 in link.ChildNodes)
                            {
                                if (link2.Name == "td")
                                {
                                    foreach (HtmlNode link3 in link2.ChildNodes)
                                    {
                                        if (link3.Name == "img")
                                        {
                                            foreach (var item in link3.Attributes)
                                            {
                                                if (item.Name == "src")
                                                {
                                                    if (item.Value.Contains("courses"))
                                                    {
                                                        info.image = item.Value;
                                                    }
                                                    else
                                                    {
                                                        if (info.meteo == null)
                                                        {
                                                            info.meteo = item.Value;
                                                        }
                                                        else if (info.ventDirection == null)
                                                        {
                                                            info.ventDirection = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "b")
                                        {
                                            if (info.vent == null)
                                            {
                                                info.vent = link3.InnerText;
                                            }
                                        }
                                        else if (link3.Name == "a")
                                        {
                                            if (info.nom == null)
                                            {
                                                info.nom = link3.InnerText;
                                            }

                                            foreach (HtmlNode link4 in link3.ChildNodes)
                                            {
                                                if (link4.Name == "img")
                                                {
                                                    foreach (var item in link4.Attributes)
                                                    {
                                                        if (item.Name == "src" && info.pays == null)
                                                        {
                                                            info.pays = item.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (link3.Name == "small")
                                        {
                                            info.km = link3.InnerText.Replace("(", "").Replace(")", "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                return info;
            }
            catch (Exception ex)
            {
                Log.Error("FindVMMagazineContent failed. Relaunch \".exe\" to solve the issue. Exception : " + ex.Message);
            }
            return info;
        }


    }
}
