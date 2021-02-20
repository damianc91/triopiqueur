using HtmlAgilityPack;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfApp1
{
    class Requests
    {
        internal static IList<RestResponseCookie> _cookies = new List<RestResponseCookie>();
        //HttpCookie

        public static string PageBlocNote()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/vip_bloc/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request bloc note failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageBlocNoteSendInfo(string text)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_bloc&de=exist");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("lebloc", text);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageVMMagazine(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=journal");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("division", division);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        internal static string PageLogin()
        {
            var client = new RestClient("https://www.velo-manager.net/office/");
            var request = new RestRequest(Method.POST);
            foreach (var cookie in _cookies)
            {
                request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
            }
            request.AddParameter("equipe", "team noob");
            request.AddParameter("pass", "clioclio");
            IRestResponse response = client.Execute(request);
            _cookies = response.Cookies;
            return (response.Content);
        }

        public static string PageRechercheEquipe(string nomEquipe)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=recherche");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("equipe", nomEquipe);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageRechercheNom(string nom)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=recherche");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("nom", nom);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageRecherchePrenom(string prenom)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=recherche");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("prenom", prenom);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageForum1()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=forum");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageForum2()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=forum&c=1&f=1");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageMessagerie()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/messagerie/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageMessagerieConversation(string idTeam)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=messagerie&pour=" + idTeam);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddHeader("Content-Type", "application/xhtml+xml");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageCoureurs(string id)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=equipe&id=" + id);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageCoureurs()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=equipe");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClub(string text)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=club&id=" + text);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageStaff()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/staff/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageMateriel()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/materiel/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageMaterielVendre(string text)//cadre///casque//groupe//roues
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=materiel");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter(text + "Vente", "Vendre");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageMaterielAcheter(string text)//cadre///casque//groupe//roues
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=materiel");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter(text + "Achat", "Acheter");//cadre///casque//groupe//roues
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageEntrainements()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/entrainements/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageStage()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/stage/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageStageSubmit()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=stage");
                var request = new RestRequest(Method.POST);
                request.AddParameter("rider[1]", "525306");
                request.AddParameter("stage[1]", "0");
                request.AddParameter("rider[2]", "520886");
                request.AddParameter("stage[2]", "0");
                request.AddParameter("rider[3]", "518671");
                request.AddParameter("stage[3]", "0");
                request.AddParameter("rider[4]", "518088");
                request.AddParameter("stage[4]", "0");
                request.AddParameter("rider[5]", "517895");
                request.AddParameter("stage[5]", "0");
                request.AddParameter("rider[6]", "517768");
                request.AddParameter("stage[6]", "0");
                request.AddParameter("rider[7]", "512917");
                request.AddParameter("stage[7]", "0");
                request.AddParameter("rider[8]", "476180");
                request.AddParameter("stage[8]", "0");
                request.AddParameter("rider[9]", "475597");
                request.AddParameter("stage[9]", "0");
                request.AddParameter("rider[10]", "474716");
                request.AddParameter("stage[10]", "0");
                request.AddParameter("rider[11]", "473792");
                request.AddParameter("stage[11]", "0");
                request.AddParameter("rider[12]", "473706");
                request.AddParameter("stage[12]", "0");
                request.AddParameter("rider[13]", "466937");
                request.AddParameter("stage[13]", "0");
                request.AddParameter("rider[14]", "465797");
                request.AddParameter("stage[14]", "0");
                request.AddParameter("rider[15]", "465207");
                request.AddParameter("stage[15]", "0");
                request.AddParameter("rider[16]", "460348");
                request.AddParameter("stage[16]", "0");
                request.AddParameter("rider[17]", "459837");
                request.AddParameter("stage[17]", "0");
                request.AddParameter("rider[18]", "459654");
                request.AddParameter("stage[18]", "0");
                request.AddParameter("rider[19]", "459634");
                request.AddParameter("stage[19]", "0");
                request.AddParameter("nb", "20");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageFinances()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/finances/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageNationalite()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/chgt_pays/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassements(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/classements/");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("id", division);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsEquipe(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=division&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsJeune(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=classements_jeune&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsNationalJeune(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_selection_p22&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageClassementsCDM(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=CDM&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsDivisionOverall(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=division_overall&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsNational(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_selection_p&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsNationalPays(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_selection_p&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageClassementsNationalCoureurs(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_selection_c&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageClassementsNationalCoureursJeunes(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_selection_c22&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageMasseSalariales(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_sal_eq&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageSalairesCoureurs(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_sal_co&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageObjectifs(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=cla_sal_co&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageFansEquipe(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=populaire&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageFansCoureurs(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=populaire_rider&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageFansCoureursOverall(string division)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=populaire_rider_overall&id=" + division);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageCalendrier()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/engagements/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageResultats(string idCourse, string division, string part="", string team="", string cn="")
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=resultats&id="+ idCourse + "&division=" + division + "&par=" + part + "&team=" + team + "&cn=" + cn + "");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageResultatsSimple()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=resultats");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTranferts(string start="0")
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=transfert&start=" + start);
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("minprix", "1");
                request.AddParameter("maxprix", "99999999");
                request.AddParameter("minage", "18");
                request.AddParameter("maxage", "50");
                request.AddParameter("minrestant", "1");
                request.AddParameter("maxrestant", "3");
                request.AddParameter("minpla", "45");
                request.AddParameter("minmon", "45");
                request.AddParameter("mindes", "45");
                request.AddParameter("minval", "45");
                request.AddParameter("minpav", "45");
                request.AddParameter("minagi", "45");
                request.AddParameter("minCLM", "45");
                request.AddParameter("minspr", "45");
                request.AddParameter("minend", "45");
                request.AddParameter("minres", "45");
                request.AddParameter("maxpla", "100");
                request.AddParameter("maxmon", "100");
                request.AddParameter("maxdes", "100");
                request.AddParameter("maxval", "100");
                request.AddParameter("maxpav", "100");
                request.AddParameter("maxagi", "100");
                request.AddParameter("maxCLM", "100");
                request.AddParameter("maxspr", "100");
                request.AddParameter("maxend", "100");
                request.AddParameter("maxres", "100");
                request.AddParameter("reset", "Reset");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTactique(string id)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=tactique&id=" + id);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTactiqueSprint(string id)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=tactique&id=14&etape=&cn=");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("id_court[0]", "459634");
                request.AddParameter("id_court[1]", "476180");
                request.AddParameter("role[1]", "0");
                request.AddParameter("id_court[2]", "520886");
                request.AddParameter("role[2]", "0");
                request.AddParameter("id_court[3]", "473706");
                request.AddParameter("role[3]", "0");
                request.AddParameter("id_court[4]", "512917");
                request.AddParameter("role[4]", "0");
                request.AddParameter("id_court[5]", "475597");
                request.AddParameter("role[5]", "0");
                request.AddParameter("id_court[6]", "465207");
                request.AddParameter("role[6]", "0");
                request.AddParameter("id_court[7]", "460348");
                request.AddParameter("role[7]", "0");
                request.AddParameter("tact_sprint", "8");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageEngagement(string id)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=eng_course&id="+ id);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTranfertsDaily()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=transfert_f");
                var request = new RestRequest(Method.GET);IRestResponse response = client.Execute(request);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTranfertsJuniors()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=transfert_u17");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageCoureursGenerateRider()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=equipe");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("pays", "40");
                request.AddParameter("age", "19");
                request.AddParameter("spe", "vallon");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageObjectifs()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/rank_objectif/");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageSelectionView()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=selection&voir=ok");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageSelectionInscription()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=s_engagement&id_course=532");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageSelectionVote()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=selection");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("pour", "1948");//pour23
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsList()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/team_liste/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsCreate()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/team_creation/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTeamsCreateTeamName()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team_creation");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("nom", "testo");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTeamsMyTeam()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/team/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsDeleteTeam()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team&id=1466&action=suppr&conf=");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTeamsDeleteTeamConfirm()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team&id=1466&action=suppr&conf=ok");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsGestionMembres()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/team_gestion/");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsSuccesseur()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team_gestion");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("equ", "1948");
                request.AddParameter("duree", "0");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageTeamsVirerEquipier()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team_gestion");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("eqd", "1948");
                request.AddParameter("enlever", "Supprimer");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsRefuserDemande()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team_gestion");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("eqd", "1948");
                request.AddParameter("refuser", "Refuser");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }


        public static string PageTeamsValiderDemande()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=team_gestion");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("eqd", "1948");
                request.AddParameter("accepter", "Valider");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageVipCoureursSuivis()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_liste");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageVipEquipesSuivies()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_liste_e");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageVipStatsSpe()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_stats");
                var request = new RestRequest(Method.POST);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                request.AddParameter("agel", "23");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageVipSuivi()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_suivi");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageVipMedaillesCDT()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Coureur%20de%20Tour");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesBaroudeur()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Baroudeur");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesCroner()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Croner");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesCrossman()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Crossman");
                
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesFlandrien()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Flandrien");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesPuncheur()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Puncheur");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesSprinteur()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Sprinteur");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }
        public static string PageVipMedaillesGrimpeur()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=vip_medaille&cat=Grimpeurr");
                
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageStats()
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=stats");
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageCoureur(string id)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=coureur&id=" + id);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }

        public static string PageInfo(string id)
        {
            try
            {
                var client = new RestClient("https://www.velo-manager.net/?page=details_course&id=" + id);
                var request = new RestRequest(Method.GET);
                foreach (var cookie in _cookies)
                {
                    request.AddCookie(cookie.Name, cookie.Value);  //this adds every cookie in the previous response.
                }
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                return response.Content;
            }
            catch (Exception ex)
            {
                Log.Error("Request sent bloc note info failed. Exception : " + ex.Message);
                return string.Empty;
            }
        }



    }
}
