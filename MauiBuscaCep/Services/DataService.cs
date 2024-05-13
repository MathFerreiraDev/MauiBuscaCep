using MauiBuscaCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MauiBuscaCep.Services
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient cli = new HttpClient())
            {
                string url = "http://cep.metoda.com.br/endereco/by-cep?cep=" + cep;
                HttpResponseMessage res = await cli.GetAsync(url);

                if (res.IsSuccessStatusCode) { 
                    string json = res.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                {
                    throw new Exception(res.RequestMessage.Content.ToString());
                }
            }

            return end;
        }

        public static async Task<List<Bairro>> GetBairrosByCidade (int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient cli = new HttpClient())
            {
                string url = "http://cep.metoda.com.br/bairro/by-cidade?id_cidade=" + id_cidade;
                HttpResponseMessage res = await cli.GetAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    string json = res.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                {
                    throw new Exception(res.RequestMessage.Content.ToString());
                }
            }
            return arr_bairros;
        }

        public static async Task<List<Cidade>> GetCidadesByEstado(string uf)
        {
            List<Cidade> arr_cidades = new List<Cidade>();

            using (HttpClient cli = new HttpClient())
            {
                string url = "http://cep.metoda.com.br/cidade/by-uf?uf=" + uf;
                HttpResponseMessage res = await cli.GetAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    string json = res.Content.ReadAsStringAsync().Result;

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                {
                    throw new Exception(res.RequestMessage.Content.ToString());
                }
            }
            return arr_cidades;
        }

        //PROXIMO
       /* public static async Task<List<Cidade>> GetCidadesByEstado(string uf)
        {
            List<Cidade> arr_cidades = new List<Cidade>();

            using (HttpClient cli = new HttpClient())
            {
                string url = "http://cep.metoda.com.br/cidade/by-uf?uf=" + uf;
                HttpResponseMessage res = await cli.GetAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    string json = res.Content.ReadAsStringAsync().Result;

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                {
                    throw new Exception(res.RequestMessage.Content.ToString());
                }
            }
            return arr_cidades;
        }*/
    }
}
